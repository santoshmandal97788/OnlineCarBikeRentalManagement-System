using OnlineCarBikeRentalSystem.Models.Services;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class PackageController : Controller
    {
        // GET: Package
        PackageDB pdb = new PackageDB();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(pdb.GetAllPackage());
        }
        public ActionResult AddPackage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPackage(PackageViewModel pvm)
        {

            pdb.AddPackages(pvm);

            return RedirectToAction("Index");
        }
        public ActionResult EditPackage(int id)
        {
            PackageViewModel pvm = pdb.GetAllPackage().Where(p => p.PackageId == id).FirstOrDefault();
            return View(pvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPackage(PackageViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                pdb.Edit(pvm);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            PackageViewModel pvm = pdb.GetAllPackage().Where(p=> p.PackageId == id).FirstOrDefault();
            return View(pvm);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            pdb.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
