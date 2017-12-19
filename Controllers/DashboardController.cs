
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
    
    public class DashboardController : Controller

    {
        private ExamContext _context;
        private User ActiveUser 
        {
            get{ return _context.Users.Where(u => u.UserID == HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }
        public DashboardController(ExamContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard(int Id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                
                return RedirectToAction("Index","Home");
            }
            // Activity oneActivity =_context.Activities.Where(p=>p.ActivityId==Id).SingleOrDefault();
            
            // int CreatedById = oneActivity.Coordinator;
            
            // User CreatedByDB =  _context.Users.Where(u => u.UserID== CreatedById).SingleOrDefault(); 
            // ViewBag.CreatedByDB = CreatedByDB;
            
            User currentUser = _context.Users.SingleOrDefault(user => user.UserID == Id);
            // List<Activity> allActivities = _context.Activities.Include(activity => activity.JoiningUser).ToList();
            ViewBag.User = currentUser;
            // ViewBag.Activities = allActivities;
            
             List<Activity> Places = _context.Activities.ToList();
             
            
            
          
            return View("Dashboard",Places);
        }
        [HttpGet]
        [Route("AddActivity")]
        public IActionResult AddActivity()
        {
            
            return View();
        }
        [HttpPost]
        [Route("CreateActivity")]
        public IActionResult CreateActivity(ActivityViewModel newActivity)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                
                return RedirectToAction("Index","Home");
            }
            
            int userSession = HttpContext.Session.GetInt32("UserId")?? default(int);
            
            if(ModelState.IsValid)
            {
                Activity activity = new Activity
            {
                Title = newActivity.Title,
                Description = newActivity.Description,
                Date = newActivity.Date,
                Time = newActivity.Time,
                Duration = newActivity.Duration,
                Coordinator = userSession
                
            }; 
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
            }
            return View("AddActivity");
        }
        [HttpGet]
        [Route("Show/{Id}")]
        public IActionResult Show(int Id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                
                return RedirectToAction("Index","Home");
            }
            
            Activity oneActivity =_context.Activities.Where(p=>p.ActivityId==Id).SingleOrDefault();
            
            int CreatedById = oneActivity.Coordinator;
            
            User CreatedByDB =  _context.Users.Where(u => u.UserID== CreatedById).SingleOrDefault(); 
           
            
            ViewBag.CreatedByDB = CreatedByDB;
            List<Activity> getsameactivity = _context.Activities.Where(p=>p.ActivityId==Id)
                                                        .Include(w => w.JoiningUser )   
                                                        .ThenInclude(u=>u.JoiningUser)
                                                        .ToList();
            
            ViewBag.getsameactivity = getsameactivity;
            ViewBag.oneActivity =oneActivity; 

            return View();
        }
        [HttpGet]
        [Route("AddToMyList/{Id}")]
        public IActionResult AddToMyList(int Id)
        {
            UserActivity MyUserActivity = new UserActivity
            {
                UserId =(int) HttpContext.Session.GetInt32("UserId"),
                ActivityId = Id
            };
            _context.UserActivities.Add(MyUserActivity);
            _context.SaveChanges();
            return RedirectToAction("Show");
            
        }
        [HttpGet]
        [RouteAttribute("delete/{Id}")]
        public IActionResult DeleteActivity(int Id)
        {
            Activity activityToDelete = _context.Activities.SingleOrDefault(activity => activity.ActivityId == Id);
            _context.Activities.Remove(activityToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}