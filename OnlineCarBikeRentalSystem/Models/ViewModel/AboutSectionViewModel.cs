using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class AboutSectionViewModel
    {
        public int AboutUsId { get; set; }
        [Required]
        public string SubHeadingParagraph { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string CardHeading { get; set; }
        [Required]
        public string CardParagraph { get; set; }
    }
}