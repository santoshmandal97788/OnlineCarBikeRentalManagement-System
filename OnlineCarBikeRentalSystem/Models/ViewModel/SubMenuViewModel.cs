using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class SubMenuViewModel
    {
        public int SubMenuId { get; set; }
        [Required]
        public int? MenuId { get; set; }
        public string MenuName { get; set; }
        [Required]
        public string SubMenuName { get; set; }
        [Required]
        public string ControllerName { get; set; }      
        [Required]
        public string ActionName { get; set; }
       
       

    }
}