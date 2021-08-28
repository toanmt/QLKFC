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
    public partial class XacNhanNhapHang : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = 0;
        String TenNV = "";
        int MaHdk;
        public XacNhanNhapHang(int MaHdk,String TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
            this.MaHdk = MaHdk;
            load();

        }

        #region Lấy dữ liệu vào cbbox + textbox
        public void load()
        {
            var query = from x in db.CthoaDonKhos
                        join y in db.NguyenLieus on x.MaNl equals y.MaNl
                        where x.MaHdk == MaHdk && x.SoLuong!=x.SoLuongDaNhap
                        select new
                        {
                            x.MaNl,
                            y.TenNl,
                            x.SoLuong,
                            x.SoLuongDaNhap
                        };
            cbNguyenLieu.DataSource = query.ToList();
            cbNguyenLieu.DisplayMember = "TenNL";
            cbNguyenLieu.ValueMember = "SoLuongDaNhap";
            txtSoLuongDaNhap.Text = cbNguyenLieu.SelectedValue.ToString();
            dateTimePicker1.Value = DateTime.Now;
            cbNguyenLieu.ValueMember = "SoLuong";
            nUDSoLuongNhap.Maximum = int.Parse(cbNguyenLieu.SelectedValue.ToString()) - int.Parse(txtSoLuongDaNhap.Text); 
            txtSoLuongDaDat.Text = cbNguyenLieu.SelectedValue.ToString();
        }
        //Lấy vị trí trên dgv
        private void dgvHuyHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
        //Sự kiện khi thay đổi cbbox
        private void cbNguyenLieu_SelectedValueChanged(object sender, EventArgs e)
        {
            var check = db.NguyenLieus.Where(x => x.TenNl == cbNguyenLieu.Text).Select(x => x.MaNl).FirstOrDefault();
            var query = db.CthoaDonKhos.Select(x => x);
            foreach (var item in query)
            {
                if (item.MaNl.ToString() == check.ToString())
                {
                    txtSoLuongDaNhap.Text = item.SoLuongDaNhap.ToString();
                    nUDSoLuongNhap.Maximum = int.Parse(item.SoLuong.ToString()) - int.Parse(txtSoLuongDaNhap.Text);
                    txtSoLuongDaDat.Text = item.SoLuong.ToString();
                }
            }
            

        }
        #endregion


        #region Nút Thêm sửa xóa hủy
        //Thêm 1 dòng
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(nUDSoLuongNhap.Text) == 0)
                    throw new Exception("Chưa chọn số lượng nhập");
                if (nUDSoLuongNhap.Text.Equals(""))
                    throw new Exception("Bạn chưa nhập số lượng nhập!");

                var queryNL = (from s in db.NguyenLieus
                             where s.TenNl == cbNguyenLieu.Text
                             select s).SingleOrDefault();
                for (int i = 0; i < dgvNhapHang.Rows.Count; i++)
                    if (queryNL.MaNl.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                    {
                        int SLCu = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                        if (SLCu > nUDSoLuongNhap.Maximum)
                            throw new Exception("Số lượng nhập vào đã đạt tối đa. Không thể thêm nữa!!!");
                        int SLMoi = int.Parse(nUDSoLuongNhap.Text);
                        if ((SLCu + SLMoi) <= nUDSoLuongNhap.Maximum)
                        {
                            dgvNhapHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", (SLCu + SLMoi));
                            return;
                        }
                        else
                            throw new Exception("Không thể nhập nhiều hơn số lượng đã đặt !!!");
                    }
                string[] row = { queryNL.MaNl.ToString(), queryNL.TenNl.ToString(),queryNL.DonGia.Value.ToString(), string.Format("{0:#,##0}",nUDSoLuongNhap.Text) };

                dgvNhapHang.Rows.Add(row);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Số lượng phải là số > 0");
                nUDSoLuongNhap.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                nUDSoLuongNhap.Focus();
            }
        }

        //Xóa 1 dòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (index > -1 && index < dgvNhapHang.Rows.Count)
            {
                dgvNhapHang.Rows.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Chưa chọn nguyên liệu để xóa !");
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Sửa 1 dòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            var query = (from s in db.NguyenLieus
                         where s.TenNl == cbNguyenLieu.Text
                         select s).SingleOrDefault();
            for (int i = 0; i < dgvNhapHang.Rows.Count; i++)
                if (query.MaNl.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                {
                    int SLMoi = int.Parse(nUDSoLuongNhap.Text);
                    if (SLMoi <= nUDSoLuongNhap.Maximum)
                        dgvNhapHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", SLMoi);
                    else
                        MessageBox.Show("Số lượng phải nhỏ hơn số lượng đặt!!!");
                    return;
                }
        }
        #endregion

        //Xác nhận nhập hàng vào kho
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var queryKho = db.Khos.Select(x => x);
                int index = dgvNhapHang.Rows.Count;
                int checkNew = 0;
                if (index == 0)
                    throw new Exception("Chưa có nguyên liệu nào");
                else
                {
                    BaoCao bc = new BaoCao();
                    bc.NgayLap = DateTime.Now;
                    bc.StoreId = "044";
                    bc.Loai = "Nhập hàng";
                    bc.TenNv = this.TenNV;
                    String MoTa = "Nhập hàng";
                    for (int i = 0; i < index; i++)
                    {
                        checkNew = 0;
                        String d1 = dgvNhapHang.Rows[i].Cells[0].Value.ToString();
                        String d2 = dgvNhapHang.Rows[i].Cells[1].Value.ToString();
                        float d3 = float.Parse(dgvNhapHang.Rows[i].Cells[2].Value.ToString());
                        int d4 = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                        MoTa += "\n"+d2 + "- Số lượng :" + d4 + "- Tổng : " + (d3*d4).ToString();
                        db.CthoaDonKhos.Where(x => x.MaHdk == MaHdk && x.MaNl == int.Parse(d1)).SingleOrDefault().SoLuongDaNhap += d4;
                        foreach (var itemKho in queryKho.ToList())
                        {
                            //Kiểm tra nếu nguyên liệu cũ thì + số lượng
                            if (d1 == itemKho.MaNl.ToString())
                            {
                                itemKho.SoLuong += d4;
                                checkNew++;
                            }                
                        }
                        //Nếu ng liệu mới thì checkNew = 0;
                        if(checkNew == 0)
                        {
                            Kho nl = new Kho();
                            nl.MaNl = int.Parse(d1.ToString());
                            nl.SoLuong = d4;
                            db.Khos.Add(nl);  
                        }    
                    }
                    bc.Mota = MoTa;
                    db.BaoCaos.Add(bc);
                    db.SaveChanges();
                    MessageBox.Show("Nhập kho thành công. !");
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

