using System;
using System.Collections.Generic;
using DAL;
using DTO;
using System.Windows.Forms;

namespace BLL
{
    public class VemaybayBLL
    {
        private VemaybayDAL vemaybayDAL = new VemaybayDAL();

        // Phương thức lấy tất cả vé máy bay
        public List<VemaybayDTO> GetAllVemaybay()
        {
            return vemaybayDAL.GetAllVemaybay();
        }

        // Phương thức lấy danh sách trạng thái vé
        public List<string> GetTrangThaiList()
        {
            return vemaybayDAL.GetTrangThaiList();
        }

        // Phương thức cập nhật thông tin vé máy bay
        public bool UpdateVemaybay(string maVe, DateTime ngayDatVe, string trangThai, decimal giaVe, string TenHanhKhack)
        {
            return vemaybayDAL.UpdateVemaybay(maVe, ngayDatVe, trangThai, giaVe, TenHanhKhack);
        }

        // Phương thức xóa vé máy bay
        public bool DeleteVemaybay(string maVe)
        {
            return vemaybayDAL.DeleteVemaybay(maVe);
        }

        // Phương thức đếm số vé đã đặt
        public int DemSoVeDaDat()
        {
            return vemaybayDAL.DemSoVeDaDat();
        }

        // Phương thức tính tổng tiền vé đã bán
        public decimal TinhTongTienVeDaBan()
        {
            return vemaybayDAL.TinhTongTienVeDaBan();
        }

        // Phương thức thêm vé máy bay
        public bool AddVemaybay(VemaybayDTO ve)
        {

            // Thực hiện thêm vé mới vào cơ sở dữ liệu
            return vemaybayDAL.AddVemaybay(ve);
        }
    }
}
