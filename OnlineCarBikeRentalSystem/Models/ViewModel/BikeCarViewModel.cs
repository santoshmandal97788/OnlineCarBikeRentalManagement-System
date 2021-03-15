using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.ViewModel
{
    public class BikeCarViewModel
    {
        public int VehicleId { get; set; }
        public int StockId { get; set; }
        [Required(ErrorMessage = "Select Vendor Name")]
        public Nullable<int> VendorId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Select Vendor Name")]
        public string VendorName { get; set; }
        [Required(ErrorMessage = "Bike/Car Name Required")]
        public string Bike_CarName { get; set; }
        [Required(ErrorMessage = "EngieneCC Required")]
        public string EngieneCC { get; set; }
        [Required(ErrorMessage = "Price/hr Required")]
        public Nullable<int> PricePerHour { get; set; }
        [Required(ErrorMessage = "Price/Day Required")]
        public Nullable<int> PricePerDay { get; set; }
        [Required(ErrorMessage = "Price/Week Required")]
        public Nullable<int> PricePerWeek { get; set; }
        [Required(ErrorMessage = "Price/Month Required")]
        public Nullable<int> PricePermonth { get; set; }

        [Required(ErrorMessage = "FuelUsed Required")]
        public string FuelUsed { get; set; }
        
        [Required(ErrorMessage = "Choose Vehicle Small Size Photo")]
        public string SmallImage { get; set; }
        [Required(ErrorMessage = "Choose Vehicle Large Size Photo")]
        public string LargeImage { get; set; }
        [Required(ErrorMessage = "Enter Total Number of Bike/car  ")]
        public Nullable<int> TotalBike_Car { get; set; }
    }
}