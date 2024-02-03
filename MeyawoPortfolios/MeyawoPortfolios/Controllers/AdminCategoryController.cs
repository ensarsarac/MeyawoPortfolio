using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminCategoryController : Controller
    {

		DbMyPortfolioEntities db = new DbMyPortfolioEntities();
		public ActionResult Index()
		{
			var values = db.TblCategory.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateCategory(TblCategory model)
		{
			db.TblCategory.Add(model);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCategory(int id)
		{
			var value = db.TblCategory.Find(id);
			db.TblCategory.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UpdateCategory(int id)
		{
			var value=db.TblCategory.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateCategory(TblCategory model)
		{
			var value = db.TblCategory.Find(model.CategoryID);
			value.CategoryName = model.CategoryName;
			db.SaveChanges();
			return RedirectToAction("Index");
		}





	}
}