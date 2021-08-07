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
        public Order()
        {
            InitializeComponent();
            loadDGVSP();
        }
        QLBHKFCContext db = new QLBHKFCContext();

        #region Lấy dữ liệu
        private void loadDGVSP()
        {

            var query = from sp in db.SanPhams
                        select new
                        {
                            sp.TenSp,
                            sp.DonGia,
                            sp.Loai,
                            sp.HinhAnh
                        };
            dgv_DSSP.DataSource = query.ToList();
        }
        #endregion

        #region Tương tác
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tensp = dgv_DSSP.Rows[e.RowIndex].Cells[0].Value.ToString();
            string dongia = dgv_DSSP.Rows[e.RowIndex].Cells[1].Value.ToString();
            using (XacNhanSL xn = new XacNhanSL())
            {
                if (xn.ShowDialog() == DialogResult.OK && xn.soluong > 0)
                {
                    int check = 0;
                    if (dgvDSOrder.RowCount > 0)
                    {
                        for (int i = 0; i < dgvDSOrder.RowCount; i++)
                        {
                            var rowss = dgvDSOrder.Rows[i];
                            if (rowss.Cells[0].Value.ToString() == tensp
                                && rowss.Cells[1].Value.ToString() == dongia)
                            {
                                int sl = xn.soluong + int.Parse(rowss.Cells[2].Value.ToString());
                                rowss.Cells[2].Value = sl;
                                rowss.Cells[3].Value = sl * float.Parse(dongia);
                                check++;
                            }
                        }
                    }
                    if (check == 0)
                    {
                        dgvDSOrder.Rows.Add(tensp, dongia, xn.soluong, float.Parse(dongia) * xn.soluong);
                    }
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            dgvDSOrder.ClearSelection();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDGVSP();
        }
        #endregion
    }
}
