using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class BikeCarRecordViewModel
    {
        public int BikeCarRecordId { get; set; }
        [Required]
        public Nullable<int> VehicleId { get; set; }
        [Required]
        public string NoPlate { get; set; }
        [Required]
        public string EngieneNo { get; set; }
    }
}