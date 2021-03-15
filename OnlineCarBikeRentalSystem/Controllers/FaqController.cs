using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faq
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageFaqHeading()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var lstfaqheading = db.tblFaqHeadings.ToList();
                return Json(new { data = lstfaqheading }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {

                    return View(new FaqViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    FaqViewModel fvm = new FaqViewModel();
                    tblFaqHeading tb = db.tblFaqHeadings.Where(f => f.FaqId == id).FirstOrDefault();
                    fvm.FaqId = tb.FaqId;
                    fvm.FaqHeading = tb.FaqHeading;

                    return View(fvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(FaqViewModel fvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (fvm.FaqId == 0)
                {
                    tblFaqHeading tb = new tblFaqHeading();
                    tb.FaqHeading = fvm.FaqHeading;
                    db.tblFaqHeadings.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblFaqHeading tb = db.tblFaqHeadings.Where(f => f.FaqId == fvm.FaqId).FirstOrDefault();
                    tb.FaqHeading = fvm.FaqHeading;
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
                tblFaqHeading tb = db.tblFaqHeadings.Where(f => f.FaqId == id).FirstOrDefault();
                db.tblFaqHeadings.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}