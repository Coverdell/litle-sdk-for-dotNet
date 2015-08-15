using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("applepayResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("applepayResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ApplepayResponse
    {
        [XmlElement("applicationPrimaryAccountNumber")]
        public string ApplicationPrimaryAccountNumber { get; set; }

        [XmlElement("applicationExpirationDate")]
        public string ApplicationExpirationDate { get; set; }

        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }

        [XmlElement("transactionAmount", DataType = "integer")]
        public string TransactionAmount { get; set; }

        [XmlElement("cardholderName")]
        public string CardholderName { get; set; }

        [XmlElement("deviceManufacturerIdentifier")]
        public string DeviceManufacturerIdentifier { get; set; }

        [XmlElement("paymentDataType")]
        public string PaymentDataType { get; set; }

        [XmlElement("onlinePaymentCryptogram", DataType = "base64Binary")]
        public byte[] OnlinePaymentCryptogram { get; set; }

        [XmlElement("eciIndicator")]
        public string EciIndicator { get; set; }
    }
}