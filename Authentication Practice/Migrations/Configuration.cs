using Authentication_Practice.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authentication_Practice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Authentication_Practice.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Authentication_Practice.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any())
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Developer"));
                roleManager.Create(new IdentityRole("NormalUser"));
            }
            if (!context.Users.Any(x => x.UserName == "kateramsey@live.com"))
            {
                var user = new ApplicationUser
                {
                    FirstName = "Kate",
                    LastName = "Ramsey",
                    DateOfBirth = DateTime.Parse("5/29/1985"),
                    Email = "kateramsey@live.com",
                    UserName = "kateramsey@live.com",
                    HomeTown = "Little Rock",
                };
                userManager.Create(user, "MyP@ssw0rd!");
          
                

                var user2 = new ApplicationUser
                {
                    FirstName = "Jennifer",
                    LastName = "Tate",
                    DateOfBirth = DateTime.Parse("9/19/1984"),
                    Email = "jstate@live.com",
                    UserName = "jstate@live.com",
                    HomeTown = "Dallas",
                };
                userManager.Create(user2, "MyP@ssw0rd!");

                var user3 = new ApplicationUser
                {
                    FirstName = "Bruce",
                    LastName = "Wills",
                    DateOfBirth = DateTime.Parse("1/24/1986"),
                    Email = "wills_martin@yahoo.com",
                    UserName = "wills_martin@yahoo.com",
                    HomeTown = "Little Rock",
                };
                userManager.Create(user3, "MyP@ssw0rd!");
                context.SaveChanges();

                userManager.AddToRole(user3.Id, "NormalUser");
                userManager.AddToRole(user2.Id, "Developer");
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
