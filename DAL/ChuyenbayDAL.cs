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
                        reader["DiemDen"].ToString(),
                        Convert.ToDecimal(reader["GiaVe"])
                    );
                    danhSach.Add(cb);
                }
                conn.Close();
            }
            return danhSach;
        }
    }
}
