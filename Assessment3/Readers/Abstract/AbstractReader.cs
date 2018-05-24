using Assessment3.Encryptions.Interface;
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

        public AbstractReader(IEncryption encryption = null)
        {
            ReaderEncryption = encryption;
        }
        
        public abstract string Read(string path);
        
    }
}
