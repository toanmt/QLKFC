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
            var getma = (from s in db.NguyenLieus
                        where s.TenNl == cbNguyenLieu.Text
                        select s.MaNl).SingleOrDefault();
            for (int i = 0; i < dgvNhapHang.Rows.Count - 1; i++)
                if (getma.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }

                string[] row = { getma.ToString(), cbNguyenLieu.Text, txtdongia.Text, txtSoLuong.Text };
                dgvNhapHang.Rows.Add(row); 
        }

        private void cbNguyenLieu_SelectedValueChanged(object sender, EventArgs e)
        {
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = dgvNhapHang.SelectedRows.Count;
            dgvNhapHang.Rows.RemoveAt(index);
        }

        private void btnGuiDi_Click(object sender, EventArgs e)
        {
            int check = dgvNhapHang.Rows.Count;

        }
    }
}
