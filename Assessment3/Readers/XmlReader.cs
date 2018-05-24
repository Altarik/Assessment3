using Assessment3.Readers.Abstract;
using Assessment3.SecurityRoles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assessment3
{
    public class XmlReader : AbstractReader
    {
        private ISecurityRole SecurityRole;
        private string UserName = string.Empty;
        private string RoleName = string.Empty;

        public XmlReader(ISecurityRole securityRole = null, string userName = null, string roleName = null)
        {
            SecurityRole = securityRole;
            UserName = userName;
            RoleName = roleName;
        }

        public override string Read(string path)
        {
            try
            {
                //Set Security Role
                if (SecurityRole != null)
                {
                    SecurityRole.SetRights(UserName, RoleName);
                }

                return XDocument.Load(path).ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
