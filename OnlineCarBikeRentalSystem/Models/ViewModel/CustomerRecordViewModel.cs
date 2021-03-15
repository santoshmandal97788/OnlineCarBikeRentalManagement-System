using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class CustomerRecordViewModel
    {
        public int CustomerRecordId { get; set; }
        [Required]
        public Nullable<int> BookingId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        [Required]
        public Nullable<int> BikeCarRecordId { get; set; }
        [Required]
        public string CitizenshipNo { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string LicenseNo { get; set; }
    }
}