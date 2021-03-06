﻿using Microsoft.Owin;
using Owin;
using RedBadgeProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Movie.Data;

[assembly: OwinStartupAttribute(typeof(RedBadgeProject.Startup))]
namespace RedBadgeProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext ADC = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ADC));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ADC));

            if (!roleManager.RoleExists("Administrator"))
            {
                var adminRole = new IdentityRole();
                adminRole.Name = "Administrator";
                roleManager.Create(adminRole);

                var superUser = new ApplicationUser();
                superUser.UserName = "Admin";
                superUser.Email = "admin@flixnchill.com";

                string pass = "Admin12!";

                userManager.Create(superUser, pass);

                userManager.AddToRole(superUser.Id, "Administrator");
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var managerRole = new IdentityRole();
                managerRole.Name = "Manager";
                roleManager.Create(managerRole);
            }
        }
    }
}