using MeyawoPortfolios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolios.Controllers
{
    public class AdminLayoutController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SideBarPartial()
        {
            
            return PartialView();
        }
		public PartialViewResult _HeadPartial()
		{
			return PartialView();
		}
		public PartialViewResult _ScriptPartial()
		{
			return PartialView();
		}
        public PartialViewResult _SideBarProfilePartial()
        {
            string s = "deneme";
            return PartialView(s);
        }
    }
}