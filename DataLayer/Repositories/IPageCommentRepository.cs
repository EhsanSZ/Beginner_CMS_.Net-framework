using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetCommentByNewsid(int pageId);
        bool AddComent (PageComment comment);
        int CountComments(int id);
    }
}
