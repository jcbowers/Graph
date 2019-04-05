using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using GraphBulkImporter.Model;

namespace GraphBulkImporter
{
    class GraphExtractor
    {
        public ObjectList LoadObjects()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObjectList));
            ObjectList objects = null;

            using (StreamReader reader = new StreamReader(ConfigurationManager.AppSettings["nodeDataPath"]))
            {
                objects = (ObjectList)serializer.Deserialize(reader);
                reader.Close();
            }

            return objects;
        }
    }
}
