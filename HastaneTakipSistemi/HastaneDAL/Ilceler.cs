//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HastaneTakipSistemi.HastaneDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ilceler
    {
        public int IlceID { get; set; }
        public Nullable<int> IlID { get; set; }
        public string Ilce { get; set; }
    
        public virtual Iller Iller { get; set; }
    }
}
