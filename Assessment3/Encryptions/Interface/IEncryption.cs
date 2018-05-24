using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.Encryptions.Interface
{
    public interface IEncryption
    {
        string Decrypt(string encryptedText);
    }
}
