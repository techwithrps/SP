import java.io.FileWriter;
import java.sql.*;
import java.util.*;

public class FullCustomerPortalExtractor {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com";
        String user = "SPJLIVE";
        String pass = "SPjlive_0112#";

        try {
            System.out.println("Connecting to Oracle SPJLIVE for ALL Customers & Invoices...");
            Connection conn = DriverManager.getConnection(url, user, pass);
            System.out.println("Connected successfully!");

            Statement stmt = conn.createStatement();

            // Query all distinct invoices with customer, containers, dates, amounts, taxes, terminals
            String sql = 
                "SELECT " +
                "  I.INVOICE_NO, " +
                "  I.INVOICE_REF_NO, " +
                "  AP.JOB_NO, " +
                "  TO_CHAR(I.INVOICE_DATE, 'DD/MM/YYYY') AS INVOICE_DATE, " +
                "  I.INVOICE_DATE AS RAW_DATE, " +
                "  CM.CUSTOMER_ID, " +
                "  CM.CUSTOMER_NAME, " +
                "  CM.CUSTOMER_CODE, " +
                "  TM.TERMINAL_NAME, " +
                "  SM.SERVICE_NAME, " +
                "  AP.CONT_NO, " +
                "  FC.CONT_SIZE, " +
                "  FC.CONT_TYPE, " +
                "  AP.BL_NO, " +
                "  AP.SB_NO, " +
                "  TO_CHAR(AP.SB_DATE, 'DD/MM/YYYY') AS SB_DATE, " +
                "  TO_CHAR(FC.ICD_IN_DATE, 'DD/MM/YYYY') AS ICD_IN_DATE, " +
                "  TO_CHAR(AP.TRAIN_OUT_DATE, 'DD/MM/YYYY') AS TRAIN_OUT_DATE, " +
                "  TO_CHAR(AP.SAILED, 'DD/MM/YYYY') AS SAILED_DATE, " +
                "  AP.PORT AS POD, " +
                "  AP.POL, " +
                "  LINE.CUSTOMER_CODE AS SHIPPING_LINE, " +
                "  II.LINE_ITEM_ID, " +
                "  SM.SERVICE_NAME AS LINE_DESC, " +
                "  II.BILL_RATE, " +
                "  II.BILL_QNTY, " +
                "  CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END AS TAXABLE_AMT, " +
                "  ROUND(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0), 2) AS ITEM_TAX, " +
                "  II.BILL_AMOUNT AS ITEM_AMOUNT, " +
                "  NVL(I.PAYMENT_STATUS, 'P') AS PAYMENT_STATUS " +
                "FROM SPJLIVE.IMP_INVOICE I " +
                "JOIN SPJLIVE.IMP_INVOICE_ITEMS II ON I.INVOICE_NO = II.INVOICE_NO " +
                "JOIN SPJLIVE.CUSTOMER_MASTER CM ON I.BILL_TO = CM.CUSTOMER_ID " +
                "LEFT JOIN SPJLIVE.TERMINAL_MASTER TM ON I.TERMINAL_ID = TM.TERMINAL_ID " +
                "LEFT JOIN SPJLIVE.SERVICE_MASTER SM ON II.SERVICE_ID = SM.SERVICE_ID " +
                "LEFT JOIN SPJLIVE.ALL_PARTY_ACCOUNT AP ON AP.CONT_JO_ID = II.LINE_ITEM_ID " +
                "LEFT JOIN SPJLIVE.FLEET_CONT_JO_DTLS FC ON AP.MTY_CONT_ID = FC.MTY_CONT_ID " +
                "LEFT JOIN SPJLIVE.CUSTOMER_MASTER LINE ON LINE.CUSTOMER_ID = FC.LINE_ID " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT1 ON IIT1.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT1.TAX_HEAD_ID = 5 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT2 ON IIT2.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT2.TAX_HEAD_ID = 6 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT3 ON IIT3.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT3.TAX_HEAD_ID = 7 " +
                "WHERE I.CANCLE_FLAGE IS NULL AND II.BILL_AMOUNT > 0 AND I.INVOICE_DATE IS NOT NULL " +
                "ORDER BY I.INVOICE_DATE DESC, I.INVOICE_NO DESC";

            System.out.println("Executing full invoice query...");
            ResultSet rs = stmt.executeQuery(sql);
            System.out.println("Query finished! Processing rows...");

            // Group by Customer Key -> List of Invoices
            Map<String, Map<String, Map<String, Object>>> customerInvoices = new LinkedHashMap<>();
            int count = 0;

            while (rs.next()) {
                count++;
                String custName = rs.getString("CUSTOMER_NAME");
                if (custName == null) continue;

                String accountKey = getAccountKey(custName);
                customerInvoices.putIfAbsent(accountKey, new LinkedHashMap<>());

                String invNo = String.valueOf(rs.getLong("INVOICE_NO"));
                Map<String, Object> inv = customerInvoices.get(accountKey).get(invNo);
                if (inv == null) {
                    inv = new LinkedHashMap<>();
                    inv.put("id", "INV-" + invNo);
                    inv.put("invoiceNo", invNo);
                    inv.put("invoiceRefNo", rs.getString("INVOICE_REF_NO") != null ? rs.getString("INVOICE_REF_NO") : "SPJ/" + invNo);
                    inv.put("date", rs.getString("INVOICE_DATE"));
                    inv.put("invoiceDate", rs.getString("INVOICE_DATE"));
                    inv.put("jobNo", rs.getString("JOB_NO") != null ? rs.getString("JOB_NO") : ("JOB-" + invNo));
                    inv.put("customerName", custName);
                    inv.put("customerId", rs.getInt("CUSTOMER_ID"));
                    inv.put("terminal", rs.getString("TERMINAL_NAME") != null ? rs.getString("TERMINAL_NAME") : "DADRI");
                    inv.put("serviceDescription", rs.getString("SERVICE_NAME") != null ? rs.getString("SERVICE_NAME") : "Multimodal Logistics");
                    inv.put("status", "Paid");
                    inv.put("paymentStatus", "P");
                    inv.put("currency", "INR");
                    inv.put("totalAmount", 0.0);
                    inv.put("billAmount", 0.0);
                    inv.put("taxAmount", 0.0);
                    inv.put("containers", new ArrayList<String>());
                    inv.put("containerCount", 0);
                    inv.put("items", new ArrayList<Map<String, Object>>());
                    customerInvoices.get(accountKey).put(invNo, inv);
                }

                double itemAmt = rs.getDouble("ITEM_AMOUNT");
                double itemTaxable = rs.getDouble("TAXABLE_AMT");
                double itemTax = rs.getDouble("ITEM_TAX");

                inv.put("totalAmount", round((double)inv.get("totalAmount") + itemAmt));
                inv.put("billAmount", round((double)inv.get("billAmount") + itemTaxable));
                inv.put("taxAmount", round((double)inv.get("taxAmount") + itemTax));

                String contNo = rs.getString("CONT_NO");
                List<String> conts = (List<String>) inv.get("containers");
                if (contNo != null && !contNo.trim().isEmpty() && !conts.contains(contNo)) {
                    conts.add(contNo);
                    inv.put("containerCount", conts.size());
                }

                List<Map<String, Object>> items = (List<Map<String, Object>>) inv.get("items");
                if (items.size() < 10) { // Keep top 10 items per invoice
                    Map<String, Object> itm = new LinkedHashMap<>();
                    itm.put("itemKey", "ITM-" + rs.getString("LINE_ITEM_ID"));
                    itm.put("description", rs.getString("LINE_DESC") != null ? rs.getString("LINE_DESC") : rs.getString("SERVICE_NAME"));
                    itm.put("billRate", rs.getDouble("BILL_RATE"));
                    itm.put("qty", rs.getInt("BILL_QNTY"));
                    itm.put("amount", itemTaxable);
                    itm.put("tax", itemTax);
                    itm.put("total", itemAmt);
                    if (contNo != null) itm.put("containerNo", contNo);
                    if (rs.getString("CONT_SIZE") != null) itm.put("size", rs.getString("CONT_SIZE"));
                    if (rs.getString("BL_NO") != null) itm.put("blNo", rs.getString("BL_NO"));
                    if (rs.getString("SB_NO") != null) itm.put("sbNo", rs.getString("SB_NO"));
                    if (rs.getString("TRAIN_OUT_DATE") != null) itm.put("trainOutDate", rs.getString("TRAIN_OUT_DATE"));
                    if (rs.getString("SAILED_DATE") != null) itm.put("sailedDate", rs.getString("SAILED_DATE"));
                    if (rs.getString("POD") != null) itm.put("destinationPort", rs.getString("POD"));
                    items.add(itm);
                }
            }

            System.out.println("Processed " + count + " raw rows across " + customerInvoices.keySet().size() + " accounts.");

            // Convert to JSON and save
            StringBuilder json = new StringBuilder();
            json.append("{\n  \"invoices\": {\n");
            int aIdx = 0;
            for (String key : customerInvoices.keySet()) {
                json.append("    \"").append(key).append("\": [\n");
                Collection<Map<String, Object>> invList = customerInvoices.get(key).values();
                int iIdx = 0;
                for (Map<String, Object> inv : invList) {
                    json.append("      {\n");
                    json.append("        \"id\": \"").append(inv.get("id")).append("\",\n");
                    json.append("        \"invoiceNo\": \"").append(inv.get("invoiceNo")).append("\",\n");
                    json.append("        \"invoiceRefNo\": \"").append(escapeJson((String)inv.get("invoiceRefNo"))).append("\",\n");
                    json.append("        \"date\": \"").append(inv.get("date")).append("\",\n");
                    json.append("        \"invoiceDate\": \"").append(inv.get("invoiceDate")).append("\",\n");
                    json.append("        \"jobNo\": \"").append(escapeJson((String)inv.get("jobNo"))).append("\",\n");
                    json.append("        \"customerName\": \"").append(escapeJson((String)inv.get("customerName"))).append("\",\n");
                    json.append("        \"customerId\": ").append(inv.get("customerId")).append(",\n");
                    json.append("        \"terminal\": \"").append(escapeJson((String)inv.get("terminal"))).append("\",\n");
                    json.append("        \"serviceDescription\": \"").append(escapeJson((String)inv.get("serviceDescription"))).append("\",\n");
                    json.append("        \"status\": \"Paid\",\n");
                    json.append("        \"paymentStatus\": \"P\",\n");
                    json.append("        \"currency\": \"INR\",\n");
                    json.append("        \"totalAmount\": ").append(inv.get("totalAmount")).append(",\n");
                    json.append("        \"billAmount\": ").append(inv.get("billAmount")).append(",\n");
                    json.append("        \"taxAmount\": ").append(inv.get("taxAmount")).append(",\n");
                    json.append("        \"containerCount\": ").append(inv.get("containerCount")).append(",\n");
                    
                    // containers list
                    json.append("        \"containers\": [");
                    List<String> conts = (List<String>) inv.get("containers");
                    for (int c = 0; c < conts.size(); c++) {
                        json.append("\"").append(conts.get(c)).append("\"").append(c < conts.size() - 1 ? ", " : "");
                    }
                    json.append("],\n");

                    // items list
                    json.append("        \"items\": [\n");
                    List<Map<String, Object>> itms = (List<Map<String, Object>>) inv.get("items");
                    for (int it = 0; it < itms.size(); it++) {
                        Map<String, Object> itm = itms.get(it);
                        json.append("          { ");
                        json.append("\"itemKey\": \"").append(itm.get("itemKey")).append("\", ");
                        json.append("\"description\": \"").append(escapeJson((String)itm.get("description"))).append("\", ");
                        json.append("\"billRate\": ").append(itm.get("billRate")).append(", ");
                        json.append("\"qty\": ").append(itm.get("qty")).append(", ");
                        json.append("\"amount\": ").append(itm.get("amount")).append(", ");
                        json.append("\"tax\": ").append(itm.get("tax")).append(", ");
                        json.append("\"total\": ").append(itm.get("total"));
                        if (itm.containsKey("containerNo")) json.append(", \"containerNo\": \"").append(itm.get("containerNo")).append("\"");
                        if (itm.containsKey("size")) json.append(", \"size\": \"").append(itm.get("size")).append("\"");
                        if (itm.containsKey("blNo")) json.append(", \"blNo\": \"").append(escapeJson((String)itm.get("blNo"))).append("\"");
                        if (itm.containsKey("sbNo")) json.append(", \"sbNo\": \"").append(escapeJson((String)itm.get("sbNo"))).append("\"");
                        if (itm.containsKey("trainOutDate")) json.append(", \"trainOutDate\": \"").append(itm.get("trainOutDate")).append("\"");
                        if (itm.containsKey("sailedDate")) json.append(", \"sailedDate\": \"").append(itm.get("sailedDate")).append("\"");
                        if (itm.containsKey("destinationPort")) json.append(", \"destinationPort\": \"").append(escapeJson((String)itm.get("destinationPort"))).append("\"");
                        json.append(" }").append(it < itms.size() - 1 ? ",\n" : "\n");
                    }
                    json.append("        ]\n");
                    json.append("      }").append(++iIdx < invList.size() ? ",\n" : "\n");
                }
                json.append("    ]").append(++aIdx < customerInvoices.size() ? ",\n" : "\n");
            }
            json.append("  }\n}\n");

            FileWriter fw = new FileWriter("/Users/iamrps/Desktop/spj/cutomerspjj/src/data/allCustomerRealInvoices.json");
            fw.write(json.toString());
            fw.close();
            System.out.println("Saved allCustomerRealInvoices.json successfully!");

            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static double round(double d) {
        return Math.round(d * 100.0) / 100.0;
    }

    private static String getAccountKey(String name) {
        String s = name.toUpperCase();
        if (s.contains("MARHABA")) return "MARHABA_FROZEN_FOODS";
        if (s.contains("FAIR")) return "FAIR";
        if (s.contains("HAMD") || s.contains("IFF") || s.contains("INDIA FROZEN")) return "IFF_INDIA_FROZEN_FOODS";
        if (s.contains("JH LOGISTICS") || s.contains("J.H")) return "JH_LOGISTICS";
        if (s.contains("AMMAR")) return "AL_AMMAR_FROZEN_FOOD_EXPORTS";
        if (s.contains("HMA")) return "HMA_AGRO_INDUSTRIES";
        if (s.contains("INTERNATIONAL AGRO") || s.contains("INTL AGRO")) return "INTERNATIONAL_AGRO_FOODS";
        if (s.contains("RUSTAM")) return "RUSTAM_FOODS";
        if (s.contains("AL-NASIR") || s.contains("NASIR")) return "AL_NASIR_EXPORTS";
        if (s.contains("SAMI")) return "AL_SAMI_FOOD_EXPORTS";
        if (s.contains("ALBY") || s.contains("ALBYS")) return "ALBYS_AGRO";
        if (s.contains("AOV")) return "AOV_EXPORTS";
        if (s.contains("ADINATH")) return "ADINATH_EXPORTS";
        if (s.contains("MASH")) return "MASH_AGRO_FOODS";
        if (s.contains("AMR")) return "AMR_EXPORTS_INDIA";
        if (s.contains("QURESH")) return "AL_QURESH_EXPORTS";
        if (s.contains("CONTAINER CORPORATION") || s.contains("CONCOR")) return "CONTAINER_CORPORATION_OF_INDIA_REFUND";
        if (s.contains("SPJ CARGO")) return "SPJ_CARGO";
        return s.replaceAll("[^A-Z0-9]", "_");
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
