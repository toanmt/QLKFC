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
    public partial class QuanLyNhapXuat : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyNhapXuat()
        {
            InitializeComponent();
            load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.ShowDialog();
            load();

        }
        public void load()
        {
            var query = db.HoaDonKhos.Where(x => x.TrangThai == "Đang xử lý");
            dgvNhapHang.DataSource = query.ToList();
            dgvNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhapHang.Columns[0].HeaderText = "Mã hóa đơn";
            dgvNhapHang.Columns[1].HeaderText = "Ngày tạo";
            dgvNhapHang.Columns[2].HeaderText = "Trạng thái";

        }
    }
}
