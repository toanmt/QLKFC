using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            CthoaDons = new HashSet<CthoaDon>();
        }

        public int MaHd { get; set; }
        public string TenNv { get; set; }
        public string StoreId { get; set; }
        public string Pos { get; set; }
        public DateTime? NgayThang { get; set; }

        public virtual ICollection<CthoaDon> CthoaDons { get; set; }
    }
}
