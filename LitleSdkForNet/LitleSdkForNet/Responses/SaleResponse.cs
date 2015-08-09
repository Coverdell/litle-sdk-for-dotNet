using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class SaleResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _cardProductIdField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private string _messageField;
        private string _authCodeField;
        private string _authorizationResponseSubCodeField;
        private string _approvedAmountField;
        private AccountInfoType _accountInformationField;
        private FraudResult _fraudResultField;
        private BillMeLaterResponseData _billMeLaterResponseDataField;
        private TokenResponseType _tokenResponseField;
        private EnhancedAuthResponse _enhancedAuthResponseField;
        private AccountUpdater _accountUpdaterField;
        private RecyclingType _recyclingField;
        private RecurringResponse _recurringResponseField;
        private GiftCardResponse _giftCardResponseField;
        private ApplepayResponse _applepayResponseField;
        private bool _duplicateField;
        private bool _duplicateFieldSpecified;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string OrderId
        {
            get { return _orderIdField; }
            set { _orderIdField = value; }
        }

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        public string CardProductId
        {
            get { return _cardProductIdField; }
            set { _cardProductIdField = value; }
        }

        [XmlElement(DataType = "date")]
        public DateTime PostDate
        {
            get { return _postDateField; }
            set { _postDateField = value; }
        }

        [XmlIgnore]
        public bool PostDateSpecified
        {
            get { return _postDateFieldSpecified; }
            set { _postDateFieldSpecified = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public string AuthCode
        {
            get { return _authCodeField; }
            set { _authCodeField = value; }
        }

        public string AuthorizationResponseSubCode
        {
            get { return _authorizationResponseSubCodeField; }
            set { _authorizationResponseSubCodeField = value; }
        }

        [XmlElement(DataType = "integer")]
        public string ApprovedAmount
        {
            get { return _approvedAmountField; }
            set { _approvedAmountField = value; }
        }

        public AccountInfoType AccountInformation
        {
            get { return _accountInformationField; }
            set { _accountInformationField = value; }
        }

        public FraudResult FraudResult
        {
            get { return _fraudResultField; }
            set { _fraudResultField = value; }
        }

        public BillMeLaterResponseData BillMeLaterResponseData
        {
            get { return _billMeLaterResponseDataField; }
            set { _billMeLaterResponseDataField = value; }
        }

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }

        public EnhancedAuthResponse EnhancedAuthResponse
        {
            get { return _enhancedAuthResponseField; }
            set { _enhancedAuthResponseField = value; }
        }

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        public RecyclingType Recycling
        {
            get { return _recyclingField; }
            set { _recyclingField = value; }
        }

        public RecurringResponse RecurringResponse
        {
            get { return _recurringResponseField; }
            set { _recurringResponseField = value; }
        }

        public GiftCardResponse GiftCardResponse
        {
            get { return _giftCardResponseField; }
            set { _giftCardResponseField = value; }
        }

        public ApplepayResponse ApplepayResponse
        {
            get { return _applepayResponseField; }
            set { _applepayResponseField = value; }
        }

        [XmlAttribute]
        public bool Duplicate
        {
            get { return _duplicateField; }
            set { _duplicateField = value; }
        }

        [XmlIgnore]
        public bool DuplicateSpecified
        {
            get { return _duplicateFieldSpecified; }
            set { _duplicateFieldSpecified = value; }
        }
    }
}