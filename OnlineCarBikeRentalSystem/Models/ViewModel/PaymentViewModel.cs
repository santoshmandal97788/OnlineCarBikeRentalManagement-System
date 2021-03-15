using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        [Required]
        public Nullable<int> CustomerRecordId { get; set; }
        [Required]
        public Nullable<int> BookingId { get; set; }
        [Required]
        public Nullable<int> TotalPrice { get; set; }
        [Required]
        public Nullable<System.DateTime> PaymentDate { get; set; }
        [Required]
        public string ReceivedBy { get; set; }
    }
}