using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageDriver()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var driverlst = db.tblDrivers.Select(x => new { Id = x.Id, DriverName = x.DriverName, DriverCategory = x.DriverCategory, Image = x.Image, }).ToList();

                return Json(new { data = driverlst }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ViewBag.Action = "Add New Driver";
                    return View(new DriverViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    DriverViewModel dvm = new DriverViewModel();
                    tblDriver tb = db.tblDrivers.Where(d => d.Id == id).FirstOrDefault();
                    ViewBag.Action = "Edit Driver";
                    dvm.Id = tb.Id;
                    dvm.DriverName = tb.DriverName;
                    dvm.DriverCategory = tb.DriverCategory;
                    dvm.Image = tb.Image;
                    return View(dvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(DriverViewModel dvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (dvm.Id == 0)
                {
                    tblDriver tb = new tblDriver();
                    tb.DriverName = dvm.DriverName;
                    tb.DriverCategory = dvm.DriverCategory;
                    HttpPostedFileBase fup = Request.Files["Image"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/Driver/" + fup.FileName));
                            tb.Image = fup.FileName;
                        }
                    }
                    db.tblDrivers.Add(tb);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblDriver tb = db.tblDrivers.Where(d => d.Id == dvm.Id).FirstOrDefault();
                    tb.DriverName = dvm.DriverName;
                    tb.DriverCategory = dvm.DriverCategory;
                    HttpPostedFileBase fup = Request.Files["Image"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/Driver/" + fup.FileName));
                            tb.Image = fup.FileName;
                        }
                    }

                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblDriver tb = db.tblDrivers.Where(d => d.Id == id).FirstOrDefault();
                db.tblDrivers.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}