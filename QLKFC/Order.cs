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
        SanPham spham = new SanPham();
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
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
