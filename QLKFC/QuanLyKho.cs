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
    public partial class QuanLyKho : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        string TenNV;
        public QuanLyKho(String TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
            load();
        }
        #region Tương tác dữ liệu
        public void load()
        {
            var query = from k in db.Khos
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            dgvKho.DataSource = query.ToList();
            dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKho.Columns[0].HeaderText = "Mã nguyên liệu";
            dgvKho.Columns[1].HeaderText = "Tên nguyên liệu";
            dgvKho.Columns[2].HeaderText = "Đơn giá";
            dgvKho.Columns[3].HeaderText = "Số lượng";
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > -1)
            {
                cbMaNL.Text = dgvKho.Rows[index].Cells[0].Value.ToString();
                txtTenNL.Text = dgvKho.Rows[index].Cells[1].Value.ToString();
                txtDonGia.Text = dgvKho.Rows[index].Cells[2].Value.ToString();
                txtSoLuong.Text = dgvKho.Rows[index].Cells[3].Value.ToString();
            }
        } 
        #endregion

        //Sửa số lượng 
        private void btnSua_Click(object sender, EventArgs e)
        {       
                XacNhanHuyHang xnhh = new XacNhanHuyHang(this.TenNV);
            xnhh.ShowDialog();
            load();
            
        }

        //Tìm kiếm Theo 3 tiêu chí : Mã => Tên => Số lượng
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var query = from k in db.Khos
                        where k.MaNl.ToString().Contains(txtTimKiem.Text)
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            if (query.ToList().Count == 0)
                query = from k in db.Khos
                        where k.MaNlNavigation.TenNl.Contains(txtTimKiem.Text)
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            if (query.ToList().Count == 0)
                query = from k in db.Khos
                        where k.SoLuong.Value.ToString().Contains(txtTimKiem.Text)
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            dgvKho.DataSource = query.ToList();
            dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKho.Columns[0].HeaderText = "Mã nguyên liệu";
            dgvKho.Columns[1].HeaderText = "Tên nguyên liệu";
            dgvKho.Columns[2].HeaderText = "Đơn giá";
            dgvKho.Columns[3].HeaderText = "Số lượng";

        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            XacNhanXuatKho frm = new XacNhanXuatKho(this.TenNV);
            frm.ShowDialog();
            load();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            load();
        }
        public void checkNLNew()
        {
            var queryNL = db.NguyenLieus.Select(x => x);
            var queryKho = db.Khos.Select(x => x);

        }
    }
}
