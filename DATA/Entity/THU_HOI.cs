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
    
    public partial class THU_HOI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THU_HOI()
        {
            this.CT_THU_HOI = new HashSet<CT_THU_HOI>();
        }
    
        public int MaTH { get; set; }
        public Nullable<System.DateTime> NgayTH { get; set; }
        public Nullable<int> DVGiao { get; set; }
        public Nullable<int> DVNhan { get; set; }
        public string NguoiLapPhieu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_THU_HOI> CT_THU_HOI { get; set; }
        public virtual DON_VI DON_VI { get; set; }
        public virtual DON_VI DON_VI1 { get; set; }
    }
}