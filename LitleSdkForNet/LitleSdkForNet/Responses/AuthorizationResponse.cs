using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("authorizationResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("authorizationResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AuthorizationResponse : TransactionTypeWithReportGroup
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
        private AccountUpdater _accountUpdaterField;
        private FraudResult _fraudResultField;
        private BillMeLaterResponseData _billMeLaterResponseDataField;
        private TokenResponseType _tokenResponseField;
        private EnhancedAuthResponse _enhancedAuthResponseField;
        private RecyclingType _recyclingField;
        private RecurringResponse _recurringResponseField;
        private GiftCardResponse _giftCardResponseField;
        private ApplepayResponse _applepayResponseField;

        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        [XmlElement("orderId")]
        public string OrderId
        {
            get { return _orderIdField; }
            set { _orderIdField = value; }
        }

        [XmlElement("response")]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlElement("responseTime")]
        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        [XmlElement("cardProductId")]
        public string CardProductId
        {
            get { return _cardProductIdField; }
            set { _cardProductIdField = value; }
        }

        [XmlElement("postDate", DataType = "date")]
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

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlElement("authCode")]
        public string AuthCode
        {
            get { return _authCodeField; }
            set { _authCodeField = value; }
        }

        [XmlElement("authorizationResponseSubCode")]
        public string AuthorizationResponseSubCode
        {
            get { return _authorizationResponseSubCodeField; }
            set { _authorizationResponseSubCodeField = value; }
        }

        [XmlElement("approvedAmount", DataType = "integer")]
        public string ApprovedAmount
        {
            get { return _approvedAmountField; }
            set { _approvedAmountField = value; }
        }

        [XmlElement("accountInformation")]
        public AccountInfoType AccountInformation
        {
            get { return _accountInformationField; }
            set { _accountInformationField = value; }
        }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        [XmlElement("fraudResult")]
        public FraudResult FraudResult
        {
            get { return _fraudResultField; }
            set { _fraudResultField = value; }
        }

        [XmlElement("billMeLaterResponseData")]
        public BillMeLaterResponseData BillMeLaterResponseData
        {
            get { return _billMeLaterResponseDataField; }
            set { _billMeLaterResponseDataField = value; }
        }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }

        [XmlElement("enhancedAuthResponse")]
        public EnhancedAuthResponse EnhancedAuthResponse
        {
            get { return _enhancedAuthResponseField; }
            set { _enhancedAuthResponseField = value; }
        }

        [XmlElement("recycling")]
        public RecyclingType Recycling
        {
            get { return _recyclingField; }
            set { _recyclingField = value; }
        }

        [XmlElement("recurringResponse")]
        public RecurringResponse RecurringResponse
        {
            get { return _recurringResponseField; }
            set { _recurringResponseField = value; }
        }

        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse
        {
            get { return _giftCardResponseField; }
            set { _giftCardResponseField = value; }
        }

        [XmlElement("applepayResponse")]
        public ApplepayResponse ApplepayResponse
        {
            get { return _applepayResponseField; }
            set { _applepayResponseField = value; }
        }
    }
}