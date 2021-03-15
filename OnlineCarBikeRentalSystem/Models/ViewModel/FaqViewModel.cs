using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class FaqViewModel
    {
        public int FaqId { get; set; }
        [Required]
        public string FaqHeading { get; set; }
    }
}