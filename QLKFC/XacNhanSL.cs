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
    public partial class XacNhanSL : Form
    {
        public XacNhanSL()
        {
            InitializeComponent();
        }

        public int soluong { get; set; }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSL.Text != "")
            {
                soluong = int.Parse(txtSL.Text);
                this.Close();
            }
            else
            {
                errorProvider1.SetError(txtSL, "Bạn phải nhập tên số lượng!");
                txtSL.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
