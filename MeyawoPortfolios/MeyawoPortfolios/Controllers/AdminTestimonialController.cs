using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminTestimonialController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            return View(db.TblTestimonial.ToList());
        }
        public ActionResult ActiveTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
		public ActionResult PassiveTestimonial(int id)
		{
			var value = db.TblTestimonial.Find(id);
			value.Status = false;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}