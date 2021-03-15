using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class ServiceSectionViewModel
    {
        public int ServiceId { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Heading { get; set; }
        [Required]
        public string Paragraph { get; set; }
    }
}