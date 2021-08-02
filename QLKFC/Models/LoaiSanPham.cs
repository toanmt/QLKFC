using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaLsp { get; set; }
        public string TenLsp { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
