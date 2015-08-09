using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk
{
    /// <remarks />
    [XmlInclude(typeof (RegisterTokenRequestType))]
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.litle.com/schema")]
    public class transactionTypeWithReportGroup : transactionType
    {
        /// <remarks />
        [XmlAttribute]
        public string reportGroup { get; set; }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class transactionResponse
    {
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class transactionRequest
    {
        public virtual string Serialize()
        {
            throw new NotImplementedException();
        }
    }

    /// <remarks />
    [XmlInclude(typeof (transactionTypeOptionReportGroup))]
    [XmlInclude(typeof (TransactionTypeWithReportGroupAndPartial))]
    [XmlInclude(typeof (transactionTypeWithReportGroup))]
    [XmlInclude(typeof (RegisterTokenRequestType))]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class transactionType : transactionRequest
    {
        private string idField;

        private string customerIdField;

        /// <remarks />
        [XmlAttribute]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public string customerId
        {
            get { return customerIdField; }
            set { customerIdField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class transactionTypeOptionReportGroup : transactionType
    {
        private string reportGroupField;

        /// <remarks />
        [XmlAttribute]
        public string reportGroup
        {
            get { return reportGroupField; }
            set { reportGroupField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class recurringTransactionResponseType : transactionResponse
    {
        private string litleTxnIdField;

        /// <remarks />
        public string litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        private string responseField;

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        private string messageField;

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        private DateTime responseTimeField;

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class recurringTransactionType : transactionRequest
    {
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        /// <remarks />
        expDate,

        /// <remarks />
        number,

        /// <remarks />
        track,

        /// <remarks />
        type,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum posCapabilityTypeEnum
    {
        /// <remarks />
        notused,

        /// <remarks />
        magstripe,

        /// <remarks />
        keyedonly,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum posEntryModeTypeEnum
    {
        /// <remarks />
        notused,

        /// <remarks />
        keyed,

        /// <remarks />
        track1,

        /// <remarks />
        track2,

        /// <remarks />
        completeread,
    }

    public sealed class posCatLevelEnum
    {
        public static readonly posCatLevelEnum selfservice = new posCatLevelEnum("self service");

        private posCatLevelEnum(String value)
        {
            this.value = value;
        }

        public string Serialize()
        {
            return value;
        }

        private readonly string value;
    }


    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum posCardholderIdTypeEnum
    {
        /// <remarks />
        signature,

        /// <remarks />
        pin,

        /// <remarks />
        nopin,

        /// <remarks />
        directmarket,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {
        /// <remarks />
        city,

        /// <remarks />
        phone,

        /// <remarks />
        url,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum govtTaxTypeEnum
    {
        /// <remarks />
        payment,

        /// <remarks />
        fee,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public enum enhancedDataDeliveryType
    {
        /// <remarks />
        CNC,

        /// <remarks />
        DIG,

        /// <remarks />
        PHY,

        /// <remarks />
        SVC,

        /// <remarks />
        TBD,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum taxTypeIdentifierEnum
    {
        /// <remarks />
        [XmlEnum("00")] Item00,

        /// <remarks />
        [XmlEnum("01")] Item01,

        /// <remarks />
        [XmlEnum("02")] Item02,

        /// <remarks />
        [XmlEnum("03")] Item03,

        /// <remarks />
        [XmlEnum("04")] Item04,

        /// <remarks />
        [XmlEnum("05")] Item05,

        /// <remarks />
        [XmlEnum("06")] Item06,

        /// <remarks />
        [XmlEnum("10")] Item10,

        /// <remarks />
        [XmlEnum("11")] Item11,

        /// <remarks />
        [XmlEnum("12")] Item12,

        /// <remarks />
        [XmlEnum("13")] Item13,

        /// <remarks />
        [XmlEnum("14")] Item14,

        /// <remarks />
        [XmlEnum("20")] Item20,

        /// <remarks />
        [XmlEnum("21")] Item21,

        /// <remarks />
        [XmlEnum("22")] Item22,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum IIASFlagType
    {
        /// <remarks />
        Y,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum recycleByTypeEnum
    {
        /// <remarks />
        Merchant,

        /// <remarks />
        Litle,

        /// <remarks />
        None,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public partial class FraudResult
    {
        private string avsResultField;

        private string cardValidationResultField;

        private string authenticationResultField;

        private string advancedAVSResultField;

        public advancedFraudResultsType advancedFraudResults;

        /// <remarks />
        public string avsResult
        {
            get { return avsResultField; }
            set { avsResultField = value; }
        }

        /// <remarks />
        public string cardValidationResult
        {
            get { return cardValidationResultField; }
            set { cardValidationResultField = value; }
        }

        /// <remarks />
        public string authenticationResult
        {
            get { return authenticationResultField; }
            set { authenticationResultField = value; }
        }

        /// <remarks />
        public string advancedAVSResult
        {
            get { return advancedAVSResultField; }
            set { advancedAVSResultField = value; }
        }
    }

    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class advancedFraudResultsType
    {
        public string deviceReviewStatus;
        public int deviceReputationScore;
        public string triggeredRule;
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class creditPaypal
    {
        private string itemField;

        private ItemChoiceType2 itemElementNameField;

        /// <remarks />
        [XmlElement("payerEmail", typeof (string))]
        [XmlElement("payerId", typeof (string))]
        [XmlChoiceIdentifier("ItemElementName")]
        public string Item
        {
            get { return itemField; }
            set { itemField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public ItemChoiceType2 ItemElementName
        {
            get { return itemElementNameField; }
            set { itemElementNameField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {
        /// <remarks />
        payerEmail,

        /// <remarks />
        payerId,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {
        /// <remarks />
        amexAggregatorData,

        /// <remarks />
        amount,

        /// <remarks />
        billMeLaterRequest,

        /// <remarks />
        billToAddress,

        /// <remarks />
        card,

        /// <remarks />
        customBilling,

        /// <remarks />
        enhancedData,

        /// <remarks />
        litleTxnId,

        /// <remarks />
        merchantData,

        /// <remarks />
        orderId,

        /// <remarks />
        orderSource,

        /// <remarks />
        paypage,

        /// <remarks />
        paypal,

        /// <remarks />
        pos,

        /// <remarks />
        processingInstructions,

        /// <remarks />
        taxType,

        /// <remarks />
        token,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum echeckAccountTypeEnum
    {
        /// <remarks />
        Checking,

        /// <remarks />
        Savings,

        /// <remarks />
        Corporate,

        /// <remarks />
        [XmlEnum("Corp Savings")] CorpSavings,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {
        /// <remarks />
        amount,

        /// <remarks />
        billToAddress,

        /// <remarks />
        customBilling,

        /// <remarks />
        echeck,

        /// <remarks />
        echeckOrEcheckToken,

        /// <remarks />
        echeckToken,

        /// <remarks />
        litleTxnId,

        /// <remarks />
        merchantData,

        /// <remarks />
        orderId,

        /// <remarks />
        orderSource,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckRedeposit", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class baseRequestTransactionEcheckRedeposit : transactionTypeWithReportGroup
    {
        protected long litleTxnIdField;
        protected bool litleTxnIdSet;

        private object itemField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set
            {
                litleTxnIdField = value;
                litleTxnIdSet = true;
            }
        }

        /// <remarks />
        [XmlElement("echeck", typeof (EcheckType))]
        [XmlElement("echeckToken", typeof (EcheckTokenType))]
        public object Item
        {
            get { return itemField; }
            set { itemField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {
        /// <remarks />
        amount,

        /// <remarks />
        billToAddress,

        /// <remarks />
        customBilling,

        /// <remarks />
        echeck,

        /// <remarks />
        echeckOrEcheckToken,

        /// <remarks />
        echeckToken,

        /// <remarks />
        litleTxnId,

        /// <remarks />
        merchantData,

        /// <remarks />
        orderId,

        /// <remarks />
        orderSource,

        /// <remarks />
        shipToAddress,

        /// <remarks />
        verify,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum Item1ChoiceType
    {
        /// <remarks />
        cardholderAuthentication,

        /// <remarks />
        fraudCheck,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class driversLicenseInfo
    {
        private string licenseNumberField;

        private string stateField;

        private string dateOfBirthField;

        /// <remarks />
        public string licenseNumber
        {
            get { return licenseNumberField; }
            set { licenseNumberField = value; }
        }

        /// <remarks />
        public string state
        {
            get { return stateField; }
            set { stateField = value; }
        }

        /// <remarks />
        public string dateOfBirth
        {
            get { return dateOfBirthField; }
            set { dateOfBirthField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class recycleAdviceType
    {
        private object itemField;

        /// <remarks />
        [XmlElement("nextRecycleTime", typeof (DateTime))]
        [XmlElement("recycleAdviceEnd", typeof (string))]
        public object Item
        {
            get { return itemField; }
            set { itemField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class recyclingType
    {
        private recycleAdviceType recycleAdviceField;

        private bool recycleEngineActiveField;

        /// <remarks />
        public recycleAdviceType recycleAdvice
        {
            get { return recycleAdviceField; }
            set { recycleAdviceField = value; }
        }

        /// <remarks />
        public bool recycleEngineActive
        {
            get { return recycleEngineActiveField; }
            set { recycleEngineActiveField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class recurringResponse
    {
        private long subscriptionIdField;
        private string responseCodeField;
        private string responseMessageField;
        private long recurringTxnIdField;

        /// <remarks />
        public long subscriptionId
        {
            get { return subscriptionIdField; }
            set { subscriptionIdField = value; }
        }

        /// <remarks />
        public string responseCode
        {
            get { return responseCodeField; }
            set { responseCodeField = value; }
        }

        /// <remarks />
        public string responseMessage
        {
            get { return responseMessageField; }
            set { responseMessageField = value; }
        }

        /// <remarks />
        public long recurringTxnId
        {
            get { return recurringTxnIdField; }
            set { recurringTxnIdField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class voidRecyclingResponseType
    {
        private long creditLitleTxnIdField;

        public long creditLitleTxnId
        {
            get { return creditLitleTxnIdField; }
            set { creditLitleTxnIdField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class tokenResponseType
    {
        private string litleTokenField;

        private string tokenResponseCodeField;

        private string tokenMessageField;

        private MethodOfPaymentTypeEnum typeField;

        private bool typeFieldSpecified;

        private string binField;

        private string eCheckAccountSuffixField;

        /// <remarks />
        public string litleToken
        {
            get { return litleTokenField; }
            set { litleTokenField = value; }
        }

        /// <remarks />
        public string tokenResponseCode
        {
            get { return tokenResponseCodeField; }
            set { tokenResponseCodeField = value; }
        }

        /// <remarks />
        public string tokenMessage
        {
            get { return tokenMessageField; }
            set { tokenMessageField = value; }
        }

        /// <remarks />
        public MethodOfPaymentTypeEnum type
        {
            get { return typeField; }
            set { typeField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool typeSpecified
        {
            get { return typeFieldSpecified; }
            set { typeFieldSpecified = value; }
        }

        /// <remarks />
        public string bin
        {
            get { return binField; }
            set { binField = value; }
        }

        /// <remarks />
        public string eCheckAccountSuffix
        {
            get { return eCheckAccountSuffixField; }
            set { eCheckAccountSuffixField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class cardTokenInfoType
    {
        private string litleTokenField;

        private MethodOfPaymentTypeEnum typeField;

        private string expDateField;

        private string binField;

        /// <remarks />
        public string litleToken
        {
            get { return litleTokenField; }
            set { litleTokenField = value; }
        }

        /// <remarks />
        public MethodOfPaymentTypeEnum type
        {
            get { return typeField; }
            set { typeField = value; }
        }

        /// <remarks />
        public string expDate
        {
            get { return expDateField; }
            set { expDateField = value; }
        }

        /// <remarks />
        public string bin
        {
            get { return binField; }
            set { binField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class extendedCardResponseType
    {
        private string messageField;

        private string codeField;

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public string code
        {
            get { return codeField; }
            set { codeField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class cardAccountInfoType
    {
        private MethodOfPaymentTypeEnum typeField;

        private string numberField;

        private string expDateField;

        /// <remarks />
        public MethodOfPaymentTypeEnum type
        {
            get { return typeField; }
            set { typeField = value; }
        }

        /// <remarks />
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }

        /// <remarks />
        public string expDate
        {
            get { return expDateField; }
            set { expDateField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class echeckTokenInfoType
    {
        private echeckAccountTypeEnum accTypeField;

        private string litleTokenField;

        private string routingNumField;

        /// <remarks />
        public echeckAccountTypeEnum accType
        {
            get { return accTypeField; }
            set { accTypeField = value; }
        }

        /// <remarks />
        public string litleToken
        {
            get { return litleTokenField; }
            set { litleTokenField = value; }
        }

        /// <remarks />
        public string routingNum
        {
            get { return routingNumField; }
            set { routingNumField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class echeckAccountInfoType
    {
        private echeckAccountTypeEnum accTypeField;

        private string accNumField;

        private string routingNumField;

        /// <remarks />
        public echeckAccountTypeEnum accType
        {
            get { return accTypeField; }
            set { accTypeField = value; }
        }

        /// <remarks />
        public string accNum
        {
            get { return accNumField; }
            set { accNumField = value; }
        }

        /// <remarks />
        public string routingNum
        {
            get { return routingNumField; }
            set { routingNumField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class accountInfoType
    {
        private MethodOfPaymentTypeEnum typeField;

        private string numberField;

        /// <remarks />
        public MethodOfPaymentTypeEnum type
        {
            get { return typeField; }
            set { typeField = value; }
        }

        /// <remarks />
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class billMeLaterResponseData
    {
        private long bmlMerchantIdField;

        private string promotionalOfferCodeField;

        private int approvedTermsCodeField;

        private bool approvedTermsCodeFieldSpecified;

        private string creditLineField;

        private string addressIndicatorField;

        private string loanToValueEstimatorField;

        private string riskEstimatorField;

        private string riskQueueAssignmentField;

        /// <remarks />
        public long bmlMerchantId
        {
            get { return bmlMerchantIdField; }
            set { bmlMerchantIdField = value; }
        }

        /// <remarks />
        public string promotionalOfferCode
        {
            get { return promotionalOfferCodeField; }
            set { promotionalOfferCodeField = value; }
        }

        /// <remarks />
        public int approvedTermsCode
        {
            get { return approvedTermsCodeField; }
            set { approvedTermsCodeField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool approvedTermsCodeSpecified
        {
            get { return approvedTermsCodeFieldSpecified; }
            set { approvedTermsCodeFieldSpecified = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "integer")]
        public string creditLine
        {
            get { return creditLineField; }
            set { creditLineField = value; }
        }

        /// <remarks />
        public string addressIndicator
        {
            get { return addressIndicatorField; }
            set { addressIndicatorField = value; }
        }

        /// <remarks />
        public string loanToValueEstimator
        {
            get { return loanToValueEstimatorField; }
            set { loanToValueEstimatorField = value; }
        }

        /// <remarks />
        public string riskEstimator
        {
            get { return riskEstimatorField; }
            set { riskEstimatorField = value; }
        }

        /// <remarks />
        public string riskQueueAssignment
        {
            get { return riskQueueAssignmentField; }
            set { riskQueueAssignmentField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class registerTokenResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string litleTokenField;

        private string binField;

        private MethodOfPaymentTypeEnum? typeField;

        private bool typeFieldSpecified;

        private string eCheckAccountSuffixField;

        private string responseField;

        private string messageField;

        private DateTime responseTimeField;

        private applepayResponse applepayResponseField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string litleToken
        {
            get { return litleTokenField; }
            set { litleTokenField = value; }
        }

        /// <remarks />
        public string bin
        {
            get { return binField; }
            set { binField = value; }
        }

        /// <remarks />
        public MethodOfPaymentTypeEnum? type
        {
            get { return typeFieldSpecified ? typeField : null; }
            set { typeField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool typeSpecified
        {
            get { return typeFieldSpecified; }
            set { typeFieldSpecified = value; }
        }

        /// <remarks />
        public string eCheckAccountSuffix
        {
            get { return eCheckAccountSuffixField; }
            set { eCheckAccountSuffixField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public applepayResponse applepayResponse
        {
            get { return applepayResponseField; }
            set { applepayResponseField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class updateCardValidationNumOnTokenResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private string messageField;

        private DateTime responseTimeField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class authorizationResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string cardProductIdField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        private string authCodeField;

        private string authorizationResponseSubCodeField;

        private string approvedAmountField;

        private accountInfoType accountInformationField;

        private accountUpdater accountUpdaterField;

        private FraudResult fraudResultField;

        private billMeLaterResponseData billMeLaterResponseDataField;

        private tokenResponseType tokenResponseField;

        private enhancedAuthResponse enhancedAuthResponseField;

        private recyclingType recyclingField;

        private recurringResponse recurringResponseField;

        private giftCardResponse giftCardResponseField;

        private applepayResponse applepayResponseField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string cardProductId
        {
            get { return cardProductIdField; }
            set { cardProductIdField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public string authCode
        {
            get { return authCodeField; }
            set { authCodeField = value; }
        }

        /// <remarks />
        public string authorizationResponseSubCode
        {
            get { return authorizationResponseSubCodeField; }
            set { authorizationResponseSubCodeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "integer")]
        public string approvedAmount
        {
            get { return approvedAmountField; }
            set { approvedAmountField = value; }
        }

        /// <remarks />
        public accountInfoType accountInformation
        {
            get { return accountInformationField; }
            set { accountInformationField = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }

        /// <remarks />
        public FraudResult fraudResult
        {
            get { return fraudResultField; }
            set { fraudResultField = value; }
        }

        /// <remarks />
        public billMeLaterResponseData billMeLaterResponseData
        {
            get { return billMeLaterResponseDataField; }
            set { billMeLaterResponseDataField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }

        /// <remarks />
        public enhancedAuthResponse enhancedAuthResponse
        {
            get { return enhancedAuthResponseField; }
            set { enhancedAuthResponseField = value; }
        }

        /// <remarks />
        public recyclingType recycling
        {
            get { return recyclingField; }
            set { recyclingField = value; }
        }

        /// <remarks />
        public recurringResponse recurringResponse
        {
            get { return recurringResponseField; }
            set { recurringResponseField = value; }
        }

        /// <remarks />
        public giftCardResponse giftCardResponse
        {
            get { return giftCardResponseField; }
            set { giftCardResponseField = value; }
        }

        /// <remarks />
        public applepayResponse applepayResponse
        {
            get { return applepayResponseField; }
            set { applepayResponseField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class cancelSubscriptionResponse
    {
        private string subscriptionIdField;

        /// <remarks />
        public string subscriptionId
        {
            get { return subscriptionIdField; }
            set { subscriptionIdField = value; }
        }

        private string litleTxnIdField;

        /// <remarks />
        public string litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        private string responseField;

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        private string messageField;

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        private DateTime responseTimeField;

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class updateSubscriptionResponse
    {
        private string subscriptionIdField;

        /// <remarks />
        public string subscriptionId
        {
            get { return subscriptionIdField; }
            set { subscriptionIdField = value; }
        }

        private string litleTxnIdField;

        /// <remarks />
        public string litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        private string responseField;

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        private string messageField;

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        private DateTime responseTimeField;

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        public tokenResponseType tokenResponse;
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class accountUpdater
    {
        public extendedCardResponseType extendedCardResponse;
        public echeckAccountInfoType newAccountInfo;
        public cardAccountInfoType newCardInfo;
        public cardTokenInfoType newCardTokenInfo;
        public echeckTokenInfoType newTokenInfo;
        public echeckAccountInfoType originalAccountInfo;
        public cardAccountInfoType originalCardInfo;
        public cardTokenInfoType originalCardTokenInfo;
        public echeckTokenInfoType originalTokenInfo;
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {
        /// <remarks />
        extendedCardResponse,

        /// <remarks />
        newAccountInfo,

        /// <remarks />
        newCardInfo,

        /// <remarks />
        newCardTokenInfo,

        /// <remarks />
        newTokenInfo,

        /// <remarks />
        originalAccountInfo,

        /// <remarks />
        originalCardInfo,

        /// <remarks />
        originalCardTokenInfo,

        /// <remarks />
        originalTokenInfo,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class enhancedAuthResponse
    {
        //public string litleTxnId;
        //public string response;
        //public string message;
        //public System.DateTime responseTime;
        //public tokenResponseType tokenResponse;
        //public string virtualAccountNumber;
        //public enhancedAuthResponseFundingSource fundingSource;
        //public affluenceTypeEnum affluence;
        //public string issuerCountry;

        private enhancedAuthResponseFundingSource fundingSourceField;

        private affluenceTypeEnum? affluenceField;

        private bool affluenceFieldSpecified;

        private string issuerCountryField;

        private cardProductTypeEnum? cardProductTypeField;

        private bool cardProductTypeFieldSpecified;

        private bool virtualAccountNumberField;

        private bool virtualAccountNumberFieldSpecified;

        /// <remarks />
        public enhancedAuthResponseFundingSource fundingSource
        {
            get { return fundingSourceField; }
            set { fundingSourceField = value; }
        }

        /// <remarks />
        public affluenceTypeEnum? affluence
        {
            get
            {
                return affluenceFieldSpecified ? affluenceField : null;
                //(!null)?return ((affluenceTypeEnum?)this).affluenceField:return null;
            }
            set { affluenceField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool affluenceSpecified
        {
            get { return affluenceFieldSpecified; }
            set { affluenceFieldSpecified = value; }
        }

        /// <remarks />
        public string issuerCountry
        {
            get { return issuerCountryField; }
            set { issuerCountryField = value; }
        }

        /// <remarks />
        public cardProductTypeEnum? cardProductType
        {
            get { return cardProductTypeFieldSpecified ? cardProductTypeField : null; }
            set { cardProductTypeField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool cardProductTypeSpecified
        {
            get { return cardProductTypeFieldSpecified; }
            set { cardProductTypeFieldSpecified = value; }
        }

        /// <remarks />
        public bool virtualAccountNumber
        {
            get { return virtualAccountNumberField; }
            set { virtualAccountNumberField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool virtualAccountNumberSpecified
        {
            get { return virtualAccountNumberFieldSpecified; }
            set { virtualAccountNumberFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class enhancedAuthResponseFundingSource
    {
        private fundingSourceTypeEnum typeField;

        private string availableBalanceField;

        private string reloadableField;

        private string prepaidCardTypeField;

        /// <remarks />
        public fundingSourceTypeEnum type
        {
            get { return typeField; }
            set { typeField = value; }
        }

        /// <remarks />
        public string availableBalance
        {
            get { return availableBalanceField; }
            set { availableBalanceField = value; }
        }

        /// <remarks />
        public string reloadable
        {
            get { return reloadableField; }
            set { reloadableField = value; }
        }

        /// <remarks />
        public string prepaidCardType
        {
            get { return prepaidCardTypeField; }
            set { prepaidCardTypeField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum fundingSourceTypeEnum
    {
        /// <remarks />
        UNKNOWN,

        /// <remarks />
        PREPAID,

        /// <remarks />
        FSA,

        /// <remarks />
        CREDIT,

        /// <remarks />
        DEBIT,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum affluenceTypeEnum
    {
        /// <remarks />
        AFFLUENT,

        /// <remarks />
        [XmlEnum("MASS AFFLUENT")] MASSAFFLUENT,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum cardProductTypeEnum
    {
        /// <remarks />
        UNKNOWN,

        /// <remarks />
        COMMERCIAL,

        /// <remarks />
        CONSUMER,
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class authReversalResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        public giftCardResponse giftCardResponse;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class captureResponse : transactionTypeWithReportGroup
    {
        public giftCardResponse giftCardResponse;
        public FraudResult fraudResult;

        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        private accountUpdater accountUpdaterField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class forceCaptureResponse : transactionTypeWithReportGroup
    {
        public giftCardResponse giftCardResponse;
        public FraudResult fraudResult;
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        private tokenResponseType tokenResponseField;

        private accountUpdater accountUpdaterField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class captureGivenAuthResponse : transactionTypeWithReportGroup
    {
        public giftCardResponse giftCardResponse;
        public FraudResult fraudResult;
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        private tokenResponseType tokenResponseField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class saleResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string cardProductIdField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        private string authCodeField;

        private string authorizationResponseSubCodeField;

        private string approvedAmountField;

        private accountInfoType accountInformationField;

        private FraudResult fraudResultField;

        private billMeLaterResponseData billMeLaterResponseDataField;

        private tokenResponseType tokenResponseField;

        private enhancedAuthResponse enhancedAuthResponseField;

        private accountUpdater accountUpdaterField;

        private recyclingType recyclingField;

        private recurringResponse recurringResponseField;

        private giftCardResponse giftCardResponseField;

        private applepayResponse applepayResponseField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string cardProductId
        {
            get { return cardProductIdField; }
            set { cardProductIdField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public string authCode
        {
            get { return authCodeField; }
            set { authCodeField = value; }
        }

        /// <remarks />
        public string authorizationResponseSubCode
        {
            get { return authorizationResponseSubCodeField; }
            set { authorizationResponseSubCodeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "integer")]
        public string approvedAmount
        {
            get { return approvedAmountField; }
            set { approvedAmountField = value; }
        }

        /// <remarks />
        public accountInfoType accountInformation
        {
            get { return accountInformationField; }
            set { accountInformationField = value; }
        }

        /// <remarks />
        public FraudResult fraudResult
        {
            get { return fraudResultField; }
            set { fraudResultField = value; }
        }

        /// <remarks />
        public billMeLaterResponseData billMeLaterResponseData
        {
            get { return billMeLaterResponseDataField; }
            set { billMeLaterResponseDataField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }

        /// <remarks />
        public enhancedAuthResponse enhancedAuthResponse
        {
            get { return enhancedAuthResponseField; }
            set { enhancedAuthResponseField = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }

        /// <remarks />
        public recyclingType recycling
        {
            get { return recyclingField; }
            set { recyclingField = value; }
        }

        /// <remarks />
        public recurringResponse recurringResponse
        {
            get { return recurringResponseField; }
            set { recurringResponseField = value; }
        }

        /// <remarks />
        public giftCardResponse giftCardResponse
        {
            get { return giftCardResponseField; }
            set { giftCardResponseField = value; }
        }

        /// <remarks />
        public applepayResponse applepayResponse
        {
            get { return applepayResponseField; }
            set { applepayResponseField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class creditResponse : transactionTypeWithReportGroup
    {
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private string messageField;

        private tokenResponseType tokenResponseField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class echeckSalesResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        private string verificationCodeField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private accountUpdater accountUpdaterField;

        private tokenResponseType tokenResponseField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public string verificationCode
        {
            get { return verificationCodeField; }
            set { verificationCodeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class echeckCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private accountUpdater accountUpdaterField;

        private tokenResponseType tokenResponseField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class echeckVerificationResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private tokenResponseType tokenResponseField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class echeckRedepositResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        private DateTime postDateField;

        private bool postDateFieldSpecified;

        private accountUpdater accountUpdaterField;

        private tokenResponseType tokenResponseField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool postDateSpecified
        {
            get { return postDateFieldSpecified; }
            set { postDateFieldSpecified = value; }
        }

        /// <remarks />
        public accountUpdater accountUpdater
        {
            get { return accountUpdaterField; }
            set { accountUpdaterField = value; }
        }

        /// <remarks />
        public tokenResponseType tokenResponse
        {
            get { return tokenResponseField; }
            set { tokenResponseField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class litleOnlineResponse
    {
        private string responseField;

        private string messageField;

        private string versionField;

        public authReversalResponse authReversalResponse;
        public authorizationResponse authorizationResponse;
        public captureGivenAuthResponse captureGivenAuthResponse;
        public captureResponse captureResponse;
        public creditResponse creditResponse;
        public echeckCreditResponse echeckCreditResponse;
        public echeckRedepositResponse echeckRedepositResponse;
        public echeckSalesResponse echeckSalesResponse;
        public echeckVerificationResponse echeckVerificationResponse;
        public litleOnlineResponseTransactionResponseEcheckVoidResponse echeckVoidResponse;
        public forceCaptureResponse forceCaptureResponse;
        public registerTokenResponse registerTokenResponse;
        public saleResponse saleResponse;
        public litleOnlineResponseTransactionResponseVoidResponse voidResponse;
        public updateCardValidationNumOnTokenResponse updateCardValidationNumOnTokenResponse;
        public cancelSubscriptionResponse cancelSubscriptionResponse;
        public updateSubscriptionResponse updateSubscriptionResponse;
        public activateResponse activateResponse;
        public deactivateResponse deactivateResponse;
        public loadResponse loadResponse;
        public unloadResponse unloadResponse;
        public balanceInquiryResponse balanceInquiryResponse;
        public createPlanResponse createPlanResponse;
        public updatePlanResponse updatePlanResponse;
        public refundReversalResponse refundReversalResponse;
        public depositReversalResponse depositReversalResponse;
        public activateReversalResponse activateReversalResponse;
        public deactivateReversalResponse deactivateReversalResponse;
        public loadReversalResponse loadReversalResponse;
        public unloadReversalResponse unloadReversalResponse;

        /// <remarks />
        [XmlAttribute]
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public string version
        {
            get { return versionField; }
            set { versionField = value; }
        }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot("litleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class litleResponse
    {
        public string id;
        public long litleBatchId;
        public long litleSessionId;
        public string merchantId;
        public string response;
        public string message;
        public string version;

        private XmlReader originalXmlReader;
        private XmlReader batchResponseReader;
        private XmlReader rfrResponseReader;
        private string filePath;

        public litleResponse()
        {
        }

        public litleResponse(string filePath)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            readXml(reader, filePath);
        }

        public litleResponse(XmlReader reader, string filePath)
        {
            readXml(reader, filePath);
        }

        public void setBatchResponseReader(XmlReader xmlReader)
        {
            batchResponseReader = xmlReader;
        }

        public void setRfrResponseReader(XmlReader xmlReader)
        {
            rfrResponseReader = xmlReader;
        }

        public void readXml(XmlReader reader, string filePath)
        {
            if (reader.ReadToFollowing("litleResponse"))
            {
                version = reader.GetAttribute("version");
                message = reader.GetAttribute("message");
                response = reader.GetAttribute("response");

                string rawLitleSessionId = reader.GetAttribute("litleSessionId");
                if (rawLitleSessionId != null)
                {
                    litleSessionId = Int64.Parse(rawLitleSessionId);
                }
            }
            else
            {
                reader.Close();
            }

            originalXmlReader = reader;
            this.filePath = filePath;

            batchResponseReader = new XmlTextReader(filePath);
            if (!batchResponseReader.ReadToFollowing("batchResponse"))
            {
                batchResponseReader.Close();
            }

            rfrResponseReader = new XmlTextReader(filePath);
            if (!rfrResponseReader.ReadToFollowing("RFRResponse"))
            {
                rfrResponseReader.Close();
            }
        }

        public virtual batchResponse nextBatchResponse()
        {
            if (batchResponseReader.ReadState != ReadState.Closed)
            {
                batchResponse litleBatchResponse = new batchResponse(batchResponseReader, filePath);
                if (!batchResponseReader.ReadToFollowing("batchResponse"))
                {
                    batchResponseReader.Close();
                }

                return litleBatchResponse;
            }

            return null;
        }

        public virtual RFRResponse nextRFRResponse()
        {
            if (rfrResponseReader.ReadState != ReadState.Closed)
            {
                string response = rfrResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (RFRResponse));
                StringReader reader = new StringReader(response);
                RFRResponse rfrResponse = (RFRResponse) serializer.Deserialize(reader);

                if (!rfrResponseReader.ReadToFollowing("RFRResponse"))
                {
                    rfrResponseReader.Close();
                }

                return rfrResponse;
            }

            return null;
        }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class batchResponse
    {
        public string id;
        public long litleBatchId;
        public string merchantId;

        private XmlReader originalXmlReader;
        private XmlReader accountUpdateResponseReader;
        private XmlReader authorizationResponseReader;
        private XmlReader authReversalResponseReader;
        private XmlReader captureResponseReader;
        private XmlReader captureGivenAuthResponseReader;
        private XmlReader creditResponseReader;
        private XmlReader forceCaptureResponseReader;
        private XmlReader echeckCreditResponseReader;
        private XmlReader echeckRedepositResponseReader;
        private XmlReader echeckSalesResponseReader;
        private XmlReader echeckVerificationResponseReader;
        private XmlReader saleResponseReader;
        private XmlReader registerTokenResponseReader;
        private XmlReader updateCardValidationNumOnTokenResponseReader;
        private XmlReader cancelSubscriptionResponseReader;
        private XmlReader updateSubscriptionResponseReader;
        private XmlReader createPlanResponseReader;
        private XmlReader updatePlanResponseReader;
        private XmlReader activateResponseReader;
        private XmlReader deactivateResponseReader;
        private XmlReader loadResponseReader;
        private XmlReader echeckPreNoteSaleResponseReader;
        private XmlReader echeckPreNoteCreditResponseReader;
        private XmlReader unloadResponseReader;
        private XmlReader balanceInquiryResponseReader;
        private XmlReader submerchantCreditResponseReader;
        private XmlReader payFacCreditResponseReader;
        private XmlReader vendorCreditResponseReader;
        private XmlReader reserveCreditResponseReader;
        private XmlReader physicalCheckCreditResponseReader;
        private XmlReader submerchantDebitResponseReader;
        private XmlReader payFacDebitResponseReader;
        private XmlReader vendorDebitResponseReader;
        private XmlReader reserveDebitResponseReader;
        private XmlReader physicalCheckDebitResponseReader;

        public batchResponse()
        {
        }

        public batchResponse(XmlReader xmlReader, string filePath)
        {
            readXml(xmlReader, filePath);
        }

        public void setAccountUpdateResponseReader(XmlReader xmlReader)
        {
            accountUpdateResponseReader = xmlReader;
        }

        public void setAuthorizationResponseReader(XmlReader xmlReader)
        {
            authorizationResponseReader = xmlReader;
        }

        public void setAuthReversalResponseReader(XmlReader xmlReader)
        {
            authReversalResponseReader = xmlReader;
        }

        public void setCaptureResponseReader(XmlReader xmlReader)
        {
            captureResponseReader = xmlReader;
        }

        public void setCaptureGivenAuthResponseReader(XmlReader xmlReader)
        {
            captureGivenAuthResponseReader = xmlReader;
        }

        public void setCreditResponseReader(XmlReader xmlReader)
        {
            creditResponseReader = xmlReader;
        }

        public void setForceCaptureResponseReader(XmlReader xmlReader)
        {
            forceCaptureResponseReader = xmlReader;
        }

        public void setEcheckCreditResponseReader(XmlReader xmlReader)
        {
            echeckCreditResponseReader = xmlReader;
        }

        public void setEcheckRedepositResponseReader(XmlReader xmlReader)
        {
            echeckRedepositResponseReader = xmlReader;
        }

        public void setEcheckSalesResponseReader(XmlReader xmlReader)
        {
            echeckSalesResponseReader = xmlReader;
        }

        public void setEcheckVerificationResponseReader(XmlReader xmlReader)
        {
            echeckVerificationResponseReader = xmlReader;
        }

        public void setSaleResponseReader(XmlReader xmlReader)
        {
            saleResponseReader = xmlReader;
        }

        public void setRegisterTokenResponseReader(XmlReader xmlReader)
        {
            registerTokenResponseReader = xmlReader;
        }

        public void setUpdateCardValidationNumOnTokenResponseReader(XmlReader xmlReader)
        {
            updateCardValidationNumOnTokenResponseReader = xmlReader;
        }

        public void setCancelSubscriptionResponseReader(XmlReader xmlReader)
        {
            cancelSubscriptionResponseReader = xmlReader;
        }

        public void setUpdateSubscriptionResponseReader(XmlReader xmlReader)
        {
            updateSubscriptionResponseReader = xmlReader;
        }

        public void setCreatePlanResponseReader(XmlReader xmlReader)
        {
            createPlanResponseReader = xmlReader;
        }

        public void setUpdatePlanResponseReader(XmlReader xmlReader)
        {
            updatePlanResponseReader = xmlReader;
        }

        public void setActivateResponseReader(XmlReader xmlReader)
        {
            activateResponseReader = xmlReader;
        }

        public void setDeactivateResponseReader(XmlReader xmlReader)
        {
            deactivateResponseReader = xmlReader;
        }

        public void setLoadResponseReader(XmlReader xmlReader)
        {
            loadResponseReader = xmlReader;
        }

        public void setEcheckPreNoteSaleResponseReader(XmlReader xmlReader)
        {
            echeckPreNoteSaleResponseReader = xmlReader;
        }

        public void setEcheckPreNoteCreditResponseReader(XmlReader xmlReader)
        {
            echeckPreNoteCreditResponseReader = xmlReader;
        }

        public void setUnloadResponseReader(XmlReader xmlReader)
        {
            unloadResponseReader = xmlReader;
        }

        public void setBalanceInquiryResponseReader(XmlReader xmlReader)
        {
            balanceInquiryResponseReader = xmlReader;
        }

        public void setSubmerchantCreditResponseReader(XmlReader xmlReader)
        {
            submerchantCreditResponseReader = xmlReader;
        }

        public void setPayFacCreditResponseReader(XmlReader xmlReader)
        {
            payFacCreditResponseReader = xmlReader;
        }

        public void setReserveCreditResponseReader(XmlReader xmlReader)
        {
            reserveCreditResponseReader = xmlReader;
        }

        public void setVendorCreditResponseReader(XmlReader xmlReader)
        {
            vendorCreditResponseReader = xmlReader;
        }

        public void setPhysicalCheckCreditResponseReader(XmlReader xmlReader)
        {
            physicalCheckCreditResponseReader = xmlReader;
        }

        public void setSubmerchantDebitResponseReader(XmlReader xmlReader)
        {
            submerchantDebitResponseReader = xmlReader;
        }

        public void setPayFacDebitResponseReader(XmlReader xmlReader)
        {
            payFacDebitResponseReader = xmlReader;
        }

        public void setReserveDebitResponseReader(XmlReader xmlReader)
        {
            reserveDebitResponseReader = xmlReader;
        }

        public void setVendorDebitResponseReader(XmlReader xmlReader)
        {
            vendorDebitResponseReader = xmlReader;
        }

        public void setPhysicalCheckDebitResponseReader(XmlReader xmlReader)
        {
            physicalCheckDebitResponseReader = xmlReader;
        }


        public void readXml(XmlReader reader, string filePath)
        {
            id = reader.GetAttribute("id");
            litleBatchId = Int64.Parse(reader.GetAttribute("litleBatchId"));
            merchantId = reader.GetAttribute("merchantId");

            originalXmlReader = reader;
            accountUpdateResponseReader = new XmlTextReader(filePath);
            authorizationResponseReader = new XmlTextReader(filePath);
            authReversalResponseReader = new XmlTextReader(filePath);
            captureResponseReader = new XmlTextReader(filePath);
            captureGivenAuthResponseReader = new XmlTextReader(filePath);
            creditResponseReader = new XmlTextReader(filePath);
            forceCaptureResponseReader = new XmlTextReader(filePath);
            echeckCreditResponseReader = new XmlTextReader(filePath);
            echeckRedepositResponseReader = new XmlTextReader(filePath);
            echeckSalesResponseReader = new XmlTextReader(filePath);
            echeckVerificationResponseReader = new XmlTextReader(filePath);
            saleResponseReader = new XmlTextReader(filePath);
            registerTokenResponseReader = new XmlTextReader(filePath);
            updateCardValidationNumOnTokenResponseReader = new XmlTextReader(filePath);
            cancelSubscriptionResponseReader = new XmlTextReader(filePath);
            updateSubscriptionResponseReader = new XmlTextReader(filePath);
            createPlanResponseReader = new XmlTextReader(filePath);
            updatePlanResponseReader = new XmlTextReader(filePath);
            activateResponseReader = new XmlTextReader(filePath);
            deactivateResponseReader = new XmlTextReader(filePath);
            loadResponseReader = new XmlTextReader(filePath);
            echeckPreNoteSaleResponseReader = new XmlTextReader(filePath);
            echeckPreNoteCreditResponseReader = new XmlTextReader(filePath);
            unloadResponseReader = new XmlTextReader(filePath);
            balanceInquiryResponseReader = new XmlTextReader(filePath);
            submerchantCreditResponseReader = new XmlTextReader(filePath);
            payFacCreditResponseReader = new XmlTextReader(filePath);
            reserveCreditResponseReader = new XmlTextReader(filePath);
            vendorCreditResponseReader = new XmlTextReader(filePath);
            physicalCheckCreditResponseReader = new XmlTextReader(filePath);
            submerchantDebitResponseReader = new XmlTextReader(filePath);
            payFacDebitResponseReader = new XmlTextReader(filePath);
            reserveDebitResponseReader = new XmlTextReader(filePath);
            vendorDebitResponseReader = new XmlTextReader(filePath);
            physicalCheckDebitResponseReader = new XmlTextReader(filePath);

            if (!accountUpdateResponseReader.ReadToFollowing("accountUpdateResponse"))
            {
                accountUpdateResponseReader.Close();
            }
            if (!authorizationResponseReader.ReadToFollowing("authorizationResponse"))
            {
                authorizationResponseReader.Close();
            }
            if (!authReversalResponseReader.ReadToFollowing("authReversalResponse"))
            {
                authReversalResponseReader.Close();
            }
            if (!captureResponseReader.ReadToFollowing("captureResponse"))
            {
                captureResponseReader.Close();
            }
            if (!captureGivenAuthResponseReader.ReadToFollowing("captureGivenAuthResponse"))
            {
                captureGivenAuthResponseReader.Close();
            }
            if (!creditResponseReader.ReadToFollowing("creditResponse"))
            {
                creditResponseReader.Close();
            }
            if (!forceCaptureResponseReader.ReadToFollowing("forceCaptureResponse"))
            {
                forceCaptureResponseReader.Close();
            }
            if (!echeckCreditResponseReader.ReadToFollowing("echeckCreditResponse"))
            {
                echeckCreditResponseReader.Close();
            }
            if (!echeckRedepositResponseReader.ReadToFollowing("echeckRedepositResponse"))
            {
                echeckRedepositResponseReader.Close();
            }
            if (!echeckSalesResponseReader.ReadToFollowing("echeckSalesResponse"))
            {
                echeckSalesResponseReader.Close();
            }
            if (!echeckVerificationResponseReader.ReadToFollowing("echeckVerificationResponse"))
            {
                echeckVerificationResponseReader.Close();
            }
            if (!saleResponseReader.ReadToFollowing("saleResponse"))
            {
                saleResponseReader.Close();
            }
            if (!registerTokenResponseReader.ReadToFollowing("registerTokenResponse"))
            {
                registerTokenResponseReader.Close();
            }
            if (!updateCardValidationNumOnTokenResponseReader.ReadToFollowing("updateCardValidationNumOnTokenResponse"))
            {
                updateCardValidationNumOnTokenResponseReader.Close();
            }
            if (!cancelSubscriptionResponseReader.ReadToFollowing("cancelSubscriptionResponse"))
            {
                cancelSubscriptionResponseReader.Close();
            }
            if (!updateSubscriptionResponseReader.ReadToFollowing("updateSubscriptionResponse"))
            {
                updateSubscriptionResponseReader.Close();
            }
            if (!createPlanResponseReader.ReadToFollowing("createPlanResponse"))
            {
                createPlanResponseReader.Close();
            }
            if (!updatePlanResponseReader.ReadToFollowing("updatePlanResponse"))
            {
                updatePlanResponseReader.Close();
            }
            if (!activateResponseReader.ReadToFollowing("activateResponse"))
            {
                activateResponseReader.Close();
            }
            if (!loadResponseReader.ReadToFollowing("loadResponse"))
            {
                loadResponseReader.Close();
            }
            if (!deactivateResponseReader.ReadToFollowing("deactivateResponse"))
            {
                deactivateResponseReader.Close();
            }
            if (!echeckPreNoteSaleResponseReader.ReadToFollowing("echeckPreNoteSaleResponse"))
            {
                echeckPreNoteSaleResponseReader.Close();
            }
            if (!echeckPreNoteCreditResponseReader.ReadToFollowing("echeckPreNoteCreditResponse"))
            {
                echeckPreNoteCreditResponseReader.Close();
            }
            if (!unloadResponseReader.ReadToFollowing("unloadResponse"))
            {
                unloadResponseReader.Close();
            }
            if (!balanceInquiryResponseReader.ReadToFollowing("balanceInquiryResponse"))
            {
                balanceInquiryResponseReader.Close();
            }
            if (!submerchantCreditResponseReader.ReadToFollowing("submerchantCreditResponse"))
            {
                submerchantCreditResponseReader.Close();
            }
            if (!payFacCreditResponseReader.ReadToFollowing("payFacCreditResponse"))
            {
                payFacCreditResponseReader.Close();
            }
            if (!vendorCreditResponseReader.ReadToFollowing("vendorCreditResponse"))
            {
                vendorCreditResponseReader.Close();
            }
            if (!reserveCreditResponseReader.ReadToFollowing("reserveCreditResponse"))
            {
                reserveCreditResponseReader.Close();
            }
            if (!physicalCheckCreditResponseReader.ReadToFollowing("physicalCheckCreditResponse"))
            {
                physicalCheckCreditResponseReader.Close();
            }
            if (!submerchantDebitResponseReader.ReadToFollowing("submerchantDebitResponse"))
            {
                submerchantDebitResponseReader.Close();
            }
            if (!payFacDebitResponseReader.ReadToFollowing("payFacDebitResponse"))
            {
                payFacDebitResponseReader.Close();
            }
            if (!vendorDebitResponseReader.ReadToFollowing("vendorDebitResponse"))
            {
                vendorDebitResponseReader.Close();
            }
            if (!reserveDebitResponseReader.ReadToFollowing("reserveDebitResponse"))
            {
                reserveDebitResponseReader.Close();
            }
            if (!physicalCheckDebitResponseReader.ReadToFollowing("physicalCheckDebitResponse"))
            {
                physicalCheckDebitResponseReader.Close();
            }
        }

        public virtual accountUpdateResponse nextAccountUpdateResponse()
        {
            if (accountUpdateResponseReader.ReadState != ReadState.Closed)
            {
                string response = accountUpdateResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (accountUpdateResponse));
                StringReader reader = new StringReader(response);
                accountUpdateResponse i = (accountUpdateResponse) serializer.Deserialize(reader);

                if (!accountUpdateResponseReader.ReadToFollowing("accountUpdateResponse"))
                {
                    accountUpdateResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual authorizationResponse nextAuthorizationResponse()
        {
            if (authorizationResponseReader.ReadState != ReadState.Closed)
            {
                string response = authorizationResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (authorizationResponse));
                StringReader reader = new StringReader(response);
                authorizationResponse i = (authorizationResponse) serializer.Deserialize(reader);

                if (!authorizationResponseReader.ReadToFollowing("authorizationResponse"))
                {
                    authorizationResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual authReversalResponse nextAuthReversalResponse()
        {
            if (authReversalResponseReader.ReadState != ReadState.Closed)
            {
                string response = authReversalResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (authReversalResponse));
                StringReader reader = new StringReader(response);
                authReversalResponse i = (authReversalResponse) serializer.Deserialize(reader);

                if (!authReversalResponseReader.ReadToFollowing("authReversalResponse"))
                {
                    authReversalResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual captureResponse nextCaptureResponse()
        {
            if (captureResponseReader.ReadState != ReadState.Closed)
            {
                string response = captureResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (captureResponse));
                StringReader reader = new StringReader(response);
                captureResponse i = (captureResponse) serializer.Deserialize(reader);

                if (!captureResponseReader.ReadToFollowing("captureResponse"))
                {
                    captureResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual captureGivenAuthResponse nextCaptureGivenAuthResponse()
        {
            if (captureGivenAuthResponseReader.ReadState != ReadState.Closed)
            {
                string response = captureGivenAuthResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (captureGivenAuthResponse));
                StringReader reader = new StringReader(response);
                captureGivenAuthResponse i = (captureGivenAuthResponse) serializer.Deserialize(reader);

                if (!captureGivenAuthResponseReader.ReadToFollowing("captureGivenAuthResponse"))
                {
                    captureGivenAuthResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual creditResponse nextCreditResponse()
        {
            if (creditResponseReader.ReadState != ReadState.Closed)
            {
                string response = creditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (creditResponse));
                StringReader reader = new StringReader(response);
                creditResponse i = (creditResponse) serializer.Deserialize(reader);

                if (!creditResponseReader.ReadToFollowing("creditResponse"))
                {
                    creditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual echeckCreditResponse nextEcheckCreditResponse()
        {
            if (echeckCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = echeckCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (echeckCreditResponse));
                StringReader reader = new StringReader(response);
                echeckCreditResponse i = (echeckCreditResponse) serializer.Deserialize(reader);

                if (!echeckCreditResponseReader.ReadToFollowing("echeckCreditResponse"))
                {
                    echeckCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual echeckRedepositResponse nextEcheckRedepositResponse()
        {
            if (echeckRedepositResponseReader.ReadState != ReadState.Closed)
            {
                string response = echeckRedepositResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (echeckRedepositResponse));
                StringReader reader = new StringReader(response);
                echeckRedepositResponse i = (echeckRedepositResponse) serializer.Deserialize(reader);

                if (!echeckRedepositResponseReader.ReadToFollowing("echeckRedepositResponse"))
                {
                    echeckRedepositResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual echeckSalesResponse nextEcheckSalesResponse()
        {
            if (echeckSalesResponseReader.ReadState != ReadState.Closed)
            {
                string response = echeckSalesResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (echeckSalesResponse));
                StringReader reader = new StringReader(response);
                echeckSalesResponse i = (echeckSalesResponse) serializer.Deserialize(reader);

                if (!echeckSalesResponseReader.ReadToFollowing("echeckSalesResponse"))
                {
                    echeckSalesResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual echeckVerificationResponse nextEcheckVerificationResponse()
        {
            if (echeckVerificationResponseReader.ReadState != ReadState.Closed)
            {
                string response = echeckVerificationResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (echeckVerificationResponse));
                StringReader reader = new StringReader(response);
                echeckVerificationResponse i = (echeckVerificationResponse) serializer.Deserialize(reader);

                if (!echeckVerificationResponseReader.ReadToFollowing("echeckVerificationResponse"))
                {
                    echeckVerificationResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual forceCaptureResponse nextForceCaptureResponse()
        {
            if (forceCaptureResponseReader.ReadState != ReadState.Closed)
            {
                string response = forceCaptureResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (forceCaptureResponse));
                StringReader reader = new StringReader(response);
                forceCaptureResponse i = (forceCaptureResponse) serializer.Deserialize(reader);

                if (!forceCaptureResponseReader.ReadToFollowing("forceCaptureResponse"))
                {
                    forceCaptureResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual registerTokenResponse nextRegisterTokenResponse()
        {
            if (registerTokenResponseReader.ReadState != ReadState.Closed)
            {
                string response = registerTokenResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (registerTokenResponse));
                StringReader reader = new StringReader(response);
                registerTokenResponse i = (registerTokenResponse) serializer.Deserialize(reader);

                if (!registerTokenResponseReader.ReadToFollowing("registerTokenResponse"))
                {
                    registerTokenResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual saleResponse nextSaleResponse()
        {
            if (saleResponseReader.ReadState != ReadState.Closed)
            {
                string response = saleResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (saleResponse));
                StringReader reader = new StringReader(response);
                saleResponse i = (saleResponse) serializer.Deserialize(reader);

                if (!saleResponseReader.ReadToFollowing("saleResponse"))
                {
                    saleResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual updateCardValidationNumOnTokenResponse nextUpdateCardValidationNumOnTokenResponse()
        {
            if (updateCardValidationNumOnTokenResponseReader.ReadState != ReadState.Closed)
            {
                string response = updateCardValidationNumOnTokenResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (updateCardValidationNumOnTokenResponse));
                StringReader reader = new StringReader(response);
                updateCardValidationNumOnTokenResponse i =
                    (updateCardValidationNumOnTokenResponse) serializer.Deserialize(reader);

                if (
                    !updateCardValidationNumOnTokenResponseReader.ReadToFollowing(
                        "updateCardValidationNumOnTokenResponse"))
                {
                    updateCardValidationNumOnTokenResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual updateSubscriptionResponse nextUpdateSubscriptionResponse()
        {
            if (updateSubscriptionResponseReader.ReadState != ReadState.Closed)
            {
                string response = updateSubscriptionResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (updateSubscriptionResponse));
                StringReader reader = new StringReader(response);
                updateSubscriptionResponse i = (updateSubscriptionResponse) serializer.Deserialize(reader);

                if (!updateSubscriptionResponseReader.ReadToFollowing("updateSubscriptionResponse"))
                {
                    updateSubscriptionResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual cancelSubscriptionResponse nextCancelSubscriptionResponse()
        {
            if (cancelSubscriptionResponseReader.ReadState != ReadState.Closed)
            {
                string response = cancelSubscriptionResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (cancelSubscriptionResponse));
                StringReader reader = new StringReader(response);
                cancelSubscriptionResponse i = (cancelSubscriptionResponse) serializer.Deserialize(reader);

                if (!cancelSubscriptionResponseReader.ReadToFollowing("cancelSubscriptionResponse"))
                {
                    cancelSubscriptionResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual createPlanResponse nextCreatePlanResponse()
        {
            if (createPlanResponseReader.ReadState != ReadState.Closed)
            {
                string response = createPlanResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (createPlanResponse));
                StringReader reader = new StringReader(response);
                createPlanResponse i = (createPlanResponse) serializer.Deserialize(reader);

                if (!createPlanResponseReader.ReadToFollowing("createPlanResponse"))
                {
                    createPlanResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual updatePlanResponse nextUpdatePlanResponse()
        {
            if (updatePlanResponseReader.ReadState != ReadState.Closed)
            {
                string response = updatePlanResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (updatePlanResponse));
                StringReader reader = new StringReader(response);
                updatePlanResponse i = (updatePlanResponse) serializer.Deserialize(reader);

                if (!updatePlanResponseReader.ReadToFollowing("updatePlanResponse"))
                {
                    updatePlanResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual activateResponse nextActivateResponse()
        {
            if (activateResponseReader.ReadState != ReadState.Closed)
            {
                string response = activateResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (activateResponse));
                StringReader reader = new StringReader(response);
                activateResponse i = (activateResponse) serializer.Deserialize(reader);

                if (!activateResponseReader.ReadToFollowing("activateResponse"))
                {
                    activateResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual deactivateResponse nextDeactivateResponse()
        {
            if (deactivateResponseReader.ReadState != ReadState.Closed)
            {
                string response = deactivateResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (deactivateResponse));
                StringReader reader = new StringReader(response);
                deactivateResponse i = (deactivateResponse) serializer.Deserialize(reader);

                if (!deactivateResponseReader.ReadToFollowing("deactivateResponse"))
                {
                    deactivateResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual echeckPreNoteSaleResponse nextEcheckPreNoteSaleResponse()
        {
            if (echeckPreNoteSaleResponseReader.ReadState != ReadState.Closed)
            {
                string response = echeckPreNoteSaleResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (echeckPreNoteSaleResponse));
                StringReader reader = new StringReader(response);
                echeckPreNoteSaleResponse i = (echeckPreNoteSaleResponse) serializer.Deserialize(reader);

                if (!echeckPreNoteSaleResponseReader.ReadToFollowing("echeckPreNoteSaleResponse"))
                {
                    echeckPreNoteSaleResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual echeckPreNoteCreditResponse nextEcheckPreNoteCreditResponse()
        {
            if (echeckPreNoteCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = echeckPreNoteCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (echeckPreNoteCreditResponse));
                StringReader reader = new StringReader(response);
                echeckPreNoteCreditResponse i = (echeckPreNoteCreditResponse) serializer.Deserialize(reader);

                if (!echeckPreNoteCreditResponseReader.ReadToFollowing("echeckPreNoteCreditResponse"))
                {
                    echeckPreNoteCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual loadResponse nextLoadResponse()
        {
            if (loadResponseReader.ReadState != ReadState.Closed)
            {
                string response = loadResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (loadResponse));
                StringReader reader = new StringReader(response);
                loadResponse i = (loadResponse) serializer.Deserialize(reader);

                if (!loadResponseReader.ReadToFollowing("loadResponse"))
                {
                    loadResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual unloadResponse nextUnloadResponse()
        {
            if (unloadResponseReader.ReadState != ReadState.Closed)
            {
                string response = unloadResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (unloadResponse));
                StringReader reader = new StringReader(response);
                unloadResponse i = (unloadResponse) serializer.Deserialize(reader);

                if (!unloadResponseReader.ReadToFollowing("unloadResponse"))
                {
                    unloadResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual balanceInquiryResponse nextBalanceInquiryResponse()
        {
            if (balanceInquiryResponseReader.ReadState != ReadState.Closed)
            {
                string response = balanceInquiryResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (balanceInquiryResponse));
                StringReader reader = new StringReader(response);
                balanceInquiryResponse i = (balanceInquiryResponse) serializer.Deserialize(reader);

                if (!balanceInquiryResponseReader.ReadToFollowing("balanceInquiryResponse"))
                {
                    balanceInquiryResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual submerchantCreditResponse nextSubmerchantCreditResponse()
        {
            if (submerchantCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = submerchantCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (submerchantCreditResponse));
                StringReader reader = new StringReader(response);
                submerchantCreditResponse i = (submerchantCreditResponse) serializer.Deserialize(reader);

                if (!submerchantCreditResponseReader.ReadToFollowing("submerchantCreditResponse"))
                {
                    submerchantCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual payFacCreditResponse nextPayFacCreditResponse()
        {
            if (payFacCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = payFacCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (payFacCreditResponse));
                StringReader reader = new StringReader(response);
                payFacCreditResponse i = (payFacCreditResponse) serializer.Deserialize(reader);

                if (!payFacCreditResponseReader.ReadToFollowing("payFacCreditResponse"))
                {
                    payFacCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual vendorCreditResponse nextVendorCreditResponse()
        {
            if (vendorCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = vendorCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (vendorCreditResponse));
                StringReader reader = new StringReader(response);
                vendorCreditResponse i = (vendorCreditResponse) serializer.Deserialize(reader);

                if (!vendorCreditResponseReader.ReadToFollowing("vendorCreditResponse"))
                {
                    vendorCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual reserveCreditResponse nextReserveCreditResponse()
        {
            if (reserveCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = reserveCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (reserveCreditResponse));
                StringReader reader = new StringReader(response);
                reserveCreditResponse i = (reserveCreditResponse) serializer.Deserialize(reader);

                if (!reserveCreditResponseReader.ReadToFollowing("reserveCreditResponse"))
                {
                    reserveCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual physicalCheckCreditResponse nextPhysicalCheckCreditResponse()
        {
            if (physicalCheckCreditResponseReader.ReadState != ReadState.Closed)
            {
                string response = physicalCheckCreditResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (physicalCheckCreditResponse));
                StringReader reader = new StringReader(response);
                physicalCheckCreditResponse i = (physicalCheckCreditResponse) serializer.Deserialize(reader);

                if (!physicalCheckCreditResponseReader.ReadToFollowing("physicalCheckCreditResponse"))
                {
                    physicalCheckCreditResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual submerchantDebitResponse nextSubmerchantDebitResponse()
        {
            if (submerchantDebitResponseReader.ReadState != ReadState.Closed)
            {
                string response = submerchantDebitResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (submerchantDebitResponse));
                StringReader reader = new StringReader(response);
                submerchantDebitResponse i = (submerchantDebitResponse) serializer.Deserialize(reader);

                if (!submerchantDebitResponseReader.ReadToFollowing("submerchantDebitResponse"))
                {
                    submerchantDebitResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual payFacDebitResponse nextPayFacDebitResponse()
        {
            if (payFacDebitResponseReader.ReadState != ReadState.Closed)
            {
                string response = payFacDebitResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (payFacDebitResponse));
                StringReader reader = new StringReader(response);
                payFacDebitResponse i = (payFacDebitResponse) serializer.Deserialize(reader);

                if (!payFacDebitResponseReader.ReadToFollowing("payFacDebitResponse"))
                {
                    payFacDebitResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual vendorDebitResponse nextVendorDebitResponse()
        {
            if (vendorDebitResponseReader.ReadState != ReadState.Closed)
            {
                string response = vendorDebitResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (vendorDebitResponse));
                StringReader reader = new StringReader(response);
                vendorDebitResponse i = (vendorDebitResponse) serializer.Deserialize(reader);

                if (!vendorDebitResponseReader.ReadToFollowing("vendorDebitResponse"))
                {
                    vendorDebitResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual reserveDebitResponse nextReserveDebitResponse()
        {
            if (reserveDebitResponseReader.ReadState != ReadState.Closed)
            {
                string response = reserveDebitResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (reserveDebitResponse));
                StringReader reader = new StringReader(response);
                reserveDebitResponse i = (reserveDebitResponse) serializer.Deserialize(reader);

                if (!reserveDebitResponseReader.ReadToFollowing("reserveDebitResponse"))
                {
                    reserveDebitResponseReader.Close();
                }

                return i;
            }

            return null;
        }

        public virtual physicalCheckDebitResponse nextPhysicalCheckDebitResponse()
        {
            if (physicalCheckDebitResponseReader.ReadState != ReadState.Closed)
            {
                string response = physicalCheckDebitResponseReader.ReadOuterXml();
                XmlSerializer serializer = new XmlSerializer(typeof (physicalCheckDebitResponse));
                StringReader reader = new StringReader(response);
                physicalCheckDebitResponse i = (physicalCheckDebitResponse) serializer.Deserialize(reader);

                if (!physicalCheckDebitResponseReader.ReadToFollowing("physicalCheckDebitResponse"))
                {
                    physicalCheckDebitResponseReader.Close();
                }

                return i;
            }

            return null;
        }
    }


    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RFRResponse
    {
        [XmlAttribute] public string response;
        [XmlAttribute] public string message;
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class accountUpdateResponseCardTokenType : CardTokenType
    {
        public string bin;
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class accountUpdateResponse : transactionTypeWithReportGroup
    {
        public long litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public string message;

        //Optional child elements
        public CardType updatedCard;
        public CardType originalCard;
        public accountUpdateResponseCardTokenType originalToken;
        public accountUpdateResponseCardTokenType updatedToken;
    }


    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckVoidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class litleOnlineResponseTransactionResponseEcheckVoidResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private string messageField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("voidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class litleOnlineResponseTransactionResponseVoidResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string responseField;

        private DateTime responseTimeField;

        private DateTime postDateField;

        private string messageField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        private voidRecyclingResponseType recyclingField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "date")]
        public DateTime postDate
        {
            get { return postDateField; }
            set { postDateField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }

        //private voidRecyclingResponseType recycling;
        public voidRecyclingResponseType recycling
        {
            get { return recyclingField; }
            set { recyclingField = value; }
        }
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class giftCardResponse
    {
        public String availableBalance;
        public String beginningBalance;
        public String endingBalance;
        public String cashBackAmount;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class virtualGiftCardResponseType
    {
        public String accountNumber;
        public String cardValidationNum;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class activateResponse : transactionTypeWithReportGroup
    {
        [XmlAttribute] public bool duplicate;
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
        public virtualGiftCardResponseType virtualGiftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class loadResponse : transactionTypeWithReportGroup
    {
        [XmlAttribute] public bool duplicate;
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class unloadResponse : transactionTypeWithReportGroup
    {
        [XmlAttribute] public bool duplicate;
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class balanceInquiryResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class deactivateResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class createPlanResponse : recurringTransactionResponseType
    {
        public string planCode;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class updatePlanResponse : recurringTransactionResponseType
    {
        public string planCode;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class loadReversalResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class unloadReversalResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class deactivateReversalResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class activateReversalResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class refundReversalResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class depositReversalResponse : transactionTypeWithReportGroup
    {
        public string litleTxnId;
        public string orderId;
        public string response;
        public DateTime responseTime;
        public DateTime postDate;
        public string message;
        public FraudResult fraudResult;
        public giftCardResponse giftCardResponse;
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class applepayResponse
    {
        private string applicationPrimaryAccountNumberField;

        private string applicationExpirationDateField;

        private string currencyCodeField;

        private string transactionAmountField;

        private string cardholderNameField;

        private string deviceManufacturerIdentifierField;

        private string paymentDataTypeField;

        private byte[] onlinePaymentCryptogramField;

        private string eciIndicatorField;

        /// <remarks />
        public string applicationPrimaryAccountNumber
        {
            get { return applicationPrimaryAccountNumberField; }
            set { applicationPrimaryAccountNumberField = value; }
        }

        /// <remarks />
        public string applicationExpirationDate
        {
            get { return applicationExpirationDateField; }
            set { applicationExpirationDateField = value; }
        }

        /// <remarks />
        public string currencyCode
        {
            get { return currencyCodeField; }
            set { currencyCodeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "integer")]
        public string transactionAmount
        {
            get { return transactionAmountField; }
            set { transactionAmountField = value; }
        }

        /// <remarks />
        public string cardholderName
        {
            get { return cardholderNameField; }
            set { cardholderNameField = value; }
        }

        /// <remarks />
        public string deviceManufacturerIdentifier
        {
            get { return deviceManufacturerIdentifierField; }
            set { deviceManufacturerIdentifierField = value; }
        }

        /// <remarks />
        public string paymentDataType
        {
            get { return paymentDataTypeField; }
            set { paymentDataTypeField = value; }
        }

        /// <remarks />
        [XmlElement(DataType = "base64Binary")]
        public byte[] onlinePaymentCryptogram
        {
            get { return onlinePaymentCryptogramField; }
            set { onlinePaymentCryptogramField = value; }
        }

        /// <remarks />
        public string eciIndicator
        {
            get { return eciIndicatorField; }
            set { eciIndicatorField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteSaleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class echeckPreNoteSaleResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class echeckPreNoteCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string orderIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        private bool duplicateField;

        private bool duplicateFieldSpecified;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string orderId
        {
            get { return orderIdField; }
            set { orderIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        [XmlAttribute]
        public bool duplicate
        {
            get { return duplicateField; }
            set { duplicateField = value; }
        }

        /// <remarks />
        [XmlIgnore]
        public bool duplicateSpecified
        {
            get { return duplicateFieldSpecified; }
            set { duplicateFieldSpecified = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class fraudCheckResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string responseField;

        private string messageField;

        private DateTime responseTimeField;

        private advancedFraudResultsType advancedFraudResultsField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public advancedFraudResultsType advancedFraudResults
        {
            get { return advancedFraudResultsField; }
            set { advancedFraudResultsField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class submerchantCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class payFacCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class vendorCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class reserveCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class physicalCheckCreditResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class submerchantDebitResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class payFacDebitResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class vendorDebitResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class reserveDebitResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }

    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class physicalCheckDebitResponse : transactionTypeWithReportGroup
    {
        private long litleTxnIdField;

        private string fundsTransferIdField;

        private string responseField;

        private DateTime responseTimeField;

        private string messageField;

        /// <remarks />
        public long litleTxnId
        {
            get { return litleTxnIdField; }
            set { litleTxnIdField = value; }
        }

        /// <remarks />
        public string fundsTransferId
        {
            get { return fundsTransferIdField; }
            set { fundsTransferIdField = value; }
        }

        /// <remarks />
        public string response
        {
            get { return responseField; }
            set { responseField = value; }
        }

        /// <remarks />
        public DateTime responseTime
        {
            get { return responseTimeField; }
            set { responseTimeField = value; }
        }

        /// <remarks />
        public string message
        {
            get { return messageField; }
            set { messageField = value; }
        }
    }
}