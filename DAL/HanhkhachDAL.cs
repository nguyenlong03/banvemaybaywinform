using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class HanhkhachDAL

    {
        private static readonly string connectionString = @"Data Source=192.168.60.128;Initial Catalog=QLbanvemaybay;Persist Security Info=True;User ID=sa;Password=Str0ngP@ssw0rd!;Encrypt=True;TrustServerCertificate=True";

        public List<HanhkhachDTO> GetAllHanhKhach()
        {
            List<HanhkhachDTO> list = new List<HanhkhachDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM HanhKhach";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HanhkhachDTO hk = new HanhkhachDTO
                    {
                        MaHanhKhach = reader["MaHanhKhach"].ToString(),
                        TenHanhKhach = reader["TenHanhKhach"].ToString(),
                        CMND = reader["CMND"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString()
                    };
                    list.Add(hk);
                }
            }
            return list;
        }
        public bool AddHanhKhach(HanhkhachDTO hk)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO HanhKhach (MaHanhKhach, TenHanhKhach, CMND, DiaChi, SoDienThoai) " +
                               "VALUES (@MaHanhKhach, @TenHanhKhach, @CMND, @DiaChi, @SoDienThoai)";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Truyền tất cả các tham số, bao gồm MaHanhKhach
                cmd.Parameters.AddWithValue("@MaHanhKhach", hk.MaHanhKhach);  // Nhập mã hành khách từ TextBox
                cmd.Parameters.AddWithValue("@TenHanhKhach", hk.TenHanhKhach);
                cmd.Parameters.AddWithValue("@CMND", hk.CMND);
                cmd.Parameters.AddWithValue("@DiaChi", hk.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", hk.SoDienThoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;  // Kiểm tra nếu thêm thành công
            }
        }



        public bool UpdateHanhKhach(HanhkhachDTO hk)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE HanhKhach SET TenHanhKhach = @TenHanhKhach, CMND = @CMND, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai " +
                               "WHERE MaHanhKhach = @MaHanhKhach";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Truyền tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@MaHanhKhach", hk.MaHanhKhach);
                cmd.Parameters.AddWithValue("@TenHanhKhach", hk.TenHanhKhach);
                cmd.Parameters.AddWithValue("@CMND", hk.CMND);
                cmd.Parameters.AddWithValue("@DiaChi", hk.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", hk.SoDienThoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công
            }
        }
      
    }
}
