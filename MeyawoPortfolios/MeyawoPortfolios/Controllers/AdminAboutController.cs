using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminAboutController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {

            return View(db.TblAbout.FirstOrDefault());
        }
        public ActionResult UpdateAbout(TblAbout model)
        {
            var value = db.TblAbout.Find(model.AboutID);
            value.Title = model.Title;
            value.Description = model.Description;
            value.Header= model.Header;
            value.ImageUrl= model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}