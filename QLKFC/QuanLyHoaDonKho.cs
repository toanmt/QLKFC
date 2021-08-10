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
    public partial class QuanLyHoaDonKho : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyHoaDonKho()
        {
            InitializeComponent();
            load();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.ShowDialog();
        }
        public void load()
        {
            float tongtien = 0;
            var query = db.HoaDonKhos.Select(x=>x);

            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(), item.NgayCc.ToString(), item.TrangThai.ToString() };
                dgvHoaDonKho.Rows.Add(hd);
            }
        }



        private void dgvHoaDonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvChiTietHoaDonKho.Rows.Clear();
            int index = e.RowIndex;
            if (index > -1 && index < dgvHoaDonKho.Rows.Count - 1)
            {
                float tg = 0;
                int check = int.Parse(dgvHoaDonKho.Rows[index].Cells[0].Value.ToString());
                var querycthd = db.CthoaDonKhos.Include(x=>x.MaNlNavigation).Where(x => x.MaHdk == check);
                foreach (var item in querycthd.ToList())
                {
                    string tongtien = string.Format("{0:#,##0}", ((float)item.SoLuong * (float)item.MaNlNavigation.DonGia));
                    string[] cthd = { item.MaNlNavigation.TenNl.ToString(), item.SoLuong.ToString(), item.MaNlNavigation.DonGia.ToString(), tongtien};
                    dgvChiTietHoaDonKho.Rows.Add(cthd);
                    tg += float.Parse(tongtien);
                }
                string[] row = { "", "", "Tổng tiền", string.Format("{0:#,##0}", tg) };
                dgvChiTietHoaDonKho.Rows.Add(row);


            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var query = from k in db.HoaDonKhos
                        where k.NgayCc >= dtpick1.Value && k.NgayCc <= dtpick2.Value
                        select new
                         {
                             k.MaHdk,
                             k.NgayCc,
                             k.TrangThai,
                         };
            dgvHoaDonKho.DataSource = query.ToList();
            dgvHoaDonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDonKho.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHoaDonKho.Columns[1].HeaderText = "Ngày Tạo";
            dgvHoaDonKho.Columns[2].HeaderText = "Trạng Thái";
        }
    }
}
