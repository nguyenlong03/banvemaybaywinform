using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;

namespace DAL
{

    public class VemaybayDAL
    {
        public List<VemaybayDTO> GetAllVemaybay()
        {
            List<VemaybayDTO> list = new List<VemaybayDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
            SELECT v.*, h.TenHanhKhach 
            FROM VeMayBay v
            JOIN HanhKhach h ON v.MaHanhKhach = h.MaHanhKhach";

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
                        GiaVe = reader["GiaVe"] != DBNull.Value ? Convert.ToDecimal(reader["GiaVe"]) : 0,
                        TenHanhKhach = reader["TenHanhKhach"].ToString()
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
        public bool UpdateVemaybay(string maVe, DateTime ngayDatVe, string trangThai, decimal giaVe, string tenHanhKhach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE VeMayBay SET NgayDatVe = @ngayDatVe, TrangThai = @trangThai, GiaVe = @giaVe, TenHanhKhach = @tenHanhKhach WHERE MaVe = @maVe";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ngayDatVe", ngayDatVe);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@giaVe", giaVe);
                cmd.Parameters.AddWithValue("@tenHanhKhach", tenHanhKhach);
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
                // Ép kiểu GiaVe để tránh tràn số
                string query = "SELECT SUM(CAST(GiaVe AS DECIMAL(18,2))) FROM VeMayBay WHERE TrangThai = N'Đã đặt'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    tongTien = Convert.ToDecimal(result);
                }
            }

            return tongTien;
        }


        public bool AddVemaybay(VemaybayDTO ve)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
            //    // Kiểm tra mã hành khách truyền vào (in ra xem có đúng không)
            //    MessageBox.Show("Mã hành khách kiểm tra là: " + ve.MaHanhKhach);

                // Kiểm tra sự tồn tại của mã hành khách trong bảng HanhKhach
                if (!IsMaHanhKhachExists(ve.MaHanhKhach))
                {
                    MessageBox.Show("Mã hành khách không tồn tại. Vui lòng kiểm tra lại!",
                                    "Lỗi mã hành khách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra sự tồn tại của mã chuyến bay trong bảng ChuyenBay
                if (!IsMaChuyenBayExists(ve.MaChuyenBay))
                {
                    MessageBox.Show("Mã chuyến bay không tồn tại. Vui lòng kiểm tra lại!",
                                    "Lỗi mã chuyến bay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Thêm câu lệnh SQL để lưu tên hành khách vào bảng VeMayBay
                string query = @"INSERT INTO VeMayBay (MaVe, MaHanhKhach, MaChuyenBay, NgayDatVe, TrangThai, GiaVe, TenHanhKhach)
                 VALUES (@MaVe, @MaHanhKhach, @MaChuyenBay, @NgayDatVe, @TrangThai, @GiaVe, @TenHanhKhach)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaVe", ve.MaVe);
                cmd.Parameters.AddWithValue("@MaHanhKhach", ve.MaHanhKhach.Trim()); // Trim để loại bỏ khoảng trắng
                cmd.Parameters.AddWithValue("@MaChuyenBay", ve.MaChuyenBay.Trim()); // Trim cho chắc
                cmd.Parameters.AddWithValue("@NgayDatVe", ve.NgayDatVe);
                cmd.Parameters.AddWithValue("@TrangThai", ve.TrangThai);
                cmd.Parameters.AddWithValue("@GiaVe", ve.GiaVe);
                cmd.Parameters.AddWithValue("@TenHanhKhach", ve.TenHanhKhach.Trim()); // Thêm tên hành khách

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm vé máy bay: " + ex.Message,
                                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public bool IsMaHanhKhachExists(string maHanhKhach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM HanhKhach WHERE MaHanhKhach = @MaHanhKhach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHanhKhach", maHanhKhach.Trim()); // Trim để chắc chắn không sai

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra mã hành khách: " + ex.Message,
                                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool IsMaChuyenBayExists(string maChuyenBay)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM ChuyenBay WHERE MaChuyenBay = @MaChuyenBay";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay.Trim());

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra mã chuyến bay: " + ex.Message,
                                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }








    }

}
