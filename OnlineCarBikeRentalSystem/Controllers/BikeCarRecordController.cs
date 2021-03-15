using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class BikeCarRecordController : Controller
    {
        // GET: BikeCarRecord
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageBikeCarRecord()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var bikecarlst = db.tblBikeCarRecords.Select(x => new { BikeCarRecordId = x.BikeCarRecordId, Bike_CarName = x.tblBikeCar.Bike_CarName, NoPlate = x.NoPlate, EngieneNo = x.EngieneNo }).ToList();

                return Json(new { data = bikecarlst }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ViewBag.bikecar = db.tblBikeCars.ToList();
                    ViewBag.Action = "Add New Record";
                    return View(new BikeCarRecordViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    BikeCarRecordViewModel bcrvm = new BikeCarRecordViewModel();
                    tblBikeCarRecord tb = db.tblBikeCarRecords.Where(x => x.BikeCarRecordId == id).FirstOrDefault();

                    ViewBag.Action = "Edit Record";
                    bcrvm.BikeCarRecordId = tb.BikeCarRecordId;
                    bcrvm.VehicleId = tb.VehicleId;
                    bcrvm.NoPlate = tb.NoPlate;
                    bcrvm.EngieneNo = tb.EngieneNo;
                    ViewBag.bikecar = db.tblBikeCars.ToList();
                    return View(bcrvm);
                }

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(BikeCarRecordViewModel bcrvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (bcrvm.BikeCarRecordId == 0)
                {
                    tblBikeCarRecord tb = new tblBikeCarRecord();
                    tb.VehicleId = bcrvm.VehicleId;
                    tb.NoPlate = bcrvm.NoPlate;
                    tb.EngieneNo = bcrvm.EngieneNo;
                    db.tblBikeCarRecords.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Bike/Car Record Added Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblBikeCarRecord tb = db.tblBikeCarRecords.Where(r => r.BikeCarRecordId == bcrvm.BikeCarRecordId).FirstOrDefault();
                    tb.VehicleId = bcrvm.VehicleId;
                    tb.NoPlate = bcrvm.NoPlate;
                    tb.EngieneNo = bcrvm.EngieneNo;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Bike/Car Record Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblBikeCarRecord tb = db.tblBikeCarRecords.Where(r => r.BikeCarRecordId == id).FirstOrDefault();
                db.tblBikeCarRecords.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Bike/Car Record Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}