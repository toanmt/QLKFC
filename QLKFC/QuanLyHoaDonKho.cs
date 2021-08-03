using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKFC
{
    public partial class QuanLyHoaDonKho : Form
    {
        public QuanLyHoaDonKho()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.ShowDialog();
        }
    }
}
