using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class CustomerRecordController : Controller
    {
        // GET: CustomerRecord
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageCustomerRecord()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var crlst = db.tblCustomerRecords.Select(x => new { CustomerRecordId = x.CustomerRecordId, Username = x.tblBooking.UserId, FullName=x.tblBooking.FullName, Address = x.Address, Phone1 = x.Phone1, Phone2 = x.Phone2, NoPlate = x.tblBikeCarRecord.NoPlate, CitizenshipNo = x.CitizenshipNo, Photo = x.Photo, LicenseNo = x.LicenseNo}).ToList();

                return Json(new { data = crlst }, JsonRequestBehavior.AllowGet);
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
                    ViewBag.noplate = db.tblBikeCarRecords.ToList();
                    ViewBag.Action = "Add New Customer";
                    return View(new CustomerRecordViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    CustomerRecordViewModel crvm = new CustomerRecordViewModel();
                    tblCustomerRecord tb = db.tblCustomerRecords.Where(c => c.CustomerRecordId == id).FirstOrDefault();
                    ViewBag.Action = "Edit Item";
                    crvm.CustomerRecordId = tb.CustomerRecordId;
                    crvm.BookingId = tb.BookingId;
                    crvm.Address = tb.Address;
                    crvm.Phone1 = tb.Phone1;
                    crvm.Phone2 = tb.Phone2;
                    crvm.BikeCarRecordId = tb.BikeCarRecordId;
                    crvm.CitizenshipNo = tb.CitizenshipNo;
                    crvm.Photo = tb.Photo;
                    crvm.LicenseNo = tb.LicenseNo;
                    ViewBag.user = db.tblBookings.ToList();
                    ViewBag.noplate = db.tblBikeCarRecords.ToList();
                    return View(crvm);
                }

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(CustomerRecordViewModel crvm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (crvm.CustomerRecordId == 0)
                {
                    tblCustomerRecord tb = new tblCustomerRecord();
                    tb.BookingId = crvm.BookingId;
                    tb.Address = crvm.Address;
                    tb.Phone1 = crvm.Phone1;
                    tb.Phone2 = crvm.Phone2;
                    tb.BikeCarRecordId = crvm.BikeCarRecordId;
                    tb.CitizenshipNo = crvm.CitizenshipNo;
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/Customer/" + fup.FileName));
                            tb.Photo = fup.FileName;
                        }
                    }
                    tb.LicenseNo = crvm.LicenseNo;
                    db.tblCustomerRecords.Add(tb);
                    db.SaveChanges();
                    ViewBag.Message = "Customer Added Successfully";
                    //return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblCustomerRecord tb = db.tblCustomerRecords.Where(c => c.CustomerRecordId == crvm.CustomerRecordId).FirstOrDefault();
                    tb.BookingId = crvm.BookingId;
                    tb.Address = crvm.Address;
                    tb.Phone1 = crvm.Phone1;
                    tb.Phone2 = crvm.Phone2;
                    tb.BikeCarRecordId = crvm.BikeCarRecordId;
                    tb.CitizenshipNo = crvm.CitizenshipNo;
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/img/Customer/" + fup.FileName));
                            tb.Photo = fup.FileName;
                        }
                    }
                    tb.LicenseNo = crvm.LicenseNo;
                    db.SaveChanges();
                    ViewBag.Message = "Customer Updated Successfully";

                    //return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
                ViewBag.user = db.tblBookings.ToList();
                ViewBag.noplate = db.tblBikeCarRecords.ToList();
                return View(new CustomerRecordViewModel());
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblCustomerRecord tb = db.tblCustomerRecords.Where(c => c.CustomerRecordId == id).FirstOrDefault();
                db.tblCustomerRecords.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Customer Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}