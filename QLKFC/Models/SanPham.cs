using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CthoaDons = new HashSet<CthoaDon>();
        }

        public int MaSp { get; set; }
        public int? MaLsp { get; set; }
        public string TenSp { get; set; }
        public string Loai { get; set; }
        public double? DonGia { get; set; }
        public string Mota { get; set; }
        public string HinhAnh { get; set; }

        public virtual LoaiSanPham MaLspNavigation { get; set; }
        public virtual ICollection<CthoaDon> CthoaDons { get; set; }
    }
}
