//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCShoesShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DON_DAT_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_DAT_HANG()
        {
            this.CT_DON_DAT_HANG = new HashSet<CT_DON_DAT_HANG>();
        }
    
        public int MaDDH { get; set; }
        public Nullable<System.DateTime> NgayLapDDH { get; set; }
        public Nullable<int> MaKH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DON_DAT_HANG> CT_DON_DAT_HANG { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
