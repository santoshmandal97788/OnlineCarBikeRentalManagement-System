using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ResponseContact()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var lstcontact = db.tblContacts.ToList();
                return Json(new { data = lstcontact }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblContact tb = db.tblContacts.Where(c => c.ContactId == id).FirstOrDefault();
                db.tblContacts.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ResponseMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResponseMessage(int id, ResponseMessageViewModel rvm)
        {
            //https://www.google.com/settings/security/lesssecureapps
            //Make Access for less secure apps=true
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                tblContact tb = db.tblContacts.Where(x => x.ContactId == id).FirstOrDefault();
                //sm.IsConfirmed = "Confirmed";
                //string from = "santoshmandal97788@gmail.com";
               
                    try
                    {
                        //tblContact tb1 = db.tblContacts.Where(u => u.Email == tb.Email).FirstOrDefault();
                        if (tb != null)
                        {
                            var fromAddress = new MailAddress("santoshmandal97788@gmail.com", "santoshmandal97788");
                            var toAddress = new MailAddress(tb .Email, "To Name");
                        //Gmail password goes here
                            const string fromPassword = "";
                            const string subject = "OnlineCarBikeRental";
                            //const string body = rvm.message;

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
                                Body = rvm.Message
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
        }
        //public class ResponseMessageViewModel
        //{
        //    [Required]
        //    public string Message { get; set; }
        //}
    }
}