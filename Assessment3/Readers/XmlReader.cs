using Assessment3.Encryptions.Interface;
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

        public XmlReader(IEncryption encryption = null, ISecurityRole securityRole = null, string userName = null, string roleName = null):base(encryption)
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

                string content = XDocument.Load(path).ToString();
                
                if (ReaderEncryption != null)
                {
                    content = ReaderEncryption.Decrypt(content);
                }

                return content;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
