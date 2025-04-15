using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{

    public class VemaybayDAL
    {
        string connectionString = @"Data Source=192.168.60.128;Initial Catalog=QLbanvemaybay;Persist Security Info=True;User ID=sa;Password=Str0ngP@ssw0rd!;Encrypt=True;TrustServerCertificate=True";
        // Phương thức lấy tất cả vé máy bay
        public List<VemaybayDTO> GetAllVemaybay()
        {
            List<VemaybayDTO> list = new List<VemaybayDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM VeMayBay";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VemaybayDTO ve = new VemaybayDTO
                    {
                        MaVe = reader["MaVe"].ToString(),
                        MaHanhKhach = reader["MaHanhKhach"].ToString(),
                        MaChuyenBay = reader["MaChuyenBay"].ToString(),
                        NgayDatVe = Convert.ToDateTime(reader["NgayDatVe"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        GiaVe = reader["GiaVe"] != DBNull.Value ? Convert.ToDecimal(reader["GiaVe"]) : 0
                    };
                    list.Add(ve);
                }
            }

            return list;

        }

        // Phương thức lấy danh sách trạng thái vé từ cơ sở dữ liệu
        public List<string> GetTrangThaiList()
        {
            List<string> trangThaiList = new List<string>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT DISTINCT TrangThai FROM VeMayBay";  // Lấy các trạng thái vé khác nhau
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    trangThaiList.Add(reader["TrangThai"].ToString());
                }
            }

            return trangThaiList;
        }

        // chức năng sửa
        public bool UpdateVemaybay(string maVe, DateTime ngayDatVe, string trangThai, decimal giaVe)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE VeMayBay SET NgayDatVe = @ngayDatVe, TrangThai = @trangThai, GiaVe = @giaVe WHERE MaVe = @maVe";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ngayDatVe", ngayDatVe);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@giaVe", giaVe);
                cmd.Parameters.AddWithValue("@maVe", maVe);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }


        // chức năng xóa
        public bool DeleteVemaybay(string maVe)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM VeMayBay WHERE MaVe = @MaVe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaVe", maVe);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // tính tổng vé
        public int DemSoVeDaDat()
        {
            int count = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM VeMayBay WHERE TrangThai = N'Đã đặt'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }


        public decimal TinhTongTienVeDaBan()
        {
            decimal tongTien = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT SUM(GiaVe) FROM VeMayBay WHERE TrangThai = N'Đã đặt'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    tongTien = Convert.ToDecimal(result);
                }
            }
            return tongTien;
        }









    }

}
