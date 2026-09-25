import java.io.FileWriter;
import java.sql.*;
import java.util.*;

public class FullCustomerFYMatrixExtractor {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com";
        String user = "SPJLIVE";
        String pass = "SPjlive_0112#";

        try {
            System.out.println("Connecting to Oracle SPJLIVE for ALL Customers x All FYs...");
            Connection conn = DriverManager.getConnection(url, user, pass);
            System.out.println("Connected successfully!");

            Statement stmt = conn.createStatement();

            // 1. Comprehensive Customer Matrix per FY with Terminals and Container breakdown
            String sql = 
                "SELECT " +
                "  CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END AS FINANCIAL_YEAR, " +
                "  CM.CUSTOMER_ID, " +
                "  CM.CUSTOMER_NAME, " +
                "  CM.CUSTOMER_CODE, " +
                "  NVL(TM.TERMINAL_ID, 0) AS TERMINAL_ID, " +
                "  NVL(TM.TERMINAL_NAME, 'OTHER TERMINAL') AS TERMINAL_NAME, " +
                "  COUNT(DISTINCT I.INVOICE_NO) AS TOTAL_INVOICES, " +
                "  COUNT(DISTINCT AP.JOB_NO) AS TOTAL_JOBS, " +
                "  COUNT(DISTINCT AP.CONT_NO) AS TOTAL_CONTAINERS, " +
                "  COUNT(DISTINCT CASE WHEN FC.CONT_SIZE = '40' THEN AP.CONT_NO END) AS UNITS_40FT, " +
                "  COUNT(DISTINCT CASE WHEN FC.CONT_SIZE = '20' THEN AP.CONT_NO END) AS UNITS_20FT, " +
                "  ROUND(SUM(CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END), 2) AS TAXABLE_SALES, " +
                "  ROUND(SUM(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0)), 2) AS TOTAL_GST_TAX, " +
                "  ROUND(SUM(II.BILL_AMOUNT), 2) AS GROSS_REVENUE " +
                "FROM SPJLIVE.IMP_INVOICE I " +
                "JOIN SPJLIVE.IMP_INVOICE_ITEMS II ON I.INVOICE_NO = II.INVOICE_NO " +
                "JOIN SPJLIVE.CUSTOMER_MASTER CM ON I.BILL_TO = CM.CUSTOMER_ID " +
                "LEFT JOIN SPJLIVE.TERMINAL_MASTER TM ON I.TERMINAL_ID = TM.TERMINAL_ID " +
                "LEFT JOIN SPJLIVE.ALL_PARTY_ACCOUNT AP ON AP.CONT_JO_ID = II.LINE_ITEM_ID " +
                "LEFT JOIN SPJLIVE.FLEET_CONT_JO_DTLS FC ON AP.MTY_CONT_ID = FC.MTY_CONT_ID " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT1 ON IIT1.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT1.TAX_HEAD_ID = 5 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT2 ON IIT2.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT2.TAX_HEAD_ID = 6 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT3 ON IIT3.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT3.TAX_HEAD_ID = 7 " +
                "WHERE I.CANCLE_FLAGE IS NULL AND II.BILL_AMOUNT > 0 AND I.INVOICE_DATE IS NOT NULL " +
                "GROUP BY CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END, CM.CUSTOMER_ID, CM.CUSTOMER_NAME, CM.CUSTOMER_CODE, TM.TERMINAL_ID, TM.TERMINAL_NAME " +
                "ORDER BY FINANCIAL_YEAR DESC, GROSS_REVENUE DESC";

            System.out.println("Executing full customer-terminal-fy matrix query...");
            ResultSet rs = stmt.executeQuery(sql);
            System.out.println("Query finished! Organizing FY Customer data structure...");

            // FY -> Map<CustomerId, CustomerAggObject>
            Map<String, Map<Integer, Map<String, Object>>> fyCustomerMap = new LinkedHashMap<>();

            while (rs.next()) {
                String fy = rs.getString("FINANCIAL_YEAR");
                int custId = rs.getInt("CUSTOMER_ID");
                String custName = rs.getString("CUSTOMER_NAME");
                String custCode = rs.getString("CUSTOMER_CODE");
                int termId = rs.getInt("TERMINAL_ID");
                String termName = rs.getString("TERMINAL_NAME");

                int invs = rs.getInt("TOTAL_INVOICES");
                int jobs = rs.getInt("TOTAL_JOBS");
                int conts = rs.getInt("TOTAL_CONTAINERS");
                int u40 = rs.getInt("UNITS_40FT");
                int u20 = rs.getInt("UNITS_20FT");
                double taxable = rs.getDouble("TAXABLE_SALES");
                double tax = rs.getDouble("TOTAL_GST_TAX");
                double gross = rs.getDouble("GROSS_REVENUE");

                fyCustomerMap.putIfAbsent(fy, new LinkedHashMap<>());
                Map<Integer, Map<String, Object>> custMap = fyCustomerMap.get(fy);

                Map<String, Object> c = custMap.get(custId);
                if (c == null) {
                    c = new LinkedHashMap<>();
                    c.put("customerId", custId);
                    c.put("customerName", custName);
                    c.put("customerCode", custCode != null ? custCode : "");
                    c.put("invoiceCount", 0);
                    c.put("jobCount", 0);
                    c.put("containerCount", 0);
                    c.put("units40ft", 0);
                    c.put("units20ft", 0);
                    c.put("teus", 0);
                    c.put("baseAmount", 0.0);
                    c.put("taxAmount", 0.0);
                    c.put("grossRevenue", 0.0);
                    c.put("terminals", new ArrayList<Map<String, Object>>());
                    custMap.put(custId, c);
                }

                c.put("invoiceCount", (int)c.get("invoiceCount") + invs);
                c.put("jobCount", (int)c.get("jobCount") + jobs);
                c.put("containerCount", (int)c.get("containerCount") + conts);
                c.put("units40ft", (int)c.get("units40ft") + u40);
                c.put("units20ft", (int)c.get("units20ft") + u20);
                int calcTeus = (int)c.get("units20ft") + ((int)c.get("units40ft") * 2);
                c.put("teus", calcTeus);
                c.put("baseAmount", round((double)c.get("baseAmount") + taxable));
                c.put("taxAmount", round((double)c.get("taxAmount") + tax));
                c.put("grossRevenue", round((double)c.get("grossRevenue") + gross));

                List<Map<String, Object>> termList = (List<Map<String, Object>>) c.get("terminals");
                Map<String, Object> tObj = new LinkedHashMap<>();
                tObj.put("terminalId", termId);
                tObj.put("terminalName", termName);
                tObj.put("invoiceCount", invs);
                tObj.put("containerCount", conts);
                tObj.put("baseAmount", taxable);
                tObj.put("taxAmount", tax);
                tObj.put("grossRevenue", gross);
                termList.add(tObj);
            }

            // Read existing realOracleFYData.json to merge terminals & services
            // Now serialize full structured JSON
            StringBuilder json = new StringBuilder();
            json.append("{\n");
            json.append("  \"metadata\": { \"generatedAt\": \"").append(new java.util.Date().toString()).append("\", \"source\": \"ORACLE_SPJLIVE_PRODUCTION\" },\n");
            
            // fyCustomers
            json.append("  \"fyCustomers\": {\n");
            int fyIdx = 0;
            for (String fy : fyCustomerMap.keySet()) {
                json.append("    \"").append(fy).append("\": [\n");
                List<Map<String, Object>> list = new ArrayList<>(fyCustomerMap.get(fy).values());
                // Sort by grossRevenue descending
                list.sort((a, b) -> Double.compare((double)b.get("grossRevenue"), (double)a.get("grossRevenue")));

                for (int i = 0; i < list.size(); i++) {
                    Map<String, Object> c = list.get(i);
                    json.append("      {\n");
                    json.append("        \"customerId\": ").append(c.get("customerId")).append(",\n");
                    json.append("        \"customerName\": \"").append(escapeJson((String)c.get("customerName"))).append("\",\n");
                    json.append("        \"customerCode\": \"").append(escapeJson((String)c.get("customerCode"))).append("\",\n");
                    json.append("        \"invoiceCount\": ").append(c.get("invoiceCount")).append(",\n");
                    json.append("        \"jobCount\": ").append(c.get("jobCount")).append(",\n");
                    json.append("        \"containerCount\": ").append(c.get("containerCount")).append(",\n");
                    json.append("        \"units40ft\": ").append(c.get("units40ft")).append(",\n");
                    json.append("        \"units20ft\": ").append(c.get("units20ft")).append(",\n");
                    json.append("        \"teus\": ").append(c.get("teus")).append(",\n");
                    json.append("        \"baseAmount\": ").append(c.get("baseAmount")).append(",\n");
                    json.append("        \"taxAmount\": ").append(c.get("taxAmount")).append(",\n");
                    json.append("        \"grossRevenue\": ").append(c.get("grossRevenue")).append(",\n");
                    
                    // terminals array
                    json.append("        \"terminals\": [\n");
                    List<Map<String, Object>> terms = (List<Map<String, Object>>) c.get("terminals");
                    for (int t = 0; t < terms.size(); t++) {
                        Map<String, Object> trm = terms.get(t);
                        json.append("          { \"terminalId\": ").append(trm.get("terminalId"))
                            .append(", \"terminalName\": \"").append(escapeJson((String)trm.get("terminalName")))
                            .append("\", \"invoiceCount\": ").append(trm.get("invoiceCount"))
                            .append(", \"containerCount\": ").append(trm.get("containerCount"))
                            .append(", \"baseAmount\": ").append(trm.get("baseAmount"))
                            .append(", \"taxAmount\": ").append(trm.get("taxAmount"))
                            .append(", \"grossRevenue\": ").append(trm.get("grossRevenue"))
                            .append(" }").append(t < terms.size() - 1 ? ",\n" : "\n");
                    }
                    json.append("        ]\n");
                    json.append("      }").append(i < list.size() - 1 ? ",\n" : "\n");
                }
                json.append("    ]").append(++fyIdx < fyCustomerMap.size() ? ",\n" : "\n");
            }
            json.append("  }\n");
            json.append("}\n");

            String outPath1 = "/Users/iamrps/Desktop/spj/frontend/src/data/realOracleFYData.json";
            String outPath2 = "/Users/iamrps/Desktop/spj/backend/src/data/realOracleFYData.json";
            String outPath3 = "/Users/iamrps/Desktop/spj/cutomerspjj/src/data/realOracleFYData.json";

            FileWriter fw1 = new FileWriter(outPath1);
            fw1.write(json.toString());
            fw1.close();

            FileWriter fw2 = new FileWriter(outPath2);
            fw2.write(json.toString());
            fw2.close();

            FileWriter fw3 = new FileWriter(outPath3);
            fw3.write(json.toString());
            fw3.close();

            System.out.println("Saved realOracleFYData.json with ALL customers across all FYs to all apps!");
            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static double round(double d) {
        return Math.round(d * 100.0) / 100.0;
    }

    private static String escapeJson(String s) {
        if (s == null) return "";
        return s.replace("\\", "\\\\")
                .replace("\"", "\\\"")
                .replace("\n", " ")
                .replace("\r", " ")
                .replace("\t", " ")
                .replaceAll("[\\p{Cntrl}]", "");
    }
}
