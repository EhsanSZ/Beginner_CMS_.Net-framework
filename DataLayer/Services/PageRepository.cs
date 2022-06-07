using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private MyCmsContext db;

        public PageRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int id)
        {
            try
            {
                var page = GetPageByID(id);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageByID(int id)
        {
            return db.Pages.Find(id);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p=> p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroup(int groupId)
        {
            return (db.Pages.Where(p=> p.GroupID == groupId));
        }

        public IEnumerable<Page> SearchPage(string parameter)
        {
            return (db.Pages.Where(p => p.Title.Contains(parameter) || p.ShortDescription.Contains(parameter) 
            || p.Tags.Contains(parameter) || p.Text.Contains(parameter))).Distinct();
        }
    }
}
