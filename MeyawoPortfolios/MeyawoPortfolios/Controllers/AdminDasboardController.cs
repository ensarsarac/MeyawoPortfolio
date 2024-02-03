using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolios.Models;
namespace MeyawoPortfolios.Controllers
{
    public class AdminDasboardController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.v = db.TblCategory.Count();
            ViewBag.v1 = db.TblProject.Count();
            ViewBag.v2 = db.TblContact.Count();
            var values = db.TblProject.GroupBy(x => x.Category).Select(x => new
            {

                Count = x.Count(),
                Key = x.Key,
            }).ToList();

            var value = values.Where(x => x.Count == values.Max(y => y.Count)).Select(z => z.Key).FirstOrDefault();
            var valueName = db.TblCategory.Where(x => x.CategoryID == value).FirstOrDefault();
            ViewBag.v3 = valueName.CategoryName;
            ViewBag.v4 = db.TblProject.ToList();
            return View();
        }
    }
}