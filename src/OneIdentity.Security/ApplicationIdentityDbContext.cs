using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using OneIdentity.Security.Entity;

namespace OneIdentity.Security
{
    public class ApplicationIdentityDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationIdentityDbContext()
            : base(nameOrConnectionString: "OneIdentityDbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).IsUnicode(false).IsFixedLength().HasMaxLength(32);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.FirstName).IsRequired().HasMaxLength(63);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.LastName).IsRequired().HasMaxLength(63);
            modelBuilder.Entity<ApplicationRole>().Property(u => u.Id).IsUnicode(false).IsFixedLength().HasMaxLength(32);
            base.OnModelCreating(modelBuilder);
        }
    }
}
