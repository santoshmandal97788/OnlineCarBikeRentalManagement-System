using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class VendorViewModel
    {
        public int VendorId { get; set; }
        [Required(ErrorMessage = "Select CategoryName")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Select CategoryName")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "VendorName is Required")]
        public string VendorName { get; set; }
    }
}