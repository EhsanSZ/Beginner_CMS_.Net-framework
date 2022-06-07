using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.Web.Mvc;

namespace MyCMS.Controllers
{
    public class SearchController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        private IPageRepository pageRepository;
        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}