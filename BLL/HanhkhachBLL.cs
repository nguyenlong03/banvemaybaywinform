using System.Collections.Generic;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class HanhkhachBLL
    {
        private HanhkhachDAL hanhKhachDAL = new HanhkhachDAL();
        
        public List<HanhkhachDTO> GetAllHanhKhach()
        {
            return hanhKhachDAL.GetAllHanhKhach();
        }
        public bool AddHanhKhach(HanhkhachDTO hk)
        {
            return hanhKhachDAL.AddHanhKhach(hk);  
        }
        public bool UpdateHanhKhach(HanhkhachDTO hk)
        {
            return hanhKhachDAL.UpdateHanhKhach(hk);

        }
       
    }
}
