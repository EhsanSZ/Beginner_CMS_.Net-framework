using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAllPage();

        Page GetPageByID(int id);

        bool InsertPage(Page page);

        bool UpdatePage(Page page);

        bool DeletePage(Page page);

        bool DeletePage(int id);

        void Save();

        IEnumerable<Page> TopNews(int take = 4);

        IEnumerable<Page> PagesInSlider();

        IEnumerable<Page> LastNews(int take =4);

        IEnumerable<Page> ShowPageByGroup(int groupId);

        IEnumerable<Page> SearchPage(string parameter);

    }
}
