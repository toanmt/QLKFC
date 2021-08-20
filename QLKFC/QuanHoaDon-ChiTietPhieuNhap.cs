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
    public partial class ChiTietPhieuNhap : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int Mahdk = 0;
        string TrangThai = "";
        public string Message { get; set; }

        public ChiTietPhieuNhap()
        {
            InitializeComponent();

        }
        //Load dữ liệu
        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            
            lblNote.Hide();
            int check = (int)this.Tag;
            Mahdk = check;
            lblMaDonHang.Text = check.ToString();
            var getHDK = db.HoaDonKhos.Where(x => x.MaHdk == check).SingleOrDefault();
            datetimpick.Value = getHDK.NgayCc.Value;
            TrangThai = getHDK.TrangThai;
            cbTrangThai.Text = TrangThai;
            if (TrangThai.Trim().Equals("Hoàn Thành"))
            {
                btnHuyDonDatHang.Hide();
                btnNhapKho.Hide();
                btnHoanThanh.Hide();
                lblNote.Show();
                lblNote.Text = "Đơn hàng đã hoàn thành.Nhập kho thành công";
            }
            else if (TrangThai.Trim().Equals("Đã hủy"))
            {
                btnHuyDonDatHang.Hide();
                btnNhapKho.Hide();
                lblNote.Show();
                lblNote.Text = "Đơn hàng đã bị hủy";
            }


            var query = from k in db.CthoaDonKhos
                        where k.MaHdk == check
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            //chk.Name = "Đã đủ hàng";
            //chk.HeaderText = "Đã đủ hàng";
            //chk.ReadOnly = false;
            foreach (var item in query)
            {
                var tongtien = item.DonGia.Value * item.SoLuong.Value;
                string[] row = { item.TenNl.ToString(), string.Format("{0:#,##0}", int.Parse(item.DonGia.ToString())), item.SoLuong.ToString(), string.Format("{0:#,##0}", int.Parse(tongtien.ToString())) };
                dgvNhapHang.Rows.Add(row);
                
            }
            //dgvNhapHang.Columns.Insert(4, chk);


        }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            int check = (int)this.Tag;
            int checkNew = 1;
            var query = db.CthoaDonKhos.Where(x => x.MaHdk == check);
            List<CthoaDonKho> listhdk = new List<CthoaDonKho>();
            List<Kho> listnlMoi = new List<Kho>();
            listhdk = query.ToList();
            var queryKho = db.Khos.Select(x => x);
            foreach (var item in listhdk)
            {
                checkNew = 1;
                foreach (var itemKho in queryKho)
                {
                    if (item.MaNl == itemKho.MaNl )
                    {
                        itemKho.SoLuong += item.SoLuong;
                        checkNew = 0;
                    }
                }
                if (checkNew == 1)
                {
                    Kho nl = new Kho();
                    nl.MaNl = item.MaNl;
                    nl.SoLuong = item.SoLuong;
                    listnlMoi.Add(nl);
                }

            }
            if (listnlMoi.Count > 0)
                foreach (var item in listnlMoi)
                {
                    db.Khos.Add(item);
                }
            db.HoaDonKhos.Where(x => x.MaHdk == check).FirstOrDefault().TrangThai = "Hoàn Thành";
            checkSoLuong();
            DialogResult dl = MessageBox.Show("Nhập hàng vào kho", "Xác nhận đã giao hàng", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                this.Close();
                MessageBox.Show("Nhập hàng thành công. Kiểm tra kho hàng của bạn");
                this.Message = "Change";
                db.SaveChanges();
            }

        }
        public void checkSoLuong()
        {
            for (int i = 0; i < dgvNhapHang.Rows.Count; i++)
            {

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cập nhập trạng thái
        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (cbTrangThai.Text == "Đang giao hàng")
            {
                db.HoaDonKhos.Where(x => x.MaHdk == Mahdk).SingleOrDefault().TrangThai = cbTrangThai.Text;
                db.SaveChanges();
                MessageBox.Show("Cập nhập trạng thái thành công !");
                this.Message = "Change";
                dgvNhapHang.Rows.Clear();
                load();
            }
            else
                MessageBox.Show("Không có gì thay đổi !!!");
        }

        //Hủy đơn hàng
        private void btnHuyDonDatHang_Click(object sender, EventArgs e)
        {
            if (TrangThai.Trim().Equals("Đang giao hàng"))
                MessageBox.Show("Đơn hàng đang được giao. Vui lòng liên hệ bếp trung tâm!");
            else
            {

                DialogResult dl = MessageBox.Show("Bạn có muổn hủy đơn hàng hiện tại", "Hủy đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl == DialogResult.Yes)
                {
                    var check = db.HoaDonKhos.Where(x => x.MaHdk == Mahdk).SingleOrDefault();
                    check.TrangThai = "Đã hủy";
                    MessageBox.Show("Hủy đơn hàng thành công. Bếp trung tâm sẽ liên hệ với bạn!");
                    db.SaveChanges();
                    this.Close();
                }
            }
        }

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //for(int i=0;i<dgvNhapHang.Rows.Count;i++)
            //{
            //    if((bool)dgvNhapHang.Rows[i].Cells[4].Value == true)
            //        dgvNhapHang.Rows[i].Cells[4].Value = "Đủ hàng";
            //}    
        }
    }
}
