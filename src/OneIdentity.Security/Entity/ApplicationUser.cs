using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace OneIdentity.Security.Entity
{
    public class ApplicationUser: IdentityUser<string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
