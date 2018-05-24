using Assessment3.Encryptions.Interface;
using Assessment3.Readers.Abstract;
using Assessment3.SecurityRoles.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        protected IEncryption ReaderEncryption;
        protected ISecurityRole SecurityRole;
        protected string UserName = string.Empty;
        protected string RoleName = string.Empty;

        public JsonReader(IEncryption encryption = null, ISecurityRole securityRole = null, string userName = null, string roleName = null)
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

            if (ReaderEncryption != null)
            {
                content = ReaderEncryption.Decrypt(content);
            }

            return content;
        }

        private string RawRead(string path)
        {
            try
            {
                using (StreamReader file = File.OpenText(path))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                    return jsonObject.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
