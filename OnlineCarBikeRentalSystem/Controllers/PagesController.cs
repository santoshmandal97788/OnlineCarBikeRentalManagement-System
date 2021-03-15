using OnlineCarBikeRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public ActionResult Pricing()
        {
            return View(_db.tblPackageContents.ToList());
        }
        public ActionResult Driver()
        {
            return View(_db.tblDrivers.ToList());
        }
        public PartialViewResult FaqHeading()
        {
            return PartialView("faqheading", _db.tblFaqHeadings.ToList());
        }
        public PartialViewResult FaqHeading1()
        {
            return PartialView("faqheading1", _db.tblFaqHeadings.ToList());
        }
        public PartialViewResult QASection()
        {
            return PartialView("qasection", _db.tblFaqQAs.ToList());
        }
        public PartialViewResult QASection1()
        {
            return PartialView("qasection1", _db.tblFaqQAs.ToList());
        }
        public ActionResult Faq()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult HelpDesk()
        {
            return View(_db.tblHelpDesks.ToList());
        }
    }
}