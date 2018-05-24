using Assessment3.Encryptions.Interface;
using Assessment3.SecurityRoles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.Readers.Abstract
{
    public abstract class AbstractReader
    {
        protected IEncryption ReaderEncryption;
        protected ISecurityRole SecurityRole;
        protected string UserName = string.Empty;
        protected string RoleName = string.Empty;

        public AbstractReader(IEncryption encryption = null, ISecurityRole securityRole = null, string userName = null, string roleName = null)
        {
            ReaderEncryption = encryption;
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

            //Decrypt encrypted file
            if (ReaderEncryption != null)
            {
                content = ReaderEncryption.Decrypt(content);
            }

            return content;
        }

        /// <summary>
        /// raw reading process (no security role based context or encryption implied)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected abstract string RawRead(string path);

    }
}
