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
    public class RentalContentController : Controller
    {
        // GET: RentalContent
        RentalContentDB rcdb = new RentalContentDB();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(rcdb.GetAllRentalContent());
        }
        public ActionResult AddNewRentalContent()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewRentalContent(RentalContentViewModel rcvm)
        {

            rcdb.AddRentalContent(rcvm);

            return RedirectToAction("Index");
        }
        public ActionResult EditContent(int id)
        {
            RentalContentViewModel rcvm = rcdb.GetAllRentalContent().Where(r => r.Id == id).FirstOrDefault();
            return View(rcvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(RentalContentViewModel rcvm)
        {
            if (ModelState.IsValid)
            {
                rcdb.Edit(rcvm);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            RentalContentViewModel rcvm = rcdb.GetAllRentalContent().Where(r => r.Id == id).FirstOrDefault();
            return View(rcvm);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            rcdb.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
