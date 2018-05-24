using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.SecurityRoles.Interface
{
    public interface ISecurityRole
    {
        void SetRights(string username, string roleName);
    }
}
