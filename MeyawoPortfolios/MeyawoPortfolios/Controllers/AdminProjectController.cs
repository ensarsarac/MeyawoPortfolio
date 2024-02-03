using MeyawoPortfolios.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminProjectController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
		{
            var values = db.TblCategory.ToList();
			ViewBag.categoryList = new SelectList(values, "CategoryID", "CategoryName");
			return View();
		}
        [HttpPost]
        public ActionResult CreateProject(TblProject model)
        {
            db.TblProject.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
			ViewBag.categoryList = new SelectList(db.TblCategory.ToList(), "CategoryID", "CategoryName");
			var value = db.TblProject.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            var value = db.TblProject.Where(x => x.ProjectID == model.ProjectID).FirstOrDefault();
            value.Title = model.Title;
            value.ProjectUrl = model.ProjectUrl;
            value.ImageUrl = model.ImageUrl;
            value.Description= model.Description;
            value.Category = model.Category;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}