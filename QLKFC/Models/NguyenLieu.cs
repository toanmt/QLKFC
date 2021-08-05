using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class NguyenLieu
    {
        public int MaNl { get; set; }
        public string TenNl { get; set; }
        public float DonGia { get; set; }

        public virtual Kho Kho { get; set; }
    }
}
