using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Surfclub.dal;
using Surfclub.Helper;
using Surfclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.Controllers
{
    public class AccountController : Controller

    {


        public AccountController()
        {

        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model,IFormFile imageData)
        {
            var context = new DataContext();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Nickname==null ||model.Email== null|| model.Password==null|| model.CheckPassword==null )
            {
                ModelState.AddModelError(string.Empty, "Заполнены не все обязательные поля");



            }

            if (context.Users.Where(u => u.Nickname == model.Nickname).Any())
            {
                ModelState.AddModelError("Nickname", "Неверный пароль");
                return View(model);

            }
            if (context.Users.Where(u => u.Email == model.Email).Any())
            {
                ModelState.AddModelError("Email", "Неверная почта");
                return View(model);

            }


            User user = new User { Nickname = model.Nickname, Email = model.Email, Password = model.Password, LastName = model.LastName, FirstName = model.FirstName };
            // добавляем пользователя
            var helper = new ImageHelper();
            user.Photo = await helper.UploadImage(imageData);

            context.Users.Add(user);
            context.SaveChanges();

            await AuthenticateHelper.Authenticate(model.Nickname, false, HttpContext); // аутентификация

            if (user.Photo.HasValue && Guid.Empty != user.Photo.Value)
            {
                HttpContext.Session.SetString("Photo", user.Photo.Value.ToString());
            }

            return RedirectToAction("Index", "Home");




        }
    }
}



