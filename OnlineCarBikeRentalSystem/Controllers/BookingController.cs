using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.Services;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageBooking()
        {
            return View();
        }
        [Authorize]
        public ActionResult BookBikeCar()
        {
            List<HireDetails> lst = new List<HireDetails>();
            lst.Add(new HireDetails() { Id = 1, Name = "Hour" });
            lst.Add(new HireDetails() { Id = 2, Name = "Day" });
            lst.Add(new HireDetails() { Id = 3, Name = "Week" });
            lst.Add(new HireDetails() { Id = 4, Name = "Month" });
            ViewBag.hire = lst;

            //var addedBikeCar = _db.tblBikeCars
            //   .Single(item => item.VehicleId == id);

         
            //var book = Booking.GetVehicle(this.HttpContext);

            //book.Book(addedBikeCar);

            
            //return RedirectToAction("ShoppingCartList");
            ViewBag.bikecar = _db.tblBikeCars.ToList();
            ViewBag.users = _db.tblUsers.ToList();
            return View();
        }
        private class HireDetails
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        [HttpPost]
       
        public ActionResult BookBikeCar(BookingViewModel bvm)
        {
            if (ModelState.IsValid)
            {
                tblBooking tb = new tblBooking();
                tb.BookingDate = System.DateTime.Now;
                tb.VehicleId = bvm.VehicleId;
                tb.PickUpDate = bvm.PickUpDate;
                tb.ReturnDate = bvm.ReturnDate;
                tb.UserId =/* bvm.UserId;*/User.Identity.Name;
                tb.FullName = bvm.FullName;
                tb.Address = bvm.Address;
                tb.Phone = bvm.Phone;
                tb.HireDetails = bvm.HireDetails;
                tb.Status = "Pending";
                _db.tblBookings.Add(tb);
                _db.SaveChanges();
                ViewBag.Message = "Thank You For Booking Please Stay Update With Email after Confirmation";
            }
            //ModelState.Clear();
            ViewBag.bikecar = _db.tblBikeCars.ToList();
            ViewBag.users = _db.tblUsers.ToList();
            List<HireDetails> lst = new List<HireDetails>();
            lst.Add(new HireDetails() { Id = 1, Name = "Hour" });
            lst.Add(new HireDetails() { Id = 2, Name = "Day" });
            lst.Add(new HireDetails() { Id = 3, Name = "Week" });
            lst.Add(new HireDetails() { Id = 4, Name = "Month" });
            ViewBag.hire = lst;
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var booklst = db.tblBookings.Select(x => new { BookingId = x.BookingId, BookingDate = x.BookingDate.ToString(), Bike_CarName = x.tblBikeCar.Bike_CarName, PickUpDate = x.PickUpDate.ToString(), ReturnDate = x.ReturnDate.ToString(), UserId =x.UserId,  FullName=x.FullName, Address=x.Address, Phone = x.Phone, HireDetails = x.HireDetails, Status = x.Status }).ToList();
                return Json(new { data = booklst }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblBooking tb = db.tblBookings.Where(x => x.BookingId == id).FirstOrDefault();
                db.tblBookings.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult ConfirmBooking(int id)
        {

            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblBooking tb = db.tblBookings.Where(x => x.BookingId == id).FirstOrDefault();
                if (Convert.ToBoolean(tb.Status == "Pending"))
                {
                    tb.Status = "Confirmed";

                    tblStock tb1 = db.tblStocks.Where(x => x.StockId == tb.VehicleId).FirstOrDefault();
                    tb1.TotalBike_Car = tb1.TotalBike_Car - 1;
                    try
                    {

                        if (tb != null)
                        {
                            var fromAddress = new MailAddress("santoshmandal97788@gmail.com", "santoshmandal97788");
                            var toAddress = new MailAddress(tb.UserId, "To Name");
                            //For Gmail password
                            const string fromPassword = " ";
                            const string subject = "OnlineCarBikeRental";
                            var vehiclename = tb.tblBikeCar.Bike_CarName;
                            var pickupdate = tb.PickUpDate;
                            var returndate = tb.ReturnDate;
                            var hire = tb.HireDetails;
                            var smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                            };
                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = "Your Booking is Confirmed For a:" + hire + " " + vehiclename + " " + "From Date:" + pickupdate + " " + "To" + " " + returndate
                            })
                            {
                                smtp.Send(message);
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {

                    }

                    db.SaveChanges();
                    return Json(new { success = true, message = "Confirm Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else if (Convert.ToBoolean(tb.Status == "Confirmed"))
                {
                    return Json(new { success = false, message = "Booking Already Confirmed " }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = " You can't Confirm!! Booking Process is Done" }, JsonRequestBehavior.AllowGet);

                }

            }
        }
        [HttpPost]
        public ActionResult ReleaseBooking(int id)
        {

            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblBooking tb = db.tblBookings.Where(x => x.BookingId == id).FirstOrDefault();
                if (Convert.ToBoolean(tb.Status == "Confirmed"))
                {
                    tb.Status = "Released";

                    tblStock tb1 = db.tblStocks.Where(x => x.StockId == tb.VehicleId).FirstOrDefault();
                    tb1.TotalBike_Car = tb1.TotalBike_Car + 1;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Booking Released Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else if (Convert.ToBoolean(tb.Status == "Released"))
                {
                    return Json(new { success = false, message = "Booking Already Released" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = " You can't Release!! Booking is not confirmed Yet" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}