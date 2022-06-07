using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContext db;

        public PageGroupRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public bool DeleteGroup(PageGroup group)
        {
            try
            {
                db.Entry(group).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(int id)
        {
            try
            {
                var group = GetPageGroupByID(id);
                DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroups;
        }

        public PageGroup GetPageGroupByID(int id)
        {
            return db.PageGroups.Find(id);
        }

        public bool InsertGroup(PageGroup group)
        {
            try
            {
                db.PageGroups.Add(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateGroup(PageGroup group)
        {
            try
            {
                db.Entry(group).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<ShowGroupViewModel> GetGroupForView()
        {
            return db.PageGroups.Select(e => new ShowGroupViewModel
            {
                GroupID = e.GroupID,
                GroupTitle = e.GroupTitle,
                PageCount = e.Pages.Count
            });
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}
