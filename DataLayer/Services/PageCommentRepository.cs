using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private MyCmsContext db;

        public PageCommentRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public bool AddComent(PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<PageComment> GetCommentByNewsid(int pageId)
        {
            return (db.PageComments.Where(cm => cm.PageID == pageId));
        }

        public int CountComments(int id)
        {
            return (db.PageComments.Where(cm => cm.PageID == id).Count());
        }
    }
}
