using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication_Practice.Models;

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
                DOB = l.DateOfBirth,
                Email = l.Email,
                FirstName = l.FirstName,
                LastName = l.LastName
            });

       
            return View(model);
        }

        public ActionResult Info()
        {
            var currentUser = User;
            var model = new InfoVM()
            {};
            return View(model);
        }
    }
}