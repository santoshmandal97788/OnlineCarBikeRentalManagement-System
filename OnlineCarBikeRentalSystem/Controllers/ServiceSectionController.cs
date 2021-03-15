using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class ServiceSectionController : Controller
    {
        // GET: Services
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageServiceSection()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var servicelst = db.tblServiceSections.Select(x => new { ServiceId = x.ServiceId, Icon = x.Icon, Heading = x.Heading, Paragraph=x.Paragraph }).ToList();

                return Json(new { data = servicelst }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    return View(new ServiceSectionViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ServiceSectionViewModel ssvm = new ServiceSectionViewModel();
                    tblServiceSection tb = db.tblServiceSections.Where(x => x.ServiceId == id).FirstOrDefault();
                    ssvm.ServiceId = tb.ServiceId;
                    ssvm.Icon = tb.Icon;
                    ssvm.Heading = tb.Heading;
                    ssvm.Paragraph = tb.Paragraph;
                    return View(ssvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ServiceSectionViewModel ssvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (ssvm.ServiceId == 0)
                {
                    tblServiceSection tb = new tblServiceSection();

                    tb.Icon= ssvm.Icon;
                    tb.Heading = ssvm.Heading;
                    tb.Paragraph = ssvm.Paragraph;
                    db.tblServiceSections.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "ServiceSection Content Added Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblServiceSection tb = db.tblServiceSections.Where(s => s.ServiceId == ssvm.ServiceId).FirstOrDefault();
                    tb.Icon = ssvm.Icon;
                    tb.Heading = ssvm.Heading;
                    tb.Paragraph = ssvm.Paragraph;
                   
                    db.SaveChanges();
                    return Json(new { success = true, message = "ServiceSection Content Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblServiceSection tb = db.tblServiceSections.Where(s => s.ServiceId == id).FirstOrDefault();
                db.tblServiceSections.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "ServiceSection Content Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}