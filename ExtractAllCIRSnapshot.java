import java.io.FileWriter;
import java.sql.*;
import java.util.*;

public class ExtractAllCIRSnapshot {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com";
        String user = "SPJLIVE";
        String pass = "SPjlive_0112#";
        try (Connection conn = DriverManager.getConnection(url, user, pass)) {
            System.out.println("Connected to Oracle SPJLIVE. Extracting CIR rows...");
            String sql = 
                "SELECT I.INVOICE_NO, I.INVOICE_REF_NO, TO_CHAR(I.INVOICE_DATE, 'DD/MM/YYYY') AS INV_DATE, " +
                "       I.INVOICE_DATE, " +
                "       CM.CUSTOMER_ID, CM.CUSTOMER_NAME, " +
                "       TM.TERMINAL_ID, NVL(TM.TERMINAL_NAME, 'TRANSWORLD-DADRI') AS TERMINAL_NAME, " +
                "       NVL(AP.JOB_NO, I.INVOICE_NO) AS JOB_NO, " +
                "       NVL(II.SERVICE_NAME, 'CUSTOMS CLEARANCE & LOGISTICS') AS SERVICE_NAME, " +
                "       NVL(AP.CONT_NO, 'GEN-CARGO') AS CONT_NO, " +
                "       NVL(FC.CONT_SIZE, '20') AS CONT_SIZE, " +
                "       NVL(AP.BL_NO, '-') AS BL_NO, " +
                "       NVL(AP.TRIP_TYPE, 'IMPORT') AS TRIP_TYPE, " +
                "       ROUND(SUM(II.BILL_AMOUNT), 2) AS GROSS_AMOUNT, " +
                "       ROUND(SUM(CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END), 2) AS TAXABLE_SALES, " +
                "       ROUND(SUM(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0)), 2) AS GST_TAX, " +
                "       ROUND(SUM(NVL(IIT1.TAX_AMT, 0)), 2) AS IGST, " +
                "       ROUND(SUM(NVL(IIT2.TAX_AMT, 0)), 2) AS CGST, " +
                "       ROUND(SUM(NVL(IIT3.TAX_AMT, 0)), 2) AS SGST, " +
                "       NVL(I.COMPANY_ID, 2) AS COMPANY_ID " +
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
                "GROUP BY I.INVOICE_NO, I.INVOICE_REF_NO, I.INVOICE_DATE, TO_CHAR(I.INVOICE_DATE, 'DD/MM/YYYY'), " +
                "         CM.CUSTOMER_ID, CM.CUSTOMER_NAME, TM.TERMINAL_ID, TM.TERMINAL_NAME, " +
                "         AP.JOB_NO, II.SERVICE_NAME, AP.CONT_NO, FC.CONT_SIZE, AP.BL_NO, AP.TRIP_TYPE, I.COMPANY_ID " +
                "ORDER BY I.INVOICE_DATE DESC";

            try (Statement st = conn.createStatement(); ResultSet rs = st.executeQuery(sql)) {
                StringBuilder json = new StringBuilder();
                json.append("[\n");
                int count = 0;
                while (rs.next()) {
                    if (count > 0) json.append(",\n");
                    count++;
                    String invRef = rs.getString("INVOICE_REF_NO");
                    if (invRef == null || invRef.trim().isEmpty()) invRef = "INV-" + rs.getString("INVOICE_NO");
                    String cName = rs.getString("CUSTOMER_NAME").replace("\"", "\\\"").replace("\n", " ").replace("\r", " ");
                    String sName = rs.getString("SERVICE_NAME").replace("\"", "\\\"").replace("\n", " ").replace("\r", " ");
                    String tName = rs.getString("TERMINAL_NAME").replace("\"", "\\\"").replace("\n", " ").replace("\r", " ");
                    String contNo = rs.getString("CONT_NO") != null ? rs.getString("CONT_NO").replace("\"", "\\\"") : "-";
                    String size = rs.getString("CONT_SIZE") != null ? rs.getString("CONT_SIZE") : "20";
                    String blNo = rs.getString("BL_NO") != null ? rs.getString("BL_NO").replace("\"", "\\\"") : "-";
                    String trip = rs.getString("TRIP_TYPE") != null ? rs.getString("TRIP_TYPE") : "IMPORT";
                    String invDate = rs.getString("INV_DATE");

                    json.append(String.format(
                        "  {\"INVOICE_NO\":\"%s\",\"INVOICE_REF_NO\":\"%s\",\"PARTY_INV_NO\":\"%s\",\"INVOICE_DATE\":\"%s\",\"CREATED_DATE\":\"%s\"," +
                        "\"JOB_NO\":\"%s\",\"CUSTOMER_ID\":%d,\"CUSTOMER_NAME\":\"%s\",\"TERMINAL_ID\":%d,\"TERMINAL_NAME\":\"%s\"," +
                        "\"SERVICE_NAME\":\"%s\",\"SERVICE_CHARGE\":\"%s\",\"CONT_NO\":\"%s\",\"CONTAINER_NO\":\"%s\",\"CONTAINER_SIZE\":\"%s\"," +
                        "\"SIZE\":\"%s\",\"TRIP_TYPE\":\"%s\",\"BILL_AMOUNT\":%.2f,\"AMOUNT\":%.2f,\"TAX_AMOUNT\":%.2f,\"TOTAL_AMOUNT\":%.2f," +
                        "\"STATUS\":\"INVOICED\",\"TYPE\":\"Invoice\",\"BL_NO\":\"%s\",\"PORT\":\"%s\",\"BILL_QNTY\":1,\"IGST\":%.2f,\"CGST\":%.2f,\"SGST\":%.2f," +
                        "\"COMPANY_ID\":%d}",
                        rs.getString("INVOICE_NO"), invRef, invRef, invDate, invDate,
                        rs.getString("JOB_NO"), rs.getLong("CUSTOMER_ID"), cName, rs.getInt("TERMINAL_ID"), tName,
                        sName, sName, contNo, contNo, size,
                        size, trip, rs.getDouble("TAXABLE_SALES"), rs.getDouble("GROSS_AMOUNT"), rs.getDouble("GST_TAX"), rs.getDouble("GROSS_AMOUNT"),
                        blNo, tName, rs.getDouble("IGST"), rs.getDouble("CGST"), rs.getDouble("SGST"),
                        rs.getInt("COMPANY_ID")
                    ));

                    if (count % 10000 == 0) {
                        System.out.println("Extracted " + count + " CIR rows...");
                    }
                }
                json.append("\n]");
                System.out.println("Total extracted: " + count + " CIR rows!");

                FileWriter fw = new FileWriter("/Users/iamrps/Desktop/spj/backend/src/data/cachedSnapshot.json");
                fw.write(json.toString());
                fw.close();
                System.out.println("Saved to backend/src/data/cachedSnapshot.json successfully!");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
