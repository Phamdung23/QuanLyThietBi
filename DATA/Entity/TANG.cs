//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TANG()
        {
            this.THIET_BI = new HashSet<THIET_BI>();
        }
    
        public Nullable<int> MaLoai { get; set; }
        public int MaTang { get; set; }
        public Nullable<System.DateTime> NgayTang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string LyDo { get; set; }
        public string NguoiLapPhieu { get; set; }
        public string NguoiNhan { get; set; }
        public Nullable<int> MaKho { get; set; }
        public Nullable<int> TongTien { get; set; }
        public string TinhTrang { get; set; }
    
        public virtual KHO KHO { get; set; }
        public virtual LOAI_THIET_BI LOAI_THIET_BI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
