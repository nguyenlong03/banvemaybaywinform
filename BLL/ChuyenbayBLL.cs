using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class ChuyenbayBLL
    {
        private ChuyenbayDAL chuyenBayDAL = new ChuyenbayDAL(); // Sửa lại tên lớp cho đúng

        public List<ChuyenbayDTO> GetAllChuyenBay()
        {
            return chuyenBayDAL.GetAllChuyenBay();
        }
    }
}
