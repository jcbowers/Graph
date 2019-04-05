using System;
using System.Xml.Serialization;

namespace GraphBulkImporter.Model
{
    [Serializable()]
    [XmlRoot("DependencyViewerReport")]
    public class ObjectList
    {
        [XmlElement("Object")]
        public Node[] Objects { get; set; }
    }

    [Serializable()]
    public class Node
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlArray("Uses")]
        [XmlArrayItem("Object")]
        public string[] Dependencies { get; set; }

        [XmlArray("UsedBy")]
        [XmlArrayItem("Object")]
        public string[] Dependents { get; set; }
    }
}
