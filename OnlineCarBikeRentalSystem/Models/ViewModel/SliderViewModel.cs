using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class SliderViewModel
    {
        public int SliderId { get; set; }
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }
        
        
        public string Description { get; set; }
    }
}