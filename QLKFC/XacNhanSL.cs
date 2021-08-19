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

        private void thucThi()
        {
            if (txtSL.Text != "")
            {
                try
                {
                    if (int.Parse(txtSL.Text) < 1)
                    {
                        MessageBox.Show("Không được nhập số lượng âm!");
                    }
                    else
                    {
                        soluong = int.Parse(txtSL.Text);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtSL, "Bạn phải nhập số lượng là số!");
                }
            }
            else
            {
                errorProvider1.SetError(txtSL, "Bạn phải nhập số lượng!");
                txtSL.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            thucThi();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                thucThi();
        }
    }
}
