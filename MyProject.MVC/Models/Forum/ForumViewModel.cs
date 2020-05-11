using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.MVC.Models.Forum
{
    public class ForumViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        public List<SelectListItem> Posts { get; set; }
        public List<SelectListItem> User { get; set; }

    }
    public class ForumListViewModel
    {

        public ForumListViewModel()
        {
            ForumList = new List<ForumViewModel>();
        }

        public List<ForumViewModel> ForumList { get; set; }
    }
}
