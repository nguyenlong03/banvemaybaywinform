using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using banvemaybay.GUI;
using BLL;
using DTO;

namespace banvemaybay
{
    public partial class Timkiemve : Form
    {
        private VemaybayBLL vemaybayBLL = new VemaybayBLL();
        public Timkiemve()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main fommani = new Main();
            fommani.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Timkiemve_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            List<VemaybayDTO> vemaybayList = vemaybayBLL.GetAllVemaybay();
            datagridviewtimliem.DataSource = vemaybayList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenHanhKhach = txttenhanhkhachtimkiem.Text.Trim().ToLower();
            string maChuyenBay = txtmachuyenbaytimkiem.Text.Trim().ToLower();

            // Lấy lại danh sách ban đầu (hoặc bạn lưu list gốc thành biến toàn cục)
            List<VemaybayDTO> danhSach = vemaybayBLL.GetAllVemaybay();

            // Tìm kiếm các dòng phù hợp
            var ketQuaTimKiem = danhSach
                .Where(ve => (string.IsNullOrEmpty(tenHanhKhach) || ve.TenHanhKhach.ToLower().Contains(tenHanhKhach)) &&
                             (string.IsNullOrEmpty(maChuyenBay) || ve.MaChuyenBay.ToLower().Contains(maChuyenBay)))
                .ToList();

            // Tách kết quả phù hợp và không phù hợp
            var khongPhuHop = danhSach.Except(ketQuaTimKiem).ToList();

            // Gộp kết quả: kết quả tìm được lên đầu
            var danhSachHienThi = ketQuaTimKiem.Concat(khongPhuHop).ToList();

            // Hiển thị lại lên DataGridView
            datagridviewtimliem.DataSource = null;
            datagridviewtimliem.DataSource = danhSachHienThi;

            // Tô màu đỏ cho các dòng khớp điều kiện
            foreach (DataGridViewRow row in datagridviewtimliem.Rows)
            {
                string ten = row.Cells["TenHanhKhach"].Value.ToString().ToLower();
                string ma = row.Cells["MaChuyenBay"].Value.ToString().ToLower();

                if ((!string.IsNullOrEmpty(tenHanhKhach) && ten.Contains(tenHanhKhach)) ||
                    (!string.IsNullOrEmpty(maChuyenBay) && ma.Contains(maChuyenBay)))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
