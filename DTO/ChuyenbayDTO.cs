using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class ChuyenbayDTO
    {
        public string MaChuyenBay { get; set; }
        public string HangBay { get; set; }
        public DateTime NgayGioKhoiHanh { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public decimal GiaVe { get; set; }
        public ChuyenbayDTO() { }

        public ChuyenbayDTO(string maChuyenBay, string hangBay, DateTime ngayGioKhoiHanh, string diemDi, string diemDen, decimal giaVe)
        {
            MaChuyenBay = maChuyenBay;
            HangBay = hangBay;
            NgayGioKhoiHanh = ngayGioKhoiHanh;
            DiemDi = diemDi;
            DiemDen = diemDen;
            GiaVe = giaVe;
        }
    }
}
