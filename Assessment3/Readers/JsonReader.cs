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
    public class JsonReader:AbstractReader
    {
        public JsonReader(IEncryption encryption = null, ISecurityRole securityRole = null, string userName = null, string roleName = null) : base(encryption, securityRole, userName, roleName)
        {
        }
        
        protected override string RawRead(string path)
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
