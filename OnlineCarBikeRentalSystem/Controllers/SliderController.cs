using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.Services;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        SliderDB sdb = new SliderDB();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(sdb.GetAllSliderContent());
        }
        public ActionResult AddNewSliderContent()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewSliderContent(SliderViewModel svm)
        {
          
                sdb.AddSliderContent(svm);

            return RedirectToAction("Index");
        }
        public ActionResult EditContent(int id)
        {
            SliderViewModel svm = sdb.GetAllSliderContent().Where(s => s.SliderId == id).FirstOrDefault();
            return View(svm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(SliderViewModel svm)
        {
            if (ModelState.IsValid)
            {
                sdb.Edit(svm);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            SliderViewModel svm = sdb.GetAllSliderContent().Where(s => s.SliderId == id).FirstOrDefault();
            return View(svm);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            sdb.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
   