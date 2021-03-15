using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class BikeCarController : Controller
    {
        // GET: BikeCar
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageBikeCar()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var bikecarlst = db.tblBikeCars.Select(x => new { VehicleId = x.VehicleId, CategoryName = x.tblVendor.tblCategory.CategoryName, VendorName = x.tblVendor.VendorName, Bike_CarName=x.Bike_CarName, EngieneCC=x.EngieneCC, PricePerHour = x.PricePerHour, PricePerDay=x.PricePerDay, PricePerWeek=x.PricePerWeek, PricePermonth=x.PricePermonth,  FuelUsed =x.FuelUsed/*, SmallImage=x.SmallImage, LargeImage=x.LargeImgae*/ }).ToList();

                return Json(new { data = bikecarlst }, JsonRequestBehavior.AllowGet);
            }

        }
        private class FuelType
        {
            public int Id { get; set; }
            public string FType { get; set; }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    List<FuelType> lst = new List<FuelType>();
                    lst.Add(new FuelType() { Id = 1, FType = "Petrol" });
                    lst.Add(new FuelType() { Id = 2, FType = "Diesel" });
                    lst.Add(new FuelType() { Id = 3, FType = "Electric Charge" });
                    ViewBag.fuel = lst;
                    ViewBag.vendor = db.tblVendors.ToList();
                    ViewBag.Action = "Add New Bike/Car";
                    return View(new BikeCarViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    BikeCarViewModel bcvm = new BikeCarViewModel();
                    tblBikeCar tb = db.tblBikeCars.Where(x => x.VehicleId == id).FirstOrDefault();
                    tblStock tb1 = db.tblStocks.Where(x => x.VehicleId == id).FirstOrDefault();
                    ViewBag.Action = "Edit Item";
                    bcvm.VehicleId = tb.VehicleId;
                    bcvm.VendorId = tb.VendorId;
                    bcvm.Bike_CarName = tb.Bike_CarName;
                    bcvm.EngieneCC = tb.EngieneCC;
                    bcvm.PricePerHour = tb.PricePerHour;
                    bcvm.PricePerDay = tb.PricePerDay;
                    bcvm.PricePerWeek = tb.PricePerWeek;
                    bcvm.PricePermonth = tb.PricePermonth;
                    bcvm.FuelUsed = tb.FuelUsed;                
                    bcvm.SmallImage = tb.SmallImage;
                    bcvm.LargeImage = tb.LargeImgae;
                    bcvm.TotalBike_Car = tb1.TotalBike_Car;
                    List<FuelType> lst = new List<FuelType>();
                    lst.Add(new FuelType() { Id = 1, FType = "Petrol" });
                    lst.Add(new FuelType() { Id = 2, FType = "Diesel" });
                    lst.Add(new FuelType() { Id = 3, FType = "Electric Charge" });
                    ViewBag.fuel = lst;
                    ViewBag.vendor = db.tblVendors.ToList();

                    return View(bcvm);
                }

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(BikeCarViewModel bcvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (bcvm.VehicleId == 0)
                {
                    tblBikeCar tb = new tblBikeCar();
                    tb.VendorId = bcvm.VendorId;
                    tb.Bike_CarName = bcvm.Bike_CarName;
                    tb.EngieneCC = bcvm.EngieneCC;
                    tb.PricePerHour = bcvm.PricePerHour;
                    tb.PricePerDay = bcvm.PricePerDay;
                    tb.PricePerWeek = bcvm.PricePerWeek;
                    tb.PricePermonth = bcvm.PricePermonth;
                    tb.FuelUsed = bcvm.FuelUsed;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/bikecar/" + fup.FileName));
                            tb.SmallImage = fup.FileName;
                        }
                    }
                    HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    if (fup1 != null)
                    {
                        if (fup1.FileName != "")
                        {
                            fup1.SaveAs(Server.MapPath("~/img/bikecar/" + fup1.FileName));
                            tb.LargeImgae = fup1.FileName;
                        }
                    }
                    db.tblBikeCars.Add(tb);
                    db.SaveChanges();
                    List<FuelType> lst = new List<FuelType>();
                    lst.Add(new FuelType() { Id = 1, FType = "Petrol" });
                    lst.Add(new FuelType() { Id = 2, FType = "Diesel" });
                    lst.Add(new FuelType() { Id = 3, FType = "Electric Charge" });
                    ViewBag.fuel = lst;

                    //For inseting stock
                    tblStock tb1 = new tblStock();
                    tb1.VehicleId = tb.VehicleId;
                    tb1.TotalBike_Car = bcvm.TotalBike_Car;
                    db.tblStocks.Add(tb1);
                    db.SaveChanges();
                    ViewBag.Message = "Bike/Car Added Successfully";
                    //return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblBikeCar tb = db.tblBikeCars.Where(c => c.VehicleId == bcvm.VehicleId).FirstOrDefault();
                    tblStock tb1 = db.tblStocks.Where(s => s.VehicleId == bcvm.VehicleId).FirstOrDefault();
                    tb1.TotalBike_Car = bcvm.TotalBike_Car;
                    db.SaveChanges();

                   
                    tb.VendorId = bcvm.VendorId;
                    tb.Bike_CarName = bcvm.Bike_CarName;
                    tb.EngieneCC = bcvm.EngieneCC;
                    tb.PricePerHour = bcvm.PricePerHour;
                    tb.PricePerDay = bcvm.PricePerDay;
                    tb.PricePerWeek = bcvm.PricePerWeek;
                    tb.PricePermonth = bcvm.PricePermonth;
                    tb.FuelUsed = bcvm.FuelUsed;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/bikecar/" + fup.FileName));
                            tb.SmallImage = fup.FileName;
                        }
                    }
                    HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    if (fup1 != null)
                    {
                        if (fup1.FileName != "")
                        {
                            fup1.SaveAs(Server.MapPath("~/img/bikecar/" + fup1.FileName));
                            tb.LargeImgae = fup1.FileName;
                        }
                    }
                    List<FuelType> lst = new List<FuelType>();
                    lst.Add(new FuelType() { Id = 1, FType = "Petrol" });
                    lst.Add(new FuelType() { Id = 2, FType = "Diesel" });
                    lst.Add(new FuelType() { Id = 3, FType = "Electric Charge" });
                    ViewBag.fuel = lst;
                    db.SaveChanges();
                    ViewBag.Message = "Bike/Car Updated Successfully";
                    //return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
                ViewBag.vendor = db.tblVendors.ToList();
                return View(new BikeCarViewModel());
                  
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblStock tb1 = db.tblStocks.Where(s => s.VehicleId == id).FirstOrDefault();
                db.tblStocks.Remove(tb1);
                db.SaveChanges();
                tblBikeCar tb = db.tblBikeCars.Where(c => c.VehicleId == id).FirstOrDefault();
                db.tblBikeCars.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Bike/Car Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}