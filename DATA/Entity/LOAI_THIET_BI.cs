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
    
    public partial class LOAI_THIET_BI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAI_THIET_BI()
        {
            this.THIET_BI = new HashSet<THIET_BI>();
            this.TANGs = new HashSet<TANG>();
        }
    
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string DVT { get; set; }
        public Nullable<int> MaNhom { get; set; }
    
        public virtual NHOM_TB NHOM_TB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TANG> TANGs { get; set; }
    }
}