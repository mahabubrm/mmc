//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mwc.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleWiseScreenPermission
    {
        public int SL { get; set; }
        public int RoleId { get; set; }
        public string ScreenCode { get; set; }
        public string AccessRightCode { get; set; }
        public Nullable<bool> IsCreate { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<bool> IsUpdate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string EntryUser { get; set; }
    }
}