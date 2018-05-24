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
    public class TextReader : AbstractReader
    {
        public TextReader(IEncryption encryption = null, ISecurityRole securityRole = null, string userName = null, string roleName = null) :base(encryption, securityRole, userName, roleName)
        {
        }

        protected override string RawRead(string path)
        {
            try
            {
                string content = File.ReadAllText(path);
                
                return content;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
