using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Windows.Forms;

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

                // Truyền tất cả các tham số
                cmd.Parameters.AddWithValue("@MaHanhKhach", hk.MaHanhKhach);
                cmd.Parameters.AddWithValue("@TenHanhKhach", hk.TenHanhKhach);
                cmd.Parameters.AddWithValue("@CMND", hk.CMND);
                cmd.Parameters.AddWithValue("@DiaChi", hk.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", hk.SoDienThoai);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Lỗi trùng khóa chính hoặc khóa duy nhất
                    {
                        MessageBox.Show("Mã hành khách đã tồn tại. Vui lòng nhập mã khác!",
                            "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm hành khách: " + ex.Message,
                            "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
            }
        }



        public bool DeleteHanhKhach(string MaHanhKhach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM HanhKhach WHERE MaHanhKhach = @MaHanhKhach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHanhKhach", MaHanhKhach);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    // 547 là mã lỗi cho vi phạm ràng buộc khóa ngoại
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa hành khách vì khách hàng đã đăng ký vé."
                          );
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message,
                            "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return false;
                }
            }
        }

        public bool UpdateHanhKhach(HanhkhachDTO hk)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                // Bắt đầu một transaction để đảm bảo cả hai cập nhật thành công
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Cập nhật tên hành khách trong bảng HanhKhach
                    string queryHanhKhach = "UPDATE HanhKhach SET TenHanhKhach = @TenHanhKhach, CMND = @CMND, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai " +
                                            "WHERE MaHanhKhach = @MaHanhKhach";

                    SqlCommand cmdHanhKhach = new SqlCommand(queryHanhKhach, conn, transaction);
                    cmdHanhKhach.Parameters.AddWithValue("@MaHanhKhach", hk.MaHanhKhach);
                    cmdHanhKhach.Parameters.AddWithValue("@TenHanhKhach", hk.TenHanhKhach);
                    cmdHanhKhach.Parameters.AddWithValue("@CMND", hk.CMND);
                    cmdHanhKhach.Parameters.AddWithValue("@DiaChi", hk.DiaChi);
                    cmdHanhKhach.Parameters.AddWithValue("@SoDienThoai", hk.SoDienThoai);

                    int rowsAffectedHanhKhach = cmdHanhKhach.ExecuteNonQuery();

                    if (rowsAffectedHanhKhach == 0)
                    {
                        MessageBox.Show("Vui lòng không sửa mã hành khách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Cập nhật tên hành khách trong bảng VeMayBay
                    string queryVeMayBay = "UPDATE VeMayBay SET TenHanhKhach = @TenHanhKhach WHERE MaHanhKhach = @MaHanhKhach";

                    SqlCommand cmdVeMayBay = new SqlCommand(queryVeMayBay, conn, transaction);
                    cmdVeMayBay.Parameters.AddWithValue("@MaHanhKhach", hk.MaHanhKhach);
                    cmdVeMayBay.Parameters.AddWithValue("@TenHanhKhach", hk.TenHanhKhach);

                    int rowsAffectedVeMayBay = cmdVeMayBay.ExecuteNonQuery();

                    if (rowsAffectedVeMayBay == 0)
                    {
                        MessageBox.Show("Không tìm thấy vé liên quan đến hành khách, không cập nhật được thông tin vé.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Commit transaction nếu tất cả các cập nhật thành công
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi xảy ra
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }



    }
}
