using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace WpfApp1
{
    class XMLWriter
    {
        public static bool ExportToXML(string address, List<StudentSerializable> list)
        {
            address = Path.ChangeExtension(address, "xml");
            
            XmlSerializer export = new XmlSerializer(typeof(List<StudentSerializable>));
            try
            {
                FileStream stream = new FileStream(address, FileMode.Create, FileAccess.Write);
                export.Serialize(stream, list);
                stream.Flush();
                stream.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
