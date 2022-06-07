using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;

namespace MyCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class PageGroupsController : Controller
    {
        private IPageGroupRepository pageGroupRepository;

        MyCmsContext db = new MyCmsContext();

        public PageGroupsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
        }
        public ActionResult Index()
        {
            return View(pageGroupRepository.GetAllGroups());
        }


        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.InsertGroup(pageGroup);
                pageGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetPageGroupByID(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.UpdateGroup(pageGroup);
                pageGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetPageGroupByID(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pageGroupRepository.DeleteGroup(id);
            pageGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
