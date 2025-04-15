using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using DTO;

namespace banvemaybay.GUI
{
    public partial class QLhanhkhach : Form
    {
        public QLhanhkhach()
        {
            InitializeComponent();
        }
        HanhkhachBLL bll = new HanhkhachBLL();

        private void button5_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QLhanhkhach_Load(object sender, EventArgs e)
        {
            LoadData();
            datagridviewhanhkhach.ReadOnly = true;

        }

        private void LoadData()
        {
          
            HanhkhachBLL hanhkhachBLL = new HanhkhachBLL();
            var data = hanhkhachBLL.GetAllHanhKhach(); 
            datagridviewhanhkhach.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmahanhkhach.Text) ||
            string.IsNullOrWhiteSpace(txttenhanhkhach.Text) ||
            string.IsNullOrWhiteSpace(txtcmnd.Text) ||
            string.IsNullOrWhiteSpace(txtdiachi.Text) ||
            string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng HanhkhachDTO và truyền đủ 5 tham số
            HanhkhachDTO newHanhKhach = new HanhkhachDTO(
                txtmahanhkhach.Text,    
                txttenhanhkhach.Text,  
                txtcmnd.Text,           
                txtdiachi.Text,         
                txtsdt.Text             
            );

            // Gọi phương thức thêm hành khách
            if (bll.AddHanhKhach(newHanhKhach))
            {
                MessageBox.Show("Thêm hành khách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại DataGridView sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm hành khách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô nhập có bị trống không
            if (string.IsNullOrWhiteSpace(txtmahanhkhach.Text) ||
                string.IsNullOrWhiteSpace(txttenhanhkhach.Text) ||
                string.IsNullOrWhiteSpace(txtcmnd.Text) ||
                string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng HanhkhachDTO với dữ liệu từ các TextBox
            HanhkhachDTO updatedHanhKhach = new HanhkhachDTO
            {
                MaHanhKhach = txtmahanhkhach.Text,  // Mã hành khách cần sửa
                TenHanhKhach = txttenhanhkhach.Text,
                CMND = txtcmnd.Text,
                DiaChi = txtdiachi.Text,
                SoDienThoai = txtsdt.Text
            };

            // Gọi phương thức cập nhật hành khách
            if (bll.UpdateHanhKhach(updatedHanhKhach))
            {
                MessageBox.Show("Cập nhật hành khách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Load lại DataGridView sau khi sửa
            }
            else
            {
                MessageBox.Show("Cập nhật hành khách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatacelclickHanhkhach(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = datagridviewhanhkhach.Rows[e.RowIndex];

                // Điền thông tin vào các TextBox
                txtmahanhkhach.Text = row.Cells["MaHanhKhach"].Value.ToString();
                txttenhanhkhach.Text = row.Cells["TenHanhKhach"].Value.ToString();
                txtcmnd.Text = row.Cells["CMND"].Value.ToString();
                txtdiachi.Text = row.Cells["DiaChi"].Value.ToString();
                txtsdt.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }

    
    }
}
