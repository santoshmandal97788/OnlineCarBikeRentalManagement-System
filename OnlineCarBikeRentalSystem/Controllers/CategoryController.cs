using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageCategory()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var lstcat = db.tblCategories.ToList();
                return Json(new { data = lstcat }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {

                    return View(new CategoryViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    CategoryViewModel cvm = new CategoryViewModel();
                    tblCategory tb = db.tblCategories.Where(c => c.CategoryId == id).FirstOrDefault();
                    cvm.CategoryId = tb.CategoryId;
                    cvm.CategoryName = tb.CategoryName;

                    return View(cvm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(CategoryViewModel cvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (cvm.CategoryId == 0)
                {
                    tblCategory tb = new tblCategory();
                    tb.CategoryName = cvm.CategoryName;
                    db.tblCategories.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Category Added Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblCategory tb = db.tblCategories.Where(c => c.CategoryId == cvm.CategoryId).FirstOrDefault();
                    tb.CategoryName = cvm.CategoryName;
                    db.SaveChanges();
                    return Json(new { success = true, message = " Category Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblCategory tb = db.tblCategories.Where(c => c.CategoryId == id).FirstOrDefault();
                db.tblCategories.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = " Category Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}