using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoginBLL
    {
        private LoginDAL loginDAL = new LoginDAL();

        public loginDTO DangNhap(string username, string password)
        {
            // Gọi hàm Login từ DAL và trả về DTO nếu đăng nhập thành công
            return loginDAL.Login(username, password);
        }
    }
}
