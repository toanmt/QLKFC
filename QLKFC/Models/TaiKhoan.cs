using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            ChucVus = new HashSet<ChucVu>();
        }

        public int Id { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public bool? Quyen { get; set; }

        public virtual ICollection<ChucVu> ChucVus { get; set; }
    }
}
