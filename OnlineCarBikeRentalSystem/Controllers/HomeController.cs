using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.Services;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        CommentDB cdb = new CommentDB();
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SliderSection()
        {
            return PartialView("slidersection", _db.tblSliders.ToList());
        }
        public PartialViewResult ServiceSection()
        {
            return PartialView("servicesection",_db.tblServiceSections.ToList());
        }
        public PartialViewResult AboutSection()
        {
            return PartialView("aboutsection", _db.tblAboutUs.ToList());
        }
        public PartialViewResult FacilitySection()
        {
            return PartialView("facilitysection", _db.tblRentalContents.ToList());
        }
        public PartialViewResult TestimonialSection()
        {
            return PartialView("testimonialsection", _db.tblTestimonials.ToList());
        }
        public PartialViewResult ServicesArea()
        {
            return PartialView("servicesarea", _db.tblServicesContents.ToList());
        }
        public ActionResult BikeHireRates()
        {
            return View();
        }
        public ActionResult CarHireRates()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }     
        public ActionResult BlogPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogPage(CommentViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                cdb.ADDComment(cvm);
                ModelState.Clear();
            }
               
            
            
            //tblComment tb = new tblComment();
            //tb.Fullname = cvm.Fullname;
            //tb.Email = cvm.Email;
            //tb.Comment = cvm.Comment;
            //tb.CommentDate = System.DateTime.Now;
            //_db.tblComments.Add(tb);
            //_db.SaveChanges();
            //var comment = _db.tblComments.ToList();
            //ViewBag.Message = "Comment Added Successfully";


            return View();
        }
        public PartialViewResult Comments()
        {
            return PartialView("comments", _db.tblComments.ToList());
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                tblContact tb = new tblContact();
                tb.FullName = cvm.FullName;
                tb.Email = cvm.Email;
                tb.Website = cvm.Website;
                tb.Subject = cvm.Subject;
                tb.Message = cvm.Message;
                _db.tblContacts.Add(tb);
                _db.SaveChanges();
              
                ModelState.Clear();
               
            }
            ViewBag.Message = "Message Sent Successfully";
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                tblUser tb = new tblUser();
                tb.Username = uvm.Username;
                tb.Password = uvm.Password;
                _db.tblUsers.Add(tb);
                _db.SaveChanges();
                ModelState.Clear();
                UserRole ur = new UserRole();
                ur.UserId = tb.UserId;
                ur.RoleId = 2;
                _db.UserRoles.Add(ur);
                _db.SaveChanges();
                ViewBag.Message = "Register Successfully";
            }
            return View();

        }
        //public ActionResult CarList(string search, int? page, int id)
        //{
        //    List<tblBikeCar> tb1 = _db.tblBikeCars.Where(s => s.tblVendor.CategoryId == 3).ToList();
        //    if (tb1.Count > 0)
        //    {
        //        return View(_db.tblBikeCars.Where(s => s.tblVendor.CategoryId == 3).ToList().ToPagedList(page ?? 1, 12));
        //    }
        //    else
        //    {
        //        return View(_db.tblBikeCars.Where(b => b.Bike_CarName.StartsWith(search) || b.EngieneCC.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 12));
        //    }

        //}

        //public ActionResult CarList(string Sorting_Order, string Search_Data)
        //{
        //    ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Bike_CarName" : "";
        //    //ViewBag.SortingPrice = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";

        //    var cars = from ca in _db.tblBikeCars.Where(s => s.tblVendor.CategoryId == 3)select ca;
        //    {
        //        cars = cars.Where(ca => ca.Bike_CarName.ToUpper().Contains(Search_Data.ToUpper())
        //            || ca.EngieneCC.ToUpper().Contains(Search_Data.ToUpper()));
        //    }
        //    switch (Sorting_Order)
        //    {
        //        case "Bike_CarName":
        //            cars = cars.OrderByDescending(ca => ca.Bike_CarName);
        //            break;
        //        case "EngieneCC":
        //            cars = cars.OrderBy(ca => ca.EngieneCC);
        //            break;

        //        default:
        //            cars = cars.OrderBy(ca => ca.Bike_CarName);
        //            break;
        //    }

        //    return View(cars.ToList());
        //}

        public ActionResult CarList(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Bike_CarName" : "";
            //ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var cars = from ca in _db.tblBikeCars.Where(s => s.tblVendor.CategoryId == 3) select ca;

            if (!String.IsNullOrEmpty(Search_Data))
            {
               
                cars = cars.Where(ca => ca.Bike_CarName.ToUpper().Contains(Search_Data.ToUpper())
                   || ca.EngieneCC.ToUpper().Contains(Search_Data.ToUpper()));
            }
            switch (Sorting_Order)
            {
                case "Bike_CarName":
                    cars = cars.OrderByDescending(ca => ca.Bike_CarName);
                    break;
                case "EngieneCC":
                    cars = cars.OrderBy(ca => ca.EngieneCC);
                    break;

                default:
                    cars = cars.OrderBy(ca => ca.Bike_CarName);
                    break;
            }

            int Size_Of_Page = 6;
            int No_Of_Page = (Page_No ?? 1);
            return View(cars.ToPagedList(No_Of_Page, Size_Of_Page));
        }
        public ActionResult BikeList(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Bike_CarName" : "";
            //ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var bikes = from bi in _db.tblBikeCars.Where(b => b.tblVendor.CategoryId == 1) select bi;

            if (!String.IsNullOrEmpty(Search_Data))
            {

                bikes = bikes.Where(ca => ca.Bike_CarName.ToUpper().Contains(Search_Data.ToUpper())
                   || ca.EngieneCC.ToUpper().Contains(Search_Data.ToUpper()));
            }
            switch (Sorting_Order)
            {
                case "Bike_CarName":
                    bikes = bikes.OrderByDescending(ca => ca.Bike_CarName);
                    break;
                case "EngieneCC":
                    bikes = bikes.OrderBy(ca => ca.EngieneCC);
                    break;

                default:
                    bikes = bikes.OrderBy(ca => ca.Bike_CarName);
                    break;
            }

            int Size_Of_Page = 6;
            int No_Of_Page = (Page_No ?? 1);
            return View(bikes.ToPagedList(No_Of_Page, Size_Of_Page));
        }
    }
}