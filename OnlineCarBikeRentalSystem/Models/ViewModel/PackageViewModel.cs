using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class PackageViewModel
    {
        public int PackageId { get; set; }
        [Required]
        [AllowHtml]
        public string PackageHeading { get; set; }
        [Required]
        [AllowHtml]
        public string ListPackage { get; set; }
    }
}