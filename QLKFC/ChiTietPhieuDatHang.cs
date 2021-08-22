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
    public partial class ChiTietPhieuDatHang : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int Mahdk = 0;
        string TrangThai = "";
        string TenNV = "";
        public string Message { get; set; }

        public ChiTietPhieuDatHang(string TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
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
                btnHoanThanh.Hide();
                lblNote.Show();
                lblNote.Text = "Đơn hàng đã bị hủy";
            }
            if (TrangThai.Trim().Equals("Đang xử lý"))
            {
                btnHoanThanh.Hide();
            }


            var query = from k in db.CthoaDonKhos
                        where k.MaHdk == check
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong,
                            k.SoLuongDaNhap
                        };
            foreach (var item in query)
            {
                var tongtien = item.DonGia.Value * item.SoLuong.Value;
                string[] row = { item.TenNl.ToString(), string.Format("{0:#,##0}", int.Parse(item.DonGia.ToString())), item.SoLuong.ToString(), string.Format("{0:#,##0}", int.Parse(tongtien.ToString())),item.SoLuongDaNhap.ToString() };
                dgvNhapHang.Rows.Add(row);
                
            }


        }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (cbTrangThai.Text == "Đang xử lý")
                MessageBox.Show("Đang hàng đang được xử lý");
            else
            {
                if (checkSoLuong() == false)
                {
                    int check = (int)this.Tag;
                    XacNhanNhapHang xnnh = new XacNhanNhapHang(check);
                    xnnh.ShowDialog();
                    dgvNhapHang.Rows.Clear();
                    load();
                }
                else
                {
                    DialogResult dl = MessageBox.Show("Đơn hàng đã đủ . Hoàn thành đơn ngay ?", "Hoàn thành", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dl == DialogResult.Yes)
                    {
                        HoanThanh();
                        this.Close();
                    }
                }
            }
        }

        public bool checkSoLuong()
        {
            int check = 0;
            for (int i = 0; i < dgvNhapHang.Rows.Count; i++)
            {
                if (dgvNhapHang.Rows[i].Cells[2].Value.ToString() == dgvNhapHang.Rows[i].Cells[4].Value.ToString())
                    check++;
            }
            if (check == dgvNhapHang.RowCount)
                return true;
            else return false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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
       
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            HoanThanh();
        }
        public void HoanThanh()
        {
            try
            {
                DialogResult dl = MessageBox.Show("Xác nhận đã hoàn thành đơn hàng", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    var query = from x in db.CthoaDonKhos
                                where x.MaHdk == Mahdk
                                select new
                                {
                                    x.MaNlNavigation.TenNl,
                                    x.SoLuong,
                                    x.SoLuongDaNhap
                                };
                    int check = 0;
                    string MoTa = "Đơn hàng thiếu \n";
                    foreach (var item in query)
                    {
                        if (item.SoLuong.Value.Equals(item.SoLuongDaNhap))
                            check++;
                        else
                        {
                            MoTa += item.TenNl + "- Thiếu :" + (item.SoLuong.Value - item.SoLuongDaNhap).ToString()+"\n";
                        }
                    }
                    if (check == query.ToList().Count)
                        MessageBox.Show("Đơn hàng hoàn thành");
                    else
                    {
                        BaoCao bc = new BaoCao();
                        bc.Loai = "Nhập hàng";
                        bc.Mota = MoTa;
                        bc.NgayLap = DateTime.Now;
                        bc.StoreId = "044";
                        bc.TenNv = this.TenNV;
                        db.BaoCaos.Add(bc);
                        MessageBox.Show(MoTa, "Hoàn thành đơn hàng.Kiểm tra kho của bạn");
                    }
                    db.HoaDonKhos.Where(x => x.MaHdk == Mahdk).FirstOrDefault().TrangThai = "Hoàn Thành";
                    db.SaveChanges();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
