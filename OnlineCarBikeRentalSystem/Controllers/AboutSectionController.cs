using OnlineCarBikeRentalSystem.Models.Services;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class AboutSectionController : Controller
    {
        // GET: AboutUs

        AboutDB adb = new AboutDB();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(adb.GetAboutSectionContent());
        }
        public ActionResult AddNewContent()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewContent(AboutSectionViewModel avm)
        {
            HttpPostedFileBase fup = Request.Files["Image"];
            if (fup != null)
            {
                avm.Image = fup.FileName;
                fup.SaveAs(Server.MapPath("~/img/AboutUs/" + fup.FileName));
            }

            adb.AddAboutSectionContent(avm);

            return RedirectToAction("Index");
        }
        public ActionResult EditContent(int id)
        {
            AboutSectionViewModel avm = adb.GetAboutSectionContent().Where(c => c.AboutUsId == id).FirstOrDefault();
            return View(avm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(AboutSectionViewModel avm)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase fup = Request.Files["Image"];
                if (fup != null)
                {
                    if (fup.FileName != "")
                    {
                        string oldfile = avm.Image;
                        System.IO.File.Delete(Server.MapPath("~/img/AboutUs/" + oldfile));

                        avm.Image = fup.FileName;
                        fup.SaveAs(Server.MapPath("~/img/AboutUs/" + fup.FileName));


                    }

                }
                adb.Edit(avm);
            }
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int id)
        //{
        //    SliderViewModel svm = sdb.GetAllSliderContent().Where(s => s.SliderId == id).FirstOrDefault();
        //    return View(svm);
        //}
        //[HttpPost, ActionName("Delete")]
        //public ActionResult Delete_post(int id)
        //{
        //    sdb.Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}
