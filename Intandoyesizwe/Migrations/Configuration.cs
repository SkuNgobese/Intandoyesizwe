namespace Intandoyesizwe.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Intandoyesizwe.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Intandoyesizwe.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@intandoyesizwe.org";
                user.Email = "admin@intandoyesizwe.org";
                string userPwd = "@IntandoAdmin1*";
                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }
            var admn = context.Users.ToList().Find(p => p.UserName == "info@intandoyesizwe.org");
            if(admn == null)
            {
                var user = new ApplicationUser();
                user.UserName = "info@intandoyesizwe.org";
                user.Email = "info@intandoyesizwe.org";
                string userPwd = "@IntandoAdmin1*";
                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}