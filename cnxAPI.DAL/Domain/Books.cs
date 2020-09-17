using System;
using System.Xml.Serialization;

namespace cnxAPI.DAL.Domain
{
    [XmlRoot(ElementName = "book")]
    public class Books
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "isbn")]
        public string ISBN { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "year")]
        public string Year { get; set; }
        [XmlElement(ElementName = "author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "copies")]
        public string Copies { get; set; }
    }
}
