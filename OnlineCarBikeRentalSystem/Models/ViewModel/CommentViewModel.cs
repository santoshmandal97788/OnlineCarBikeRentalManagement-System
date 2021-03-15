using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Comment { get; set; }
        //[Required]
        //public DateTime? CommentDate { get; set; }
    }
}