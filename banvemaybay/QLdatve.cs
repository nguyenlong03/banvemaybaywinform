using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace banvemaybay.GUI
{
    public partial class QLdatve : Form
    {
        public QLdatve()
        {
            InitializeComponent();
        }

        private void cbbtrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbtrangthai.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void QLdatve_Load(object sender, EventArgs e)
        {
            cbbtrangthai.SelectedIndex = 0;
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
    }
}
