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
        public string  Title { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Display(Name = "AuthorRating")]
        public long AuthorRating { get; set; }

        public string AuthorId { get; set; }

        [Display(Name = "Data Posted")]
        public string DatePosted { get; set; }

        public List<SelectListItem> Forum { get; set; }
        public List<SelectListItem> PostReply { get; set; }


        public class PostListViewModel
        {

            public PostListViewModel()
            {
                PostList = new List<PostViewModel>();
            }

            public List<PostViewModel> PostList { get; set; }
        }
    }
}
