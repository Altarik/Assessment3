using Assessment3.Encryptions.Interface;
using Assessment3.Readers.Abstract;
using Assessment3.SecurityRoles.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public class JsonReader
    {
        protected ISecurityRole SecurityRole;
        protected string UserName = string.Empty;
        protected string RoleName = string.Empty;

        public JsonReader(ISecurityRole securityRole = null, string userName = null, string roleName = null)
        {
            SecurityRole = securityRole;
            UserName = userName;
            RoleName = roleName;
        }

        public string Read(string path)
        {
            //Set Security Role
            if (SecurityRole != null)
            {
                SecurityRole.SetRights(UserName, RoleName);
            }

            // Read content
            string content = RawRead(path);
            
            return content;
        }

        private string RawRead(string path)
        {
            throw new NotImplementedException();
        }
    }
}
