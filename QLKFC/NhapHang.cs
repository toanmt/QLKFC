using QLKFC.Models;
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
    public partial class NhapHang : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public NhapHang()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            var query = from x in db.NguyenLieus
                        select x;
            cbNguyenLieu.DataSource = query.ToList();
            cbNguyenLieu.DisplayMember = "TenNL";
            cbNguyenLieu.ValueMember = "DonGia";
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var check = (from s in db.NguyenLieus
                        where s.TenNl == cbNguyenLieu.Text
                        select s.MaNl).SingleOrDefault();
            string[] row = {check.ToString(),cbNguyenLieu.Text,txtSoLuong.Text,txtdongia.Text};
            dgvNhapHang.Rows.Add(row);
        }

        private void cbNguyenLieu_SelectedValueChanged(object sender, EventArgs e)
        {
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
        }
    }
}
