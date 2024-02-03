using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminServiceController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            
            return View(db.TblService.ToList());
        }
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
		public ActionResult CreateService(TblService model)
		{
            db.TblService.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
        public ActionResult DeleteService(int id)
        {
            db.TblService.Remove(db.TblService.Find(id)); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateService(int id)
        {
            return View(db.TblService.Find(id));
        }
        [HttpPost]
		public ActionResult UpdateService(TblService model)
		{
            var value = db.TblService.Find(model.ServiceID);
            value.Title = model.Title;
            value.Description= model.Description;   
            value.ImageUrl= model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
		}




	}
}