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
        public XmlReader(IEncryption encryption = null, ISecurityRole securityRole = null, string userName = null, string roleName = null):base(encryption, securityRole, userName, roleName)
        {
        }

        protected override string RawRead(string path)
        {
            try
            {   
                string content = XDocument.Load(path).ToString();
                
                return content;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
