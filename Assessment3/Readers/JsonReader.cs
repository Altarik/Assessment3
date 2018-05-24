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
        protected IEncryption ReaderEncryption;

        public JsonReader(IEncryption encryption)
        {
            ReaderEncryption = encryption;
        }

        public string Read(string path)
        {
            // Read content
            string content = RawRead(path);

            //Decrypt encrypted file
            if (ReaderEncryption != null)
            {
                content = ReaderEncryption.Decrypt(content);
            }

            return content;
        }

        private string RawRead(string path)
        {
            throw new NotImplementedException();
        }
    }
}
