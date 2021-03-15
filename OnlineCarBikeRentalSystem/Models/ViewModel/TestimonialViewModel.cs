using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class TestimonialViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Paragraph { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Image { get; set; }
    }
}