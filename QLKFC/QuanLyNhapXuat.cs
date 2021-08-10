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
        int index = 0;
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
                string[] hd = { item.MaHdk.ToString(),item.NgayCc.ToString(), item.TrangThai.ToString(),""};
                            dgvNhapHang.Rows.Add(hd);
            }
        }
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            string MaHDK = dgvNhapHang.Rows[index].Cells[0].Value.ToString();
            var query = db.CthoaDonKhos.Where(x => x.MaHdk.ToString() == MaHDK);
            List<CthoaDonKho> listhdk = new List<CthoaDonKho>();
            listhdk = query.ToList();
            var queryKho = db.Khos.Select(x => x);
            foreach (var item in listhdk)
            {
                foreach (var itemKho in queryKho)
                {
                    if (item.MaNl == itemKho.MaNl)
                        itemKho.SoLuong += item.SoLuong;
                }
            }

            db.HoaDonKhos.Where(x => x.MaHdk.ToString() == MaHDK).FirstOrDefault().TrangThai = "Hoàn Thành";
            db.SaveChanges();
            load();


        }

       
    }
}
