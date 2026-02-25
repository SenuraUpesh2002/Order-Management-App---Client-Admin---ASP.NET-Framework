using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderManagementApp.App_Code
{
    public class FoodDAL
    {
        //Updated DB connection string.
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public DataTable GetMainCategories()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("sp_GetMainCategories", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetSubCategories(int mainCategoryID)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetSubCategoriesByMain", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MainCategoryID", mainCategoryID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public decimal GetPrice(int subCategoryID)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_GetPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubCategoryID", subCategoryID);

                con.Open();
                object result = cmd.ExecuteScalar();

                return Convert.ToDecimal(result);
            }
        }

     
        // Add Main Category
        public void AddMainCategory(string categoryName)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_AddMainCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        // Add Sub Category
        public void AddSubCategory(int mainCategoryID, string subCategoryName, decimal price)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_AddSubCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MainCategoryID", mainCategoryID);
                cmd.Parameters.AddWithValue("@SubCategoryName", subCategoryName);
                cmd.Parameters.AddWithValue("@Price", price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get Orders

        public DataTable GetOrdersByUser(int userID)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetOrdersByUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // Get Order Items

        public DataTable GetOrderItems(int orderID)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetOrderItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }


        // Cancel Order

        public void CancelOrder(int orderID)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Orders SET OrderStatus='Cancelled' WHERE OrderID=@OrderID",
                    con);

                cmd.Parameters.AddWithValue("@OrderID", orderID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int PlaceOrder(int userID, int subCategoryID, int quantity, decimal totalAmount, decimal itemPrice)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_PlaceOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@SubCategoryID", subCategoryID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@ItemPrice", itemPrice);

                SqlParameter outputID = new SqlParameter("@OrderID", SqlDbType.Int);
                outputID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputID);

                con.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(outputID.Value);
            }
        }

    }
}