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
    public partial class QuanLyKho : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyKho()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            var query = from k in db.Khos
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            dgvKho.DataSource = query.ToList();
            dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKho.Columns[0].HeaderText = "Mã nguyên liệu";
            dgvKho.Columns[1].HeaderText = "Tên nguyên liệu";
            dgvKho.Columns[2].HeaderText = "Đơn giá";
            dgvKho.Columns[3].HeaderText = "Số lượng";
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > -1)
            {
                cbMaNL.Text = dgvKho.Rows[index].Cells[0].Value.ToString();
                txtTenNL.Text = dgvKho.Rows[index].Cells[1].Value.ToString();
                txtDonGia.Text = dgvKho.Rows[index].Cells[2].Value.ToString();
                txtSoLuong.Text = dgvKho.Rows[index].Cells[3].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                Kho NLSua = db.Khos.SingleOrDefault(k => k.MaNl == int.Parse(cbMaNL.Text));

                NLSua.SoLuong = int.Parse(txtSoLuong.Text);
                db.SaveChanges();

                load();


        }
    }
}
