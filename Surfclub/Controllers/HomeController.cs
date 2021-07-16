using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Surfclub.dal;
using Surfclub.Helper;
using Surfclub.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var context = new DataContext();
            var news = context.News.Include(n => n.Author)

                .OrderByDescending(n => n.CreateDate).ToList();
            if(!news.Any())
            {
                ViewBag.Posts = new List<News>();
            } else
            {
                ViewBag.Posts = news;
            }
            return View();
        }

        [Authorize]

        [HttpPost]
        public async Task<IActionResult> AddNewPost(News news, IFormFile imageData)
        {
                     var context = new DataContext();

            if (string.IsNullOrEmpty(news.Text)
                && imageData == null)
            {
                ViewBag.Posts = context.News.Include(n => n.Author)

    .OrderByDescending(n => n.CreateDate).ToList();

                return View("Index");
            }

            news.AuthorId = 1;
            news.CreateDate = DateTime.Now;
            var helper = new ImageHelper();
            news.Photo = await helper.UploadImage(imageData);

            context.News.Add(news);
            context.SaveChanges();
            ViewBag.Posts = context.News.Include(n => n.Author)

    .OrderByDescending(n => n.CreateDate).ToList();
            
            return View("Index");
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new UserViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
