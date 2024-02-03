using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminSocialMediaController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {

            return View(db.TblSocialMedia.ToList());
        }
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
		public ActionResult CreateSocialMedia(TblSocialMedia model)
		{
            db.TblSocialMedia.Add(model);
            db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteSocialMedia(int id)
		{
			db.TblSocialMedia.Remove(db.TblSocialMedia.Find(id));
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateSocialMedia(int id)
		{			
			return View(db.TblSocialMedia.Find(id));
		}
		[HttpPost]
		public ActionResult UpdateSocialMedia(TblSocialMedia model)
		{
			var value = db.TblSocialMedia.Find(model.SocialMediaID);
			value.Title = model.Title;
			value.Icon = model.Icon;
			value.Url= model.Url;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}