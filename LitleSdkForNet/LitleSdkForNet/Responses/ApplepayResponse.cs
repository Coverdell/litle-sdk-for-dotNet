using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
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

        public string ApplicationPrimaryAccountNumber
        {
            get { return _applicationPrimaryAccountNumberField; }
            set { _applicationPrimaryAccountNumberField = value; }
        }

        public string ApplicationExpirationDate
        {
            get { return _applicationExpirationDateField; }
            set { _applicationExpirationDateField = value; }
        }

        public string CurrencyCode
        {
            get { return _currencyCodeField; }
            set { _currencyCodeField = value; }
        }

        [XmlElement(DataType = "integer")]
        public string TransactionAmount
        {
            get { return _transactionAmountField; }
            set { _transactionAmountField = value; }
        }

        public string CardholderName
        {
            get { return _cardholderNameField; }
            set { _cardholderNameField = value; }
        }

        public string DeviceManufacturerIdentifier
        {
            get { return _deviceManufacturerIdentifierField; }
            set { _deviceManufacturerIdentifierField = value; }
        }

        public string PaymentDataType
        {
            get { return _paymentDataTypeField; }
            set { _paymentDataTypeField = value; }
        }

        [XmlElement(DataType = "base64Binary")]
        public byte[] OnlinePaymentCryptogram
        {
            get { return _onlinePaymentCryptogramField; }
            set { _onlinePaymentCryptogramField = value; }
        }

        public string EciIndicator
        {
            get { return _eciIndicatorField; }
            set { _eciIndicatorField = value; }
        }
    }
}