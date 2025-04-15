using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HanhkhachDTO
    {
        public string MaHanhKhach { get; set; }
        public string TenHanhKhach { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public HanhkhachDTO() { }
        public HanhkhachDTO(string maHanhKhach, string tenHanhKhach, string cmnd, string diaChi, string soDienThoai)
        {
            MaHanhKhach = maHanhKhach;
            TenHanhKhach = tenHanhKhach;
            CMND = cmnd;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }

}
