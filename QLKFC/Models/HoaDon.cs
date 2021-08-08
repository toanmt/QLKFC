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

<<<<<<< HEAD
=======
        public virtual NhanVien MaNvNavigation { get; set; }
>>>>>>> dc0e9e0c90873dcca5dd72ac9f26f1a03748ebd7
        public virtual ICollection<CthoaDon> CthoaDons { get; set; }
    }
}
