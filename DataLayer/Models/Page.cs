using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Page


    {
        private ICollection<PageComment> _pageComment;
        public Page()
        {
            _pageComment = new List<PageComment>();
        }

        [Key]
        public int PageID { get; set; }


        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupID { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Title { get; set; }


        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }


        [Display(Name = "تصویر")]
        public string ImageName { get; set; }


        [Display(Name = "بازدید")]
        public int Visit { get; set; }


        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd }")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }

        public virtual PageGroup PageGroup { get; set; }

        public virtual ICollection<PageComment> PageComment
        {
            get { return _pageComment; }
            set { _pageComment = value; }
        }


    }

    //public class PageMappings : EntityTypeConfiguration<Page>
    //{
    //    public PageMappings()
    //    {
    //        HasKey(p => p.PageID);
    //        //Property(p => p.Text).HasColumnName("News");
    //        Property(p => p.ImageName).IsUnicode(false);
    //        HasRequired(p => p.Title);
    //        ToTable("Page");
    //    }
    //}
}
