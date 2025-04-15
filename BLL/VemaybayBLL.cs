using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAL;
using DTO;

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
        public bool UpdateVemaybay(string maVe, DateTime ngayDatVe, string trangThai,decimal giaVe)
        {
            return vemaybayDAL.UpdateVemaybay(maVe, ngayDatVe, trangThai, giaVe);
        }

        public bool DeleteVemaybay(string maVe)
        {
            return vemaybayDAL.DeleteVemaybay(maVe);
        }


        public int DemSoVeDaDat()
        {
            return vemaybayDAL.DemSoVeDaDat();
        }

        public decimal TinhTongTienVeDaBan()
        {
            return vemaybayDAL.TinhTongTienVeDaBan();
        }

    }
}
