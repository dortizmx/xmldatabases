using System;
using System.Xml.Serialization;

namespace cnxAPI.DAL.Domain
{
    [XmlRoot(ElementName = "loan")]
    public class Loans
    {
        [XmlElement(ElementName ="id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "memberid")]
        public int MemberId { get; set; }
        [XmlElement(ElementName = "bookid")]
        public int BookId { get; set; }
        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
        [XmlElement(ElementName = "loandate")]
        public DateTime LoanDate { get; set; }
        [XmlElement(ElementName = "loandays")]
        public int LoanDays { get; set; }
        [XmlElement(ElementName = "transactiontype")]
        public string TransactionType { get; set; }
    }
}
