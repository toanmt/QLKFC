using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKFC.Models;

namespace QLKFC
{
    public partial class Order : Form
    {
        //Khai báo biến
        QLBHKFCContext db = new QLBHKFCContext();
        string Pos, Storeid, Tennv;
        int maHD;
        public Order()
        {
            InitializeComponent();
        }
        public Order(string storeid, string pos, string tennv)
        {
            InitializeComponent();
            this.Pos = pos;
            this.Storeid = storeid;
            this.Tennv = tennv;
            loadDGVSP();
        }

        #region Khai báo hàm
        private string pathImage()
        {
            //Lấy đường dẫn thư mục lưu ảnh
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }

        private void loadDGVSP()
        {
            var query = from sp in db.SanPhams 
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.DonGia,
                            sp.Loai,
                            sp.HinhAnh
                        };
            foreach (var item in query)
            {
                if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.Loai, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.Loai);
            }
            dgv_DSSP.Columns["dg"].DefaultCellStyle.Format = "N0";
        }

        private void locDL(string loc)
        {
            dgv_DSSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSanPhams on sp.MaLsp equals lsp.MaLsp
                        where lsp.TenLsp.Contains(loc)
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.DonGia,
                            sp.Loai,
                            sp.HinhAnh
                        };
            foreach (var item in query)
            {
                if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.Loai, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.Loai);
            }
            dgv_DSSP.Columns["dg"].DefaultCellStyle.Format = "N0";
        }

        private void TinhTien()
        {
            float tt = 0;
            for (int i = 0; i < dgvDSOrder.RowCount; i++)
            {
                tt += float.Parse(dgvDSOrder.Rows[i].Cells[4].Value.ToString());
            }
            lblThanhTien.Text = string.Format("{0:N0}", tt);
        }

        private void Don()
        {
            dgvDSOrder.Rows.Clear();
            lblThanhTien.Text = 0 + "";
            txtDua.Clear();
            lblTienThua.Text = 0 + "";
        }
        #endregion

        #region Tương tác người dùng
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dgvDSOrder.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvDSOrder.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            if (e.RowIndex != -1)
            {
                string masp = dgv_DSSP.Rows[e.RowIndex].Cells[0].Value.ToString();
                string tensp = dgv_DSSP.Rows[e.RowIndex].Cells[1].Value.ToString();
                string dongia = dgv_DSSP.Rows[e.RowIndex].Cells[2].Value.ToString();
                using (XacNhanSL xn = new XacNhanSL())
                {
                    if (xn.ShowDialog() == DialogResult.OK)
                    {
                        int check = 0;
                        if (dgvDSOrder.RowCount > 0)
                        {
                            for (int i = 0; i < dgvDSOrder.RowCount; i++)
                            {
                                var rowss = dgvDSOrder.Rows[i];
                                if (rowss.Cells[1].Value.ToString() == tensp
                                    && rowss.Cells[2].Value.ToString() == dongia)
                                {
                                    int sl = xn.soluong + int.Parse(rowss.Cells[3].Value.ToString());
                                    if (sl < 1)
                                    {
                                        dgvDSOrder.Rows.RemoveAt(i);
                                    }
                                    else
                                    {
                                        rowss.Cells[3].Value = sl;
                                        rowss.Cells[4].Value = sl * float.Parse(dongia);
                                    }
                                    check++;
                                }
                            }
                        }
                        else if (xn.soluong < 0)
                        {
                            MessageBox.Show("Chưa tồn tại sản phẩm này chưa không được nhập số lượng âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (check == 0)
                        {
                            dgvDSOrder.Rows.Add(masp, tensp, dongia, xn.soluong, float.Parse(dongia) * xn.soluong);
                        }
                    }
                }
            }
            TinhTien();
        }

        private void dgvDSOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSOrder.Columns[e.ColumnIndex].Name=="Xoa")
            {
                if(MessageBox.Show("Xóa sản phẩm này?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                    ==DialogResult.Yes)
                {
                    dgvDSOrder.Rows.RemoveAt(e.RowIndex);
                    TinhTien();
                }    
            }
        }

        #region Lọc bảng sản phẩm
        private void btnChonComBo_Click(object sender, EventArgs e)
        {
            locDL("Combo");
        }

        private void btnChonMonLe_Click(object sender, EventArgs e)
        {
            locDL("Đồ ăn");
        }

        private void btnChonDoUong_Click(object sender, EventArgs e)
        {
            locDL("Đồ uống");
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            dgv_DSSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        where sp.TenSp.Contains(txtFind.Text)
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.DonGia,
                            sp.Loai,
                            sp.HinhAnh
                        };
            foreach (var item in query)
            {
                if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.Loai, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.Loai);
            }
            dgv_DSSP.Columns["dg"].DefaultCellStyle.Format = "N0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDGVSP();
            txtFind.Clear();
        }
        #endregion

        #region Sự kiện khi nhấn nút Thanh toán
        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Lấy độ rong của giấy
            var chieurong = pdHoaDon.DefaultPageSettings.PaperSize.Width;

            //Khai báo biến tọa độ
            float vtdong = 10;


            // Khai báo định dạng kiểu căn giữa
            StringFormat formatCenter = new StringFormat(StringFormatFlags.NoClip);
            formatCenter.Alignment = StringAlignment.Center;

            //Tạo khung nhập liệu
            SizeF layoutSize = new SizeF(chieurong - vtdong * 2, 10);

            #region Tạo header
            e.Graphics.DrawString("PHIEU TINH TIEN",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Cty LD TNHH KFC Viet Nam",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("292 Ba Trieu, Hai Ba Trung, HN",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("01 00773885",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("KFC BIG C HA NOI",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("222 Tran Duy Hung, Trung Hoa, CG",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            #endregion

            //Lấy dữ liệu hóa đơn
            var hoadonin = db.HoaDons.SingleOrDefault(hd => hd.MaHd == maHD);

            #region StoreID
            vtdong += 30;
            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 40;
            e.Graphics.DrawString("STOREID:  "+hoadonin.StoreId,
                                new Font("Courier New", 24, FontStyle.Bold),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 40;
            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            #endregion

            #region Máy pos và tên nhân viên

            vtdong += 30;
            e.Graphics.DrawString(
                                hoadonin.Pos + "    POS" + hoadonin.Pos,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong)
                                );

            e.Graphics.DrawString(
                                hoadonin.TenNv,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 220, vtdong)
                                );
            vtdong += 30;

            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            #endregion

            #region Mã hóa đơn và thời gian
            vtdong += 30;
            e.Graphics.DrawString("Chk  " + maHD,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            vtdong += 30;
            e.Graphics.DrawString(String.Format("\t\t {0}", ((DateTime)hoadonin.NgayThang).ToString("dd/MM/yyyy HH:mm:ss")),
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            vtdong += 30;

            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            #endregion

            #region Lấy dữ liệu danh sách sản phẩm mua
            var dsmua = from ct in db.CthoaDons.Where(x => x.MaHd == maHD)
                        join sp in db.SanPhams on ct.MaSp equals sp.MaSp
                        select new
                        {
                            ct.MaSp,
                            ct.SoLuong,
                            sp.TenSp,
                            sp.DonGia
                        };
            #endregion

            #region Danh sách sản phẩm mua
            vtdong += 30;
            foreach (var item in dsmua)
            {
                e.Graphics.DrawString(item.SoLuong + "\t",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(0, vtdong));
                e.Graphics.DrawString(item.TenSp,
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(35, vtdong));
                e.Graphics.DrawString(string.Format("{0:N0}", item.DonGia),
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(chieurong - 150, vtdong));
                vtdong += 30;
            }
            #endregion

            #region Thông tin Thanh toán
            e.Graphics.DrawString("Cash",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            e.Graphics.DrawString(string.Format("{0:N0}", Double.Parse(txtDua.Text)),
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Sub Total",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            e.Graphics.DrawString(lblThanhTien.Text,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Total: ",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            e.Graphics.DrawString(lblThanhTien.Text,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Payment: ",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            e.Graphics.DrawString(string.Format("{0:N0}", Double.Parse(txtDua.Text)),
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Change Due: ",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(0, vtdong));
            e.Graphics.DrawString(lblTienThua.Text,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            #endregion

            #region footer
            e.Graphics.DrawString(String.Format("---- CLOSE  {0} ", DateTime.Now.ToString("dd / MM / yyyy HH: mm: ss")) + "  -----",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Tham gia khao sat va nhan qua tai:  www.talk2kfcvietnam.com",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Ma doi thuong:..........................",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Thoi gian tham gia doi thuong la 7 ngay ke tu ngay mua hang.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Co gia tri doi thuong trong vong 15 ngay ke tu ngay mua hang.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Khao sat chi ap dung cho hoa don co gia tri tu 70.000 tro len.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Quy khach can hoa don tai chinh de nghi lay ngay khi mua hang.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Thank you!",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);

            #endregion
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDSOrder.RowCount == 0)
            {
                MessageBox.Show("Hóa đơn trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDua.Text == "")
            {
                MessageBox.Show("Chưa nhập tiền đưa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                HoaDon hd = new HoaDon();
                hd.TenNv = Tennv;
                hd.StoreId = Storeid;
                hd.Pos = Pos;
                DateTime tg = DateTime.Now;
                hd.NgayThang = tg;
                db.HoaDons.Add(hd);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CthoaDon cthd = new CthoaDon();
                maHD = db.HoaDons.SingleOrDefault(hdm => hdm.NgayThang == tg).MaHd;
                cthd.MaHd = maHD;
                for (int i = 0; i < dgvDSOrder.RowCount; i++)
                {
                    cthd.MaSp = int.Parse(dgvDSOrder.Rows[i].Cells[0].Value.ToString());
                    cthd.SoLuong = int.Parse(dgvDSOrder.Rows[i].Cells[3].Value.ToString());
                    db.CthoaDons.Add(cthd);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ppdHoaDon.ShowDialog();
                Don();
            }
        }

        private void txtDua_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || double.Parse(txtDua.Text) > double.Parse(lblThanhTien.Text))
                {
                    errorProvider_TD.Clear();
                    lblTienThua.Text = string.Format("{0:N0}", (float.Parse(txtDua.Text) - float.Parse(lblThanhTien.Text)));
                }
                if (double.Parse(lblTienThua.Text) < 0)
                {
                    errorProvider_TD.SetError(txtDua, "Tiền đưa phải lớn hơn tổng tiền!");
                    txtDua.Focus();
                    txtDua.SelectAll();
                    lblTienThua.Text = 0 + "";
                }
            }
            catch (Exception)
            {
                errorProvider_TD.SetError(txtDua, "Bạn phải nhập đơn giá là số !");
            }
        }
        #endregion

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Don();
        }
        #endregion
    }
}
