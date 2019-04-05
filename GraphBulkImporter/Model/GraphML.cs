using System;
using System.Xml.Serialization;

namespace GraphBulkImporter.Model
{
    [Serializable()]
    [XmlRoot("graph")]
    public class GraphML
    {
        [XmlArrayItem("key")]
        public GraphMLKey[] Keys { get; set; }

        [XmlArrayItem("node")]
        public GraphMLNode[] Nodes { get; set; }

        [XmlArrayItem("edge")]
        public GraphMLEdge[] Edges { get; set; }
    }

    [Serializable()]
    public class GraphMLEdge
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("target")]
        public string Target { get; set; }
    }

    [Serializable()]
    public class GraphMLNode
    {
        [XmlAttribute("id")]
        public string Name { get; set; }

        [XmlArrayItem("data")]
        public GraphMLData[] Data { get; set; }
    }

    [Serializable()]
    public class GraphMLData
    {
        [XmlAttribute("key")]
        public string KeyId { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [Serializable()]
    public class GraphMLKey
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("for")]
        public string For { get; set; } = "node";

        [XmlElement("attr.name")]
        public string Name { get; set; }

        [XmlElement("attr.type")]
        public string Type { get; set; } = "string";
    }
}
