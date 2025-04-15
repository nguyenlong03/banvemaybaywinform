using System;
using System.Collections.Generic;
using DTO;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    public class ChuyenbayBLL
    {
        private ChuyenbayDAL chuyenBayDAL = new ChuyenbayDAL(); // Sửa lại tên lớp cho đúng
        // gọi data từ SQl
        public List<ChuyenbayDTO> GetAllChuyenBay()
        {
            return chuyenBayDAL.GetAllChuyenBay();
        }
        // thêm chuyễn bay BLL
        public bool AddChuyenBay(ChuyenbayDTO chuyenBay)
        {
            return chuyenBayDAL.AddChuyenBay(chuyenBay);
        }
        // sửa chuyến bay BLL
        public bool UpdateChuyenBay(ChuyenbayDTO cb)
        {
            
            try
            {
                // Chạy câu lệnh SQL để cập nhật chuyến bay
                return chuyenBayDAL.UpdateChuyenBay(cb);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // xóa chuyến bay
        public bool DeleteChuyenBay(string maChuyenBay)
        {
            
            return chuyenBayDAL.DeleteChuyenBay(maChuyenBay);
        }

      
    }
}
