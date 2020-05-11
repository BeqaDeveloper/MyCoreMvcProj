using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.MVC.Models.Post
{
    public class PostViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        [Display(Name = "Post Title")]
        public string Title { get; set; }
        [Display(Name = "Content")]
        public string content { get; set; }
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        public List<SelectListItem> Replies { get; set; }
    }

    public class PostListViewModel
    {

        public PostListViewModel()
        {
            PostList = new List<PostViewModel>();
        }
        public List<PostViewModel> PostList { get; set; }
    }
}
