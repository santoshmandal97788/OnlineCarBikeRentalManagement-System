using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class SubMenuController : Controller
    {
        // GET: SubMenu
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageSubMenu()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var submenulst = db.tblSubMenus.Select(x => new { SubMenuId = x.SubMenuId, MenuName = x.tblMenu.MenuName, SubMenuName = x.SubMenuName, ControllerName=x.ControllerName, ActionName=x.ActionName }).ToList();

                return Json(new { data = submenulst }, JsonRequestBehavior.AllowGet);
            }

        }
        private class Controller
        {
            public int Id { get; set; }
            public string ControllerName { get; set; }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    List<Controller> lst = new List<Controller>();
                    lst.Add(new Controller() { Id = 1, ControllerName = "Pages" });
                    lst.Add(new Controller() { Id = 2, ControllerName = "Home" });
                
                    ViewBag.Controller = lst;
                    ViewBag.menu = db.tblMenus.ToList();                  
                    return View(new SubMenuViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    SubMenuViewModel svm = new SubMenuViewModel();
                    tblSubMenu tb = db.tblSubMenus.Where(x => x.SubMenuId == id).FirstOrDefault();
                    svm.SubMenuId = tb.SubMenuId;

                    svm.MenuId = tb.MenuId;

                    svm.SubMenuName = tb.SubMenuName;
                    svm.ControllerName = tb.ControllerName;
                    List<Controller> lst = new List<Controller>();
                    lst.Add(new Controller() { Id = 1, ControllerName = "Pages" });
                    lst.Add(new Controller() { Id = 2, ControllerName = "Home" });

                    ViewBag.Controller = lst;
                    svm.ActionName = tb.ActionName;
                    ViewBag.menu = db.tblMenus.ToList();
                    return View(svm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(SubMenuViewModel svm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (svm.SubMenuId == 0)
                {
                    tblSubMenu tb = new tblSubMenu();

                    tb.MenuId = svm.MenuId;
                    tb.SubMenuName = svm.SubMenuName;
                    tb.ControllerName = svm.ControllerName;
                    tb.ActionName = svm.ActionName;
                    db.tblSubMenus.Add(tb);
                    db.SaveChanges();
                    List<Controller> lst = new List<Controller>();
                    lst.Add(new Controller() { Id = 1, ControllerName = "Pages" });
                    lst.Add(new Controller() { Id = 2, ControllerName = "Home" });

                    ViewBag.Controller = lst;
                    return Json(new { success = true, message = "SubMenu Added Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblSubMenu tb = db.tblSubMenus.Where(c => c.SubMenuId == svm.SubMenuId).FirstOrDefault();
                    tb.MenuId = svm.MenuId;
                    tb.SubMenuName = svm.SubMenuName;
                    tb.ControllerName = svm.ControllerName;
                    tb.ActionName = svm.ActionName;
                    List<Controller> lst = new List<Controller>();
                    lst.Add(new Controller() { Id = 1, ControllerName = "Pages" });
                    lst.Add(new Controller() { Id = 2, ControllerName = "Home" });

                    ViewBag.Controller = lst;
                    db.SaveChanges();
                    return Json(new { success = true, message = "SubMenu Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblSubMenu tb = db.tblSubMenus.Where(x => x.SubMenuId == id).FirstOrDefault();
                db.tblSubMenus.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = " SubMenu Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}