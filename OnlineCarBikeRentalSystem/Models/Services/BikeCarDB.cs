using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public static class BikeCarDB
    {
        public static List<tblBikeCar> GetAllBike()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                List<tblBikeCar> tb1 = db.tblBikeCars.Where(s => s.tblVendor.tblCategory.CategoryName == "Bike").ToList();
                if (tb1.Count<=6)
                {
                    List<tblBikeCar> tb11=  db.tblBikeCars.Where(s => s.tblVendor.tblCategory.CategoryName == "Bike").ToList();
               
                    return tb11;
                }
                else
                {
                    List<tblBikeCar> tb2 = db.tblBikeCars.Where(s => s.tblVendor.tblCategory.CategoryName == "Bike").Take(6).ToList();
                    return tb2;
                }
                
            }
          
        }
        public static List<tblBikeCar> GetAllCars()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                List<tblBikeCar> tb1 = db.tblBikeCars.Where(s => s.tblVendor.tblCategory.CategoryName == "Car").ToList();
                if (tb1.Count <= 6)
                {
                    List<tblBikeCar> tb11 = db.tblBikeCars.Where(s => s.tblVendor.tblCategory.CategoryName == "Car").ToList();

                    return tb11;
                }
                else
                {
                    List<tblBikeCar> tb2 = db.tblBikeCars.Where(s => s.tblVendor.tblCategory.CategoryName == "Car").Take(6).ToList();
                    return tb2;
                }

            }

        }
    }
}
