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
        int pageNu = 1, numberRe = 5;
        string locLoai = null;

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
            loadDGVSP(pageNu, numberRe);
        }

        #region Khai báo hàm
        private string pathImage()
        {
            //Lấy đường dẫn thư mục lưu ảnh
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }

        private void loadDGVSP(int page, int recordNum)
        {
            dgv_DSSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.DonGia,
                            sp.DonVi,
                            sp.HinhAnh
                        };
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.DonVi, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.DonVi); i++;
                    }
                    else
                        break;
                }
            }
            dgv_DSSP.Columns["dg"].DefaultCellStyle.Format = "N0";
            
            if (page == 1)
                btnTrangTruoc.Visible = false;
            else
                btnTrangTruoc.Visible = true;

            if (page - 1 >= query.Count() / recordNum ||
                (page == query.Count() / recordNum && query.Count() % recordNum == 0))
                btnTrangSau.Visible = false;
            else
                btnTrangSau.Visible = true;
        }

        private void locDL(int page, int recordNum, string loc)
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
                            sp.DonVi,
                            sp.HinhAnh
                        };
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.DonVi, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.DonVi); i++;
                    }
                    else
                        break;
                }
            }
            dgv_DSSP.Columns["dg"].DefaultCellStyle.Format = "N0";
            if (page == 1)
                btnTrangTruoc.Visible = false;
            else
                btnTrangTruoc.Visible = true;

            if (page - 1 >= query.Count() / recordNum ||
                (page == query.Count() / recordNum && query.Count() % recordNum == 0))
                btnTrangSau.Visible = false;
            else
                btnTrangSau.Visible = true;
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
                                    rowss.Cells[3].Value = xn.soluong + int.Parse(rowss.Cells[3].Value.ToString());
                                    rowss.Cells[4].Value = int.Parse(rowss.Cells[3].Value.ToString()) * double.Parse(dongia);
                                    check++;
                                }
                            }
                        }

                        if (check == 0)
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
                }
            }
            else
            {
                using(XacNhanSL xnsl=new XacNhanSL())
                {
                    if (xnsl.ShowDialog() == DialogResult.OK)
                    {
                        dgvDSOrder.Rows[e.RowIndex].Cells[3].Value = xnsl.soluong;
                        dgvDSOrder.Rows[e.RowIndex].Cells[4].Value = xnsl.soluong*double.Parse(dgvDSOrder.Rows[e.RowIndex].Cells[2].Value.ToString());
                    }
                }    
            }
            TinhTien();
        }

        #region Lọc bảng sản phẩm
        private void btnChonComBo_Click(object sender, EventArgs e)
        {
            locLoai = "ComBo";
            pageNu = 1;
            txtSoTrang.Text = pageNu + "";
            locDL(pageNu, numberRe, locLoai);
        }

        private void btnChonMonLe_Click(object sender, EventArgs e)
        {
            locLoai = "Đồ ăn";
            pageNu = 1;
            txtSoTrang.Text = pageNu + "";
            locDL(pageNu, numberRe, locLoai);
        }

        private void btnChonDoUong_Click(object sender, EventArgs e)
        {
            locLoai = "Đồ uống";
            pageNu = 1;
            txtSoTrang.Text = pageNu + "";
            locDL(pageNu, numberRe, locLoai);
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
                            sp.DonVi,
                            sp.HinhAnh
                        };
            foreach (var item in query)
            {
                if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.DonVi, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia, item.DonVi);
            }
            dgv_DSSP.Columns["dg"].DefaultCellStyle.Format = "N0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnTrangSau.Visible = true;
            btnTrangTruoc.Visible = true;
            txtSoTrang.Visible = true;
            pageNu = 1;
            txtSoTrang.Text = pageNu + "";
            locLoai = null;
            loadDGVSP(pageNu, numberRe);
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
            e.Graphics.DrawString("STOREID:  " + hoadonin.StoreId,
                                new Font("Courier New", 24, FontStyle.Bold),
                                Brushes.Black,
                                new RectangleF(new PointF(10, vtdong), layoutSize),
                                formatCenter);
            vtdong += 40;
            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(10, vtdong), layoutSize),
                                formatCenter);
            #endregion

            #region Máy pos và tên nhân viên

            vtdong += 30;
            e.Graphics.DrawString(
                                hoadonin.Pos + "    POS " + hoadonin.Pos,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong)
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
                                new PointF(30, vtdong));
            vtdong += 30;
            e.Graphics.DrawString(String.Format("\t\t {0}", ((DateTime)hoadonin.NgayThang).ToString("dd/MM/yyyy HH:mm:ss")),
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong));
            vtdong += 30;

            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(10, vtdong), layoutSize), formatCenter);
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
                                    new PointF(30, vtdong));
                e.Graphics.DrawString(item.TenSp,
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(65, vtdong));
                e.Graphics.DrawString(string.Format("{0:N0}", item.DonGia * item.SoLuong),
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(chieurong - 150, vtdong));
                vtdong += 30;
            }
            #endregion

            #region Thông tin Thanh toán
            vtdong += 20;
            e.Graphics.DrawString("Cash",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong));
            e.Graphics.DrawString(string.Format("{0:N0}", Double.Parse(txtDua.Text)),
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Sub Total",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong));
            e.Graphics.DrawString(lblThanhTien.Text,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Total: ",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong));
            e.Graphics.DrawString(lblThanhTien.Text,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Payment: ",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong));
            e.Graphics.DrawString(string.Format("{0:N0}", Double.Parse(txtDua.Text)),
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            e.Graphics.DrawString("Change Due: ",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(30, vtdong));
            e.Graphics.DrawString(lblTienThua.Text,
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong - 150, vtdong));
            vtdong += 30;
            #endregion

            #region footer
            e.Graphics.DrawString(String.Format("---- CLOSE  {0} ", DateTime.Now.ToString()) + "  -----",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Tham gia khao sat va nhan qua tai:",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("www.talk2kfcvietnam.com",
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
            e.Graphics.DrawString("Thoi gian tham gia doi thuong la",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("7 ngay ke tu ngay mua hang.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Co gia tri doi thuong trong vong",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("15 ngay ke tu ngay mua hang.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Khao sat chi ap dung cho hoa don co gia tri",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("tu 70.000 tro len.",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Quy khach can hoa don tai chinh de nghi",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("lay ngay khi mua hang.",
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

        #region Phân trang
        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (pageNu - 1 > 0)
            {
                pageNu--;
                txtSoTrang.Text = pageNu + "";
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (pageNu - 1 < db.SanPhams.Count() / numberRe)
            {
                pageNu++;
                txtSoTrang.Text = pageNu + "";
            }
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (locLoai == null)
                loadDGVSP(pageNu, numberRe);
            else
                locDL(pageNu, numberRe, locLoai);
        }
        #endregion

        #endregion
    }
}
