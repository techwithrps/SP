import java.sql.*;

public class FetchFair2627 {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com";
        String user = "SPJLIVE";
        String pass = "SPjlive_0112#";
        try (Connection conn = DriverManager.getConnection(url, user, pass)) {
            System.out.println("Connected to Oracle SPJLIVE");
            String sql = 
                "SELECT I.INVOICE_NO, I.INVOICE_REF_NO, TO_CHAR(I.INVOICE_DATE, 'DD/MM/YYYY') AS INV_DATE, CM.CUSTOMER_ID, CM.CUSTOMER_NAME, " +
                "       TM.TERMINAL_ID, TM.TERMINAL_NAME, " +
                "       ROUND(SUM(II.BILL_AMOUNT), 2) AS GROSS_AMOUNT, " +
                "       ROUND(SUM(CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END), 2) AS TAXABLE_SALES, " +
                "       ROUND(SUM(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0)), 2) AS GST_TAX, " +
                "       NVL(AP.CONT_NO, '-') AS CONT_NO, NVL(FC.CONT_SIZE, '20') AS CONT_SIZE, NVL(AP.BL_NO, '-') AS BL_NO " +
                "FROM SPJLIVE.IMP_INVOICE I " +
                "JOIN SPJLIVE.IMP_INVOICE_ITEMS II ON I.INVOICE_NO = II.INVOICE_NO " +
                "JOIN SPJLIVE.CUSTOMER_MASTER CM ON I.BILL_TO = CM.CUSTOMER_ID " +
                "LEFT JOIN SPJLIVE.TERMINAL_MASTER TM ON I.TERMINAL_ID = TM.TERMINAL_ID " +
                "LEFT JOIN SPJLIVE.ALL_PARTY_ACCOUNT AP ON AP.CONT_JO_ID = II.LINE_ITEM_ID " +
                "LEFT JOIN SPJLIVE.FLEET_CONT_JO_DTLS FC ON AP.MTY_CONT_ID = FC.MTY_CONT_ID " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT1 ON IIT1.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT1.TAX_HEAD_ID = 5 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT2 ON IIT2.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT2.TAX_HEAD_ID = 6 " +
                "LEFT JOIN SPJLIVE.IMP_INVOICE_TAX IIT3 ON IIT3.ITEM_KEY_ID = II.ITEM_KEY_ID AND IIT3.TAX_HEAD_ID = 7 " +
                "WHERE I.CANCLE_FLAGE IS NULL AND II.BILL_AMOUNT > 0 " +
                "  AND I.INVOICE_DATE >= TO_DATE('2026-04-01','YYYY-MM-DD') " +
                "  AND UPPER(CM.CUSTOMER_NAME) LIKE '%FAIR%' " +
                "GROUP BY I.INVOICE_NO, I.INVOICE_REF_NO, TO_CHAR(I.INVOICE_DATE, 'DD/MM/YYYY'), CM.CUSTOMER_ID, CM.CUSTOMER_NAME, TM.TERMINAL_ID, TM.TERMINAL_NAME, AP.CONT_NO, FC.CONT_SIZE, AP.BL_NO " +
                "ORDER BY 3 DESC";

            try (Statement st = conn.createStatement(); ResultSet rs = st.executeQuery(sql)) {
                int count = 0;
                while (rs.next()) {
                    count++;
                    System.out.println(String.format("Row %d: [Customer: %s (ID: %s)] | InvNo: %s | RefNo: %s | Date: %s | Terminal: %s | Taxable: %.2f | GST: %.2f | Gross: %.2f | ContNo: %s | Size: %s | BL: %s",
                        count,
                        rs.getString("CUSTOMER_NAME"),
                        rs.getString("CUSTOMER_ID"),
                        rs.getString("INVOICE_NO"),
                        rs.getString("INVOICE_REF_NO"),
                        rs.getString("INV_DATE"),
                        rs.getString("TERMINAL_NAME"),
                        rs.getDouble("TAXABLE_SALES"),
                        rs.getDouble("GST_TAX"),
                        rs.getDouble("GROSS_AMOUNT"),
                        rs.getString("CONT_NO"),
                        rs.getString("CONT_SIZE"),
                        rs.getString("BL_NO")
                    ));
                }
                System.out.println("Total matching records: " + count);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
