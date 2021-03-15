using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class RentalContentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Heading { get; set; }
        [Required]
        [AllowHtml]
        public string FeatureList { get; set; }
    }
}