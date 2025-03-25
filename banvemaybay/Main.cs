using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banvemaybay.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLhanhkhach formQLhanhkhach = new QLhanhkhach();
            formQLhanhkhach.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLchuyenbay formQLchuyenbay = new QLchuyenbay();
            formQLchuyenbay.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLdatve formdatve = new QLdatve();
            formdatve.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QLbaocao formbaocao = new QLbaocao();
            formbaocao.Show();
            this.Hide();
        }
    }
}
