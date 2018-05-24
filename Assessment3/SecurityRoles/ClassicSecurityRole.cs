using Assessment3.SecurityRoles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment3.SecurityRoles
{
    public class ClassicSecurityRole : ISecurityRole
    {
        public void SetRights(string username, string roleName)
        {
            GenericIdentity identity = new GenericIdentity(username);
            Thread.CurrentPrincipal = new GenericPrincipal(identity, new string[] { roleName });
        }
    }
}
