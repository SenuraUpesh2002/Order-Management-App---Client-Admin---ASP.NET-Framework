using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace OrderManagementApp
{
    public class RegisterDAL
    {

        public  RegisterDAL()
        {
        }

            private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public bool RegisterUser(string name, string email, string password)
        {
            bool isSuccess = false;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_RegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FullName", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", password);
                cmd.Parameters.AddWithValue("@Role", "Customer");

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    isSuccess = true;
            }

            return isSuccess;
        }

        
    }

}
