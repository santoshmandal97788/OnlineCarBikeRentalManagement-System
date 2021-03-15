using OnlineCarBikeRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ViewStock()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var stocklst = db.tblStocks.Select(x => new { StockId = x.StockId,  VehicleName = x.tblBikeCar.Bike_CarName, EngieneCC = x.tblBikeCar.EngieneCC, TotalBike_Car = x.TotalBike_Car }).ToList();

                return Json(new { data = stocklst }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}