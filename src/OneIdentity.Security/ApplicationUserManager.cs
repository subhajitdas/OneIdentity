using Microsoft.AspNet.Identity;
using OneIdentity.Security.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Security
{
    public class ApplicationUserManager : UserManager<ApplicationUser, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, string> userStore)
            : base(userStore)
        {
            this.UserValidator = new UserValidator<ApplicationUser, string>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            this.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                RequiredLength = 6
            };
        }
    }
}
