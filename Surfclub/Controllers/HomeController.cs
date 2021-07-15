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
        public async Task AddNewPost(News news, IFormFile imageData)
        {
         
            if (string.IsNullOrEmpty(news.Text)
                && imageData == null)
            {
                return;
            }

            news.AuthorId = 1;
            news.CreateDate = DateTime.Now;
            var helper = new ImageHelper();
            news.Photo = await helper.UploadImage(imageData);

            var context = new DataContext();
            context.News.Add(news);
            context.SaveChanges();
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
