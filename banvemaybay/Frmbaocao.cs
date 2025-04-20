using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using BLL;
using DTO;
using System.Data;
using banvemaybay.baocaoreponrtingTableAdapters;
using System.Data.SqlClient;
using banvemaybay.GUI;


namespace banvemaybay
{
    public partial class Frmbaocao : Form
    {
   

        public Frmbaocao()
        {
            InitializeComponent();
            
        }

        public void loadatabaocao(object sender, EventArgs e)
        {
          
            VeMayBayTableAdapter vmb = new VeMayBayTableAdapter();
            DataTable vemaybay = vmb.GetData();

            ReportDocument Baocaovemaybay = new ReportDocument();
            Baocaovemaybay.Load("D:\\NguyenLongWK\\Winformc#\\banvemaybay\\banvemaybay\\Baocaovemaybay.rpt");
            Baocaovemaybay.SetDataSource(vemaybay);

            string connectionString = @"Data Source=192.168.60.128;Initial Catalog=QLbanvemaybay;Persist Security Info=True;User ID=sa;Password=Str0ngP@ssw0rd!;Encrypt=True;TrustServerCertificate=True";

            int tongSoVe = 0;
            decimal tongTien = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdSoVe = new SqlCommand("SELECT COUNT(*) FROM VeMayBay WHERE TrangThai = N'Đã đặt'", conn);
                tongSoVe = Convert.ToInt32(cmdSoVe.ExecuteScalar());  

            
                SqlCommand cmdTongTien = new SqlCommand("SELECT SUM(CAST(GiaVe AS DECIMAL(18, 2))) FROM VeMayBay WHERE TrangThai = N'Đã đặt'", conn);
                object result = cmdTongTien.ExecuteScalar();
                tongTien = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                conn.Close();
            }

            Baocaovemaybay.SetParameterValue("TongSoVe", tongSoVe); 
            Baocaovemaybay.SetParameterValue("TongTien", tongTien);

            crystalReportViewer1.ReportSource = Baocaovemaybay;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Main frmmain = new Main();
            frmmain.ShowDialog();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
