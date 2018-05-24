using Assessment3.Encryptions.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.Encryptions
{
    public class ReverseEncryption:IEncryption
    {
        public string Decrypt(string encryptedText)
        {
            char[] charArray = encryptedText.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
