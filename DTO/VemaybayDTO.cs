using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VemaybayDTO
    {
        public string MaVe { get; set; }
        public string MaHanhKhach { get; set; }
        public string MaChuyenBay { get; set; }
        public DateTime NgayDatVe { get; set; }
        public string TrangThai { get; set; }
        public decimal GiaVe { get; set; }

        public VemaybayDTO() { }

        public VemaybayDTO(string maVe, string maHanhKhach, string maChuyenBay, DateTime ngayDatVe, string trangThai, decimal giaVe)
        {
            MaVe = maVe;
            MaHanhKhach = maHanhKhach;
            MaChuyenBay = maChuyenBay;
            NgayDatVe = ngayDatVe;
            TrangThai = trangThai;
            GiaVe = giaVe;
        }
    }
}
