import java.io.FileWriter;
import java.sql.*;
import java.util.*;

public class ExtractOracleRealData {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com";
        String user = "SPJLIVE";
        String pass = "SPjlive_0112#";

        try {
            System.out.println("Connecting to Oracle SPJLIVE...");
            Connection conn = DriverManager.getConnection(url, user, pass);
            System.out.println("Connected successfully! Starting full extraction across all FYs...");

            Statement stmt = conn.createStatement();

            // 1. Extract All Financial Years with Date Logic:
            // FY is determined by INVOICE_DATE (Apr 1 of Year to Mar 31 of Year+1)
            String fyQuery = 
                "SELECT " +
                "  CASE " +
                "    WHEN EXTRACT(MONTH FROM I.INVOICE_DATE) >= 4 " +
                "    THEN EXTRACT(YEAR FROM I.INVOICE_DATE) || '-' || (EXTRACT(YEAR FROM I.INVOICE_DATE) + 1) " +
                "    ELSE (EXTRACT(YEAR FROM I.INVOICE_DATE) - 1) || '-' || EXTRACT(YEAR FROM I.INVOICE_DATE) " +
                "  END AS FY, " +
                "  COUNT(DISTINCT I.INVOICE_NO) AS TOTAL_INVOICES, " +
                "  COUNT(II.LINE_ITEM_ID) AS TOTAL_LINE_ITEMS, " +
                "  COUNT(DISTINCT AP.CONT_NO) AS TOTAL_CONTAINERS, " +
                "  ROUND(SUM(CASE WHEN CM.STATE_CODE = '0' THEN II.BILL_RATE * II.BILL_QNTY ELSE II.BILL_RATE * NVL(II.EX_RATE, 1) * II.BILL_QNTY END), 2) AS TAXABLE_SALES, " +
                "  ROUND(SUM(NVL(IIT1.TAX_AMT, 0) + NVL(IIT2.TAX_AMT, 0) + NVL(IIT3.TAX_AMT, 0)), 2) AS TOTAL_TAX, " +
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
                "  END " +
                "ORDER BY FY DESC";

            System.out.println("Extracting FY Summaries...");
            ResultSet rsFy = stmt.executeQuery(fyQuery);
            System.out.println("=== REAL ORACLE FINANCIAL YEARS SUMMARY ===");
            while (rsFy.next()) {
                System.out.println("FY: " + rsFy.getString("FY") + 
                                   " | Invoices: " + rsFy.getInt("TOTAL_INVOICES") + 
                                   " | Containers: " + rsFy.getInt("TOTAL_CONTAINERS") + 
                                   " | Taxable: " + rsFy.getDouble("TAXABLE_SALES") + 
                                   " | Tax: " + rsFy.getDouble("TOTAL_TAX") + 
                                   " | Gross: " + rsFy.getDouble("GROSS_REVENUE"));
            }

            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
