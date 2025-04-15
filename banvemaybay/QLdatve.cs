using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL; 
using DTO; 

namespace banvemaybay.GUI
{
    public partial class QLdatve : Form
    {
        private VemaybayBLL vemaybayBLL = new VemaybayBLL();  

        public QLdatve()
        {
            InitializeComponent();
        }

       
        private void QLdatve_Load(object sender, EventArgs e)
        {
            
            LoadTrangThaiComboBox();
           
            LoadDataGridView();
        }

        private void LoadTrangThaiComboBox()
        {
            List<string> trangThaiList = vemaybayBLL.GetTrangThaiList(); 
            cbbtrangthai.DataSource = trangThaiList;  
        }

        // Tải dữ liệu vé máy bay vào DataGridView
        private void LoadDataGridView()
        {
            List<VemaybayDTO> vemaybayList = vemaybayBLL.GetAllVemaybay(); 
            datagridviewdatve.DataSource = vemaybayList;  
        }

        // Chuyển đổi trạng thái ComboBox khi người dùng thay đổi
        private void cbbtrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbtrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        // Sự kiện khi nhấn nút thoát
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Datacelclickdatve(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (không phải tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng dữ liệu được chọn
                DataGridViewRow row = datagridviewdatve.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột và điền vào các TextBox
                txtmave.Text = row.Cells["MaVe"].Value.ToString(); // Giả sử cột "MaVe" có tên là "MaVe"
                txtMahanhkhach.Text = row.Cells["MaHanhKhach"].Value.ToString();
                txtmachuyenbay.Text = row.Cells["MaChuyenBay"].Value.ToString();
                txtgiatien.Text = row.Cells["GiaVe"].Value.ToString();
                dtpkdatve.Text = row.Cells["NgayDatVe"].Value.ToString(); // Nếu bạn cần định dạng lại ngày
                cbbtrangthai.SelectedItem = row.Cells["TrangThai"].Value.ToString(); // Chọn trạng thái trong ComboBox
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maVe = txtmave.Text;
            DateTime ngayDatVe = dtpkdatve.Value;
            string trangThai = cbbtrangthai.Text;

            // Kiểm tra hợp lệ cho Giatien
            if (!decimal.TryParse(txtgiatien.Text, out decimal Giatien))
            {
                MessageBox.Show("Giá tiền phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maVe))
            {
                MessageBox.Show("Vui lòng chọn vé cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm cập nhật
            bool result = vemaybayBLL.UpdateVemaybay(maVe, ngayDatVe, trangThai, Giatien);

            if (result)
            {
                MessageBox.Show("Cập nhật vé thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView(); // Load lại dữ liệu
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void xoa_Click(object sender, EventArgs e)
        {
            string maVe = txtmave.Text.Trim();

            if (string.IsNullOrEmpty(maVe))
            {
                MessageBox.Show("Vui lòng chọn vé cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa vé này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (vemaybayBLL.DeleteVemaybay(maVe))
                {
                    MessageBox.Show("Xóa vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();

                }
                else
                {
                    MessageBox.Show("Xóa vé thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
