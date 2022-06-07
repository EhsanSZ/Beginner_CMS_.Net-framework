using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroup

    {
        private ICollection<Page> _pages;

        public PageGroup()
        {
            _pages = new List<Page>();
        }

        [Key]
        public int GroupID { get; set; }

        [Display(Name = "گروه خبری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string GroupTitle { get; set; }

        public virtual ICollection<Page> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

    }

}
