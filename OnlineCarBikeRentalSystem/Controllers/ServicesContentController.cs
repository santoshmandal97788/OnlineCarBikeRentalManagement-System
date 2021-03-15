using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class ServicesContentController : Controller
    {
        // GET: ServicesContent
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageServicesContent()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var lstserv = db.tblServicesContents.ToList();
                return Json(new { data = lstserv }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ViewBag.Action = "Add ServicesContent";
                    return View(new ServicesContentViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ServicesContentViewModel scvm = new ServicesContentViewModel();
                    tblServicesContent tb = db.tblServicesContents.Where(s => s.Id == id).FirstOrDefault();
                    ViewBag.Action = "Edit Item";
                    scvm.Id = tb.Id;
                    scvm.Heading = tb.Heading;
                    scvm.Paragraph = tb.Paragraph;
                    scvm.Image = tb.Image;
                    return View(scvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ServicesContentViewModel scvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (scvm.Id == 0)
                {
                    tblServicesContent tb = new tblServicesContent();
                    tb.Heading = scvm.Heading;
                    tb.Paragraph = scvm.Paragraph;
                    HttpPostedFileBase fup = Request.Files["Image"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/ServicesContent/" + fup.FileName));
                            tb.Image = fup.FileName;
                        }
                    }
                    db.tblServicesContents.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblServicesContent tb = db.tblServicesContents.Where(s => s.Id == scvm.Id).FirstOrDefault();
                    tb.Heading = scvm.Heading;
                    tb.Paragraph = scvm.Paragraph;
                    HttpPostedFileBase fup = Request.Files["Image"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/ServicesContent/" + fup.FileName));
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
                tblServicesContent tb = db.tblServicesContents.Where(s => s.Id == id).FirstOrDefault();
                db.tblServicesContents.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
  