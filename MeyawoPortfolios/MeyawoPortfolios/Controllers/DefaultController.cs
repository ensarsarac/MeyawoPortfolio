using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
		public PartialViewResult NavbarPartial()
		{
			return PartialView();
		}
        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView(db.TblSocialMedia.ToList());
        }
		public PartialViewResult FeaturePartial()
		{
            return PartialView(db.TblFeature.FirstOrDefault());
		}
		public PartialViewResult AboutPartial()
		{
			return PartialView(db.TblAbout.FirstOrDefault());
		}
		public PartialViewResult ServicePartial()
		{
			return PartialView(db.TblService.ToList());
		}
		public PartialViewResult ProjectPartial()
		{
			return PartialView(db.TblProject.ToList());
		}
		public PartialViewResult TestimonialPartial()
		{
			return PartialView(db.TblTestimonial.ToList());
		}
		public PartialViewResult ContactPartial()
		{
			return PartialView();
		}
		[HttpPost]
		public ActionResult SendMessage(TblContact model)
        {
			model.SendDate = DateTime.Now;
			model.IsRead = false;
			db.TblContact.Add(model);
			db.SaveChanges();
			return RedirectToAction("Index");
        }
	}
}