using System;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LoginDAL
    {
        public loginDTO Login(string username, string password)
        {
            loginDTO user = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = @Username AND MatKhau = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new loginDTO
                    {
                        MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        Vaitro = reader["VaiTro"].ToString()
                    };
                }
            }

            return user;
        }
    }
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=192.168.60.128;Initial Catalog=QLbanvemaybay;Persist Security Info=True;User ID=sa;Password=Str0ngP@ssw0rd!;Encrypt=True;TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
