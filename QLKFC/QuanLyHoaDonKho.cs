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
    public partial class Quản_lý_hóa_đơn_kho : Form
    {
        public Quản_lý_hóa_đơn_kho()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Nhập_Hàng frm = new Nhập_Hàng();
            frm.ShowDialog();
        }
    }
}
