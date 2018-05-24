using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public class TextReader
    {
        public string Read(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
