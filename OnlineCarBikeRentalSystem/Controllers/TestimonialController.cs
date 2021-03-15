using OnlineCarBikeRentalSystem.Models.Services;
using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        TestimonialDB tdb = new TestimonialDB();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(tdb.GetTestimonialList());
        }
        public ActionResult AddNewTestimonial()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewTestimonial(TestimonialViewModel tvm)
        {
            HttpPostedFileBase fup = Request.Files["Image"];
            if (fup != null)
            {
                tvm.Image = fup.FileName;
                fup.SaveAs(Server.MapPath("~/img/Testimonial/" + fup.FileName));
            }
            tdb.AddNewTestimonial(tvm);

            return RedirectToAction("Index");
        }
        public ActionResult EditTestimonial(int id)
        {
            TestimonialViewModel tvm = tdb.GetTestimonialList().Where(t => t.Id == id).FirstOrDefault();
            return View(tvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTestimonial(TestimonialViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase fup = Request.Files["Image"];
                if (fup != null)
                {
                    if (fup.FileName != "")
                    {
                        string oldfile = tvm.Image;
                        System.IO.File.Delete(Server.MapPath("~/img/Testimonial/" + oldfile));

                        tvm.Image = fup.FileName;
                        fup.SaveAs(Server.MapPath("~/img/Testimonial/" + fup.FileName));
                    }

                }
                tdb.Edit(tvm);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            TestimonialViewModel tvm = tdb.GetTestimonialList().Where(t => t.Id == id).FirstOrDefault();
            return View(tvm);
        }
        [HttpPost, ActionName("DeleteTestimonial")]
        public ActionResult Delete_post(int id)
        {
            tdb.Delete(id);
            return RedirectToAction("Index");
        }
    }
}