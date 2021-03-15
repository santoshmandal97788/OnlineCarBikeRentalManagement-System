using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class ResponseMessageViewModel
    {
        [Required]
        public string Message { get; set; }
    }
}