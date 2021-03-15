using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class PricingDB
    {
        public static List<tblBikeCar> GetAllBikPrice()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                List<tblBikeCar> tb1 = db.tblBikeCars.Where(s => s.tblVendor.CategoryId == 1).ToList();
                return tb1;
                
            }
        }
        public static List<tblBikeCar> GetAllCarPrice()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                List<tblBikeCar> tb1 = db.tblBikeCars.Where(s => s.tblVendor.CategoryId == 3).ToList();
                return tb1;

            }
        }
    }
}