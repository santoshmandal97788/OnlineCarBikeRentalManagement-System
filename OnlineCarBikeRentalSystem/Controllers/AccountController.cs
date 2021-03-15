using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                var users = db.tblUsers.Where(a => a.Username == l.Username && a.Password == l.Password).FirstOrDefault();
                if (users != null)
                {
                    FormsAuthentication.SetAuthCookie(l.Username, true);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        Session.Add("userid", users.UserId);
                        if (users.UserRoles.Where(r => r.RoleId == 1).FirstOrDefault() != null)
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }


                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
            }
            return View();

        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ChangePassword()
        {
            return View();
        }
        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult ChangePassword(ChangePasswordViewModel ch)
        //{
        //    int userid = Convert.ToInt32(Session["userid"].ToString());

        //    tblUser us = _db.tblUsers.Where(u => u.UserId == userid && u.Password == ch.OldPassword).FirstOrDefault();
        //    if (us != null)
        //    {
        //        us.Password = ch.NewPassword;
        //        _db.SaveChanges();
        //        ViewBag.Message = "Password Changed Successfully";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Wrong Old Password";
        //    }
        //    ModelState.Clear();
        //    return View();
        //}

    }


}
