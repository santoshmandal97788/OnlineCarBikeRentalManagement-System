using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageVendor()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var vendorlst = db.tblVendors.Select(x => new { VendorId = x.VendorId, CategoryName = x.tblCategory.CategoryName, VendorName = x.VendorName }).ToList();

                return Json(new { data = vendorlst }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {

                    ViewBag.category = db.tblCategories.ToList();
                 
                    return View(new VendorViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    VendorViewModel vvm = new VendorViewModel();
                    tblVendor tb = db.tblVendors.Where(x => x.VendorId == id).FirstOrDefault();
                    vvm.VendorId = tb.VendorId;
                   
                    vvm.CategoryId = tb.CategoryId;
                   
                    vvm.VendorName = tb.VendorName;

                    ViewBag.category = db.tblCategories.ToList();
                    return View(vvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(VendorViewModel vvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (vvm.VendorId == 0)
                {
                    tblVendor tb = new tblVendor();
                   
                    tb.CategoryId = vvm.CategoryId;
                    tb.VendorName = vvm.VendorName;

                    //ViewBag.category = db.tblCategories.ToList();

                    db.tblVendors.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Vendor Added Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblVendor tb = db.tblVendors.Where(c => c.VendorId == vvm.VendorId).FirstOrDefault();
                    tb.CategoryId = vvm.CategoryId;
                    tb.VendorName = vvm.VendorName;
                    //ViewBag.category = db.tblCategories.ToList();
                    db.SaveChanges();
                    return Json(new { success = true, message = " Vendor Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblVendor tb = db.tblVendors.Where(x => x.VendorId == id).FirstOrDefault();
                db.tblVendors.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Vendor Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}