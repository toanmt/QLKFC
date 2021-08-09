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
            dgvNhapHang.Rows.Clear();
            float tongtien = 0;
            var query = db.HoaDonKhos.Where(x => x.TrangThai == "Đang xử lý");
           
            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(),item.NgayCc.ToString(), item.TrangThai.ToString() };
                            dgvNhapHang.Rows.Add(hd);
            }
            //var querycthdk = db.CthoaDonKhos.Include(x => x.MaHdkNavigation).Include(x => x.MaNlNavigation).Where(x => x.MaHdkNavigation.TrangThai == "Đang xử lý");

            //for (int i = 0; i < query.ToList().Count; i++)
            //{
            //    tongtien += (float)querycthdk.ToList()[i].SoLuong * (float)querycthdk.ToList()[i].MaNlNavigation.DonGia;
            //    dgvNhapHang.Rows[i].Cells[2].Value = string.Format("{0:#,##0}", tongtien);
            //    tongtien = 0;
            //}
        }
    }
}
