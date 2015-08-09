using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlInclude(typeof (RegisterTokenRequestType))]
    public class TransactionTypeWithReportGroup : TransactionType
    {
        [XmlAttribute]
        public string ReportGroup { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TransactionResponse
    {
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TransactionRequest
    {
        public virtual string Serialize()
        {
            throw new NotImplementedException();
        }
    }

    [XmlInclude(typeof (TransactionTypeOptionReportGroup))]
    [XmlInclude(typeof (TransactionTypeWithReportGroupAndPartial))]
    [XmlInclude(typeof (TransactionTypeWithReportGroup))]
    [XmlInclude(typeof (RegisterTokenRequestType))]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TransactionType : TransactionRequest
    {
        private string _idField;
        private string _customerIdField;

        [XmlAttribute]
        public string ID
        {
            get { return _idField; }
            set { _idField = value; }
        }

        [XmlAttribute]
        public string CustomerId
        {
            get { return _customerIdField; }
            set { _customerIdField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TransactionTypeOptionReportGroup : TransactionType
    {
        private string _reportGroupField;

        [XmlAttribute]
        public string ReportGroup
        {
            get { return _reportGroupField; }
            set { _reportGroupField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecurringTransactionResponseType : TransactionResponse
    {
        private string _litleTxnIdField;

        public string LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        private string _responseField;

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        private string _messageField;

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        private DateTime _responseTimeField;

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecurringTransactionType : TransactionRequest
    {
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        ExpDate,
        Number,
        Track,
        Type,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum PosCapabilityTypeEnum
    {
        Notused,
        Magstripe,
        Keyedonly,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum PosEntryModeTypeEnum
    {
        Notused,
        Keyed,
        Track1,
        Track2,
        Completeread,
    }

    public sealed class PosCatLevelEnum
    {
        public static readonly PosCatLevelEnum Selfservice = new PosCatLevelEnum("self service");

        private PosCatLevelEnum(String value)
        {
            _value = value;
        }

        public string Serialize()
        {
            return _value;
        }

        private readonly string _value;
    }


    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum PosCardholderIdTypeEnum
    {
        Signature,
        Pin,
        Nopin,
        Directmarket,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {
        City,
        Phone,
        Url,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum GovtTaxTypeEnum
    {
        Payment,
        Fee,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public enum EnhancedDataDeliveryType
    {
        CNC,
        DIG,
        PHY,
        SVC,
        TBD,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum TaxTypeIdentifierEnum
    {
        [XmlEnum("00")] Item00,
        [XmlEnum("01")] Item01,
        [XmlEnum("02")] Item02,
        [XmlEnum("03")] Item03,
        [XmlEnum("04")] Item04,
        [XmlEnum("05")] Item05,
        [XmlEnum("06")] Item06,
        [XmlEnum("10")] Item10,
        [XmlEnum("11")] Item11,
        [XmlEnum("12")] Item12,
        [XmlEnum("13")] Item13,
        [XmlEnum("14")] Item14,
        [XmlEnum("20")] Item20,
        [XmlEnum("21")] Item21,
        [XmlEnum("22")] Item22,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum IIASFlagType
    {
        Y,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum RecycleByTypeEnum
    {
        Merchant,
        Litle,
        None,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AdvancedFraudResultsType
    {
        public string DeviceReviewStatus;
        public int DeviceReputationScore;
        public string TriggeredRule;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class CreditPaypal
    {
        private string _itemField;

        private ItemChoiceType2 _itemElementNameField;

        [XmlElement("payerEmail", typeof (string))]
        [XmlElement("payerId", typeof (string))]
        [XmlChoiceIdentifier("ItemElementName")]
        public string Item
        {
            get { return _itemField; }
            set { _itemField = value; }
        }

        [XmlIgnore]
        public ItemChoiceType2 ItemElementName
        {
            get { return _itemElementNameField; }
            set { _itemElementNameField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {
        PayerEmail,
        PayerId,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {
        AmexAggregatorData,
        Amount,
        BillMeLaterRequest,
        BillToAddress,
        Card,
        CustomBilling,
        EnhancedData,
        LitleTxnId,
        MerchantData,
        OrderId,
        OrderSource,
        Paypage,
        Paypal,
        Pos,
        ProcessingInstructions,
        TaxType,
        Token,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum EcheckAccountTypeEnum
    {
        Checking,
        Savings,
        Corporate,
        [XmlEnum("Corp Savings")] CorpSavings,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {
        Amount,
        BillToAddress,
        CustomBilling,
        Echeck,
        EcheckOrEcheckToken,
        EcheckToken,
        LitleTxnId,
        MerchantData,
        OrderId,
        OrderSource,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckRedeposit", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BaseRequestTransactionEcheckRedeposit : TransactionTypeWithReportGroup
    {
        protected long LitleTxnIdField;
        protected bool LitleTxnIdSet;

        private object _itemField;

        public long LitleTxnId
        {
            get { return LitleTxnIdField; }
            set
            {
                LitleTxnIdField = value;
                LitleTxnIdSet = true;
            }
        }

        [XmlElement("echeck", typeof (EcheckType))]
        [XmlElement("echeckToken", typeof (EcheckTokenType))]
        public object Item
        {
            get { return _itemField; }
            set { _itemField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {
        Amount,
        BillToAddress,
        CustomBilling,
        Echeck,
        EcheckOrEcheckToken,
        EcheckToken,
        LitleTxnId,
        MerchantData,
        OrderId,
        OrderSource,
        ShipToAddress,
        Verify,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum Item1ChoiceType
    {
        CardholderAuthentication,
        FraudCheck,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class DriversLicenseInfo
    {
        private string _licenseNumberField;
        private string _stateField;
        private string _dateOfBirthField;

        public string LicenseNumber
        {
            get { return _licenseNumberField; }
            set { _licenseNumberField = value; }
        }

        public string State
        {
            get { return _stateField; }
            set { _stateField = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirthField; }
            set { _dateOfBirthField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecycleAdviceType
    {
        private object _itemField;

        [XmlElement("nextRecycleTime", typeof (DateTime))]
        [XmlElement("recycleAdviceEnd", typeof (string))]
        public object Item
        {
            get { return _itemField; }
            set { _itemField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecyclingType
    {
        private RecycleAdviceType _recycleAdviceField;
        private bool _recycleEngineActiveField;

        public RecycleAdviceType RecycleAdvice
        {
            get { return _recycleAdviceField; }
            set { _recycleAdviceField = value; }
        }

        public bool RecycleEngineActive
        {
            get { return _recycleEngineActiveField; }
            set { _recycleEngineActiveField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecurringResponse
    {
        private long _subscriptionIdField;
        private string _responseCodeField;
        private string _responseMessageField;
        private long _recurringTxnIdField;

        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

        public string ResponseCode
        {
            get { return _responseCodeField; }
            set { _responseCodeField = value; }
        }

        public string ResponseMessage
        {
            get { return _responseMessageField; }
            set { _responseMessageField = value; }
        }

        public long RecurringTxnId
        {
            get { return _recurringTxnIdField; }
            set { _recurringTxnIdField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class VoidRecyclingResponseType
    {
        private long _creditLitleTxnIdField;

        public long CreditLitleTxnId
        {
            get { return _creditLitleTxnIdField; }
            set { _creditLitleTxnIdField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TokenResponseType
    {
        private string _litleTokenField;
        private string _tokenResponseCodeField;
        private string _tokenMessageField;
        private MethodOfPaymentTypeEnum _typeField;
        private bool _typeFieldSpecified;
        private string _binField;
        private string _eCheckAccountSuffixField;

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public string TokenResponseCode
        {
            get { return _tokenResponseCodeField; }
            set { _tokenResponseCodeField = value; }
        }

        public string TokenMessage
        {
            get { return _tokenMessageField; }
            set { _tokenMessageField = value; }
        }

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        [XmlIgnore]
        public bool TypeSpecified
        {
            get { return _typeFieldSpecified; }
            set { _typeFieldSpecified = value; }
        }

        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }

        public string ECheckAccountSuffix
        {
            get { return _eCheckAccountSuffixField; }
            set { _eCheckAccountSuffixField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class CardTokenInfoType
    {
        private string _litleTokenField;
        private MethodOfPaymentTypeEnum _typeField;
        private string _expDateField;
        private string _binField;

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string ExpDate
        {
            get { return _expDateField; }
            set { _expDateField = value; }
        }

        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class ExtendedCardResponseType
    {
        private string _messageField;
        private string _codeField;

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public string Code
        {
            get { return _codeField; }
            set { _codeField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class CardAccountInfoType
    {
        private MethodOfPaymentTypeEnum _typeField;
        private string _numberField;
        private string _expDateField;

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string Number
        {
            get { return _numberField; }
            set { _numberField = value; }
        }

        public string ExpDate
        {
            get { return _expDateField; }
            set { _expDateField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class EcheckTokenInfoType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private string _litleTokenField;
        private string _routingNumField;

        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set { _accTypeField = value; }
        }

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public string RoutingNum
        {
            get { return _routingNumField; }
            set { _routingNumField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class EcheckAccountInfoType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private string _accNumField;
        private string _routingNumField;

        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set { _accTypeField = value; }
        }

        public string AccNum
        {
            get { return _accNumField; }
            set { _accNumField = value; }
        }

        public string RoutingNum
        {
            get { return _routingNumField; }
            set { _routingNumField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class AccountInfoType
    {
        private MethodOfPaymentTypeEnum _typeField;
        private string _numberField;

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string Number
        {
            get { return _numberField; }
            set { _numberField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BillMeLaterResponseData
    {
        private long _bmlMerchantIdField;
        private string _promotionalOfferCodeField;
        private int _approvedTermsCodeField;
        private bool _approvedTermsCodeFieldSpecified;
        private string _creditLineField;
        private string _addressIndicatorField;
        private string _loanToValueEstimatorField;
        private string _riskEstimatorField;
        private string _riskQueueAssignmentField;

        public long BmlMerchantId
        {
            get { return _bmlMerchantIdField; }
            set { _bmlMerchantIdField = value; }
        }

        public string PromotionalOfferCode
        {
            get { return _promotionalOfferCodeField; }
            set { _promotionalOfferCodeField = value; }
        }

        public int ApprovedTermsCode
        {
            get { return _approvedTermsCodeField; }
            set { _approvedTermsCodeField = value; }
        }

        [XmlIgnore]
        public bool ApprovedTermsCodeSpecified
        {
            get { return _approvedTermsCodeFieldSpecified; }
            set { _approvedTermsCodeFieldSpecified = value; }
        }

        [XmlElement(DataType = "integer")]
        public string CreditLine
        {
            get { return _creditLineField; }
            set { _creditLineField = value; }
        }

        public string AddressIndicator
        {
            get { return _addressIndicatorField; }
            set { _addressIndicatorField = value; }
        }

        public string LoanToValueEstimator
        {
            get { return _loanToValueEstimatorField; }
            set { _loanToValueEstimatorField = value; }
        }

        public string RiskEstimator
        {
            get { return _riskEstimatorField; }
            set { _riskEstimatorField = value; }
        }

        public string RiskQueueAssignment
        {
            get { return _riskQueueAssignmentField; }
            set { _riskQueueAssignmentField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RegisterTokenResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _litleTokenField;
        private string _binField;
        private MethodOfPaymentTypeEnum? _typeField;
        private bool _typeFieldSpecified;
        private string _eCheckAccountSuffixField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;
        private ApplepayResponse _applepayResponseField;

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

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }

        public MethodOfPaymentTypeEnum? Type
        {
            get { return _typeFieldSpecified ? _typeField : null; }
            set { _typeField = value; }
        }

        [XmlIgnore]
        public bool TypeSpecified
        {
            get { return _typeFieldSpecified; }
            set { _typeFieldSpecified = value; }
        }

        public string ECheckAccountSuffix
        {
            get { return _eCheckAccountSuffixField; }
            set { _eCheckAccountSuffixField = value; }
        }

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        public ApplepayResponse ApplepayResponse
        {
            get { return _applepayResponseField; }
            set { _applepayResponseField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateCardValidationNumOnTokenResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;

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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
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

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
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
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CancelSubscriptionResponse
    {
        private string _subscriptionIdField;

        public string SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

        private string _litleTxnIdField;

        public string LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        private string _responseField;

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        private string _messageField;

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        private DateTime _responseTimeField;

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateSubscriptionResponse
    {
        private string _subscriptionIdField;

        public string SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

        private string _litleTxnIdField;

        public string LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        private string _responseField;

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        private string _messageField;

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        private DateTime _responseTimeField;

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        public TokenResponseType TokenResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdater
    {
        public ExtendedCardResponseType ExtendedCardResponse;
        public EcheckAccountInfoType NewAccountInfo;
        public CardAccountInfoType NewCardInfo;
        public CardTokenInfoType NewCardTokenInfo;
        public EcheckTokenInfoType NewTokenInfo;
        public EcheckAccountInfoType OriginalAccountInfo;
        public CardAccountInfoType OriginalCardInfo;
        public CardTokenInfoType OriginalCardTokenInfo;
        public EcheckTokenInfoType OriginalTokenInfo;
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {
        ExtendedCardResponse,
        NewAccountInfo,
        NewCardInfo,
        NewCardTokenInfo,
        NewTokenInfo,
        OriginalAccountInfo,
        OriginalCardInfo,
        OriginalCardTokenInfo,
        OriginalTokenInfo,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EnhancedAuthResponse
    {
        private EnhancedAuthResponseFundingSource _fundingSourceField;
        private AffluenceTypeEnum? _affluenceField;
        private bool _affluenceFieldSpecified;
        private string _issuerCountryField;
        private CardProductTypeEnum? _cardProductTypeField;
        private bool _cardProductTypeFieldSpecified;
        private bool _virtualAccountNumberField;
        private bool _virtualAccountNumberFieldSpecified;

        public EnhancedAuthResponseFundingSource FundingSource
        {
            get { return _fundingSourceField; }
            set { _fundingSourceField = value; }
        }

        public AffluenceTypeEnum? Affluence
        {
            get { return _affluenceFieldSpecified ? _affluenceField : null; }
            set { _affluenceField = value; }
        }

        [XmlIgnore]
        public bool AffluenceSpecified
        {
            get { return _affluenceFieldSpecified; }
            set { _affluenceFieldSpecified = value; }
        }

        public string IssuerCountry
        {
            get { return _issuerCountryField; }
            set { _issuerCountryField = value; }
        }

        public CardProductTypeEnum? CardProductType
        {
            get { return _cardProductTypeFieldSpecified ? _cardProductTypeField : null; }
            set { _cardProductTypeField = value; }
        }

        [XmlIgnore]
        public bool CardProductTypeSpecified
        {
            get { return _cardProductTypeFieldSpecified; }
            set { _cardProductTypeFieldSpecified = value; }
        }

        public bool VirtualAccountNumber
        {
            get { return _virtualAccountNumberField; }
            set { _virtualAccountNumberField = value; }
        }

        [XmlIgnore]
        public bool VirtualAccountNumberSpecified
        {
            get { return _virtualAccountNumberFieldSpecified; }
            set { _virtualAccountNumberFieldSpecified = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class EnhancedAuthResponseFundingSource
    {
        private FundingSourceTypeEnum _typeField;
        private string _availableBalanceField;
        private string _reloadableField;
        private string _prepaidCardTypeField;

        public FundingSourceTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string AvailableBalance
        {
            get { return _availableBalanceField; }
            set { _availableBalanceField = value; }
        }

        public string Reloadable
        {
            get { return _reloadableField; }
            set { _reloadableField = value; }
        }

        public string PrepaidCardType
        {
            get { return _prepaidCardTypeField; }
            set { _prepaidCardTypeField = value; }
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum FundingSourceTypeEnum
    {
        Unknown,
        Prepaid,
        Fsa,
        Credit,
        Debit,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum AffluenceTypeEnum
    {
        Affluent,
        [XmlEnum("MASS AFFLUENT")] Massaffluent,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum CardProductTypeEnum
    {
        Unknown,
        Commercial,
        Consumer,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AuthReversalResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private string _messageField;

        public GiftCardResponse GiftCardResponse;

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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CaptureResponse : TransactionTypeWithReportGroup
    {
        public GiftCardResponse GiftCardResponse;
        public FraudResult FraudResult;

        private long _litleTxnIdField;

        private string _orderIdField;

        private string _responseField;

        private DateTime _responseTimeField;

        private DateTime _postDateField;

        private bool _postDateFieldSpecified;

        private string _messageField;

        private AccountUpdater _accountUpdaterField;

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

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ForceCaptureResponse : TransactionTypeWithReportGroup
    {
        public GiftCardResponse GiftCardResponse;
        public FraudResult FraudResult;
        private long _litleTxnIdField;

        private string _orderIdField;

        private string _responseField;

        private DateTime _responseTimeField;

        private DateTime _postDateField;

        private bool _postDateFieldSpecified;

        private string _messageField;

        private TokenResponseType _tokenResponseField;

        private AccountUpdater _accountUpdaterField;

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

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }
    }


    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CaptureGivenAuthResponse : TransactionTypeWithReportGroup
    {
        public GiftCardResponse GiftCardResponse;
        public FraudResult FraudResult;
        private long _litleTxnIdField;

        private string _orderIdField;

        private string _responseField;

        private DateTime _responseTimeField;

        private DateTime _postDateField;

        private bool _postDateFieldSpecified;

        private string _messageField;

        private TokenResponseType _tokenResponseField;


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

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }
    }

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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CreditResponse : TransactionTypeWithReportGroup
    {
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private string _messageField;
        private TokenResponseType _tokenResponseField;
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

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckSalesResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        private string _verificationCodeField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private AccountUpdater _accountUpdaterField;
        private TokenResponseType _tokenResponseField;
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public string VerificationCode
        {
            get { return _verificationCodeField; }
            set { _verificationCodeField = value; }
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

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private AccountUpdater _accountUpdaterField;
        private TokenResponseType _tokenResponseField;
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckVerificationResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private TokenResponseType _tokenResponseField;

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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckRedepositResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private AccountUpdater _accountUpdaterField;
        private TokenResponseType _tokenResponseField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponse
    {
        private string _responseField;
        private string _messageField;
        private string _versionField;

        public AuthReversalResponse AuthReversalResponse;
        public AuthorizationResponse AuthorizationResponse;
        public CaptureGivenAuthResponse CaptureGivenAuthResponse;
        public CaptureResponse CaptureResponse;
        public CreditResponse CreditResponse;
        public EcheckCreditResponse EcheckCreditResponse;
        public EcheckRedepositResponse EcheckRedepositResponse;
        public EcheckSalesResponse EcheckSalesResponse;
        public EcheckVerificationResponse EcheckVerificationResponse;
        public LitleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoidResponse;
        public ForceCaptureResponse ForceCaptureResponse;
        public RegisterTokenResponse RegisterTokenResponse;
        public SaleResponse SaleResponse;
        public LitleOnlineResponseTransactionResponseVoidResponse VoidResponse;
        public UpdateCardValidationNumOnTokenResponse UpdateCardValidationNumOnTokenResponse;
        public CancelSubscriptionResponse CancelSubscriptionResponse;
        public UpdateSubscriptionResponse UpdateSubscriptionResponse;
        public ActivateResponse ActivateResponse;
        public DeactivateResponse DeactivateResponse;
        public LoadResponse LoadResponse;
        public UnloadResponse UnloadResponse;
        public BalanceInquiryResponse BalanceInquiryResponse;
        public CreatePlanResponse CreatePlanResponse;
        public UpdatePlanResponse UpdatePlanResponse;
        public RefundReversalResponse RefundReversalResponse;
        public DepositReversalResponse DepositReversalResponse;
        public ActivateReversalResponse ActivateReversalResponse;
        public DeactivateReversalResponse DeactivateReversalResponse;
        public LoadReversalResponse LoadReversalResponse;
        public UnloadReversalResponse UnloadReversalResponse;

        [XmlAttribute]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlAttribute]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlAttribute]
        public string Version
        {
            get { return _versionField; }
            set { _versionField = value; }
        }
    }

    [Serializable]
    [XmlRoot("litleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleResponse
    {
        public string ID;
        public long LitleBatchId;
        public long LitleSessionId;
        public string MerchantId;
        public string Response;
        public string Message;
        public string Version;

        private XmlReader _originalXmlReader;
        private XmlReader _batchResponseReader;
        private XmlReader _rfrResponseReader;
        private string _filePath;

        public LitleResponse()
        {
        }

        public LitleResponse(string filePath)
        {
            var reader = new XmlTextReader(filePath);
            ReadXml(reader, filePath);
        }

        public LitleResponse(XmlReader reader, string filePath)
        {
            ReadXml(reader, filePath);
        }

        public void SetBatchResponseReader(XmlReader xmlReader)
        {
            _batchResponseReader = xmlReader;
        }

        public void SetRfrResponseReader(XmlReader xmlReader)
        {
            _rfrResponseReader = xmlReader;
        }

        public void ReadXml(XmlReader reader, string filePath)
        {
            if (reader.ReadToFollowing("litleResponse"))
            {
                Version = reader.GetAttribute("version");
                Message = reader.GetAttribute("message");
                Response = reader.GetAttribute("response");

                string rawLitleSessionId = reader.GetAttribute("litleSessionId");
                if (rawLitleSessionId != null)
                {
                    LitleSessionId = Int64.Parse(rawLitleSessionId);
                }
            }
            else
            {
                reader.Close();
            }

            _originalXmlReader = reader;
            _filePath = filePath;

            _batchResponseReader = new XmlTextReader(filePath);
            if (!_batchResponseReader.ReadToFollowing("batchResponse"))
            {
                _batchResponseReader.Close();
            }

            _rfrResponseReader = new XmlTextReader(filePath);
            if (!_rfrResponseReader.ReadToFollowing("RFRResponse"))
            {
                _rfrResponseReader.Close();
            }
        }

        public virtual BatchResponse NextBatchResponse()
        {
            if (_batchResponseReader.ReadState == ReadState.Closed) return null;
            var litleBatchResponse = new BatchResponse(_batchResponseReader, _filePath);
            if (!_batchResponseReader.ReadToFollowing("batchResponse"))
            {
                _batchResponseReader.Close();
            }

            return litleBatchResponse;
        }

        public virtual RFRResponse NextRFRResponse()
        {
            if (_rfrResponseReader.ReadState == ReadState.Closed) return null;
            string response = _rfrResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (RFRResponse));
            var reader = new StringReader(response);
            var rfrResponse = (RFRResponse) serializer.Deserialize(reader);

            if (!_rfrResponseReader.ReadToFollowing("RFRResponse"))
            {
                _rfrResponseReader.Close();
            }

            return rfrResponse;
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BatchResponse
    {
        public string ID;
        public long LitleBatchId;
        public string MerchantId;

        private XmlReader _originalXmlReader;
        private XmlReader _accountUpdateResponseReader;
        private XmlReader _authorizationResponseReader;
        private XmlReader _authReversalResponseReader;
        private XmlReader _captureResponseReader;
        private XmlReader _captureGivenAuthResponseReader;
        private XmlReader _creditResponseReader;
        private XmlReader _forceCaptureResponseReader;
        private XmlReader _echeckCreditResponseReader;
        private XmlReader _echeckRedepositResponseReader;
        private XmlReader _echeckSalesResponseReader;
        private XmlReader _echeckVerificationResponseReader;
        private XmlReader _saleResponseReader;
        private XmlReader _registerTokenResponseReader;
        private XmlReader _updateCardValidationNumOnTokenResponseReader;
        private XmlReader _cancelSubscriptionResponseReader;
        private XmlReader _updateSubscriptionResponseReader;
        private XmlReader _createPlanResponseReader;
        private XmlReader _updatePlanResponseReader;
        private XmlReader _activateResponseReader;
        private XmlReader _deactivateResponseReader;
        private XmlReader _loadResponseReader;
        private XmlReader _echeckPreNoteSaleResponseReader;
        private XmlReader _echeckPreNoteCreditResponseReader;
        private XmlReader _unloadResponseReader;
        private XmlReader _balanceInquiryResponseReader;
        private XmlReader _submerchantCreditResponseReader;
        private XmlReader _payFacCreditResponseReader;
        private XmlReader _vendorCreditResponseReader;
        private XmlReader _reserveCreditResponseReader;
        private XmlReader _physicalCheckCreditResponseReader;
        private XmlReader _submerchantDebitResponseReader;
        private XmlReader _payFacDebitResponseReader;
        private XmlReader _vendorDebitResponseReader;
        private XmlReader _reserveDebitResponseReader;
        private XmlReader _physicalCheckDebitResponseReader;

        public BatchResponse()
        {
        }

        public BatchResponse(XmlReader xmlReader, string filePath)
        {
            ReadXml(xmlReader, filePath);
        }

        public void SetAccountUpdateResponseReader(XmlReader xmlReader)
        {
            _accountUpdateResponseReader = xmlReader;
        }

        public void SetAuthorizationResponseReader(XmlReader xmlReader)
        {
            _authorizationResponseReader = xmlReader;
        }

        public void SetAuthReversalResponseReader(XmlReader xmlReader)
        {
            _authReversalResponseReader = xmlReader;
        }

        public void SetCaptureResponseReader(XmlReader xmlReader)
        {
            _captureResponseReader = xmlReader;
        }

        public void SetCaptureGivenAuthResponseReader(XmlReader xmlReader)
        {
            _captureGivenAuthResponseReader = xmlReader;
        }

        public void SetCreditResponseReader(XmlReader xmlReader)
        {
            _creditResponseReader = xmlReader;
        }

        public void SetForceCaptureResponseReader(XmlReader xmlReader)
        {
            _forceCaptureResponseReader = xmlReader;
        }

        public void SetEcheckCreditResponseReader(XmlReader xmlReader)
        {
            _echeckCreditResponseReader = xmlReader;
        }

        public void SetEcheckRedepositResponseReader(XmlReader xmlReader)
        {
            _echeckRedepositResponseReader = xmlReader;
        }

        public void SetEcheckSalesResponseReader(XmlReader xmlReader)
        {
            _echeckSalesResponseReader = xmlReader;
        }

        public void SetEcheckVerificationResponseReader(XmlReader xmlReader)
        {
            _echeckVerificationResponseReader = xmlReader;
        }

        public void SetSaleResponseReader(XmlReader xmlReader)
        {
            _saleResponseReader = xmlReader;
        }

        public void SetRegisterTokenResponseReader(XmlReader xmlReader)
        {
            _registerTokenResponseReader = xmlReader;
        }

        public void SetUpdateCardValidationNumOnTokenResponseReader(XmlReader xmlReader)
        {
            _updateCardValidationNumOnTokenResponseReader = xmlReader;
        }

        public void SetCancelSubscriptionResponseReader(XmlReader xmlReader)
        {
            _cancelSubscriptionResponseReader = xmlReader;
        }

        public void SetUpdateSubscriptionResponseReader(XmlReader xmlReader)
        {
            _updateSubscriptionResponseReader = xmlReader;
        }

        public void SetCreatePlanResponseReader(XmlReader xmlReader)
        {
            _createPlanResponseReader = xmlReader;
        }

        public void SetUpdatePlanResponseReader(XmlReader xmlReader)
        {
            _updatePlanResponseReader = xmlReader;
        }

        public void SetActivateResponseReader(XmlReader xmlReader)
        {
            _activateResponseReader = xmlReader;
        }

        public void SetDeactivateResponseReader(XmlReader xmlReader)
        {
            _deactivateResponseReader = xmlReader;
        }

        public void SetLoadResponseReader(XmlReader xmlReader)
        {
            _loadResponseReader = xmlReader;
        }

        public void SetEcheckPreNoteSaleResponseReader(XmlReader xmlReader)
        {
            _echeckPreNoteSaleResponseReader = xmlReader;
        }

        public void SetEcheckPreNoteCreditResponseReader(XmlReader xmlReader)
        {
            _echeckPreNoteCreditResponseReader = xmlReader;
        }

        public void SetUnloadResponseReader(XmlReader xmlReader)
        {
            _unloadResponseReader = xmlReader;
        }

        public void SetBalanceInquiryResponseReader(XmlReader xmlReader)
        {
            _balanceInquiryResponseReader = xmlReader;
        }

        public void SetSubmerchantCreditResponseReader(XmlReader xmlReader)
        {
            _submerchantCreditResponseReader = xmlReader;
        }

        public void SetPayFacCreditResponseReader(XmlReader xmlReader)
        {
            _payFacCreditResponseReader = xmlReader;
        }

        public void SetReserveCreditResponseReader(XmlReader xmlReader)
        {
            _reserveCreditResponseReader = xmlReader;
        }

        public void SetVendorCreditResponseReader(XmlReader xmlReader)
        {
            _vendorCreditResponseReader = xmlReader;
        }

        public void SetPhysicalCheckCreditResponseReader(XmlReader xmlReader)
        {
            _physicalCheckCreditResponseReader = xmlReader;
        }

        public void SetSubmerchantDebitResponseReader(XmlReader xmlReader)
        {
            _submerchantDebitResponseReader = xmlReader;
        }

        public void SetPayFacDebitResponseReader(XmlReader xmlReader)
        {
            _payFacDebitResponseReader = xmlReader;
        }

        public void SetReserveDebitResponseReader(XmlReader xmlReader)
        {
            _reserveDebitResponseReader = xmlReader;
        }

        public void SetVendorDebitResponseReader(XmlReader xmlReader)
        {
            _vendorDebitResponseReader = xmlReader;
        }

        public void SetPhysicalCheckDebitResponseReader(XmlReader xmlReader)
        {
            _physicalCheckDebitResponseReader = xmlReader;
        }

        public void ReadXml(XmlReader reader, string filePath)
        {
            ID = reader.GetAttribute("id");
            LitleBatchId = Int64.Parse(reader.GetAttribute("litleBatchId"));
            MerchantId = reader.GetAttribute("merchantId");

            _originalXmlReader = reader;
            _accountUpdateResponseReader = new XmlTextReader(filePath);
            _authorizationResponseReader = new XmlTextReader(filePath);
            _authReversalResponseReader = new XmlTextReader(filePath);
            _captureResponseReader = new XmlTextReader(filePath);
            _captureGivenAuthResponseReader = new XmlTextReader(filePath);
            _creditResponseReader = new XmlTextReader(filePath);
            _forceCaptureResponseReader = new XmlTextReader(filePath);
            _echeckCreditResponseReader = new XmlTextReader(filePath);
            _echeckRedepositResponseReader = new XmlTextReader(filePath);
            _echeckSalesResponseReader = new XmlTextReader(filePath);
            _echeckVerificationResponseReader = new XmlTextReader(filePath);
            _saleResponseReader = new XmlTextReader(filePath);
            _registerTokenResponseReader = new XmlTextReader(filePath);
            _updateCardValidationNumOnTokenResponseReader = new XmlTextReader(filePath);
            _cancelSubscriptionResponseReader = new XmlTextReader(filePath);
            _updateSubscriptionResponseReader = new XmlTextReader(filePath);
            _createPlanResponseReader = new XmlTextReader(filePath);
            _updatePlanResponseReader = new XmlTextReader(filePath);
            _activateResponseReader = new XmlTextReader(filePath);
            _deactivateResponseReader = new XmlTextReader(filePath);
            _loadResponseReader = new XmlTextReader(filePath);
            _echeckPreNoteSaleResponseReader = new XmlTextReader(filePath);
            _echeckPreNoteCreditResponseReader = new XmlTextReader(filePath);
            _unloadResponseReader = new XmlTextReader(filePath);
            _balanceInquiryResponseReader = new XmlTextReader(filePath);
            _submerchantCreditResponseReader = new XmlTextReader(filePath);
            _payFacCreditResponseReader = new XmlTextReader(filePath);
            _reserveCreditResponseReader = new XmlTextReader(filePath);
            _vendorCreditResponseReader = new XmlTextReader(filePath);
            _physicalCheckCreditResponseReader = new XmlTextReader(filePath);
            _submerchantDebitResponseReader = new XmlTextReader(filePath);
            _payFacDebitResponseReader = new XmlTextReader(filePath);
            _reserveDebitResponseReader = new XmlTextReader(filePath);
            _vendorDebitResponseReader = new XmlTextReader(filePath);
            _physicalCheckDebitResponseReader = new XmlTextReader(filePath);

            if (!_accountUpdateResponseReader.ReadToFollowing("accountUpdateResponse"))
            {
                _accountUpdateResponseReader.Close();
            }
            if (!_authorizationResponseReader.ReadToFollowing("authorizationResponse"))
            {
                _authorizationResponseReader.Close();
            }
            if (!_authReversalResponseReader.ReadToFollowing("authReversalResponse"))
            {
                _authReversalResponseReader.Close();
            }
            if (!_captureResponseReader.ReadToFollowing("captureResponse"))
            {
                _captureResponseReader.Close();
            }
            if (!_captureGivenAuthResponseReader.ReadToFollowing("captureGivenAuthResponse"))
            {
                _captureGivenAuthResponseReader.Close();
            }
            if (!_creditResponseReader.ReadToFollowing("creditResponse"))
            {
                _creditResponseReader.Close();
            }
            if (!_forceCaptureResponseReader.ReadToFollowing("forceCaptureResponse"))
            {
                _forceCaptureResponseReader.Close();
            }
            if (!_echeckCreditResponseReader.ReadToFollowing("echeckCreditResponse"))
            {
                _echeckCreditResponseReader.Close();
            }
            if (!_echeckRedepositResponseReader.ReadToFollowing("echeckRedepositResponse"))
            {
                _echeckRedepositResponseReader.Close();
            }
            if (!_echeckSalesResponseReader.ReadToFollowing("echeckSalesResponse"))
            {
                _echeckSalesResponseReader.Close();
            }
            if (!_echeckVerificationResponseReader.ReadToFollowing("echeckVerificationResponse"))
            {
                _echeckVerificationResponseReader.Close();
            }
            if (!_saleResponseReader.ReadToFollowing("saleResponse"))
            {
                _saleResponseReader.Close();
            }
            if (!_registerTokenResponseReader.ReadToFollowing("registerTokenResponse"))
            {
                _registerTokenResponseReader.Close();
            }
            if (!_updateCardValidationNumOnTokenResponseReader.ReadToFollowing("updateCardValidationNumOnTokenResponse"))
            {
                _updateCardValidationNumOnTokenResponseReader.Close();
            }
            if (!_cancelSubscriptionResponseReader.ReadToFollowing("cancelSubscriptionResponse"))
            {
                _cancelSubscriptionResponseReader.Close();
            }
            if (!_updateSubscriptionResponseReader.ReadToFollowing("updateSubscriptionResponse"))
            {
                _updateSubscriptionResponseReader.Close();
            }
            if (!_createPlanResponseReader.ReadToFollowing("createPlanResponse"))
            {
                _createPlanResponseReader.Close();
            }
            if (!_updatePlanResponseReader.ReadToFollowing("updatePlanResponse"))
            {
                _updatePlanResponseReader.Close();
            }
            if (!_activateResponseReader.ReadToFollowing("activateResponse"))
            {
                _activateResponseReader.Close();
            }
            if (!_loadResponseReader.ReadToFollowing("loadResponse"))
            {
                _loadResponseReader.Close();
            }
            if (!_deactivateResponseReader.ReadToFollowing("deactivateResponse"))
            {
                _deactivateResponseReader.Close();
            }
            if (!_echeckPreNoteSaleResponseReader.ReadToFollowing("echeckPreNoteSaleResponse"))
            {
                _echeckPreNoteSaleResponseReader.Close();
            }
            if (!_echeckPreNoteCreditResponseReader.ReadToFollowing("echeckPreNoteCreditResponse"))
            {
                _echeckPreNoteCreditResponseReader.Close();
            }
            if (!_unloadResponseReader.ReadToFollowing("unloadResponse"))
            {
                _unloadResponseReader.Close();
            }
            if (!_balanceInquiryResponseReader.ReadToFollowing("balanceInquiryResponse"))
            {
                _balanceInquiryResponseReader.Close();
            }
            if (!_submerchantCreditResponseReader.ReadToFollowing("submerchantCreditResponse"))
            {
                _submerchantCreditResponseReader.Close();
            }
            if (!_payFacCreditResponseReader.ReadToFollowing("payFacCreditResponse"))
            {
                _payFacCreditResponseReader.Close();
            }
            if (!_vendorCreditResponseReader.ReadToFollowing("vendorCreditResponse"))
            {
                _vendorCreditResponseReader.Close();
            }
            if (!_reserveCreditResponseReader.ReadToFollowing("reserveCreditResponse"))
            {
                _reserveCreditResponseReader.Close();
            }
            if (!_physicalCheckCreditResponseReader.ReadToFollowing("physicalCheckCreditResponse"))
            {
                _physicalCheckCreditResponseReader.Close();
            }
            if (!_submerchantDebitResponseReader.ReadToFollowing("submerchantDebitResponse"))
            {
                _submerchantDebitResponseReader.Close();
            }
            if (!_payFacDebitResponseReader.ReadToFollowing("payFacDebitResponse"))
            {
                _payFacDebitResponseReader.Close();
            }
            if (!_vendorDebitResponseReader.ReadToFollowing("vendorDebitResponse"))
            {
                _vendorDebitResponseReader.Close();
            }
            if (!_reserveDebitResponseReader.ReadToFollowing("reserveDebitResponse"))
            {
                _reserveDebitResponseReader.Close();
            }
            if (!_physicalCheckDebitResponseReader.ReadToFollowing("physicalCheckDebitResponse"))
            {
                _physicalCheckDebitResponseReader.Close();
            }
        }

        public virtual AccountUpdateResponse NextAccountUpdateResponse()
        {
            if (_accountUpdateResponseReader.ReadState == ReadState.Closed) return null;
            string response = _accountUpdateResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (AccountUpdateResponse));
            var reader = new StringReader(response);
            var i = (AccountUpdateResponse) serializer.Deserialize(reader);

            if (!_accountUpdateResponseReader.ReadToFollowing("accountUpdateResponse"))
            {
                _accountUpdateResponseReader.Close();
            }

            return i;
        }

        public virtual AuthorizationResponse NextAuthorizationResponse()
        {
            if (_authorizationResponseReader.ReadState == ReadState.Closed) return null;
            string response = _authorizationResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (AuthorizationResponse));
            var reader = new StringReader(response);
            var i = (AuthorizationResponse) serializer.Deserialize(reader);

            if (!_authorizationResponseReader.ReadToFollowing("authorizationResponse"))
            {
                _authorizationResponseReader.Close();
            }

            return i;
        }

        public virtual AuthReversalResponse NextAuthReversalResponse()
        {
            if (_authReversalResponseReader.ReadState == ReadState.Closed) return null;
            string response = _authReversalResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (AuthReversalResponse));
            var reader = new StringReader(response);
            var i = (AuthReversalResponse) serializer.Deserialize(reader);

            if (!_authReversalResponseReader.ReadToFollowing("authReversalResponse"))
            {
                _authReversalResponseReader.Close();
            }

            return i;
        }

        public virtual CaptureResponse NextCaptureResponse()
        {
            if (_captureResponseReader.ReadState == ReadState.Closed) return null;
            string response = _captureResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CaptureResponse));
            var reader = new StringReader(response);
            var i = (CaptureResponse) serializer.Deserialize(reader);

            if (!_captureResponseReader.ReadToFollowing("captureResponse"))
            {
                _captureResponseReader.Close();
            }

            return i;
        }

        public virtual CaptureGivenAuthResponse NextCaptureGivenAuthResponse()
        {
            if (_captureGivenAuthResponseReader.ReadState == ReadState.Closed) return null;
            string response = _captureGivenAuthResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CaptureGivenAuthResponse));
            var reader = new StringReader(response);
            var i = (CaptureGivenAuthResponse) serializer.Deserialize(reader);

            if (!_captureGivenAuthResponseReader.ReadToFollowing("captureGivenAuthResponse"))
            {
                _captureGivenAuthResponseReader.Close();
            }

            return i;
        }

        public virtual CreditResponse NextCreditResponse()
        {
            if (_creditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _creditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CreditResponse));
            var reader = new StringReader(response);
            var i = (CreditResponse) serializer.Deserialize(reader);

            if (!_creditResponseReader.ReadToFollowing("creditResponse"))
            {
                _creditResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckCreditResponse NextEcheckCreditResponse()
        {
            if (_echeckCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckCreditResponse));
            var reader = new StringReader(response);
            var i = (EcheckCreditResponse) serializer.Deserialize(reader);

            if (!_echeckCreditResponseReader.ReadToFollowing("echeckCreditResponse"))
            {
                _echeckCreditResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckRedepositResponse NextEcheckRedepositResponse()
        {
            if (_echeckRedepositResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckRedepositResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckRedepositResponse));
            var reader = new StringReader(response);
            var i = (EcheckRedepositResponse) serializer.Deserialize(reader);

            if (!_echeckRedepositResponseReader.ReadToFollowing("echeckRedepositResponse"))
            {
                _echeckRedepositResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckSalesResponse NextEcheckSalesResponse()
        {
            if (_echeckSalesResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckSalesResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckSalesResponse));
            var reader = new StringReader(response);
            var i = (EcheckSalesResponse) serializer.Deserialize(reader);

            if (!_echeckSalesResponseReader.ReadToFollowing("echeckSalesResponse"))
            {
                _echeckSalesResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckVerificationResponse NextEcheckVerificationResponse()
        {
            if (_echeckVerificationResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckVerificationResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckVerificationResponse));
            var reader = new StringReader(response);
            var i = (EcheckVerificationResponse) serializer.Deserialize(reader);

            if (!_echeckVerificationResponseReader.ReadToFollowing("echeckVerificationResponse"))
            {
                _echeckVerificationResponseReader.Close();
            }

            return i;
        }

        public virtual ForceCaptureResponse NextForceCaptureResponse()
        {
            if (_forceCaptureResponseReader.ReadState == ReadState.Closed) return null;
            string response = _forceCaptureResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ForceCaptureResponse));
            var reader = new StringReader(response);
            var i = (ForceCaptureResponse) serializer.Deserialize(reader);

            if (!_forceCaptureResponseReader.ReadToFollowing("forceCaptureResponse"))
            {
                _forceCaptureResponseReader.Close();
            }

            return i;
        }

        public virtual RegisterTokenResponse NextRegisterTokenResponse()
        {
            if (_registerTokenResponseReader.ReadState == ReadState.Closed) return null;
            string response = _registerTokenResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (RegisterTokenResponse));
            var reader = new StringReader(response);
            var i = (RegisterTokenResponse) serializer.Deserialize(reader);

            if (!_registerTokenResponseReader.ReadToFollowing("registerTokenResponse"))
            {
                _registerTokenResponseReader.Close();
            }

            return i;
        }

        public virtual SaleResponse NextSaleResponse()
        {
            if (_saleResponseReader.ReadState == ReadState.Closed) return null;
            string response = _saleResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (SaleResponse));
            var reader = new StringReader(response);
            var i = (SaleResponse) serializer.Deserialize(reader);

            if (!_saleResponseReader.ReadToFollowing("saleResponse"))
            {
                _saleResponseReader.Close();
            }

            return i;
        }

        public virtual UpdateCardValidationNumOnTokenResponse NextUpdateCardValidationNumOnTokenResponse()
        {
            if (_updateCardValidationNumOnTokenResponseReader.ReadState == ReadState.Closed) return null;
            string response = _updateCardValidationNumOnTokenResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UpdateCardValidationNumOnTokenResponse));
            var reader = new StringReader(response);
            var i =
                (UpdateCardValidationNumOnTokenResponse) serializer.Deserialize(reader);

            if (
                !_updateCardValidationNumOnTokenResponseReader.ReadToFollowing(
                    "updateCardValidationNumOnTokenResponse"))
            {
                _updateCardValidationNumOnTokenResponseReader.Close();
            }

            return i;
        }

        public virtual UpdateSubscriptionResponse NextUpdateSubscriptionResponse()
        {
            if (_updateSubscriptionResponseReader.ReadState == ReadState.Closed) return null;
            string response = _updateSubscriptionResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UpdateSubscriptionResponse));
            var reader = new StringReader(response);
            var i = (UpdateSubscriptionResponse) serializer.Deserialize(reader);

            if (!_updateSubscriptionResponseReader.ReadToFollowing("updateSubscriptionResponse"))
            {
                _updateSubscriptionResponseReader.Close();
            }

            return i;
        }

        public virtual CancelSubscriptionResponse NextCancelSubscriptionResponse()
        {
            if (_cancelSubscriptionResponseReader.ReadState == ReadState.Closed) return null;
            string response = _cancelSubscriptionResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CancelSubscriptionResponse));
            var reader = new StringReader(response);
            var i = (CancelSubscriptionResponse) serializer.Deserialize(reader);

            if (!_cancelSubscriptionResponseReader.ReadToFollowing("cancelSubscriptionResponse"))
            {
                _cancelSubscriptionResponseReader.Close();
            }

            return i;
        }

        public virtual CreatePlanResponse NextCreatePlanResponse()
        {
            if (_createPlanResponseReader.ReadState == ReadState.Closed) return null;
            string response = _createPlanResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CreatePlanResponse));
            var reader = new StringReader(response);
            var i = (CreatePlanResponse) serializer.Deserialize(reader);

            if (!_createPlanResponseReader.ReadToFollowing("createPlanResponse"))
            {
                _createPlanResponseReader.Close();
            }

            return i;
        }

        public virtual UpdatePlanResponse NextUpdatePlanResponse()
        {
            if (_updatePlanResponseReader.ReadState == ReadState.Closed) return null;
            string response = _updatePlanResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UpdatePlanResponse));
            var reader = new StringReader(response);
            var i = (UpdatePlanResponse) serializer.Deserialize(reader);

            if (!_updatePlanResponseReader.ReadToFollowing("updatePlanResponse"))
            {
                _updatePlanResponseReader.Close();
            }

            return i;
        }

        public virtual ActivateResponse NextActivateResponse()
        {
            if (_activateResponseReader.ReadState == ReadState.Closed) return null;
            string response = _activateResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ActivateResponse));
            var reader = new StringReader(response);
            var i = (ActivateResponse) serializer.Deserialize(reader);

            if (!_activateResponseReader.ReadToFollowing("activateResponse"))
            {
                _activateResponseReader.Close();
            }

            return i;
        }

        public virtual DeactivateResponse NextDeactivateResponse()
        {
            if (_deactivateResponseReader.ReadState == ReadState.Closed) return null;
            string response = _deactivateResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (DeactivateResponse));
            var reader = new StringReader(response);
            var i = (DeactivateResponse) serializer.Deserialize(reader);

            if (!_deactivateResponseReader.ReadToFollowing("deactivateResponse"))
            {
                _deactivateResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckPreNoteSaleResponse NextEcheckPreNoteSaleResponse()
        {
            if (_echeckPreNoteSaleResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckPreNoteSaleResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckPreNoteSaleResponse));
            var reader = new StringReader(response);
            var i = (EcheckPreNoteSaleResponse) serializer.Deserialize(reader);

            if (!_echeckPreNoteSaleResponseReader.ReadToFollowing("echeckPreNoteSaleResponse"))
            {
                _echeckPreNoteSaleResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckPreNoteCreditResponse NextEcheckPreNoteCreditResponse()
        {
            if (_echeckPreNoteCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckPreNoteCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckPreNoteCreditResponse));
            var reader = new StringReader(response);
            var i = (EcheckPreNoteCreditResponse) serializer.Deserialize(reader);

            if (!_echeckPreNoteCreditResponseReader.ReadToFollowing("echeckPreNoteCreditResponse"))
            {
                _echeckPreNoteCreditResponseReader.Close();
            }

            return i;
        }

        public virtual LoadResponse NextLoadResponse()
        {
            if (_loadResponseReader.ReadState == ReadState.Closed) return null;
            string response = _loadResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (LoadResponse));
            var reader = new StringReader(response);
            var i = (LoadResponse) serializer.Deserialize(reader);

            if (!_loadResponseReader.ReadToFollowing("loadResponse"))
            {
                _loadResponseReader.Close();
            }

            return i;
        }

        public virtual UnloadResponse NextUnloadResponse()
        {
            if (_unloadResponseReader.ReadState == ReadState.Closed) return null;
            string response = _unloadResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UnloadResponse));
            var reader = new StringReader(response);
            var i = (UnloadResponse) serializer.Deserialize(reader);

            if (!_unloadResponseReader.ReadToFollowing("unloadResponse"))
            {
                _unloadResponseReader.Close();
            }

            return i;
        }

        public virtual BalanceInquiryResponse NextBalanceInquiryResponse()
        {
            if (_balanceInquiryResponseReader.ReadState == ReadState.Closed) return null;
            string response = _balanceInquiryResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (BalanceInquiryResponse));
            var reader = new StringReader(response);
            var i = (BalanceInquiryResponse) serializer.Deserialize(reader);

            if (!_balanceInquiryResponseReader.ReadToFollowing("balanceInquiryResponse"))
            {
                _balanceInquiryResponseReader.Close();
            }

            return i;
        }

        public virtual SubmerchantCreditResponse NextSubmerchantCreditResponse()
        {
            if (_submerchantCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _submerchantCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (SubmerchantCreditResponse));
            var reader = new StringReader(response);
            var i = (SubmerchantCreditResponse) serializer.Deserialize(reader);

            if (!_submerchantCreditResponseReader.ReadToFollowing("submerchantCreditResponse"))
            {
                _submerchantCreditResponseReader.Close();
            }

            return i;
        }

        public virtual PayFacCreditResponse NextPayFacCreditResponse()
        {
            if (_payFacCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _payFacCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PayFacCreditResponse));
            var reader = new StringReader(response);
            var i = (PayFacCreditResponse) serializer.Deserialize(reader);

            if (!_payFacCreditResponseReader.ReadToFollowing("payFacCreditResponse"))
            {
                _payFacCreditResponseReader.Close();
            }

            return i;
        }

        public virtual VendorCreditResponse NextVendorCreditResponse()
        {
            if (_vendorCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _vendorCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (VendorCreditResponse));
            var reader = new StringReader(response);
            var i = (VendorCreditResponse) serializer.Deserialize(reader);

            if (!_vendorCreditResponseReader.ReadToFollowing("vendorCreditResponse"))
            {
                _vendorCreditResponseReader.Close();
            }

            return i;
        }

        public virtual ReserveCreditResponse NextReserveCreditResponse()
        {
            if (_reserveCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _reserveCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ReserveCreditResponse));
            var reader = new StringReader(response);
            var i = (ReserveCreditResponse) serializer.Deserialize(reader);

            if (!_reserveCreditResponseReader.ReadToFollowing("reserveCreditResponse"))
            {
                _reserveCreditResponseReader.Close();
            }

            return i;
        }

        public virtual PhysicalCheckCreditResponse NextPhysicalCheckCreditResponse()
        {
            if (_physicalCheckCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _physicalCheckCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PhysicalCheckCreditResponse));
            var reader = new StringReader(response);
            var i = (PhysicalCheckCreditResponse) serializer.Deserialize(reader);

            if (!_physicalCheckCreditResponseReader.ReadToFollowing("physicalCheckCreditResponse"))
            {
                _physicalCheckCreditResponseReader.Close();
            }

            return i;
        }

        public virtual SubmerchantDebitResponse NextSubmerchantDebitResponse()
        {
            if (_submerchantDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _submerchantDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (SubmerchantDebitResponse));
            var reader = new StringReader(response);
            var i = (SubmerchantDebitResponse) serializer.Deserialize(reader);

            if (!_submerchantDebitResponseReader.ReadToFollowing("submerchantDebitResponse"))
            {
                _submerchantDebitResponseReader.Close();
            }

            return i;
        }

        public virtual PayFacDebitResponse NextPayFacDebitResponse()
        {
            if (_payFacDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _payFacDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PayFacDebitResponse));
            var reader = new StringReader(response);
            var i = (PayFacDebitResponse) serializer.Deserialize(reader);

            if (!_payFacDebitResponseReader.ReadToFollowing("payFacDebitResponse"))
            {
                _payFacDebitResponseReader.Close();
            }

            return i;
        }

        public virtual VendorDebitResponse NextVendorDebitResponse()
        {
            if (_vendorDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _vendorDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (VendorDebitResponse));
            var reader = new StringReader(response);
            var i = (VendorDebitResponse) serializer.Deserialize(reader);

            if (!_vendorDebitResponseReader.ReadToFollowing("vendorDebitResponse"))
            {
                _vendorDebitResponseReader.Close();
            }

            return i;
        }

        public virtual ReserveDebitResponse NextReserveDebitResponse()
        {
            if (_reserveDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _reserveDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ReserveDebitResponse));
            var reader = new StringReader(response);
            var i = (ReserveDebitResponse) serializer.Deserialize(reader);

            if (!_reserveDebitResponseReader.ReadToFollowing("reserveDebitResponse"))
            {
                _reserveDebitResponseReader.Close();
            }

            return i;
        }

        public virtual PhysicalCheckDebitResponse NextPhysicalCheckDebitResponse()
        {
            if (_physicalCheckDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _physicalCheckDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PhysicalCheckDebitResponse));
            var reader = new StringReader(response);
            var i = (PhysicalCheckDebitResponse) serializer.Deserialize(reader);

            if (!_physicalCheckDebitResponseReader.ReadToFollowing("physicalCheckDebitResponse"))
            {
                _physicalCheckDebitResponseReader.Close();
            }

            return i;
        }
    }


    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RFRResponse
    {
        [XmlAttribute] public string Response;
        [XmlAttribute] public string Message;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponseCardTokenType : CardTokenType
    {
        public string Bin;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponse : TransactionTypeWithReportGroup
    {
        public long LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public string Message;

        //Optional child elements
        public CardType UpdatedCard;
        public CardType OriginalCard;
        public AccountUpdateResponseCardTokenType OriginalToken;
        public AccountUpdateResponseCardTokenType UpdatedToken;
    }


    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckVoidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponseTransactionResponseEcheckVoidResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private string _messageField;
        private bool _duplicateField;
        private bool _duplicateFieldSpecified;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
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

        [XmlElement(DataType = "date")]
        public DateTime PostDate
        {
            get { return _postDateField; }
            set { _postDateField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("voidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponseTransactionResponseVoidResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private string _messageField;
        private bool _duplicateField;
        private bool _duplicateFieldSpecified;
        private VoidRecyclingResponseType _recyclingField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
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

        [XmlElement(DataType = "date")]
        public DateTime PostDate
        {
            get { return _postDateField; }
            set { _postDateField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

        public VoidRecyclingResponseType Recycling
        {
            get { return _recyclingField; }
            set { _recyclingField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class GiftCardResponse
    {
        public String AvailableBalance;
        public String BeginningBalance;
        public String EndingBalance;
        public String CashBackAmount;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class VirtualGiftCardResponseType
    {
        public String AccountNumber;
        public String CardValidationNum;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ActivateResponse : TransactionTypeWithReportGroup
    {
        [XmlAttribute] public bool Duplicate;
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
        public VirtualGiftCardResponseType VirtualGiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LoadResponse : TransactionTypeWithReportGroup
    {
        [XmlAttribute] public bool Duplicate;
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UnloadResponse : TransactionTypeWithReportGroup
    {
        [XmlAttribute] public bool Duplicate;
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BalanceInquiryResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DeactivateResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CreatePlanResponse : RecurringTransactionResponseType
    {
        public string PlanCode;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdatePlanResponse : RecurringTransactionResponseType
    {
        public string PlanCode;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LoadReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UnloadReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DeactivateReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ActivateReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RefundReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DepositReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }

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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteSaleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckPreNoteSaleResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckPreNoteCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class FraudCheckResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;
        private AdvancedFraudResultsType _advancedFraudResultsField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        public AdvancedFraudResultsType AdvancedFraudResults
        {
            get { return _advancedFraudResultsField; }
            set { _advancedFraudResultsField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class SubmerchantCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PayFacCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class VendorCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ReserveCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PhysicalCheckCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class SubmerchantDebitResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PayFacDebitResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class VendorDebitResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ReserveDebitResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PhysicalCheckDebitResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }
    }
}