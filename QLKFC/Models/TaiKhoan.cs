using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int Id { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public int? Quyen { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
