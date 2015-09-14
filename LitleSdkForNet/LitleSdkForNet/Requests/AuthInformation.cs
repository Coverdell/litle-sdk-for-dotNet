using System;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("authInformation")]
    public class AuthInformation
    {
        [XmlElement("authDate", DataType = "date")]
        public DateTime AuthDate { get; set; }
        [XmlElement("authCode")]
        public string AuthCode { get; set; }
        [XmlElement("fraudResult")]
        public FraudResult FraudResult { get; set; }
        [XmlElement("authAmount", IsNullable = true)]
        public long? AuthAmount { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}