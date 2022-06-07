using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Controllers
{
    public class NewsController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        private IPageGroupRepository pageGroupRepository ;
        private IPageRepository pageRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
        }
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupForView());
        }

        public ActionResult ShowGroupInMenu()
        {
            return PartialView (pageGroupRepository.GetAllGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView (pageRepository.TopNews());
        }

    }
}