using Assessment3.Encryptions.Interface;
using Assessment3.Readers.Abstract;
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
        public TextReader(IEncryption encryption = null):base(encryption)
        {
        }

        public override string Read(string path)
        {
            try
            {
                string content = File.ReadAllText(path);

                if(ReaderEncryption != null)
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
