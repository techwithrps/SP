import java.io.FileWriter;
import java.sql.*;
import java.util.*;

public class FullOracleExtractor {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com";
        String user = "SPJLIVE";
        String pass = "SPjlive_0112#";

        try {
            System.out.println("Connecting to Oracle SPJLIVE for FULL REAL EXTRACTION...");
            Connection conn = DriverManager.getConnection(url, user, pass);
            System.out.println("Connected successfully!");

            Statement stmt = conn.createStatement();

            // 1. Extract Top Customers per FY
            System.out.println("Extracting Top Customers per FY...");
            String topCustQuery = 
                "SELECT " +
                "  CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END AS FY, " +
                "  CM.CUSTOMER_ID, " +
                "  CM.CUSTOMER_NAME, " +
                "  COUNT(DISTINCT I.INVOICE_NO) AS INVOICE_COUNT, " +
                "  COUNT(DISTINCT AP.CONT_NO) AS CONTAINER_COUNT, " +
                "  ROUND(SUM(CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END), 2) AS TAXABLE_SALES, " +
                "  ROUND(SUM(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0)), 2) AS TAX_AMOUNT, " +
                "  ROUND(SUM(II.BILL_AMOUNT), 2) AS GROSS_REVENUE " +
                "FROM SPJLIVE.IMP_INVOICE I " +
                "JOIN SPJLIVE.IMP_INVOICE_ITEMS II ON I.INVOICE_NO = II.INVOICE_NO " +
                "JOIN SPJLIVE.CUSTOMER_MASTER CM ON I.BILL_TO = CM.CUSTOMER_ID " +
                "LEFT JOIN SPJLIVE.ALL_PARTY_ACCOUNT AP ON AP.CONT_JO_ID = II.LINE_ITEM_ID " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT1 ON IIT1.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT1.TAX_HEAD_ID = 5 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT2 ON IIT2.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT2.TAX_HEAD_ID = 6 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT3 ON IIT3.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT3.TAX_HEAD_ID = 7 " +
                "WHERE I.CANCLE_FLAGE IS NULL AND II.BILL_AMOUNT > 0 AND I.INVOICE_DATE IS NOT NULL " +
                "GROUP BY CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END, CM.CUSTOMER_ID, CM.CUSTOMER_NAME " +
                "ORDER BY FY DESC, GROSS_REVENUE DESC";

            ResultSet rsCust = stmt.executeQuery(topCustQuery);
            Map<String, List<Map<String, Object>>> fyCustomersMap = new LinkedHashMap<>();
            while (rsCust.next()) {
                String fy = rsCust.getString("FY");
                fyCustomersMap.putIfAbsent(fy, new ArrayList<>());
                Map<String, Object> c = new LinkedHashMap<>();
                c.put("customerId", rsCust.getInt("CUSTOMER_ID"));
                c.put("customerName", rsCust.getString("CUSTOMER_NAME"));
                c.put("invoiceCount", rsCust.getInt("INVOICE_COUNT"));
                c.put("containerCount", rsCust.getInt("CONTAINER_COUNT"));
                c.put("baseAmount", rsCust.getDouble("TAXABLE_SALES"));
                c.put("taxAmount", rsCust.getDouble("TAX_AMOUNT"));
                c.put("grossRevenue", rsCust.getDouble("GROSS_REVENUE"));
                fyCustomersMap.get(fy).add(c);
            }
            System.out.println("Loaded Top Customers for " + fyCustomersMap.keySet().size() + " FYs.");

            // 2. Extract Terminals / Branches per FY
            System.out.println("Extracting Terminals per FY...");
            String termQuery = 
                "SELECT " +
                "  CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END AS FY, " +
                "  NVL(TM.TERMINAL_ID, 0) AS TERMINAL_ID, " +
                "  NVL(TM.TERMINAL_NAME, 'OTHER / UNALLOCATED') AS TERMINAL_NAME, " +
                "  COUNT(DISTINCT I.INVOICE_NO) AS INVOICE_COUNT, " +
                "  COUNT(DISTINCT AP.CONT_NO) AS CONTAINER_COUNT, " +
                "  ROUND(SUM(CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END), 2) AS TAXABLE_SALES, " +
                "  ROUND(SUM(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0)), 2) AS TAX_AMOUNT, " +
                "  ROUND(SUM(II.BILL_AMOUNT), 2) AS GROSS_REVENUE " +
                "FROM SPJLIVE.IMP_INVOICE I " +
                "JOIN SPJLIVE.IMP_INVOICE_ITEMS II ON I.INVOICE_NO = II.INVOICE_NO " +
                "JOIN SPJLIVE.CUSTOMER_MASTER CM ON I.BILL_TO = CM.CUSTOMER_ID " +
                "LEFT JOIN SPJLIVE.TERMINAL_MASTER TM ON I.TERMINAL_ID = TM.TERMINAL_ID " +
                "LEFT JOIN SPJLIVE.ALL_PARTY_ACCOUNT AP ON AP.CONT_JO_ID = II.LINE_ITEM_ID " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT1 ON IIT1.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT1.TAX_HEAD_ID = 5 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT2 ON IIT2.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT2.TAX_HEAD_ID = 6 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT3 ON IIT3.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT3.TAX_HEAD_ID = 7 " +
                "WHERE I.CANCLE_FLAGE IS NULL AND II.BILL_AMOUNT > 0 AND I.INVOICE_DATE IS NOT NULL " +
                "GROUP BY CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END, TM.TERMINAL_ID, TM.TERMINAL_NAME " +
                "ORDER BY FY DESC, GROSS_REVENUE DESC";

            ResultSet rsTerm = stmt.executeQuery(termQuery);
            Map<String, List<Map<String, Object>>> fyTerminalsMap = new LinkedHashMap<>();
            while (rsTerm.next()) {
                String fy = rsTerm.getString("FY");
                fyTerminalsMap.putIfAbsent(fy, new ArrayList<>());
                Map<String, Object> t = new LinkedHashMap<>();
                t.put("terminalId", rsTerm.getInt("TERMINAL_ID"));
                t.put("terminalName", rsTerm.getString("TERMINAL_NAME"));
                t.put("invoiceCount", rsTerm.getInt("INVOICE_COUNT"));
                t.put("containerCount", rsTerm.getInt("CONTAINER_COUNT"));
                t.put("baseAmount", rsTerm.getDouble("TAXABLE_SALES"));
                t.put("taxAmount", rsTerm.getDouble("TAX_AMOUNT"));
                t.put("grossRevenue", rsTerm.getDouble("GROSS_REVENUE"));
                fyTerminalsMap.get(fy).add(t);
            }
            System.out.println("Loaded Terminals for " + fyTerminalsMap.keySet().size() + " FYs.");

            // 3. Extract Services per FY
            System.out.println("Extracting Services per FY...");
            String servQuery = 
                "SELECT " +
                "  CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END AS FY, " +
                "  NVL(SM.SERVICE_ID, 0) AS SERVICE_ID, " +
                "  NVL(SM.SERVICE_NAME, 'OTHER LOGISTICS') AS SERVICE_NAME, " +
                "  COUNT(DISTINCT I.INVOICE_NO) AS INVOICE_COUNT, " +
                "  ROUND(SUM(II.BILL_AMOUNT), 2) AS GROSS_REVENUE " +
                "FROM SPJLIVE.IMP_INVOICE I " +
                "JOIN SPJLIVE.IMP_INVOICE_ITEMS II ON I.INVOICE_NO = II.INVOICE_NO " +
                "LEFT JOIN SPJLIVE.SERVICE_MASTER SM ON II.SERVICE_ID = SM.SERVICE_ID " +
                "WHERE I.CANCLE_FLAGE IS NULL AND II.BILL_AMOUNT > 0 AND I.INVOICE_DATE IS NOT NULL " +
                "GROUP BY CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END, SM.SERVICE_ID, SM.SERVICE_NAME " +
                "ORDER BY FY DESC, GROSS_REVENUE DESC";

            ResultSet rsServ = stmt.executeQuery(servQuery);
            Map<String, List<Map<String, Object>>> fyServicesMap = new LinkedHashMap<>();
            while (rsServ.next()) {
                String fy = rsServ.getString("FY");
                fyServicesMap.putIfAbsent(fy, new ArrayList<>());
                Map<String, Object> s = new LinkedHashMap<>();
                s.put("serviceId", rsServ.getInt("SERVICE_ID"));
                s.put("serviceName", rsServ.getString("SERVICE_NAME"));
                s.put("invoiceCount", rsServ.getInt("INVOICE_COUNT"));
                s.put("grossRevenue", rsServ.getDouble("GROSS_REVENUE"));
                fyServicesMap.get(fy).add(s);
            }
            System.out.println("Loaded Services for " + fyServicesMap.keySet().size() + " FYs.");

            // 4. Save to JSON File
            StringBuilder json = new StringBuilder();
            json.append("{\n");
            json.append("  \"metadata\": { \"generatedAt\": \"").append(new java.util.Date().toString()).append("\", \"source\": \"ORACLE_SPJLIVE_PRODUCTION\" },\n");
            
            // fyCustomers
            json.append("  \"fyCustomers\": {\n");
            int fyIdx = 0;
            for (String fy : fyCustomersMap.keySet()) {
                json.append("    \"").append(fy).append("\": [\n");
                List<Map<String, Object>> list = fyCustomersMap.get(fy);
                for (int i = 0; i < list.size(); i++) {
                    Map<String, Object> c = list.get(i);
                    json.append("      { \"customerId\": ").append(c.get("customerId"))
                        .append(", \"customerName\": \"").append(escapeJson((String)c.get("customerName")))
                        .append("\", \"invoiceCount\": ").append(c.get("invoiceCount"))
                        .append(", \"containerCount\": ").append(c.get("containerCount"))
                        .append(", \"baseAmount\": ").append(c.get("baseAmount"))
                        .append(", \"taxAmount\": ").append(c.get("taxAmount"))
                        .append(", \"grossRevenue\": ").append(c.get("grossRevenue"))
                        .append(" }").append(i < list.size() - 1 ? ",\n" : "\n");
                }
                json.append("    ]").append(++fyIdx < fyCustomersMap.size() ? ",\n" : "\n");
            }
            json.append("  },\n");

            // fyTerminals
            json.append("  \"fyTerminals\": {\n");
            fyIdx = 0;
            for (String fy : fyTerminalsMap.keySet()) {
                json.append("    \"").append(fy).append("\": [\n");
                List<Map<String, Object>> list = fyTerminalsMap.get(fy);
                for (int i = 0; i < list.size(); i++) {
                    Map<String, Object> t = list.get(i);
                    json.append("      { \"terminalId\": ").append(t.get("terminalId"))
                        .append(", \"terminalName\": \"").append(escapeJson((String)t.get("terminalName")))
                        .append("\", \"invoiceCount\": ").append(t.get("invoiceCount"))
                        .append(", \"containerCount\": ").append(t.get("containerCount"))
                        .append(", \"baseAmount\": ").append(t.get("baseAmount"))
                        .append(", \"taxAmount\": ").append(t.get("taxAmount"))
                        .append(", \"grossRevenue\": ").append(t.get("grossRevenue"))
                        .append(" }").append(i < list.size() - 1 ? ",\n" : "\n");
                }
                json.append("    ]").append(++fyIdx < fyTerminalsMap.size() ? ",\n" : "\n");
            }
            json.append("  },\n");

            // fyServices
            json.append("  \"fyServices\": {\n");
            fyIdx = 0;
            for (String fy : fyServicesMap.keySet()) {
                json.append("    \"").append(fy).append("\": [\n");
                List<Map<String, Object>> list = fyServicesMap.get(fy);
                for (int i = 0; i < list.size(); i++) {
                    Map<String, Object> s = list.get(i);
                    json.append("      { \"serviceId\": ").append(s.get("serviceId"))
                        .append(", \"serviceName\": \"").append(escapeJson((String)s.get("serviceName")))
                        .append("\", \"invoiceCount\": ").append(s.get("invoiceCount"))
                        .append(", \"grossRevenue\": ").append(s.get("grossRevenue"))
                        .append(" }").append(i < list.size() - 1 ? ",\n" : "\n");
                }
                json.append("    ]").append(++fyIdx < fyServicesMap.size() ? ",\n" : "\n");
            }
            json.append("  }\n");
            json.append("}\n");

            FileWriter fw = new FileWriter("/Users/iamrps/Desktop/spj/backend/src/data/realOracleFYData.json");
            fw.write(json.toString());
            fw.close();
            System.out.println("Saved /Users/iamrps/Desktop/spj/backend/src/data/realOracleFYData.json successfully!");

            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
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
