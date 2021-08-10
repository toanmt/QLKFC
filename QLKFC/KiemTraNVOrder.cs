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
        }
        QLBHKFCContext db = new QLBHKFCContext();
        public string storeid{get;set;}
        public string tennv{get;set;}
        public string pos{get;set;}
        private void btnVao_Click(object sender, EventArgs e)
        {
            var query = from nv in db.NhanViens
                        where nv.TenNv.Equals(txtTenNV.Text)
                        select nv;
            if(query.Count()==0)
            {
                MessageBox.Show("Bạn đã nhập sai tên!","Thông báo");
            }
            else
            {
                btnVao.DialogResult = DialogResult.OK;
                storeid = txtStoreID.Text;
                pos = cmbPOS.SelectedItem.ToString();
                tennv = txtTenNV.Text;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
