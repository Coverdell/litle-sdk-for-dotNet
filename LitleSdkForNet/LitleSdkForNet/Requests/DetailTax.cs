using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("detailTax")]
    public class DetailTax
    {
        [XmlElement("taxIncludedInTotal", IsNullable = true)]
        public bool? TaxIncludedInTotal { get; set; }
        [XmlElement("taxAmount", IsNullable = true)]
        public long? TaxAmount { get; set; }
        [XmlElement("taxRate")]
        public string TaxRate { get; set; }
        [XmlElement("taxTypeIdentifier", IsNullable = true)]
        public TaxTypeIdentifierEnum? TaxTypeIdentifier { get; set; }
        [XmlElement("cardAcceptorTaxId")]
        public string CardAcceptorTaxId { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}