using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class HelpDeskController : Controller
    {
        // GET: HelpDesk
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageHelpDesk()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var helplst = db.tblHelpDesks.Select(x => new { Id = x.Id, Name = x.Name, Position = x.Position, About = x.About, SmallImage = x.SmallImage, LargeImage = x.LargeImage}).ToList();

                return Json(new { data = helplst }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ViewBag.Action = "Add New HelpDesk";
                    return View(new HelpDeskViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    HelpDeskViewModel hdvm = new HelpDeskViewModel();
                    tblHelpDesk tb = db.tblHelpDesks.Where(h => h.Id == id).FirstOrDefault();
                    ViewBag.Action = "Edit HelpDesk";
                    hdvm.Id = tb.Id;
                    hdvm.Name = tb.Name;
                    hdvm.Position = tb.Position;
                    hdvm.About = tb.About;
                    hdvm.SmallImage = tb.SmallImage;
                    hdvm.LargeImage = tb.LargeImage;
                    return View(hdvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(HelpDeskViewModel hdvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (hdvm.Id == 0)
                {
                    tblHelpDesk tb = new tblHelpDesk();
                    tb.Name = hdvm.Name;
                    tb.Position = hdvm.Position;
                    tb.About = hdvm.About;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/HelpDesk/" + fup.FileName));
                            tb.SmallImage = fup.FileName;
                        }
                    }
                    HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    if (fup1 != null)
                    {
                        if (fup1.FileName != "")
                        {
                            fup1.SaveAs(Server.MapPath("~/img/HelpDesk/" + fup1.FileName));
                            tb.LargeImage = fup1.FileName;
                        }
                    }
                    db.tblHelpDesks.Add(tb);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblHelpDesk tb = db.tblHelpDesks.Where(h => h.Id == hdvm.Id).FirstOrDefault();
                    tb.Name = hdvm.Name;
                    tb.Position = hdvm.Position;
                    tb.About = hdvm.About;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/HelpDesk/" + fup.FileName));
                            tb.SmallImage = fup.FileName;
                        }
                    }
                    HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    if (fup1 != null)
                    {
                        if (fup1.FileName != "")
                        {
                            fup1.SaveAs(Server.MapPath("~/img/HelpDesk/" + fup1.FileName));
                            tb.LargeImage = fup1.FileName;
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
                tblHelpDesk tb = db.tblHelpDesks.Where(h => h.Id == id).FirstOrDefault();
                db.tblHelpDesks.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}