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
    
    public partial class CAP_PHAT
    {
        public int MaCP { get; set; }
        public Nullable<System.DateTime> NgayCP { get; set; }
        public string NguoiLapPhieu { get; set; }
        public Nullable<int> MaKho { get; set; }
        public Nullable<int> MaDV { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual DON_VI DON_VI { get; set; }
    }
}
