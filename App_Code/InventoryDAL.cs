using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace OrderManagementApp.App_Code
{
    public class InventoryDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;


        // Upload Inventory from Excel (OleDb)
   
        public void UploadInventoryFromExcel(Stream fileStream, string filePath)
        {
            // Save file temporarily
            string tempPath = Path.Combine(Path.GetTempPath(), filePath);

            using (FileStream fs = new FileStream(tempPath, FileMode.Create))
            {
                fileStream.CopyTo(fs);
            }

            string excelConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + tempPath + ";" +
                "Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            using (OleDbConnection excelConn = new OleDbConnection(excelConnectionString))
            {
                excelConn.Open();

                // Read first sheet
                DataTable dt = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = dt.Rows[0]["TABLE_NAME"].ToString();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", excelConn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable excelData = new DataTable();
                adapter.Fill(excelData);

                excelConn.Close();

                // Insert into SQL
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    SqlTransaction transaction = sqlConn.BeginTransaction();

                    try
                    {
                        foreach (DataRow row in excelData.Rows)
                        {
                            int productID = Convert.ToInt32(row["ProductID"]);
                            string productName = row["ProductName"].ToString();
                            int mainCategoryID = Convert.ToInt32(row["MainCategoryID"]);
                            int subCategoryID = Convert.ToInt32(row["SubCategoryID"]);
                            decimal price = Convert.ToDecimal(row["Price"]);
                            int quantity = Convert.ToInt32(row["Quantity"]);

                            // Check if exists
                            SqlCommand checkCmd = new SqlCommand(
                                "SELECT COUNT(*) FROM Products WHERE ProductID=@ProductID",
                                sqlConn, transaction);

                            checkCmd.Parameters.AddWithValue("@ProductID", productID);

                            int exists = (int)checkCmd.ExecuteScalar();

                            if (exists > 0)
                            {
                                SqlCommand updateCmd = new SqlCommand(
                                    @"UPDATE Products
                                      SET StockQuantity = StockQuantity + @Quantity,
                                          Price=@Price
                                      WHERE ProductID=@ProductID",
                                    sqlConn, transaction);

                                updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                                updateCmd.Parameters.AddWithValue("@Price", price);
                                updateCmd.Parameters.AddWithValue("@ProductID", productID);

                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                SqlCommand insertCmd = new SqlCommand(
                                    @"INSERT INTO Products
                                      (ProductID, ProductName, MainCategoryID, SubCategoryID, Price, StockQuantity)
                                      VALUES
                                      (@ProductID, @ProductName, @MainCategoryID, @SubCategoryID, @Price, @Quantity)",
                                    sqlConn, transaction);

                                insertCmd.Parameters.AddWithValue("@ProductID", productID);
                                insertCmd.Parameters.AddWithValue("@ProductName", productName);
                                insertCmd.Parameters.AddWithValue("@MainCategoryID", mainCategoryID);
                                insertCmd.Parameters.AddWithValue("@SubCategoryID", subCategoryID);
                                insertCmd.Parameters.AddWithValue("@Price", price);
                                insertCmd.Parameters.AddWithValue("@Quantity", quantity);

                                insertCmd.ExecuteNonQuery();
                            }

                            // Insert Log (IN)
                            SqlCommand logCmd = new SqlCommand(
                                @"INSERT INTO InventoryLog
                                  (ProductID, QuantityChanged, ChangeType, ReferenceID)
                                  VALUES
                                  (@ProductID, @Quantity, 'IN', NULL)",
                                sqlConn, transaction);

                            logCmd.Parameters.AddWithValue("@ProductID", productID);
                            logCmd.Parameters.AddWithValue("@Quantity", quantity);

                            logCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            // Delete temp file
            File.Delete(tempPath);
        }

   
        // Reduce Stock When Customer Orders
 
        public void ReduceStock(int productID, int quantity, int orderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand updateCmd = new SqlCommand(
                        @"UPDATE Products
                          SET StockQuantity = StockQuantity - @Quantity
                          WHERE ProductID=@ProductID",
                        conn, transaction);

                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                    updateCmd.Parameters.AddWithValue("@ProductID", productID);
                    updateCmd.ExecuteNonQuery();

                    SqlCommand logCmd = new SqlCommand(
                        @"INSERT INTO InventoryLog
                          (ProductID, QuantityChanged, ChangeType, ReferenceID)
                          VALUES
                          (@ProductID, @Quantity, 'OUT', @OrderID)",
                        conn, transaction);

                    logCmd.Parameters.AddWithValue("@ProductID", productID);
                    logCmd.Parameters.AddWithValue("@Quantity", quantity);
                    logCmd.Parameters.AddWithValue("@OrderID", orderID);
                    logCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}