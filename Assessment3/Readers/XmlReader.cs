using Assessment3.Readers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assessment3
{
    public class XmlReader : AbstractReader
    {
        public override string Read(string path)
        {
            try
            {
                return XDocument.Load(path).ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
