using Microsoft.EntityFrameworkCore;
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
    public partial class QuanLyNhap : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = 0;
        public QuanLyNhap()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            dgvNhapHang.Rows.Clear();
            var query = db.HoaDonKhos.Where(x => x.TrangThai == "Đang xử lý");
           
            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(),item.NgayCc.ToString(), item.TrangThai.ToString(),""};
                            dgvNhapHang.Rows.Add(hd);
            }
        }
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }


        private void btnChiTiet_Click(object sender, EventArgs e)
        {

            if (index > -1)
            {
                ChiTietPhieuNhap frm = new ChiTietPhieuNhap();
                frm.Tag =int.Parse(dgvNhapHang.Rows[index].Cells[0].Value.ToString());
                frm.Show();
            }
            else
                MessageBox.Show("Chưa chọn hóa đơn !");
        }

        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.ShowDialog();
            load();
        }
    }
}
