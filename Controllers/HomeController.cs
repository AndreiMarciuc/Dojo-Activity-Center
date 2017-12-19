using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exam.Models;


namespace exam.Controllers
{
    
    public class HomeController : Controller

    {
        private ExamContext _context;
        public HomeController(ExamContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/Register")]
        public IActionResult Register(UserViewModel model)
        {
            User CheckUser = _context.Users.SingleOrDefault(User=>User.Email == model.Email);
            if(CheckUser !=null)
            {
                ViewBag.Err = "Email already exists";
            }
             else if(ModelState.IsValid){
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User NewUser = new User();
                NewUser.FirstName = model.FirstName;
                NewUser.LastName = model.LastName;
                NewUser.Email = model.Email;
                NewUser.Password= Hasher.HashPassword(NewUser ,model.Password);
                NewUser.CreatedAt = DateTime.Now;
                NewUser.UpdatedAt = DateTime.Now;
                _context.Users.Add(NewUser);
                _context.SaveChanges();
                User LoggedUser = _context.Users.SingleOrDefault(user=>user.Email == model.Email);
                HttpContext.Session.SetInt32("UserId", LoggedUser.UserID);
                return RedirectToAction("Dashboard","Dashboard");
             }
            return View("Index");
        }
        [HttpPost]
        [Route("Home/LogIn")]
        public IActionResult LogIn(string email, string Password)
        {
            User CheckUser = _context.Users.SingleOrDefault(User=>User.Email == email);
            if(CheckUser !=null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(CheckUser,CheckUser.Password,Password))
                {
                    HttpContext.Session.SetInt32("UserId", CheckUser.UserID);
                    return RedirectToAction("Dashboard","Dashboard");
                    };
                }
                ViewBag.Err= "Email and/or are incorect";
                return View("Index");
           
            

        }
        [HttpPost]
        [Route("Home/LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    
    }
}
