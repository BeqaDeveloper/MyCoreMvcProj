using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Domain.Interfaces;
using MyProject.MVC.Models.Forum;

namespace MyProject.MVC.Controllers
{
    public class ForumController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IForumService _forumService;
        private readonly IPostService _postService;

        public ForumController( IMapper mapper, IForumService forumService)
        {
            _mapper = mapper;
            _forumService = forumService;
        }

        /// <summary>
        /// ფორუმების წამოღება ბაზიდან.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var forumList = _forumService.Set().ToList();
            var forumListViewModel = new ForumListViewModel();
            _mapper.Map(forumList, forumListViewModel.ForumList);
            return View(forumListViewModel);
        }


        public IActionResult Topic(int id)
        {
            var posts = _postService.Set().ToList();
            return View(posts);
        }
    }
}