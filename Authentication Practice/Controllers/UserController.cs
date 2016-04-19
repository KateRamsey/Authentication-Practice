using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication_Practice.Models;
using Microsoft.AspNet.Identity;

namespace Authentication_Practice.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            var model = db.Users.ToList().Select(l => new InfoVM()
            {
                DOB = l.DateOfBirth.ToShortDateString(),
                Email = l.Email,
                FirstName = l.FirstName,
                LastName = l.LastName
            });

       
            return View(model);
        }

        public ActionResult Info()
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            var model = new InfoVM()
            {
                DOB = currentUser.DateOfBirth.ToShortDateString(),
                Email = currentUser.Email,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName
            };
            return View(model);
        }
    }
}