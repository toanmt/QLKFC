﻿using Microsoft.EntityFrameworkCore;
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
        int index = 0;
        public QuanLyHoaDonKho()
        {
            InitializeComponent();
            load();
        }
        //Clear datagridview
        public void clear()
        {
            dgvChiTietHoaDonKho.Rows.Clear();
            dgvHoaDonKho.Rows.Clear();
        }
        //Load dữ liệu
        public void load()
        {
            var query = db.HoaDonKhos.Select(x=>x).OrderByDescending(x=>x.NgayCc);

            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(), item.NgayCc.ToString(), item.TrangThai.ToString() };
                dgvHoaDonKho.Rows.Add(hd);
            }
        }
        //Tương tác với bảng hóa đơn kho
        private void dgvHoaDonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvChiTietHoaDonKho.Rows.Clear();
            index = e.RowIndex;
            if (index > -1 && index < dgvHoaDonKho.Rows.Count - 1)
            {
                float tg = 0;
                int check = int.Parse(dgvHoaDonKho.Rows[index].Cells[0].Value.ToString());
                var querycthd = db.CthoaDonKhos.Include(x=>x.MaNlNavigation).Where(x => x.MaHdk == check);
                foreach (var item in querycthd.ToList())
                {
                    string tongtien = string.Format("{0:#,##0}", ((float)item.SoLuong * (float)item.MaNlNavigation.DonGia));
                    string[] cthd = { item.MaNlNavigation.TenNl.ToString(), item.SoLuong.ToString(), string.Format("{0:#,##0}", item.MaNlNavigation.DonGia), tongtien};
                    dgvChiTietHoaDonKho.Rows.Add(cthd);
                    tg += float.Parse(tongtien);
                }
                string[] row = { "", "", "Tổng tiền", string.Format("{0:#,##0}", tg) };
                dgvChiTietHoaDonKho.Rows.Add(row);
                lblMaHoaDon.Text = check.ToString() ;
            }
        }

        //Thống kê theo ngày
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonKho.Rows.Count > 0)
                clear();
            var query = from k in db.HoaDonKhos
                        where k.NgayCc >= dtpick1.Value && k.NgayCc <= dtpick2.Value
                        select new
                         {
                             k.MaHdk,
                             k.NgayCc,
                             k.TrangThai,
                         };
            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(), item.NgayCc.ToString(), item.TrangThai.ToString() };
                dgvHoaDonKho.Rows.Add(hd);
            }
        }

        //Tìm kiếm theo Mã hoặc Trạng thái của hóa đơn
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonKho.Rows.Count > 0)
                clear();
            var query = db.HoaDonKhos.Where(x => x.MaHdk.ToString().Contains(txtTimKiem.Text));
            if (query.ToList().Count == 0)
                query = db.HoaDonKhos.Where(x => x.TrangThai.Contains(txtTimKiem.Text));
            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(), item.NgayCc.ToString(), item.TrangThai.ToString() };
                dgvHoaDonKho.Rows.Add(hd);
            }


        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                ChiTietPhieuNhap frm = new ChiTietPhieuNhap();
                frm.Tag = int.Parse(dgvHoaDonKho.Rows[index].Cells[0].Value.ToString());
                frm.ShowDialog();
                dgvHoaDonKho.Rows.Clear();
                load();
            }
            else
                MessageBox.Show("Chưa chọn hóa đơn !");
        }
    }
}
