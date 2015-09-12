namespace OneIdentity.Security.Migrations
{
    using Entity;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationIdentityDbContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new ApplicationUserStore(context));
            ApplicationRoleManager roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));

            if (!roleManager.RoleExists("ServerAdmin"))
            {
                roleManager.Create(new ApplicationRole
                {
                    Name = "ServerAdmin"
                });
            }

            if (!roleManager.RoleExists("GeneralUser"))
            {
                roleManager.Create(new ApplicationRole
                {
                    Name = "GeneralUser"
                });
            }

            var serverAdminUser = userManager.FindByName("serveradmin");
            if (serverAdminUser == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "serveradmin",
                    FirstName = "Server",
                    LastName = "Admin",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    Email = "admin@gmail.com"
                }, "Password1$");
            }

            var user1 = userManager.FindByName("user1");
            if (user1 == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "user1",
                    FirstName = "Subhajit",
                    LastName = "Das",
                    Email = "user1@gmail.com",
                    DateOfBirth = DateTime.Now.AddYears(-29),
                }, "Password1$");
            }

            var user2 = userManager.FindByName("user2");
            if (user2 == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "user2",
                    FirstName = "Padmabati",
                    LastName = "Sen",
                    DateOfBirth = DateTime.Now.AddYears(-27),
                    Email = "user2@gmail.com",
                }, "Password1$");
            }
            userManager.AddToRoles(userManager.FindByName("serveradmin").Id, "ServerAdmin", "GeneralUser");
            userManager.AddToRoles(userManager.FindByName("user1").Id, "GeneralUser");
            userManager.AddToRoles(userManager.FindByName("user2").Id, "GeneralUser");
        }
    }
}
