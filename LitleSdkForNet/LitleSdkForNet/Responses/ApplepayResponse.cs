using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("applepayResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("applepayResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ApplepayResponse
    {
        private string _applicationPrimaryAccountNumberField;
        private string _applicationExpirationDateField;
        private string _currencyCodeField;
        private string _transactionAmountField;
        private string _cardholderNameField;
        private string _deviceManufacturerIdentifierField;
        private string _paymentDataTypeField;
        private byte[] _onlinePaymentCryptogramField;
        private string _eciIndicatorField;

        [XmlElement("applicationPrimaryAccountNumber")]
        public string ApplicationPrimaryAccountNumber
        {
            get { return _applicationPrimaryAccountNumberField; }
            set { _applicationPrimaryAccountNumberField = value; }
        }

        [XmlElement("applicationExpirationDate")]
        public string ApplicationExpirationDate
        {
            get { return _applicationExpirationDateField; }
            set { _applicationExpirationDateField = value; }
        }

        [XmlElement("currencyCode")]
        public string CurrencyCode
        {
            get { return _currencyCodeField; }
            set { _currencyCodeField = value; }
        }

        [XmlElement("transactionAmount", DataType = "integer")]
        public string TransactionAmount
        {
            get { return _transactionAmountField; }
            set { _transactionAmountField = value; }
        }

        [XmlElement("cardholderName")]
        public string CardholderName
        {
            get { return _cardholderNameField; }
            set { _cardholderNameField = value; }
        }

        [XmlElement("deviceManufacturerIdentifier")]
        public string DeviceManufacturerIdentifier
        {
            get { return _deviceManufacturerIdentifierField; }
            set { _deviceManufacturerIdentifierField = value; }
        }

        [XmlElement("paymentDataType")]
        public string PaymentDataType
        {
            get { return _paymentDataTypeField; }
            set { _paymentDataTypeField = value; }
        }

        [XmlElement("onlinePaymentCryptogram", DataType = "base64Binary")]
        public byte[] OnlinePaymentCryptogram
        {
            get { return _onlinePaymentCryptogramField; }
            set { _onlinePaymentCryptogramField = value; }
        }

        [XmlElement("eciIndicator")]
        public string EciIndicator
        {
            get { return _eciIndicatorField; }
            set { _eciIndicatorField = value; }
        }
    }
}