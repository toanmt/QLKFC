﻿using QLKFC.Models;
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
        int index;
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

        private void dgvHDBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        { 
            ChiTietHoaDonBanHang frm = new ChiTietHoaDonBanHang();
            frm.Tag = (int)dgvHDBH.Rows[index].Cells[0].Value;
            frm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var query = from h in db.HoaDons
                        where h.NgayThang >= dtpick1.Value && h.NgayThang <= dtpick2.Value
                        select new
                        {
                            h.MaHd,
                            h.TenNv,
                            h.StoreId,
                            h.Pos,
                            h.NgayThang,
                        };
            dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHDBH.Columns[1].HeaderText = "Nhân viên";
            dgvHDBH.Columns[2].HeaderText = "Store ID";
            dgvHDBH.Columns[3].HeaderText = "Pos";
            dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
            dgvHDBH.DataSource = query.ToList();
        }
    }
}
