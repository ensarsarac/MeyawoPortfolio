using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolios.Models;
namespace MeyawoPortfolios.Controllers
{
    public class AdminStatisticController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.totalCategory = db.TblCategory.Count();
            ViewBag.totalProject= db.TblProject.Count();
            ViewBag.totalContact = db.TblContact.Count();
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalTestimonial= db.TblTestimonial.Count();
            ViewBag.totalFlutter = db.TblProject.Where(x => x.TblCategory.CategoryName == "Flutter").Count();


            var values = db.TblProject.GroupBy(x => x.Category).Select(x => new
            {

                Count = x.Count(),
                Key = x.Key,
            }).ToList();

            var value = values.Where(x => x.Count == values.Max(y => y.Count)).Select(z => z.Key).FirstOrDefault();
            var valueName = db.TblCategory.Where(x => x.CategoryID == value).FirstOrDefault();
            ViewBag.val = valueName.CategoryName;
            return View();
        }
    }
}