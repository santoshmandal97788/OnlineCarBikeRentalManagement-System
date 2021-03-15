using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManagePayment()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var paylst = db.tblPayments.Select(x => new { PaymentId = x.PaymentId,Address=x.tblCustomerRecord.Address, CitizenshipNo = x.tblCustomerRecord.CitizenshipNo, FullName = x.tblBooking.FullName, HireDetails = x.tblBooking.HireDetails, TotalPrice = x.TotalPrice, PaymentDate = x.PaymentDate.ToString(), ReceivedBy = x.ReceivedBy}).ToList();

                return Json(new { data = paylst }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ViewBag.user = db.tblBookings.ToList();
                    ViewBag.customer = db.tblCustomerRecords.ToList();
                    ViewBag.Action = "Add New Bill";
                    return View(new PaymentViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    PaymentViewModel pvm = new PaymentViewModel();
                    tblPayment tb = db.tblPayments.Where(p => p.PaymentId == id).FirstOrDefault();
                    ViewBag.Action = "Edit Payment";
                    pvm.PaymentId = tb.PaymentId;
                    pvm.CustomerRecordId = tb.CustomerRecordId;
                    pvm.BookingId = tb.BookingId;
                    pvm.TotalPrice = tb.TotalPrice;
                    pvm.PaymentDate = tb.PaymentDate;
                    pvm.ReceivedBy = tb.ReceivedBy;
                    ViewBag.user = db.tblBookings.ToList();
                    ViewBag.customer = db.tblCustomerRecords.ToList();
                    return View(pvm);
                }

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(PaymentViewModel pvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (pvm.PaymentId == 0)
                {
                    tblPayment tb = new tblPayment();
                    tb.CustomerRecordId = pvm.CustomerRecordId;
                    tb.BookingId = pvm.BookingId;
                    tb.TotalPrice = pvm.TotalPrice;
                    tb.PaymentDate = pvm.PaymentDate;
                    tb.ReceivedBy = pvm.ReceivedBy;
                   
                    db.tblPayments.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblPayment tb = db.tblPayments.Where(p => p.PaymentId == pvm.PaymentId).FirstOrDefault();
                    tb.CustomerRecordId = pvm.CustomerRecordId;
                    tb.BookingId = pvm.BookingId;
                    tb.TotalPrice = pvm.TotalPrice;
                    tb.PaymentDate = pvm.PaymentDate;
                    tb.ReceivedBy = pvm.ReceivedBy;
                   
                   
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
                tblPayment tb = db.tblPayments.Where(p => p.PaymentId == id).FirstOrDefault();
                db.tblPayments.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}