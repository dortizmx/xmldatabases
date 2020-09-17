using System;
using System.Xml.Serialization;
namespace cnxAPI.DAL.Domain
{
    [XmlRoot(ElementName ="member")]
    public class Member
    {
        [XmlElement(ElementName ="id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "firstname")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "lastname")]
        public string LastName { get; set; }
        [XmlElement(ElementName ="suscriptiondate")]
        public DateTime SuscriptionDate { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
       
    }
}
