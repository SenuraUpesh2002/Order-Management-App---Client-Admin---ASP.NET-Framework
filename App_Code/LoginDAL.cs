using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OrderManagementApp
{
    public class LoginDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public User ValidateUser(string email, string passwordHash)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, Role FROM Users WHERE Email=@Email AND PasswordHash=@PasswordHash";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Role = reader["Role"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}