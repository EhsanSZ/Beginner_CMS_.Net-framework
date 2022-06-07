using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Controllers
{
    public class HomeController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        private IPageRepository pageRepository;
        private IPageCommentRepository commentRepository;

        public HomeController()
        {
            pageRepository = new PageRepository(db);
            commentRepository = new PageCommentRepository(db);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(pageRepository.PagesInSlider());
        }

        public ActionResult LetsNews()
        {
            return PartialView(pageRepository.LastNews());
        }


        [Route("Archive")]
        public ActionResult Archive()
        {
            return View(pageRepository.GetAllPage());
        }

        public ActionResult ShowNewsByGroupId(int id, string name)
        {
            ViewBag.name = name;
            return View(pageRepository.ShowPageByGroup(id));
        }


        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageByID(id);
            //ViewBag.CountCM = commentRepository.CountComments(id);

            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;

            pageRepository.UpdatePage(news);
            pageRepository.Save();

            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment pageComment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Name = name,
                Email = email,
                Comment = comment
            };

            commentRepository.AddComent(pageComment);

            return PartialView("ShowComments", commentRepository.GetCommentByNewsid(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(commentRepository.GetCommentByNewsid(id));

        }


    }
}