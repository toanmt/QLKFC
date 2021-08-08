using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class HoaDonKho
    {
        public HoaDonKho()
        {
            CthoaDonKhos = new HashSet<CthoaDonKho>();
        }

        public int MaHdk { get; set; }
        public DateTime? NgayCc { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection<CthoaDonKho> CthoaDonKhos { get; set; }
    }
}
