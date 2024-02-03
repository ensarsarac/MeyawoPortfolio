using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminFeatureController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblFeature.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature model)
        {
            var value = db.TblFeature.Find(model.FeatureID);
            value.Title = model.Title;
            value.NameSurname = model.NameSurname;
            value.Header = model.Header;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}