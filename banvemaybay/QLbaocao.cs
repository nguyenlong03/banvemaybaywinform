using System;
using System.Collections.Generic;
using System.Windows.Forms;
using banvemaybay.GUI;
using BLL;
using DTO;

namespace banvemaybay
{
    public partial class QLbaocao : Form
    {
        private VemaybayBLL vemaybayBLL = new VemaybayBLL();
        public QLbaocao()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal tongTien = vemaybayBLL.TinhTongTienVeDaBan();
            txtsotienbanduoc.Text = tongTien.ToString("N0") + " VNĐ"; // Hiển thị có định dạng tiền
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void QLbaocao_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            List<VemaybayDTO> vemaybayList = vemaybayBLL.GetAllVemaybay();
            dataGridViewbaocao.DataSource = vemaybayList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soVe = vemaybayBLL.DemSoVeDaDat();
            txttongsovebanduoc.Text = soVe.ToString();
        }
    }
}
