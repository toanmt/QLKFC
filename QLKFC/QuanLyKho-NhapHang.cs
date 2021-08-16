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
    public partial class QuanLyNhap : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = 0;
        public QuanLyNhap()
        {
            InitializeComponent();
            load();
        }
        #region Hiển thị và tương tác vs bảng
        public void load()
        {
            db = new QLBHKFCContext();
            var query = db.HoaDonKhos.Where(x => x.TrangThai == "Đang xử lý" || x.TrangThai == "Đang giao hàng");
            dgvNhapHang.Rows.Clear();
            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(), item.NgayCc.ToString(), item.TrangThai.ToString(), "" };
                dgvNhapHang.Rows.Add(hd);
            }
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvNhapHang.Rows.Clear();
            load();
        }
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        } 
        #endregion

        //Chi tiết 1 đơn nhập
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (index > -1 && index < dgvNhapHang.RowCount-1)
            {
                ChiTietPhieuNhap frm = new ChiTietPhieuNhap();
                frm.Tag =int.Parse(dgvNhapHang.Rows[index].Cells[0].Value.ToString());
                frm.ShowDialog();
                this.Refresh();
                load();

            }
            else
                MessageBox.Show("Chưa chọn hóa đơn !");
        }
        //Gọi thêm hàng vào kho
        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.ShowDialog();
            dgvNhapHang.Rows.Clear();
            load();
        }
        //Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var query = db.HoaDonKhos.Where(x => x.MaHdk.ToString().Contains(txtTimKiem.Text) || x.TrangThai.Contains(txtTimKiem.Text));
            dgvNhapHang.Rows.Clear();
            foreach (var item in query.ToList())
            {
                string[] hd = { item.MaHdk.ToString(), item.NgayCc.ToString(), item.TrangThai.ToString(), "" };
                dgvNhapHang.Rows.Add(hd);
            }
        }

        
    }
}
