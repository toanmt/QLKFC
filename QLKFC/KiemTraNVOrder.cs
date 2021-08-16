using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKFC.Models;

namespace QLKFC
{
    public partial class KiemTraNVOrder : Form
    {
        public KiemTraNVOrder()
        {
            InitializeComponent();
            cmbPOS.Focus();
        }
        QLBHKFCContext db = new QLBHKFCContext();
        public string storeid{ get; set; }
        public string tennv{ get; set; }
        public string pos{ get; set; }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            var query = from nv in db.NhanViens
                        where nv.TenNv.Equals(txtTenNV.Text)
                        select nv;
            if (cmbPOS.SelectedItem == null)
            {
                errorProvider1.SetError(cmbPOS, "Bạn chưa nhập máy POS!");
                cmbPOS.Focus();
            }
            else if (query.Count() == 0)
            {
                errorProvider1.SetError(txtTenNV, "Bạn đã nhập sai tên!");
            }
            else
            {
                errorProvider1.Dispose();
                btnVao.DialogResult = DialogResult.OK;
                storeid = txtStoreID.Text;
                tennv = txtTenNV.Text;
                pos = cmbPOS.SelectedItem.ToString();
            }
        }

        private void txtTenNV_Click(object sender, EventArgs e)
        {
            if (cmbPOS.SelectedItem == null)
            {
                errorProvider1.SetError(cmbPOS, "Bạn chưa nhập máy POS!");
                cmbPOS.Focus();
            }
        }
    }
}
