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
    public partial class QuanLyHoaDon : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyHoaDon()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            var query = from h in db.HoaDons
                        select new
                        {
                            h.MaHd,
                            h.TenNv,
                            h.StoreId,
                            h.Pos,
                            h.NgayThang,         
                        };
            dgvHDBH.DataSource = query.ToList();
            dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHDBH.Columns[1].HeaderText = "Nhân viên";
            dgvHDBH.Columns[2].HeaderText = "Store ID";
            dgvHDBH.Columns[3].HeaderText = "Pos";
            dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dgvHDBH.SelectedRows.Count;
            ChiTietHoaDonBanHang frm = new ChiTietHoaDonBanHang();
            frm.Tag = (int)dgvHDBH.Rows[index].Cells[0].Value;
            
            frm.Show();
            
        }
    }
}
