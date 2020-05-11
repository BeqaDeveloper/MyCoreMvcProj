using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Domain.Interfaces;

namespace MyProject.MVC.Controllers
{
    public class ForumController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IForumService forumService;

        public IActionResult Index()
        {
            return View();
        }
    }
}