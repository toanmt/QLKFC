using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class NguyenLieu
    {
        public NguyenLieu()
        {
            CthoaDonKhos = new HashSet<CthoaDonKho>();
        }

        public int MaNl { get; set; }
        public string TenNl { get; set; }
        public double? DonGia { get; set; }

        public virtual ICollection<CthoaDonKho> CthoaDonKhos { get; set; }
    }
}
