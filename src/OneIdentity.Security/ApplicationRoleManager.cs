using Microsoft.AspNet.Identity;
using OneIdentity.Security.Entity;

namespace OneIdentity.Security
{
    public class ApplicationRoleManager: RoleManager<ApplicationRole, string>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {

        }
    }
}
