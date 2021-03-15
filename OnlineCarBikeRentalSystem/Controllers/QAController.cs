using OnlineCarBikeRentalSystem.Models;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class QAController : Controller
    {
        // GET: QA
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult ManageQA()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var qalst = db.tblFaqQAs.Select(x => new { Id = x.Id, FaqHeading = x.tblFaqHeading.FaqHeading, Question = x.Question, Answer = x.Answer }).ToList();

                return Json(new { data = qalst }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    ViewBag.faqheading = db.tblFaqHeadings.ToList();
                    ViewBag.Action = "Add New QA";
                    return View(new QAViewModel());
                }
            }
            else
            {
                using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
                {
                    QAViewModel qavm = new QAViewModel();
                    tblFaqQA tb = db.tblFaqQAs.Where(x => x.Id == id).FirstOrDefault();
                    ViewBag.Action = "Edit QA";
                    qavm.Id = tb.Id;
                    qavm.FaqId = tb.FaqId;
                    qavm.Question = tb.Question;
                    qavm.Answer = tb.Answer;
                    ViewBag.faqheading = db.tblFaqHeadings.ToList();
                    return View(qavm);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(QAViewModel qavm)
        {
            using (OnlineCarBikeRentalDBEntities db = new OnlineCarBikeRentalDBEntities())
            {
                if (qavm.Id == 0)
                {
                    tblFaqQA tb = new tblFaqQA();
                    tb.FaqId = qavm.FaqId;
                    tb.Question = qavm.Question;
                    tb.Answer = qavm.Answer;
                    db.tblFaqQAs.Add(tb);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblFaqQA tb = db.tblFaqQAs.Where(q => q.Id == qavm.Id).FirstOrDefault();
                    tb.FaqId = qavm.FaqId;
                    tb.Question = qavm.Question;
                    tb.Answer = qavm.Answer;
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
                tblFaqQA tb = db.tblFaqQAs.Where(q => q.Id == id).FirstOrDefault();
                db.tblFaqQAs.Remove(tb);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}