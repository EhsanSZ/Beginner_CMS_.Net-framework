using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository : IDisposable
    {
        
        IEnumerable<PageGroup> GetAllGroups();

        PageGroup GetPageGroupByID(int id);

        bool InsertGroup(PageGroup group);

        bool UpdateGroup(PageGroup group);

        bool DeleteGroup(PageGroup group);

        bool DeleteGroup(int id);

        void Save();

        IEnumerable<ShowGroupViewModel> GetGroupForView();


    }
}
