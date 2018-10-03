namespace SmileTech.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SmileTech.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SmileTech.Data.SmileTechDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmileTech.Data.SmileTechDbContext context)
        {
            CreateUser(context);
        }

        private void CreateUser(SmileTechDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SmileTechDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SmileTechDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "khanhpham",
                Email = "phamkhanh1811@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Smile Tech"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("phamkhanh1811@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
