using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DnD
{
    public static class EasyXML
    {
        public static bool SerializeXML<T>(T obj, string FilePath)
        {
            bool result = true;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fs = File.Open(FilePath, FileMode.Create);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            try
            {
                ser.Serialize(fs, obj, ns);
            }
            catch
            {
                result = false;
            }
            fs.Close();
            return result;
        }
        public static T DeserializeXML<T>(string FilePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fs = File.Open(FilePath, FileMode.Open);
            T result = default(T);
            using (XmlReader red = XmlReader.Create(fs, new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true }))
            {
                try
                {
                    result = (T)ser.Deserialize(red);
                }
                catch { }
                fs.Close();
            }
            return result;
        }
    }
}
