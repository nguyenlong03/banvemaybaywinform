using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DTO;

namespace banvemaybay.GUI
{
    public partial class QLchuyenbay : Form
    {
        private ChuyenbayBLL chuyenBayBLL = new ChuyenbayBLL(); // Tạo đối tượng toàn cục

        public QLchuyenbay()
        {
            InitializeComponent();
        }

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

        private void QLchuyenbay_Load(object sender, EventArgs e)
        {

            datagvQLchuyenbay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagvQLchuyenbay.CellClick += checkeddata;
            LoadDataChuyenBay();
           

        }

        private void LoadDataChuyenBay()
        {
            List<ChuyenbayDTO> danhSach = chuyenBayBLL.GetAllChuyenBay();
            datagvQLchuyenbay.DataSource = danhSach;
        }
        // thêm chuyến bay
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các ô nhập bị trống
            if (string.IsNullOrWhiteSpace(txtmachuyenbay.Text) ||
                string.IsNullOrWhiteSpace(txttenhang.Text) ||
                string.IsNullOrWhiteSpace(txtdiemdi.Text) ||
                string.IsNullOrWhiteSpace(txtdiemden.Text)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng ChuyenbayDTO (không còn giá vé)
            ChuyenbayDTO newChuyenBay = new ChuyenbayDTO
                (
                txtmachuyenbay.Text,
                txttenhang.Text,
                dtpngaykhoihanh.Value,
                txtdiemdi.Text,
                txtdiemden.Text
            );

            // Gọi phương thức thêm chuyến bay
            if (chuyenBayBLL.AddChuyenBay(newChuyenBay))
            {
                MessageBox.Show("Thêm chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataChuyenBay(); // Load lại DataGridView sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm chuyến bay thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void checkeddata(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có phải tiêu đề không
            {
                DataGridViewRow row = datagvQLchuyenbay.Rows[e.RowIndex];

                txtmachuyenbay.Text = row.Cells["MaChuyenBay"].Value.ToString();
                txttenhang.Text = row.Cells["HangBay"].Value.ToString();
                dtpngaykhoihanh.Value = Convert.ToDateTime(row.Cells["NgayGioKhoiHanh"].Value);
                txtdiemdi.Text = row.Cells["DiemDi"].Value.ToString();
                txtdiemden.Text = row.Cells["DiemDen"].Value.ToString();
               
            }
        }
        // sửa chuyến bay
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmachuyenbay.Text))
            {
                MessageBox.Show("Vui lòng chọn chuyến bay để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            // Lấy ngày mà không có giờ
            DateTime ngayKhoiHanh = dtpngaykhoihanh.Value.Date; // Chỉ lấy ngày (không có giờ)
           
            // Tạo đối tượng DTO với giá trị ngày giờ đã chỉnh sửa
            ChuyenbayDTO updateChuyenBay = new ChuyenbayDTO(
                txtmachuyenbay.Text,
                txttenhang.Text,
                ngayKhoiHanh, // Truyền trực tiếp đối tượng DateTime
                txtdiemdi.Text,
                txtdiemden.Text
              
            );

            // Cập nhật chuyến bay
            if (chuyenBayBLL.UpdateChuyenBay(updateChuyenBay))
            {
                MessageBox.Show("Cập nhật chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataChuyenBay();
            }
            else
            {
                MessageBox.Show("Bạn không được thay đổi Mã chuyến bay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDataChuyenBay();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmachuyenbay.Text))
            {
                MessageBox.Show("Vui lòng chọn chuyến bay để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hộp thoại xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chuyến bay này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maChuyenBay = txtmachuyenbay.Text;

                try
                {
                    // Gọi phương thức xóa từ BLL
                    if (chuyenBayBLL.DeleteChuyenBay(maChuyenBay)) // Truyền mã chuyến bay thay vì đối tượng DTO
                    {
                        MessageBox.Show("Xóa chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataChuyenBay(); // Tải lại danh sách chuyến bay sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa chuyến bay thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
