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
            float tongtien = 0;
            var querycthdk = db.CthoaDonKhos.Include(x=>x.MaHdkNavigation).Include(x=>x.MaNlNavigation).Where(x => x.MaHdkNavigation.TrangThai == "Đang xử lý");

            foreach (var item in querycthdk.ToList())
            {
                tongtien += (float)item.SoLuong * (float)item.MaNlNavigation.DonGia;
                string[] hd = { item.MaHdk.ToString(), item.MaHdkNavigation.NgayCc.ToString(), string.Format("{0:#,##0}", tongtien), item.MaHdkNavigation.TrangThai.ToString() };
                dgvNhapHang.Rows.Add(hd);
            }
        }
    }
}
