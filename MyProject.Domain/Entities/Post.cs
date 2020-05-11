using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
        public DateTime Created { get; set; }

        //Lazy-Loading
        public virtual ApplicationUser User { get; set; }
        public virtual Forum Forum { get; set; }
    }
}
