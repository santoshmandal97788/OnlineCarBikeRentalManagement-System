//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineCarBikeRentalSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSubMenu
    {
        public int SubMenuId { get; set; }
        public Nullable<int> MenuId { get; set; }
        public string SubMenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    
        public virtual tblMenu tblMenu { get; set; }
    }
}
