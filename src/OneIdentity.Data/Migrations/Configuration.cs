namespace OneIdentity.Data.Migrations
{
    using Domain.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OneIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OneIdentityDbContext context)
        {
            context.Applications.AddOrUpdate(a => a.Id,
                new Application
                {
                    Id = "app1",
                    Name = "Application 1",
                    Description = "This is application 1",
                    Audiance= "Audiance1",
                    TokenLifetime = 60,
                    AllowRefreshToken = true,
                    IsActive = true
                }, new Application
                {
                    Id = "app2",
                    Name = "Application 2",
                    Description = "This is application 2",
                    Audiance = "Audiance2",
                    TokenLifetime = 60,
                    AllowRefreshToken = false,
                    IsActive = true
                });
        }
    }
}
