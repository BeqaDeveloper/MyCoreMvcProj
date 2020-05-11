using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.MVC.Models.Post.PostReply
{
    public class PostReplyViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        [Display(Name = "Reply Content")]
        public string Content { get; set; }
        [Display(Name = "Replied Date")]
        public DateTime Created { get; set; }

        public class PostReplyListViewModel
        {

            public PostReplyListViewModel()
            {
                PostReplyList = new List<PostReplyViewModel>();
            }

            public List<PostReplyViewModel> PostReplyList { get; set; }
        }
    }
}
