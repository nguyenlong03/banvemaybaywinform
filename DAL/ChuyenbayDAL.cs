using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChuyenbayDAL
    {
        private static readonly string connectionString = @"Data Source=192.168.60.128;Initial Catalog=QLbanvemaybay;Persist Security Info=True;User ID=sa;Password=Str0ngP@ssw0rd!;Encrypt=True;TrustServerCertificate=True";

        // Lấy danh sách chuyến bay
        public List<ChuyenbayDTO> GetAllChuyenBay()
        {
            List<ChuyenbayDTO> danhSach = new List<ChuyenbayDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ChuyenBay";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChuyenbayDTO cb = new ChuyenbayDTO(
                        reader["MaChuyenBay"].ToString(),
                        reader["HangBay"].ToString(),
                        Convert.ToDateTime(reader["NgayGioKhoiHanh"]),
                        reader["DiemDi"].ToString(),
                        reader["DiemDen"].ToString()
                       
                    );
                    danhSach.Add(cb);
                }
                conn.Close();
            }
            return danhSach;
        }
        // thêm chuyến bay mới
        public bool AddChuyenBay(ChuyenbayDTO chuyenBay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ChuyenBay (MaChuyenBay, HangBay, NgayGioKhoiHanh, DiemDi, DiemDen) " +
                               "VALUES (@MaChuyenBay, @HangBay, @NgayGioKhoiHanh, @DiemDi, @DiemDen)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaChuyenBay", chuyenBay.MaChuyenBay);
                cmd.Parameters.AddWithValue("@HangBay", chuyenBay.HangBay);
                cmd.Parameters.AddWithValue("@NgayGioKhoiHanh", chuyenBay.NgayGioKhoiHanh);
                cmd.Parameters.AddWithValue("@DiemDi", chuyenBay.DiemDi);
                cmd.Parameters.AddWithValue("@DiemDen", chuyenBay.DiemDen);
              

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Trả về true nếu thêm thành công
            }
        }


        // Sửa chuyến bay
        public bool UpdateChuyenBay(ChuyenbayDTO cb)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ChuyenBay SET HangBay = @HangBay, NgayGioKhoiHanh = @NgayGioKhoiHanh, DiemDi = @DiemDi, DiemDen = @DiemDen, GiaVe = @GiaVe WHERE MaChuyenBay = @MaChuyenBay";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaChuyenBay", cb.MaChuyenBay);
                cmd.Parameters.AddWithValue("@HangBay", cb.HangBay);

                // Truyền trực tiếp đối tượng DateTime mà không cần chuyển đổi thành chuỗi
                cmd.Parameters.AddWithValue("@NgayGioKhoiHanh", cb.NgayGioKhoiHanh);

                cmd.Parameters.AddWithValue("@DiemDi", cb.DiemDi);
                cmd.Parameters.AddWithValue("@DiemDen", cb.DiemDen);
      

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
        }
       
        // Xóa chuyến bay
        public bool DeleteChuyenBay(string machuyenbay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ChuyenBay WHERE MaChuyenBay = @MaChuyenBay";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaChuyenBay", machuyenbay);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Trả về true nếu xóa thành công
            }
        }


       
    }
}
