using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class DriverViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Driver Name")]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "Enter Driver Category")]
        public string DriverCategory { get; set; }
        [Required(ErrorMessage = "Choose Driver Photo")]
        public string Image { get; set; }
    }
}