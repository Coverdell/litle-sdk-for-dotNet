using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class LitleOnlineRequest
    {
        public string MerchantId;
        public string MerchantSdk;
        public Authentication Authentication;
        public Authorization Authorization;
        public Capture Capture;
        public Credit Credit;
        public VoidTxn VoidTxn;
        public Sale Sale;
        public AuthReversal AuthReversal;
        public EcheckCredit EcheckCredit;
        public EcheckVerification EcheckVerification;
        public EcheckSale EcheckSale;
        public RegisterTokenRequestType RegisterTokenRequest;
        public ForceCapture ForceCapture;
        public CaptureGivenAuth CaptureGivenAuth;
        public EcheckRedeposit EcheckRedeposit;
        public EcheckVoid EcheckVoid;
        public UpdateCardValidationNumOnToken UpdateCardValidationNumOnToken;
        public UpdateSubscription UpdateSubscription;
        public CancelSubscription CancelSubscription;
        public Activate Activate;
        public Deactivate Deactivate;
        public Load Load;
        public Unload Unload;
        public BalanceInquiry BalanceInquiry;
        public CreatePlan CreatePlan;
        public UpdatePlan UpdatePlan;
        public RefundReversal RefundReversal;
        public LoadReversal LoadReversal;
        public DepositReversal DepositReversal;
        public ActivateReversal ActivateReversal;
        public DeactivateReversal DeactivateReversal;
        public UnloadReversal UnloadReversal;

        public string Serialize()
        {
            var xml = "<?xml version='1.0' encoding='utf-8'?>\r\n<litleOnlineRequest merchantId=\"" + MerchantId +
                         "\" version=\"9.3\" merchantSdk=\"" + MerchantSdk + "\" xmlns=\"http://www.litle.com/schema\">"
                         + Authentication.Serialize();

            if (Authorization != null) xml += Authorization.Serialize();
            else if (Capture != null) xml += Capture.Serialize();
            else if (Credit != null) xml += Credit.Serialize();
            else if (VoidTxn != null) xml += VoidTxn.Serialize();
            else if (Sale != null) xml += Sale.Serialize();
            else if (AuthReversal != null) xml += AuthReversal.Serialize();
            else if (EcheckCredit != null) xml += EcheckCredit.Serialize();
            else if (EcheckVerification != null) xml += EcheckVerification.Serialize();
            else if (EcheckSale != null) xml += EcheckSale.Serialize();
            else if (RegisterTokenRequest != null) xml += RegisterTokenRequest.Serialize();
            else if (ForceCapture != null) xml += ForceCapture.Serialize();
            else if (CaptureGivenAuth != null) xml += CaptureGivenAuth.Serialize();
            else if (EcheckRedeposit != null) xml += EcheckRedeposit.Serialize();
            else if (EcheckVoid != null) xml += EcheckVoid.Serialize();
            else if (UpdateCardValidationNumOnToken != null) xml += UpdateCardValidationNumOnToken.Serialize();
            else if (UpdateSubscription != null) xml += UpdateSubscription.Serialize();
            else if (CancelSubscription != null) xml += CancelSubscription.Serialize();
            else if (Activate != null) xml += Activate.Serialize();
            else if (Deactivate != null) xml += Deactivate.Serialize();
            else if (Load != null) xml += Load.Serialize();
            else if (Unload != null) xml += Unload.Serialize();
            else if (BalanceInquiry != null) xml += BalanceInquiry.Serialize();
            else if (CreatePlan != null) xml += CreatePlan.Serialize();
            else if (UpdatePlan != null) xml += UpdatePlan.Serialize();
            else if (RefundReversal != null) xml += RefundReversal.Serialize();
            else if (LoadReversal != null) xml += LoadReversal.Serialize();
            else if (DepositReversal != null) xml += DepositReversal.Serialize();
            else if (ActivateReversal != null) xml += ActivateReversal.Serialize();
            else if (DeactivateReversal != null) xml += DeactivateReversal.Serialize();
            else if (UnloadReversal != null) xml += UnloadReversal.Serialize();
            xml += "\r\n</litleOnlineRequest>";

            return xml;
        }
    }

    public class Authentication
    {
        public string User;
        public string Password;

        public String Serialize()
        {
            return "\r\n<authentication>\r\n<user>" + SecurityElement.Escape(User) + "</user>\r\n<password>" +
                   SecurityElement.Escape(Password) + "</password>\r\n</authentication>";
        }
    }

    public class CustomerInfo
    {
        public string Ssn;

        public DateTime Dob;

        public DateTime CustomerRegistrationDate;

        private CustomerInfoCustomerType _customerTypeField;
        private bool _customerTypeSet;

        public CustomerInfoCustomerType CustomerType
        {
            get { return _customerTypeField; }
            set
            {
                _customerTypeField = value;
                _customerTypeSet = true;
            }
        }

        private long _incomeAmountField;
        private bool _incomeAmountSet;

        public long IncomeAmount
        {
            get { return _incomeAmountField; }
            set
            {
                _incomeAmountField = value;
                _incomeAmountSet = true;
            }
        }

        private CurrencyCodeEnum _incomeCurrencyField;
        private bool _incomeCurrencySet;

        public CurrencyCodeEnum IncomeCurrency
        {
            get { return _incomeCurrencyField; }
            set
            {
                _incomeCurrencyField = value;
                _incomeCurrencySet = true;
            }
        }

        private bool _customerCheckingAccountField;
        private bool _customerCheckingAccountSet;

        public bool CustomerCheckingAccount
        {
            get { return _customerCheckingAccountField; }
            set
            {
                _customerCheckingAccountField = value;
                _customerCheckingAccountSet = true;
            }
        }

        private bool _customerSavingAccountField;
        private bool _customerSavingAccountSet;

        public bool CustomerSavingAccount
        {
            get { return _customerSavingAccountField; }
            set
            {
                _customerSavingAccountField = value;
                _customerSavingAccountSet = true;
            }
        }

        public string EmployerName;

        public string CustomerWorkTelephone;

        private CustomerInfoResidenceStatus _residenceStatusField;
        private bool _residenceStatusSet;

        public CustomerInfoResidenceStatus ResidenceStatus
        {
            get { return _residenceStatusField; }
            set
            {
                _residenceStatusField = value;
                _residenceStatusSet = true;
            }
        }

        private int _yearsAtResidenceField;
        private bool _yearsAtResidenceSet;

        public int YearsAtResidence
        {
            get { return _yearsAtResidenceField; }
            set
            {
                _yearsAtResidenceField = value;
                _yearsAtResidenceSet = true;
            }
        }

        private int _yearsAtEmployerField;
        private bool _yearsAtEmployerSet;

        public int YearsAtEmployer
        {
            get { return _yearsAtEmployerField; }
            set
            {
                _yearsAtEmployerField = value;
                _yearsAtEmployerSet = true;
            }
        }

        public CustomerInfo()
        {
            IncomeCurrency = CurrencyCodeEnum.USD;
        }

        public string Serialize()
        {
            var xml = "";
            if (Ssn != null)
            {
                xml += "\r\n<ssn>" + SecurityElement.Escape(Ssn) + "</ssn>";
            }
            xml += "\r\n<dob>" + XmlUtil.ToXsdDate(Dob) + "</dob>";
            xml += "\r\n<customerRegistrationDate>" + XmlUtil.ToXsdDate(CustomerRegistrationDate) +
                   "</customerRegistrationDate>";
            if (_customerTypeSet)
            {
                xml += "\r\n<customerType>" + _customerTypeField + "</customerType>";
            }
            if (_incomeAmountSet)
            {
                xml += "\r\n<incomeAmount>" + _incomeAmountField + "</incomeAmount>";
            }
            if (_incomeCurrencySet)
            {
                xml += "\r\n<incomeCurrency>" + _incomeCurrencyField + "</incomeCurrency>";
            }
            if (_customerCheckingAccountSet)
            {
                xml += "\r\n<customerCheckingAccount>" + _customerCheckingAccountField.ToString().ToLower() +
                       "</customerCheckingAccount>";
            }
            if (_customerSavingAccountSet)
            {
                xml += "\r\n<customerSavingAccount>" + _customerSavingAccountField.ToString().ToLower() +
                       "</customerSavingAccount>";
            }
            if (EmployerName != null)
            {
                xml += "\r\n<employerName>" + SecurityElement.Escape(EmployerName) + "</employerName>";
            }
            if (CustomerWorkTelephone != null)
            {
                xml += "\r\n<customerWorkTelephone>" + SecurityElement.Escape(CustomerWorkTelephone) +
                       "</customerWorkTelephone>";
            }
            if (_residenceStatusSet)
            {
                xml += "\r\n<residenceStatus>" + _residenceStatusField + "</residenceStatus>";
            }
            if (_yearsAtResidenceSet)
            {
                xml += "\r\n<yearsAtResidence>" + _yearsAtResidenceField + "</yearsAtResidence>";
            }
            if (_yearsAtEmployerSet)
            {
                xml += "\r\n<yearsAtEmployer>" + _yearsAtEmployerField + "</yearsAtEmployer>";
            }
            return xml;
        }
    }

    public enum CustomerInfoCustomerType
    {
        New,
        Existing,
    }

    public enum CurrencyCodeEnum
    {
        AUD,
        CAD,
        CHF,
        DKK,
        EUR,
        GBP,
        HKD,
        JPY,
        NOK,
        NZD,
        SEK,
        SGD,
        USD,
    }

    public enum CustomerInfoResidenceStatus
    {
        Own,
        Rent,
        Other,
    }

    public class EnhancedData
    {
        public string CustomerReference;
        private long _salesTaxField;
        private bool _salesTaxSet;

        public long SalesTax
        {
            get { return _salesTaxField; }
            set
            {
                _salesTaxField = value;
                _salesTaxSet = true;
            }
        }

        private enhancedDataDeliveryType _deliveryTypeField;
        private bool _deliveryTypeSet;

        public enhancedDataDeliveryType DeliveryType
        {
            get { return _deliveryTypeField; }
            set
            {
                _deliveryTypeField = value;
                _deliveryTypeSet = true;
            }
        }

        public bool TaxExemptField;
        public bool TaxExemptSet;

        public bool TaxExempt
        {
            get { return TaxExemptField; }
            set
            {
                TaxExemptField = value;
                TaxExemptSet = true;
            }
        }

        private long _discountAmountField;
        private bool _discountAmountSet;

        public long DiscountAmount
        {
            get { return _discountAmountField; }
            set
            {
                _discountAmountField = value;
                _discountAmountSet = true;
            }
        }

        private long _shippingAmountField;
        private bool _shippingAmountSet;

        public long ShippingAmount
        {
            get { return _shippingAmountField; }
            set
            {
                _shippingAmountField = value;
                _shippingAmountSet = true;
            }
        }

        private long _dutyAmountField;
        private bool _dutyAmountSet;

        public long DutyAmount
        {
            get { return _dutyAmountField; }
            set
            {
                _dutyAmountField = value;
                _dutyAmountSet = true;
            }
        }

        public string ShipFromPostalCode;
        public string DestinationPostalCode;
        private CountryTypeEnum _destinationCountryCodeField;
        private bool _destinationCountryCodeSet;

        public CountryTypeEnum DestinationCountry
        {
            get { return _destinationCountryCodeField; }
            set
            {
                _destinationCountryCodeField = value;
                _destinationCountryCodeSet = true;
            }
        }

        public string InvoiceReferenceNumber;
        private DateTime _orderDateField;
        private bool _orderDateSet;

        public DateTime OrderDate
        {
            get { return _orderDateField; }
            set
            {
                _orderDateField = value;
                _orderDateSet = true;
            }
        }

        public List<DetailTax> DetailTaxes;
        public List<LineItemData> LineItems;

        public EnhancedData()
        {
            LineItems = new List<LineItemData>();
            DetailTaxes = new List<DetailTax>();
        }

        public string Serialize()
        {
            var xml = "";
            if (CustomerReference != null)
                xml += "\r\n<customerReference>" + SecurityElement.Escape(CustomerReference) + "</customerReference>";
            if (_salesTaxSet) xml += "\r\n<salesTax>" + _salesTaxField + "</salesTax>";
            if (_deliveryTypeSet) xml += "\r\n<deliveryType>" + _deliveryTypeField + "</deliveryType>";
            if (TaxExemptSet) xml += "\r\n<taxExempt>" + TaxExemptField.ToString().ToLower() + "</taxExempt>";
            if (_discountAmountSet) xml += "\r\n<discountAmount>" + _discountAmountField + "</discountAmount>";
            if (_shippingAmountSet) xml += "\r\n<shippingAmount>" + _shippingAmountField + "</shippingAmount>";
            if (_dutyAmountSet) xml += "\r\n<dutyAmount>" + _dutyAmountField + "</dutyAmount>";
            if (ShipFromPostalCode != null)
                xml += "\r\n<shipFromPostalCode>" + SecurityElement.Escape(ShipFromPostalCode) + "</shipFromPostalCode>";
            if (DestinationPostalCode != null)
                xml += "\r\n<destinationPostalCode>" + SecurityElement.Escape(DestinationPostalCode) +
                       "</destinationPostalCode>";
            if (_destinationCountryCodeSet)
                xml += "\r\n<destinationCountryCode>" + _destinationCountryCodeField + "</destinationCountryCode>";
            if (InvoiceReferenceNumber != null)
                xml += "\r\n<invoiceReferenceNumber>" + SecurityElement.Escape(InvoiceReferenceNumber) +
                       "</invoiceReferenceNumber>";
            if (_orderDateSet) xml += "\r\n<orderDate>" + XmlUtil.ToXsdDate(_orderDateField) + "</orderDate>";
            foreach (var detailTax in DetailTaxes)
            {
                xml += "\r\n<detailTax>" + detailTax.Serialize() + "\r\n</detailTax>";
            }
            foreach (var lineItem in LineItems)
            {
                xml += "\r\n<lineItemData>" + lineItem.Serialize() + "\r\n</lineItemData>";
            }
            return xml;
        }
    }

    public class VoidTxn : transactionTypeWithReportGroup
    {
        public long LitleTxnId;
        public ProcessingInstructions ProcessingInstructions;

        public override string Serialize()
        {
            var xml = "\r\n<void";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            if (ProcessingInstructions != null)
                xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            xml += "\r\n</void>";

            return xml;
        }
    }

    public class LineItemData
    {
        private int _itemSeqenceNumberField;
        private bool _itemSequenceNumberSet;

        public int ItemSequenceNumber
        {
            get { return _itemSeqenceNumberField; }
            set
            {
                _itemSeqenceNumberField = value;
                _itemSequenceNumberSet = true;
            }
        }

        public string ItemDescription;
        public string ProductCode;
        public string Quantity;
        public string UnitOfMeasure;
        private long _taxAmountField;
        private bool _taxAmountSet;

        public long TaxAmount
        {
            get { return _taxAmountField; }
            set
            {
                _taxAmountField = value;
                _taxAmountSet = true;
            }
        }

        private long _lineItemTotalField;
        private bool _lineItemTotalSet;

        public long LineItemTotal
        {
            get { return _lineItemTotalField; }
            set
            {
                _lineItemTotalField = value;
                _lineItemTotalSet = true;
            }
        }

        private long _lineItemTotalWithTaxField;
        private bool _lineItemTotalWithTaxSet;

        public long LineItemTotalWithTax
        {
            get { return _lineItemTotalWithTaxField; }
            set
            {
                _lineItemTotalWithTaxField = value;
                _lineItemTotalWithTaxSet = true;
            }
        }

        private long _itemDiscountAmountField;
        private bool _itemDiscountAmountSet;

        public long ItemDiscountAmount
        {
            get { return _itemDiscountAmountField; }
            set
            {
                _itemDiscountAmountField = value;
                _itemDiscountAmountSet = true;
            }
        }

        public string CommodityCode;
        public string UnitCost;
        public List<DetailTax> DetailTaxes;

        public LineItemData()
        {
            DetailTaxes = new List<DetailTax>();
        }

        public string Serialize()
        {
            var xml = "";
            if (_itemSequenceNumberSet)
                xml += "\r\n<itemSequenceNumber>" + _itemSeqenceNumberField + "</itemSequenceNumber>";
            if (ItemDescription != null)
                xml += "\r\n<itemDescription>" + SecurityElement.Escape(ItemDescription) + "</itemDescription>";
            if (ProductCode != null)
                xml += "\r\n<productCode>" + SecurityElement.Escape(ProductCode) + "</productCode>";
            if (Quantity != null) xml += "\r\n<quantity>" + SecurityElement.Escape(Quantity) + "</quantity>";
            if (UnitOfMeasure != null)
                xml += "\r\n<unitOfMeasure>" + SecurityElement.Escape(UnitOfMeasure) + "</unitOfMeasure>";
            if (_taxAmountSet) xml += "\r\n<taxAmount>" + _taxAmountField + "</taxAmount>";
            if (_lineItemTotalSet) xml += "\r\n<lineItemTotal>" + _lineItemTotalField + "</lineItemTotal>";
            if (_lineItemTotalWithTaxSet)
                xml += "\r\n<lineItemTotalWithTax>" + _lineItemTotalWithTaxField + "</lineItemTotalWithTax>";
            if (_itemDiscountAmountSet)
                xml += "\r\n<itemDiscountAmount>" + _itemDiscountAmountField + "</itemDiscountAmount>";
            if (CommodityCode != null)
                xml += "\r\n<commodityCode>" + SecurityElement.Escape(CommodityCode) + "</commodityCode>";
            if (UnitCost != null) xml += "\r\n<unitCost>" + SecurityElement.Escape(UnitCost) + "</unitCost>";
            foreach (var detailTax in DetailTaxes)
            {
                if (detailTax != null) xml += "\r\n<detailTax>" + detailTax.Serialize() + "</detailTax>";
            }
            return xml;
        }
    }

    public class DetailTax
    {
        private bool _taxIncludedInTotalField;
        private bool _taxIncludedInTotalSet;

        public bool TaxIncludedInTotal
        {
            get { return _taxIncludedInTotalField; }
            set
            {
                _taxIncludedInTotalField = value;
                _taxIncludedInTotalSet = true;
            }
        }

        private long _taxAmountField;
        private bool _taxAmountSet;

        public long TaxAmount
        {
            get { return _taxAmountField; }
            set
            {
                _taxAmountField = value;
                _taxAmountSet = true;
            }
        }

        public string TaxRate;
        private taxTypeIdentifierEnum _taxTypeIdentifierField;
        private bool _taxTypeIdentifierSet;

        public taxTypeIdentifierEnum TaxTypeIdentifier
        {
            get { return _taxTypeIdentifierField; }
            set
            {
                _taxTypeIdentifierField = value;
                _taxTypeIdentifierSet = true;
            }
        }

        public string CardAcceptorTaxId;

        public string Serialize()
        {
            var xml = "";
            if (_taxIncludedInTotalSet)
                xml += "\r\n<taxIncludedInTotal>" + _taxIncludedInTotalField.ToString().ToLower() +
                       "</taxIncludedInTotal>";
            if (_taxAmountSet) xml += "\r\n<taxAmount>" + _taxAmountField + "</taxAmount>";
            if (TaxRate != null) xml += "\r\n<taxRate>" + SecurityElement.Escape(TaxRate) + "</taxRate>";
            if (_taxTypeIdentifierSet)
                xml += "\r\n<taxTypeIdentifier>" + _taxTypeIdentifierField + "</taxTypeIdentifier>";
            if (CardAcceptorTaxId != null)
                xml += "\r\n<cardAcceptorTaxId>" + SecurityElement.Escape(CardAcceptorTaxId) + "</cardAcceptorTaxId>";
            return xml;
        }
    }

    public class TransactionTypeWithReportGroupAndPartial : transactionType
    {
        public string ReportGroup;
        private bool _partialField;
        protected bool PartialSet;

        public bool Partial
        {
            get { return _partialField; }
            set
            {
                _partialField = value;
                PartialSet = true;
            }
        }
    }

    public class Capture : TransactionTypeWithReportGroupAndPartial
    {
        public long LitleTxnId;
        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public EnhancedData EnhancedData;
        public ProcessingInstructions ProcessingInstructions;
        private bool _payPalOrderCompleteField;
        private bool _payPalOrderCompleteSet;

        public bool PayPalOrderComplete
        {
            get { return _payPalOrderCompleteField; }
            set
            {
                _payPalOrderCompleteField = value;
                _payPalOrderCompleteSet = true;
            }
        }

        public string PayPalNotes;

        public override string Serialize()
        {
            var xml = "\r\n<capture";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\"";
            if (PartialSet)
            {
                xml += " partial=\"" + Partial.ToString().ToLower() + "\"";
            }
            xml += ">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (EnhancedData != null) xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "\r\n</enhancedData>";
            if (ProcessingInstructions != null)
                xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            if (_payPalOrderCompleteSet)
                xml += "\r\n<payPalOrderComplete>" + _payPalOrderCompleteField.ToString().ToLower() +
                       "</payPalOrderComplete>";
            if (PayPalNotes != null)
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(PayPalNotes) + "</payPalNotes>";
            xml += "\r\n</capture>";

            return xml;
        }
    }

    public class EcheckCredit : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        public CustomBilling CustomBilling;
        public string OrderId;
        public OrderSourceType OrderSource;
        public Contact BillToAddress;
        public EcheckType Echeck;

        [Obsolete]
        public EcheckTokenType Token
        {
            get { return EcheckToken; }
            set { EcheckToken = value; }
        }

        public EcheckTokenType EcheckToken;

        public MerchantDataType MerchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckCredit";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
                if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (CustomBilling != null)
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "</customBilling>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
                xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
                if (BillToAddress != null)
                    xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "</billToAddress>";
                if (Echeck != null) xml += "\r\n<echeck>" + Echeck.Serialize() + "</echeck>";
                else if (EcheckToken != null) xml += "\r\n<echeckToken>" + EcheckToken.Serialize() + "</echeckToken>";
                if (CustomBilling != null)
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "</customBilling>";
                if (MerchantData != null) xml += "\r\n<merchantData>" + MerchantData.Serialize() + "</merchantData>";
            }
            xml += "\r\n</echeckCredit>";
            return xml;
        }
    }

    public class EcheckSale : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        public CustomBilling CustomBilling;
        public string OrderId;
        private bool _verifyField;
        private bool _verifySet;

        public bool Verify
        {
            get { return _verifyField; }
            set
            {
                _verifyField = value;
                _verifySet = true;
            }
        }

        public OrderSourceType OrderSource;
        public Contact BillToAddress;
        public Contact ShipToAddress;
        public EcheckType Echeck;
        public EcheckTokenType Token;
        public MerchantDataType MerchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckSale";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
                if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
                // let sandbox do the validation for secondaryAmount
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (CustomBilling != null)
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "</customBilling>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
                if (_verifySet) xml += "\r\n<verify>" + (_verifyField ? "true" : "false") + "</verify>";
                xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
                if (BillToAddress != null)
                    xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "</billToAddress>";
                if (ShipToAddress != null)
                    xml += "\r\n<shipToAddress>" + ShipToAddress.Serialize() + "</shipToAddress>";
                if (Echeck != null) xml += "\r\n<echeck>" + Echeck.Serialize() + "</echeck>";
                else if (Token != null) xml += "\r\n<echeckToken>" + Token.Serialize() + "</echeckToken>";
                if (CustomBilling != null)
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "</customBilling>";
                if (MerchantData != null) xml += "\r\n<merchantData>" + MerchantData.Serialize() + "</merchantData>";
            }
            xml += "\r\n</echeckSale>";
            return xml;
        }
    }

    public class EcheckVerification : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        public string OrderId;
        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        public OrderSourceType OrderSource;
        public Contact BillToAddress;
        public EcheckType Echeck;
        public EcheckTokenType Token;
        public MerchantDataType MerchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckVerification";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet) xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
            xml += "\r\n<orderId>" + OrderId + "</orderId>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            if (BillToAddress != null) xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "</billToAddress>";
            if (Echeck != null) xml += "\r\n<echeck>" + Echeck.Serialize() + "</echeck>";
            else if (Token != null) xml += "\r\n<echeckToken>" + Token.Serialize() + "</echeckToken>";
            if (MerchantData != null) xml += "\r\n<merchantData>" + MerchantData.Serialize() + "</merchantData>";
            xml += "\r\n</echeckVerification>";
            return xml;
        }
    }

    public class RegisterTokenRequestType : transactionTypeWithReportGroup
    {
        public string OrderId;
        public string AccountNumber;
        public EcheckForTokenType EcheckForToken;
        public string PaypageRegistrationId;
        public string CardValidationNum;
        public ApplepayType Applepay;

        public override string Serialize()
        {
            var xml = "\r\n<registerTokenRequest";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            xml += "\r\n<orderId>" + OrderId + "</orderId>";
            if (AccountNumber != null) xml += "\r\n<accountNumber>" + AccountNumber + "</accountNumber>";
            else if (EcheckForToken != null)
                xml += "\r\n<echeckForToken>" + EcheckForToken.Serialize() + "</echeckForToken>";
            else if (PaypageRegistrationId != null)
                xml += "\r\n<paypageRegistrationId>" + PaypageRegistrationId + "</paypageRegistrationId>";
            else if (Applepay != null) xml += "\r\n<applepay>" + Applepay.Serialize() + "\r\n</applepay>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + CardValidationNum + "</cardValidationNum>";
            xml += "\r\n</registerTokenRequest>";
            return xml;
        }
    }

    public class UpdateCardValidationNumOnToken : transactionTypeWithReportGroup
    {
        public string OrderId;
        public string LitleToken;
        public string CardValidationNum;

        public override string Serialize()
        {
            var xml = "\r\n<updateCardValidationNumOnToken";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (OrderId != null) xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            if (LitleToken != null) xml += "\r\n<litleToken>" + SecurityElement.Escape(LitleToken) + "</litleToken>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            xml += "\r\n</updateCardValidationNumOnToken>";
            return xml;
        }
    }

    public class EcheckForTokenType
    {
        public string AccNum;
        public string RoutingNum;

        public string Serialize()
        {
            var xml = "";
            if (AccNum != null) xml += "\r\n<accNum>" + SecurityElement.Escape(AccNum) + "</accNum>";
            if (RoutingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(RoutingNum) + "</routingNum>";
            return xml;
        }
    }

    public class Credit : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public CustomBilling CustomBilling;
        public EnhancedData EnhancedData;
        public ProcessingInstructions ProcessingInstructions;
        public string OrderId;
        public OrderSourceType OrderSource;
        public Contact BillToAddress;
        public CardType Card;
        public MposType Mpos;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        public PayPal Paypal;
        private taxTypeIdentifierEnum _taxTypeField;
        private bool _taxTypeSet;

        public taxTypeIdentifierEnum TaxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public BillMeLaterRequest BillMeLaterRequest;
        public Pos Pos;
        public AmexAggregatorData AmexAggregatorData;
        public MerchantDataType MerchantData;
        public String PayPalNotes;
        public String ActionReason;

        public override string Serialize()
        {
            var xml = "\r\n<credit";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
                if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
                if (CustomBilling != null)
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "</customBilling>";
                if (EnhancedData != null) xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "</enhancedData>";
                if (ProcessingInstructions != null)
                    xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                           "</processingInstructions>";
                if (Pos != null) xml += "\r\n<pos>" + Pos.Serialize() + "</pos>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
                xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
                if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
                if (BillToAddress != null)
                    xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "</billToAddress>";
                if (Card != null) xml += "\r\n<card>" + Card.Serialize() + "</card>";
                else if (Token != null) xml += "\r\n<token>" + Token.Serialize() + "</token>";
                else if (Mpos != null) xml += "\r\n<mpos>" + Mpos.Serialize() + "</mpos>";
                else if (Paypage != null) xml += "\r\n<paypage>" + Paypage.Serialize() + "</paypage>";
                else if (Paypal != null)
                {
                    xml += "\r\n<paypal>";
                    if (Paypal.PayerId != null)
                        xml += "\r\n<payerId>" + SecurityElement.Escape(Paypal.PayerId) + "</payerId>";
                    else if (Paypal.PayerEmail != null)
                        xml += "\r\n<payerEmail>" + SecurityElement.Escape(Paypal.PayerEmail) + "</payerEmail>";
                    xml += "\r\n</paypal>";
                }
                if (CustomBilling != null)
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "</customBilling>";
                if (_taxTypeSet) xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
                if (BillMeLaterRequest != null)
                    xml += "\r\n<billMeLaterRequest>" + BillMeLaterRequest.Serialize() + "</billMeLaterRequest>";
                if (EnhancedData != null) xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "</enhancedData>";
                if (ProcessingInstructions != null)
                    xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                           "</processingInstructions>";
                if (Pos != null) xml += "\r\n<pos>" + Pos.Serialize() + "</pos>";
                if (AmexAggregatorData != null)
                    xml += "\r\n<amexAggregatorData>" + AmexAggregatorData.Serialize() + "</amexAggregatorData>";
                if (MerchantData != null) xml += "\r\n<merchantData>" + MerchantData.Serialize() + "</merchantData>";
            }
            if (PayPalNotes != null)
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(PayPalNotes) + "</payPalNotes>";
            if (ActionReason != null)
                xml += "\r\n<actionReason>" + SecurityElement.Escape(ActionReason) + "</actionReason>";
            xml += "\r\n</credit>";
            return xml;
        }
    }

    public class EcheckType
    {
        private echeckAccountTypeEnum _accTypeField;
        private bool _accTypeSet;

        public echeckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set
            {
                _accTypeField = value;
                _accTypeSet = true;
            }
        }

        public string AccNum;
        public string RoutingNum;
        public string CheckNum;
        public string CcdPaymentInformation;

        public string Serialize()
        {
            var xml = "";
            var accTypeName = _accTypeField.ToString();
            var attributes =
                (XmlEnumAttribute[])
                    typeof (echeckAccountTypeEnum).GetMember(_accTypeField.ToString())[0].GetCustomAttributes(
                        typeof (XmlEnumAttribute), false);
            if (attributes.Length > 0) accTypeName = attributes[0].Name;
            if (_accTypeSet) xml += "\r\n<accType>" + accTypeName + "</accType>";
            if (AccNum != null) xml += "\r\n<accNum>" + SecurityElement.Escape(AccNum) + "</accNum>";
            if (RoutingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(RoutingNum) + "</routingNum>";
            if (CheckNum != null) xml += "\r\n<checkNum>" + SecurityElement.Escape(CheckNum) + "</checkNum>";
            if (CcdPaymentInformation != null)
                xml += "\r\n<ccdPaymentInformation>" + SecurityElement.Escape(CcdPaymentInformation) +
                       "</ccdPaymentInformation>";
            return xml;
        }
    }

    public class EcheckTokenType
    {
        public string LitleToken;
        public string RoutingNum;
        private echeckAccountTypeEnum _accTypeField;
        private bool _accTypeSet;

        public echeckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set
            {
                _accTypeField = value;
                _accTypeSet = true;
            }
        }

        public string CheckNum;

        public string Serialize()
        {
            var xml = "";
            if (LitleToken != null) xml += "\r\n<litleToken>" + SecurityElement.Escape(LitleToken) + "</litleToken>";
            if (RoutingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(RoutingNum) + "</routingNum>";
            if (_accTypeSet) xml += "\r\n<accType>" + _accTypeField + "</accType>";
            if (CheckNum != null) xml += "\r\n<checkNum>" + SecurityElement.Escape(CheckNum) + "</checkNum>";
            return xml;
        }
    }

    public class Pos
    {
        private posCapabilityTypeEnum _capabilityField;
        private bool _capabilitySet;

        public posCapabilityTypeEnum Capability
        {
            get { return _capabilityField; }
            set
            {
                _capabilityField = value;
                _capabilitySet = true;
            }
        }

        private posEntryModeTypeEnum _entryModeField;
        private bool _entryModeSet;

        public posEntryModeTypeEnum EntryMode
        {
            get { return _entryModeField; }
            set
            {
                _entryModeField = value;
                _entryModeSet = true;
            }
        }

        private posCardholderIdTypeEnum _cardholderIdField;
        private bool _cardholderIdSet;

        public posCardholderIdTypeEnum CardholderId
        {
            get { return _cardholderIdField; }
            set
            {
                _cardholderIdField = value;
                _cardholderIdSet = true;
            }
        }

        public string TerminalId;

        private posCatLevelEnum _catLevelField;
        private bool _catLevelSet;

        public posCatLevelEnum CatLevel
        {
            get { return _catLevelField; }
            set
            {
                _catLevelField = value;
                _catLevelSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_capabilitySet) xml += "\r\n<capability>" + _capabilityField + "</capability>";
            if (_entryModeSet) xml += "\r\n<entryMode>" + _entryModeField + "</entryMode>";
            if (_cardholderIdSet) xml += "\r\n<cardholderId>" + _cardholderIdField + "</cardholderId>";
            if (TerminalId != null) xml += "\r\n<terminalId>" + SecurityElement.Escape(TerminalId) + "</terminalId>";
            if (_catLevelSet) xml += "\r\n<catLevel>" + _catLevelField.Serialize() + "</catLevel>";
            return xml;
        }
    }

    public class PayPal
    {
        public string PayerId;
        public string PayerEmail;
        public string Token;
        public string TransactionId;

        public string Serialize()
        {
            var xml = "";
            if (PayerId != null) xml += "\r\n<payerId>" + SecurityElement.Escape(PayerId) + "</payerId>";
            if (PayerEmail != null) xml += "\r\n<payerEmail>" + SecurityElement.Escape(PayerEmail) + "</payerEmail>";
            if (Token != null) xml += "\r\n<token>" + SecurityElement.Escape(Token) + "</token>";
            if (TransactionId != null)
                xml += "\r\n<transactionId>" + SecurityElement.Escape(TransactionId) + "</transactionId>";
            return xml;
        }
    }

    public class MerchantDataType
    {
        public string Campaign;
        public string Affiliate;
        public string MerchantGroupingId;

        public string Serialize()
        {
            var xml = "";
            if (Campaign != null) xml += "\r\n<campaign>" + SecurityElement.Escape(Campaign) + "</campaign>";
            if (Affiliate != null) xml += "\r\n<affiliate>" + SecurityElement.Escape(Affiliate) + "</affiliate>";
            if (MerchantGroupingId != null)
                xml += "\r\n<merchantGroupingId>" + SecurityElement.Escape(MerchantGroupingId) + "</merchantGroupingId>";
            return xml;
        }
    }

    public class CardTokenType
    {
        public string LitleToken;
        public string ExpDate;
        public string CardValidationNum;
        private MethodOfPaymentTypeEnum _typeField;
        private bool _typeSet;

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set
            {
                _typeField = value;
                _typeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "\r\n<litleToken>" + SecurityElement.Escape(LitleToken) + "</litleToken>";
            if (ExpDate != null) xml += "\r\n<expDate>" + SecurityElement.Escape(ExpDate) + "</expDate>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            if (_typeSet) xml += "\r\n<type>" + MethodOfPaymentSerializer.Serialize(_typeField) + "</type>";
            return xml;
        }
    }

    public class CardPaypageType
    {
        public string PaypageRegistrationId;
        public string ExpDate;
        public string CardValidationNum;
        private MethodOfPaymentTypeEnum _typeField;
        private bool _typeSet;

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set
            {
                _typeField = value;
                _typeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "\r\n<paypageRegistrationId>" + SecurityElement.Escape(PaypageRegistrationId) +
                         "</paypageRegistrationId>";
            if (ExpDate != null) xml += "\r\n<expDate>" + SecurityElement.Escape(ExpDate) + "</expDate>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            if (_typeSet) xml += "\r\n<type>" + MethodOfPaymentSerializer.Serialize(_typeField) + "</type>";
            return xml;
        }
    }

    public class BillMeLaterRequest
    {
        private long _bmlMerchantIdField;
        private bool _bmlMerchantIdSet;

        public long BmlMerchantId
        {
            get { return _bmlMerchantIdField; }
            set
            {
                _bmlMerchantIdField = value;
                _bmlMerchantIdSet = true;
            }
        }

        private long _bmlProductTypeField;
        private bool _bmlProductTypeSet;

        public long BmlProductType
        {
            get { return _bmlProductTypeField; }
            set
            {
                _bmlProductTypeField = value;
                _bmlProductTypeSet = true;
            }
        }

        private int _termsAndConditionsField;
        private bool _termsAndConditionsSet;

        public int TermsAndConditions
        {
            get { return _termsAndConditionsField; }
            set
            {
                _termsAndConditionsField = value;
                _termsAndConditionsSet = true;
            }
        }

        public string PreapprovalNumber;
        private int _merchantPromotionalCodeField;
        private bool _merchantPromotionalCodeSet;

        public int MerchantPromotionalCode
        {
            get { return _merchantPromotionalCodeField; }
            set
            {
                _merchantPromotionalCodeField = value;
                _merchantPromotionalCodeSet = true;
            }
        }

        public string VirtualAuthenticationKeyPresenceIndicator;
        public string VirtualAuthenticationKeyData;
        private int _itemCategoryCodeField;
        private bool _itemCategoryCodeSet;

        public int ItemCategoryCode
        {
            get { return _itemCategoryCodeField; }
            set
            {
                _itemCategoryCodeField = value;
                _itemCategoryCodeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_bmlMerchantIdSet) xml += "\r\n<bmlMerchantId>" + _bmlMerchantIdField + "</bmlMerchantId>";
            if (_bmlProductTypeSet) xml += "\r\n<bmlProductType>" + _bmlProductTypeField + "</bmlProductType>";
            if (_termsAndConditionsSet)
                xml += "\r\n<termsAndConditions>" + _termsAndConditionsField + "</termsAndConditions>";
            if (PreapprovalNumber != null)
                xml += "\r\n<preapprovalNumber>" + SecurityElement.Escape(PreapprovalNumber) + "</preapprovalNumber>";
            if (_merchantPromotionalCodeSet)
                xml += "\r\n<merchantPromotionalCode>" + _merchantPromotionalCodeField + "</merchantPromotionalCode>";
            if (VirtualAuthenticationKeyPresenceIndicator != null)
                xml += "\r\n<virtualAuthenticationKeyPresenceIndicator>" +
                       SecurityElement.Escape(VirtualAuthenticationKeyPresenceIndicator) +
                       "</virtualAuthenticationKeyPresenceIndicator>";
            if (VirtualAuthenticationKeyData != null)
                xml += "\r\n<virtualAuthenticationKeyData>" + SecurityElement.Escape(VirtualAuthenticationKeyData) +
                       "</virtualAuthenticationKeyData>";
            if (_itemCategoryCodeSet) xml += "\r\n<itemCategoryCode>" + _itemCategoryCodeField + "</itemCategoryCode>";
            return xml;
        }
    }

    public class CustomBilling
    {
        public string Phone;
        public string City;
        public string Url;
        public string Descriptor;

        public string Serialize()
        {
            var xml = "";
            if (Phone != null) xml += "\r\n<phone>" + SecurityElement.Escape(Phone) + "</phone>";
            else if (City != null) xml += "\r\n<city>" + SecurityElement.Escape(City) + "</city>";
            else if (Url != null) xml += "\r\n<url>" + SecurityElement.Escape(Url) + "</url>";
            if (Descriptor != null) xml += "\r\n<descriptor>" + SecurityElement.Escape(Descriptor) + "</descriptor>";
            return xml;
        }
    }

    public class AmexAggregatorData
    {
        public string SellerId;
        public string SellerMerchantCategoryCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<sellerId>" + SecurityElement.Escape(SellerId) + "</sellerId>";
            xml += "\r\n<sellerMerchantCategoryCode>" + SecurityElement.Escape(SellerMerchantCategoryCode) +
                   "</sellerMerchantCategoryCode>";
            return xml;
        }
    }

    public class ProcessingInstructions
    {
        private bool _bypassVelocityCheckField;
        private bool _bypassVelocityCheckSet;

        public bool BypassVelocityCheck
        {
            get { return _bypassVelocityCheckField; }
            set
            {
                _bypassVelocityCheckField = value;
                _bypassVelocityCheckSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_bypassVelocityCheckSet)
                xml += "\r\n<bypassVelocityCheck>" + _bypassVelocityCheckField.ToString().ToLower() +
                       "</bypassVelocityCheck>";
            return xml;
        }
    }

    public class EcheckRedeposit : baseRequestTransactionEcheckRedeposit
    {
        //litleTxnIdField and set are in super
        public EcheckType Echeck;
        public EcheckTokenType Token;
        public MerchantDataType MerchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckRedeposit";
            xml += " id=\"" + id + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + customerId + "\"";
            }
            xml += " reportGroup=\"" + reportGroup + "\">";
            if (litleTxnIdSet) xml += "\r\n<litleTxnId>" + litleTxnIdField + "</litleTxnId>";
            if (Echeck != null) xml += "\r\n<echeck>" + Echeck.Serialize() + "</echeck>";
            else if (Token != null) xml += "\r\n<echeckToken>" + Token.Serialize() + "</echeckToken>";
            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>" + MerchantData.Serialize() + "\r\n</merchantData>";
            }
            xml += "\r\n</echeckRedeposit>";
            return xml;
        }
    }

    public class Authorization : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        public string OrderId;
        public long Amount;
        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public OrderSourceType OrderSource;
        public CustomerInfo CustomerInfo;
        public Contact BillToAddress;
        public Contact ShipToAddress;
        public CardType Card;
        public MposType Mpos;
        public PayPal Paypal;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        public ApplepayType Applepay;
        public BillMeLaterRequest BillMeLaterRequest;
        public FraudCheckType CardholderAuthentication;
        public ProcessingInstructions ProcessingInstructions;
        public Pos Pos;
        public CustomBilling CustomBilling;
        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum TaxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public EnhancedData EnhancedData;
        public AmexAggregatorData AmexAggregatorData;
        private bool _allowPartialAuthField;
        private bool _allowPartialAuthSet;

        public bool AllowPartialAuth
        {
            get { return _allowPartialAuthField; }
            set
            {
                _allowPartialAuthField = value;
                _allowPartialAuthSet = true;
            }
        }

        public HealthcareIIAS HealthcareIIAS;
        public FilteringType Filtering;
        public MerchantDataType MerchantData;
        public RecyclingRequestType RecyclingRequest;
        private bool _fraudFilterOverrideField;
        private bool _fraudFilterOverrideSet;

        public bool FraudFilterOverride
        {
            get { return _fraudFilterOverrideField; }
            set
            {
                _fraudFilterOverrideField = value;
                _fraudFilterOverrideSet = true;
            }
        }

        public RecurringRequest RecurringRequest;
        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool DebtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public AdvancedFraudChecksType AdvancedFraudChecks;
        public Wallet Wallet;

        public override String Serialize()
        {
            var xml = "\r\n<authorization";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
                xml += "\r\n<amount>" + Amount + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
                if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";

                if (CustomerInfo != null)
                {
                    xml += "\r\n<customerInfo>" + CustomerInfo.Serialize() + "\r\n</customerInfo>";
                }
                if (BillToAddress != null)
                {
                    xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "\r\n</billToAddress>";
                }
                if (ShipToAddress != null)
                {
                    xml += "\r\n<shipToAddress>" + ShipToAddress.Serialize() + "\r\n</shipToAddress>";
                }
                if (Card != null)
                {
                    xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
                }
                else if (Paypal != null)
                {
                    xml += "\r\n<paypal>" + Paypal.Serialize() + "\r\n</paypal>";
                }
                else if (Mpos != null)
                {
                    xml += "\r\n<mpos>" + Mpos.Serialize() + "\r\n</mpos>";
                }
                else if (Token != null)
                {
                    xml += "\r\n<token>" + Token.Serialize() + "\r\n</token>";
                }
                else if (Paypage != null)
                {
                    xml += "\r\n<paypage>" + Paypage.Serialize() + "\r\n</paypage>";
                }
                else if (Applepay != null)
                {
                    xml += "\r\n<applepay>" + Applepay.Serialize() + "\r\n</applepay>";
                }
                if (BillMeLaterRequest != null)
                {
                    xml += "\r\n<billMeLaterRequest>" + BillMeLaterRequest.Serialize() + "\r\n</billMeLaterRequest>";
                }
                if (CardholderAuthentication != null)
                {
                    xml += "\r\n<cardholderAuthentication>" + CardholderAuthentication.Serialize() +
                           "\r\n</cardholderAuthentication>";
                }
                if (ProcessingInstructions != null)
                {
                    xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                           "\r\n</processingInstructions>";
                }
                if (Pos != null)
                {
                    xml += "\r\n<pos>" + Pos.Serialize() + "\r\n</pos>";
                }
                if (CustomBilling != null)
                {
                    xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "\r\n</customBilling>";
                }
                if (_taxTypeSet)
                {
                    xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
                }
                if (EnhancedData != null)
                {
                    xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "\r\n</enhancedData>";
                }
                if (AmexAggregatorData != null)
                {
                    xml += "\r\n<amexAggregatorData>" + AmexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
                }
                if (_allowPartialAuthSet)
                {
                    xml += "\r\n<allowPartialAuth>" + _allowPartialAuthField.ToString().ToLower() + "</allowPartialAuth>";
                }
                if (HealthcareIIAS != null)
                {
                    xml += "\r\n<healthcareIIAS>" + HealthcareIIAS.Serialize() + "\r\n</healthcareIIAS>";
                }
                if (Filtering != null)
                {
                    xml += "\r\n<filtering>" + Filtering.Serialize() + "\r\n</filtering>";
                }
                if (MerchantData != null)
                {
                    xml += "\r\n<merchantData>" + MerchantData.Serialize() + "\r\n</merchantData>";
                }
                if (RecyclingRequest != null)
                {
                    xml += "\r\n<recyclingRequest>" + RecyclingRequest.Serialize() + "\r\n</recyclingRequest>";
                }
                if (_fraudFilterOverrideSet)
                    xml += "\r\n<fraudFilterOverride>" + _fraudFilterOverrideField.ToString().ToLower() +
                           "</fraudFilterOverride>";
                if (RecurringRequest != null)
                {
                    xml += "\r\n<recurringRequest>" + RecurringRequest.Serialize() + "\r\n</recurringRequest>";
                }
                if (_debtRepaymentSet)
                    xml += "\r\n<debtRepayment>" + DebtRepayment.ToString().ToLower() + "</debtRepayment>";
                if (AdvancedFraudChecks != null)
                {
                    xml += "\r\n<advancedFraudChecks>" + AdvancedFraudChecks.Serialize() + "\r\n</advancedFraudChecks>";
                }
                if (Wallet != null)
                {
                    xml += "\r\n<wallet>" + Wallet.Serialize() + "\r\n</wallet>";
                }
            }

            xml += "\r\n</authorization>";
            return xml;
        }
    }

    public class Sale : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        public string OrderId;
        public long Amount;
        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public OrderSourceType OrderSource;
        public CustomerInfo CustomerInfo;
        public Contact BillToAddress;
        public Contact ShipToAddress;
        public CardType Card;
        public MposType Mpos;
        public PayPal Paypal;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        public ApplepayType Applepay;
        public BillMeLaterRequest BillMeLaterRequest;
        public FraudCheckType CardholderAuthentication;
        public CustomBilling CustomBilling;
        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum TaxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public EnhancedData EnhancedData;
        public ProcessingInstructions ProcessingInstructions;
        public Pos Pos;
        private bool _payPalOrderCompleteField;
        private bool _payPalOrderCompleteSet;

        public bool PayPalOrderComplete
        {
            get { return _payPalOrderCompleteField; }
            set
            {
                _payPalOrderCompleteField = value;
                _payPalOrderCompleteSet = true;
            }
        }

        public string PayPalNotes;
        public AmexAggregatorData AmexAggregatorData;
        private bool _allowPartialAuthField;
        private bool _allowPartialAuthSet;

        public bool AllowPartialAuth
        {
            get { return _allowPartialAuthField; }
            set
            {
                _allowPartialAuthField = value;
                _allowPartialAuthSet = true;
            }
        }

        public HealthcareIIAS HealthcareIIAS;
        public FilteringType Filtering;
        public MerchantDataType MerchantData;
        public RecyclingRequestType RecyclingRequest;
        private bool _fraudFilterOverrideField;
        private bool _fraudFilterOverrideSet;

        public bool FraudFilterOverride
        {
            get { return _fraudFilterOverrideField; }
            set
            {
                _fraudFilterOverrideField = value;
                _fraudFilterOverrideSet = true;
            }
        }

        public RecurringRequest RecurringRequest;
        public LitleInternalRecurringRequest LitleInternalRecurringRequest;
        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool DebtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public AdvancedFraudChecksType AdvancedFraudChecks;
        public Wallet Wallet;

        public override String Serialize()
        {
            var xml = "\r\n<sale";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (_litleTxnIdSet) xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
            xml += "\r\n<orderId>" + OrderId + "</orderId>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            if (CustomerInfo != null)
            {
                xml += "\r\n<customerInfo>" + CustomerInfo.Serialize() + "\r\n</customerInfo>";
            }
            if (BillToAddress != null)
            {
                xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "\r\n</billToAddress>";
            }
            if (ShipToAddress != null)
            {
                xml += "\r\n<shipToAddress>" + ShipToAddress.Serialize() + "\r\n</shipToAddress>";
            }
            if (Card != null)
            {
                xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            }
            else if (Paypal != null)
            {
                xml += "\r\n<paypal>" + Paypal.Serialize() + "\r\n</paypal>";
            }
            else if (Token != null)
            {
                xml += "\r\n<token>" + Token.Serialize() + "\r\n</token>";
            }
            else if (Mpos != null)
            {
                xml += "\r\n<mpos>" + Mpos.Serialize() + "</mpos>";
            }
            else if (Paypage != null)
            {
                xml += "\r\n<paypage>" + Paypage.Serialize() + "\r\n</paypage>";
            }
            else if (Applepay != null)
            {
                xml += "\r\n<applepay>" + Applepay.Serialize() + "\r\n</applepay>";
            }
            if (BillMeLaterRequest != null)
            {
                xml += "\r\n<billMeLaterRequest>" + BillMeLaterRequest.Serialize() + "\r\n</billMeLaterRequest>";
            }
            if (CardholderAuthentication != null)
            {
                xml += "\r\n<cardholderAuthentication>" + CardholderAuthentication.Serialize() +
                       "\r\n</cardholderAuthentication>";
            }
            if (CustomBilling != null)
            {
                xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "\r\n</customBilling>";
            }
            if (_taxTypeSet)
            {
                xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
            }
            if (EnhancedData != null)
            {
                xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "\r\n</enhancedData>";
            }
            if (ProcessingInstructions != null)
            {
                xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            }
            if (Pos != null)
            {
                xml += "\r\n<pos>" + Pos.Serialize() + "\r\n</pos>";
            }
            if (_payPalOrderCompleteSet)
                xml += "\r\n<payPalOrderCompleteSet>" + _payPalOrderCompleteField.ToString().ToLower() +
                       "</payPalOrderCompleteSet>";
            if (PayPalNotes != null)
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(PayPalNotes) + "</payPalNotes>";
            if (AmexAggregatorData != null)
            {
                xml += "\r\n<amexAggregatorData>" + AmexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
            }
            if (_allowPartialAuthSet)
            {
                xml += "\r\n<allowPartialAuth>" + _allowPartialAuthField.ToString().ToLower() + "</allowPartialAuth>";
            }
            if (HealthcareIIAS != null)
            {
                xml += "\r\n<healthcareIIAS>" + HealthcareIIAS.Serialize() + "\r\n</healthcareIIAS>";
            }
            if (Filtering != null)
            {
                xml += "\r\n<filtering>" + Filtering.Serialize() + "\r\n</filtering>";
            }
            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>" + MerchantData.Serialize() + "\r\n</merchantData>";
            }
            if (RecyclingRequest != null)
            {
                xml += "\r\n<recyclingRequest>" + RecyclingRequest.Serialize() + "\r\n</recyclingRequest>";
            }
            if (_fraudFilterOverrideSet)
                xml += "\r\n<fraudFilterOverride>" + _fraudFilterOverrideField.ToString().ToLower() +
                       "</fraudFilterOverride>";
            if (RecurringRequest != null)
            {
                xml += "\r\n<recurringRequest>" + RecurringRequest.Serialize() + "\r\n</recurringRequest>";
            }
            if (LitleInternalRecurringRequest != null)
            {
                xml += "\r\n<litleInternalRecurringRequest>" + LitleInternalRecurringRequest.Serialize() +
                       "\r\n</litleInternalRecurringRequest>";
            }
            if (_debtRepaymentSet)
                xml += "\r\n<debtRepayment>" + DebtRepayment.ToString().ToLower() + "</debtRepayment>";
            if (AdvancedFraudChecks != null)
                xml += "\r\n<advancedFraudChecks>" + AdvancedFraudChecks.Serialize() + "\r\n</advancedFraudChecks>";
            if (Wallet != null)
            {
                xml += "\r\n<wallet>" + Wallet.Serialize() + "\r\n</wallet>";
            }
            xml += "\r\n</sale>";
            return xml;
        }
    }

    public class ForceCapture : transactionTypeWithReportGroup
    {
        public string OrderId;
        public long Amount;
        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public OrderSourceType OrderSource;
        public Contact BillToAddress;
        public CardType Card;
        public MposType Mpos;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        public CustomBilling CustomBilling;
        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum TaxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public EnhancedData EnhancedData;
        public ProcessingInstructions ProcessingInstructions;
        public Pos Pos;
        public AmexAggregatorData AmexAggregatorData;
        public MerchantDataType MerchantData;
        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool DebtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<forceCapture";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            if (BillToAddress != null)
            {
                xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "\r\n</billToAddress>";
            }
            if (Card != null)
            {
                xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            }
            else if (Token != null)
            {
                xml += "\r\n<token>" + Token.Serialize() + "\r\n</token>";
            }
            else if (Mpos != null)
            {
                xml += "\r\n<mpos>" + Mpos.Serialize() + "</mpos>";
            }
            else if (Paypage != null)
            {
                xml += "\r\n<paypage>" + Paypage.Serialize() + "\r\n</paypage>";
            }
            if (CustomBilling != null)
            {
                xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "\r\n</customBilling>";
            }
            if (_taxTypeSet)
            {
                xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
            }
            if (EnhancedData != null)
            {
                xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "\r\n</enhancedData>";
            }
            if (ProcessingInstructions != null)
            {
                xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            }
            if (Pos != null)
            {
                xml += "\r\n<pos>" + Pos.Serialize() + "\r\n</pos>";
            }
            if (AmexAggregatorData != null)
            {
                xml += "\r\n<amexAggregatorData>" + AmexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
            }
            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>" + MerchantData.Serialize() + "\r\n</merchantData>";
            }
            if (_debtRepaymentSet)
                xml += "\r\n<debtRepayment>" + DebtRepayment.ToString().ToLower() + "</debtRepayment>";
            xml += "\r\n</forceCapture>";
            return xml;
        }
    }

    public class CaptureGivenAuth : transactionTypeWithReportGroup
    {
        public string OrderId;
        public AuthInformation AuthInformation;
        public long Amount;
        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long SecondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public OrderSourceType OrderSource;
        public Contact BillToAddress;
        public Contact ShipToAddress;
        public CardType Card;
        public MposType Mpos;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        public CustomBilling CustomBilling;
        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum TaxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public BillMeLaterRequest BillMeLaterRequest;
        public EnhancedData EnhancedData;
        public ProcessingInstructions ProcessingInstructions;
        public Pos Pos;
        public AmexAggregatorData AmexAggregatorData;
        public MerchantDataType MerchantData;
        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool DebtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<captureGivenAuth";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            if (AuthInformation != null)
                xml += "\r\n<authInformation>" + AuthInformation.Serialize() + "\r\n</authInformation>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (OrderSource != null) xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            if (BillToAddress != null)
            {
                xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "\r\n</billToAddress>";
            }
            if (ShipToAddress != null)
            {
                xml += "\r\n<shipToAddress>" + ShipToAddress.Serialize() + "\r\n</shipToAddress>";
            }
            if (Card != null)
            {
                xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            }
            else if (Token != null)
            {
                xml += "\r\n<token>" + Token.Serialize() + "\r\n</token>";
            }
            else if (Mpos != null)
            {
                xml += "\r\n<mpos>" + Mpos.Serialize() + "</mpos>";
            }
            else if (Paypage != null)
            {
                xml += "\r\n<paypage>" + Paypage.Serialize() + "\r\n</paypage>";
            }
            if (CustomBilling != null)
            {
                xml += "\r\n<customBilling>" + CustomBilling.Serialize() + "\r\n</customBilling>";
            }
            if (_taxTypeSet)
            {
                xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
            }
            if (BillMeLaterRequest != null)
            {
                xml += "\r\n<billMeLaterRequest>" + BillMeLaterRequest.Serialize() + "\r\n</billMeLaterRequest>";
            }
            if (EnhancedData != null)
            {
                xml += "\r\n<enhancedData>" + EnhancedData.Serialize() + "\r\n</enhancedData>";
            }
            if (ProcessingInstructions != null)
            {
                xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            }
            if (Pos != null)
            {
                xml += "\r\n<pos>" + Pos.Serialize() + "\r\n</pos>";
            }
            if (AmexAggregatorData != null)
            {
                xml += "\r\n<amexAggregatorData>" + AmexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
            }
            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>" + MerchantData.Serialize() + "\r\n</merchantData>";
            }
            if (_debtRepaymentSet)
                xml += "\r\n<debtRepayment>" + DebtRepayment.ToString().ToLower() + "</debtRepayment>";
            xml += "\r\n</captureGivenAuth>";
            return xml;
        }
    }

    public class CancelSubscription : recurringTransactionType
    {
        private long _subscriptionIdField;
        private bool _subscriptionIdSet;

        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set
            {
                _subscriptionIdField = value;
                _subscriptionIdSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<cancelSubscription>";
            if (_subscriptionIdSet) xml += "\r\n<subscriptionId>" + _subscriptionIdField + "</subscriptionId>";
            xml += "\r\n</cancelSubscription>";
            return xml;
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum IntervalType
    {
        Annual,
        Semiannual,
        Quarterly,
        Monthly,
        Weekly
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum TrialIntervalType
    {
        Month,
        Day
    }

    public class CreatePlan : recurringTransactionType
    {
        public string PlanCode;
        public string Name;

        private string _descriptionField;
        private bool _descriptionSet;

        public string Description
        {
            get { return _descriptionField; }
            set
            {
                _descriptionField = value;
                _descriptionSet = true;
            }
        }

        public IntervalType IntervalType;
        public long Amount;

        public int NumberOfPaymentsField;
        public bool NumberOfPaymentsSet;

        public int NumberOfPayments
        {
            get { return NumberOfPaymentsField; }
            set
            {
                NumberOfPaymentsField = value;
                NumberOfPaymentsSet = true;
            }
        }

        public int TrialNumberOfIntervalsField;
        public bool TrialNumberOfIntervalsSet;

        public int TrialNumberOfIntervals
        {
            get { return TrialNumberOfIntervalsField; }
            set
            {
                TrialNumberOfIntervalsField = value;
                TrialNumberOfIntervalsSet = true;
            }
        }

        private TrialIntervalType _trialIntervalTypeField;
        private bool _trialIntervalTypeSet;

        public TrialIntervalType TrialIntervalType
        {
            get { return _trialIntervalTypeField; }
            set
            {
                _trialIntervalTypeField = value;
                _trialIntervalTypeSet = true;
            }
        }

        private bool _activeField;
        private bool _activeSet;

        public bool Active
        {
            get { return _activeField; }
            set
            {
                _activeField = value;
                _activeSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<createPlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            if (_descriptionSet)
                xml += "\r\n<description>" + SecurityElement.Escape(_descriptionField) + "</description>";
            xml += "\r\n<intervalType>" + IntervalType + "</intervalType>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            if (NumberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + NumberOfPaymentsField + "</numberOfPayments>";
            if (TrialNumberOfIntervalsSet)
                xml += "\r\n<trialNumberOfIntervals>" + TrialNumberOfIntervalsField + "</trialNumberOfIntervals>";
            if (_trialIntervalTypeSet)
                xml += "\r\n<trialIntervalType>" + _trialIntervalTypeField + "</trialIntervalType>";
            if (_activeSet) xml += "\r\n<active>" + _activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</createPlan>";
            return xml;
        }
    }

    public class UpdatePlan : recurringTransactionType
    {
        public string PlanCode;

        private bool _activeField;
        private bool _activeSet;

        public bool Active
        {
            get { return _activeField; }
            set
            {
                _activeField = value;
                _activeSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<updatePlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            if (_activeSet) xml += "\r\n<active>" + _activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</updatePlan>";
            return xml;
        }
    }

    public class UpdateSubscription : recurringTransactionType
    {
        private long _subscriptionIdField;
        private bool _subscriptionIdSet;

        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set
            {
                _subscriptionIdField = value;
                _subscriptionIdSet = true;
            }
        }

        public string PlanCode;
        public Contact BillToAddress;
        public CardType Card;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        private DateTime _billingDateField;
        private bool _billingDateSet;

        public DateTime BillingDate
        {
            get { return _billingDateField; }
            set
            {
                _billingDateField = value;
                _billingDateSet = true;
            }
        }

        public List<CreateDiscount> CreateDiscounts;
        public List<UpdateDiscount> UpdateDiscounts;
        public List<DeleteDiscount> DeleteDiscounts;
        public List<CreateAddOn> CreateAddOns;
        public List<UpdateAddOn> UpdateAddOns;
        public List<DeleteAddOn> DeleteAddOns;

        public UpdateSubscription()
        {
            CreateDiscounts = new List<CreateDiscount>();
            UpdateDiscounts = new List<UpdateDiscount>();
            DeleteDiscounts = new List<DeleteDiscount>();
            CreateAddOns = new List<CreateAddOn>();
            UpdateAddOns = new List<UpdateAddOn>();
            DeleteAddOns = new List<DeleteAddOn>();
        }

        public override String Serialize()
        {
            var xml = "\r\n<updateSubscription>";
            if (_subscriptionIdSet) xml += "\r\n<subscriptionId>" + _subscriptionIdField + "</subscriptionId>";
            if (PlanCode != null) xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            if (BillToAddress != null)
                xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "\r\n</billToAddress>";
            if (Card != null) xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            else if (Token != null) xml += "\r\n<token>" + Token.Serialize() + "\r\n</token>";
            else if (Paypage != null) xml += "\r\n<paypage>" + Paypage.Serialize() + "\r\n</paypage>";
            if (_billingDateSet) xml += "\r\n<billingDate>" + XmlUtil.ToXsdDate(_billingDateField) + "</billingDate>";
            foreach (var createDiscount in CreateDiscounts)
            {
                xml += "\r\n<createDiscount>" + createDiscount.Serialize() + "\r\n</createDiscount>";
            }
            foreach (var updateDiscount in UpdateDiscounts)
            {
                xml += "\r\n<updateDiscount>" + updateDiscount.Serialize() + "\r\n</updateDiscount>";
            }
            foreach (var deleteDiscount in DeleteDiscounts)
            {
                xml += "\r\n<deleteDiscount>" + deleteDiscount.Serialize() + "\r\n</deleteDiscount>";
            }
            foreach (var createAddOn in CreateAddOns)
            {
                xml += "\r\n<createAddOn>" + createAddOn.Serialize() + "\r\n</createAddOn>";
            }
            foreach (var updateAddOn in UpdateAddOns)
            {
                xml += "\r\n<updateAddOn>" + updateAddOn.Serialize() + "\r\n</updateAddOn>";
            }
            foreach (DeleteAddOn deleteAddOn in DeleteAddOns)
            {
                xml += "\r\n<deleteAddOn>" + deleteAddOn.Serialize() + "\r\n</deleteAddOn>";
            }
            xml += "\r\n</updateSubscription>";
            return xml;
        }
    }

    public partial class FraudResult
    {
        public string Serialize()
        {
            var xml = "";
            if (avsResult != null) xml += "\r\n<avsResult>" + SecurityElement.Escape(avsResult) + "</avsResult>";
            if (cardValidationResult != null)
                xml += "\r\n<cardValidationResult>" + SecurityElement.Escape(cardValidationResult) +
                       "</cardValidationResult>";
            if (authenticationResult != null)
                xml += "\r\n<authenticationResult>" + SecurityElement.Escape(authenticationResult) +
                       "</authenticationResult>";
            if (advancedAVSResult != null)
                xml += "\r\n<advancedAVSResult>" + SecurityElement.Escape(advancedAVSResult) + "</advancedAVSResult>";
            return xml;
        }
    }

    public class AuthInformation
    {
        public DateTime AuthDate;
        public string AuthCode;
        public FraudResult FraudResult;
        private long _authAmountField;
        private bool _authAmountSet;

        public long AuthAmount
        {
            get { return _authAmountField; }
            set
            {
                _authAmountField = value;
                _authAmountSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<authDate>" + XmlUtil.ToXsdDate(AuthDate) + "</authDate>";
            if (AuthCode != null) xml += "\r\n<authCode>" + SecurityElement.Escape(AuthCode) + "</authCode>";
            if (FraudResult != null) xml += "\r\n<fraudResult>" + FraudResult.Serialize() + "</fraudResult>";
            if (_authAmountSet) xml += "\r\n<authAmount>" + _authAmountField + "</authAmount>";
            return xml;
        }
    }

    public class XmlUtil
    {
        public static string ToXsdDate(DateTime dateTime)
        {
            var year = dateTime.Year.ToString(CultureInfo.InvariantCulture);
            var month = dateTime.Month.ToString(CultureInfo.InvariantCulture);
            if (dateTime.Month < 10)
            {
                month = "0" + month;
            }
            var day = dateTime.Day.ToString(CultureInfo.InvariantCulture);
            if (dateTime.Day < 10)
            {
                day = "0" + day;
            }
            return year + "-" + month + "-" + day;
        }
    }

    public class RecyclingRequestType
    {
        private recycleByTypeEnum _recycleByField;
        private bool _recycleBySet;

        public recycleByTypeEnum RecycleBy
        {
            get { return _recycleByField; }
            set
            {
                _recycleByField = value;
                _recycleBySet = true;
            }
        }

        public string RecycleId;

        public string Serialize()
        {
            var xml = "";
            if (_recycleBySet) xml += "\r\n<recycleBy>" + _recycleByField + "</recycleBy>";
            if (RecycleId != null) xml += "\r\n<recycleId>" + SecurityElement.Escape(RecycleId) + "</recycleId>";
            return xml;
        }
    }

    public class LitleInternalRecurringRequest
    {
        public string SubscriptionId;
        public string RecurringTxnId;

        private bool _finalPaymentField;
        private bool _finalPaymentSet;

        public bool FinalPayment
        {
            get { return _finalPaymentField; }
            set
            {
                _finalPaymentField = value;
                _finalPaymentSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (SubscriptionId != null)
                xml += "\r\n<subscriptionId>" + SecurityElement.Escape(SubscriptionId) + "</subscriptionId>";
            if (RecurringTxnId != null)
                xml += "\r\n<recurringTxnId>" + SecurityElement.Escape(RecurringTxnId) + "</recurringTxnId>";
            if (_finalPaymentSet)
                xml += "\r\n<finalPayment>" + _finalPaymentField.ToString().ToLower() + "</finalPayment>";
            return xml;
        }
    }

    public class CreateDiscount
    {
        public string DiscountCode;
        public string Name;
        public long Amount;
        public DateTime StartDate;
        public DateTime EndDate;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(DiscountCode) + "</discountCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(StartDate) + "</startDate>";
            xml += "\r\n<endDate>" + XmlUtil.ToXsdDate(EndDate) + "</endDate>";
            return xml;
        }
    }

    public class UpdateDiscount
    {
        public string DiscountCode;

        private string _nameField;
        private bool _nameSet;

        public string Name
        {
            get { return _nameField; }
            set
            {
                _nameField = value;
                _nameSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private DateTime _startDateField;
        private bool _startDateSet;

        public DateTime StartDate
        {
            get { return _startDateField; }
            set
            {
                _startDateField = value;
                _startDateSet = true;
            }
        }

        private DateTime _endDateField;
        private bool _endDateSet;

        public DateTime EndDate
        {
            get { return _endDateField; }
            set
            {
                _endDateField = value;
                _endDateSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(DiscountCode) + "</discountCode>";
            if (_nameSet) xml += "\r\n<name>" + SecurityElement.Escape(_nameField) + "</name>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (_startDateSet) xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(_startDateField) + "</startDate>";
            if (_endDateSet) xml += "\r\n<endDate>" + XmlUtil.ToXsdDate(_endDateField) + "</endDate>";
            return xml;
        }
    }

    public class DeleteDiscount
    {
        public string DiscountCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(DiscountCode) + "</discountCode>";
            return xml;
        }
    }

    public class CreateAddOn
    {
        public string AddOnCode;
        public string Name;
        public long Amount;
        public DateTime StartDate;
        public DateTime EndDate;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(AddOnCode) + "</addOnCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(StartDate) + "</startDate>";
            xml += "\r\n<endDate>" + XmlUtil.ToXsdDate(EndDate) + "</endDate>";
            return xml;
        }
    }

    public class UpdateAddOn
    {
        public string AddOnCode;

        private string _nameField;
        private bool _nameSet;

        public string Name
        {
            get { return _nameField; }
            set
            {
                _nameField = value;
                _nameSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private DateTime _startDateField;
        private bool _startDateSet;

        public DateTime StartDate
        {
            get { return _startDateField; }
            set
            {
                _startDateField = value;
                _startDateSet = true;
            }
        }

        private DateTime _endDateField;
        private bool _endDateSet;

        public DateTime EndDate
        {
            get { return _endDateField; }
            set
            {
                _endDateField = value;
                _endDateSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(AddOnCode) + "</addOnCode>";
            if (_nameSet) xml += "\r\n<name>" + SecurityElement.Escape(_nameField) + "</name>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (_startDateSet) xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(_startDateField) + "</startDate>";
            if (_endDateSet) xml += "\r\n<endDate>" + XmlUtil.ToXsdDate(_endDateField) + "</endDate>";
            return xml;
        }
    }

    public class DeleteAddOn
    {
        public string AddOnCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(AddOnCode) + "</addOnCode>";
            return xml;
        }
    }

    public class Subscription
    {
        public string PlanCode;
        private bool _numberOfPaymentsSet;
        private int _numberOfPaymentsField;

        public int NumberOfPayments
        {
            get { return _numberOfPaymentsField; }
            set
            {
                _numberOfPaymentsField = value;
                _numberOfPaymentsSet = true;
            }
        }

        private bool _startDateSet;
        private DateTime _startDateField;

        public DateTime StartDate
        {
            get { return _startDateField; }
            set
            {
                _startDateField = value;
                _startDateSet = true;
            }
        }

        private bool _amountSet;
        private long _amountField;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        public List<CreateDiscount> CreateDiscounts;
        public List<CreateAddOn> CreateAddOns;

        public Subscription()
        {
            CreateDiscounts = new List<CreateDiscount>();
            CreateAddOns = new List<CreateAddOn>();
        }


        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<planCode>" + PlanCode + "</planCode>";
            if (_numberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + NumberOfPayments + "</numberOfPayments>";
            if (_startDateSet) xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(_startDateField) + "</startDate>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            foreach (var createDiscount in CreateDiscounts)
            {
                xml += "\r\n<createDiscount>" + createDiscount.Serialize() + "\r\n</createDiscount>";
            }
            foreach (var createAddOn in CreateAddOns)
            {
                xml += "\r\n<createAddOn>" + createAddOn.Serialize() + "\r\n</createAddOn>";
            }

            return xml;
        }
    }

    public class FilteringType
    {
        private bool _prepaidField;
        private bool _prepaidSet;

        public bool Prepaid
        {
            get { return _prepaidField; }
            set
            {
                _prepaidField = value;
                _prepaidSet = true;
            }
        }

        private bool _internationalField;
        private bool _internationalSet;

        public bool International
        {
            get { return _internationalField; }
            set
            {
                _internationalField = value;
                _internationalSet = true;
            }
        }

        private bool _chargebackField;
        private bool _chargebackSet;

        public bool Chargeback
        {
            get { return _chargebackField; }
            set
            {
                _chargebackField = value;
                _chargebackSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_prepaidSet) xml += "\r\n<prepaid>" + _prepaidField.ToString().ToLower() + "</prepaid>";
            if (_internationalSet)
                xml += "\r\n<international>" + _internationalField.ToString().ToLower() + "</international>";
            if (_chargebackSet) xml += "\r\n<chargeback>" + _chargebackField.ToString().ToLower() + "</chargeback>";
            return xml;
        }
    }

    public class HealthcareIIAS
    {
        public HealthcareAmounts HealthcareAmounts;
        private IIASFlagType _iiasFlagField;
        private bool _iiasFlagSet;

        public IIASFlagType IIASFlag
        {
            get { return _iiasFlagField; }
            set
            {
                _iiasFlagField = value;
                _iiasFlagSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (HealthcareAmounts != null)
                xml += "\r\n<healthcareAmounts>" + HealthcareAmounts.Serialize() + "</healthcareAmounts>";
            if (_iiasFlagSet) xml += "\r\n<IIASFlag>" + _iiasFlagField + "</IIASFlag>";
            return xml;
        }
    }

    public class RecurringRequest
    {
        public Subscription Subscription;

        public string Serialize()
        {
            var xml = "";
            if (Subscription != null) xml += "\r\n<subscription>" + Subscription.Serialize() + "\r\n</subscription>";
            return xml;
        }
    }
    
    public class HealthcareAmounts
    {
        private int _totalHealthcareAmountField;
        private bool _totalHealthcareAmountSet;

        public int TotalHealthcareAmount
        {
            get { return _totalHealthcareAmountField; }
            set
            {
                _totalHealthcareAmountField = value;
                _totalHealthcareAmountSet = true;
            }
        }

        private int _rxAmountField;
        private bool _rxAmountSet;

        public int RxAmount
        {
            get { return _rxAmountField; }
            set
            {
                _rxAmountField = value;
                _rxAmountSet = true;
            }
        }

        private int _visionAmountField;
        private bool _visionAmountSet;

        public int VisionAmount
        {
            get { return _visionAmountField; }
            set
            {
                _visionAmountField = value;
                _visionAmountSet = true;
            }
        }

        private int _clinicOtherAmountField;
        private bool _clinicOtherAmountSet;

        public int ClinicOtherAmount
        {
            get { return _clinicOtherAmountField; }
            set
            {
                _clinicOtherAmountField = value;
                _clinicOtherAmountSet = true;
            }
        }

        private int _dentalAmountField;
        private bool _dentalAmountSet;

        public int DentalAmount
        {
            get { return _dentalAmountField; }
            set
            {
                _dentalAmountField = value;
                _dentalAmountSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_totalHealthcareAmountSet)
                xml += "\r\n<totalHealthcareAmount>" + _totalHealthcareAmountField + "</totalHealthcareAmount>";
            if (_rxAmountSet) xml += "\r\n<RxAmount>" + _rxAmountField + "</RxAmount>";
            if (_visionAmountSet) xml += "\r\n<visionAmount>" + _visionAmountField + "</visionAmount>";
            if (_clinicOtherAmountSet)
                xml += "\r\n<clinicOtherAmount>" + _clinicOtherAmountField + "</clinicOtherAmount>";
            if (_dentalAmountSet) xml += "\r\n<dentalAmount>" + _dentalAmountField + "</dentalAmount>";
            return xml;
        }
    }

    public sealed class OrderSourceType
    {
        public static readonly OrderSourceType Ecommerce = new OrderSourceType("ecommerce");
        public static readonly OrderSourceType Installment = new OrderSourceType("installment");
        public static readonly OrderSourceType Mailorder = new OrderSourceType("mailorder");
        public static readonly OrderSourceType Recurring = new OrderSourceType("recurring");
        public static readonly OrderSourceType Retail = new OrderSourceType("retail");
        public static readonly OrderSourceType Telephone = new OrderSourceType("telephone");
        public static readonly OrderSourceType Item3DsAuthenticated = new OrderSourceType("3dsAuthenticated");
        public static readonly OrderSourceType Item3DsAttempted = new OrderSourceType("3dsAttempted");
        public static readonly OrderSourceType Recurringtel = new OrderSourceType("recurringtel");
        public static readonly OrderSourceType Echeckppd = new OrderSourceType("echeckppd");
        public static readonly OrderSourceType Applepay = new OrderSourceType("applepay");

        private OrderSourceType(String value)
        {
            _value = value;
        }

        public string Serialize()
        {
            return _value;
        }

        private readonly string _value;
    }

    public class Contact
    {
        public string Name;
        public string FirstName;
        public string MiddleInitial;
        public string LastName;
        public string CompanyName;
        public string AddressLine1;
        public string AddressLine2;
        public string AddressLine3;
        public string City;
        public string State;
        public string Zip;
        private CountryTypeEnum _countryField;
        private bool _countrySpecified;

        public CountryTypeEnum Country
        {
            get { return _countryField; }
            set
            {
                _countryField = value;
                _countrySpecified = true;
            }
        }

        public string Email;
        public string Phone;

        public string Serialize()
        {
            var xml = "";
            if (Name != null) xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            if (FirstName != null) xml += "\r\n<firstName>" + SecurityElement.Escape(FirstName) + "</firstName>";
            if (MiddleInitial != null)
                xml += "\r\n<middleInitial>" + SecurityElement.Escape(MiddleInitial) + "</middleInitial>";
            if (LastName != null) xml += "\r\n<lastName>" + SecurityElement.Escape(LastName) + "</lastName>";
            if (CompanyName != null)
                xml += "\r\n<companyName>" + SecurityElement.Escape(CompanyName) + "</companyName>";
            if (AddressLine1 != null)
                xml += "\r\n<addressLine1>" + SecurityElement.Escape(AddressLine1) + "</addressLine1>";
            if (AddressLine2 != null)
                xml += "\r\n<addressLine2>" + SecurityElement.Escape(AddressLine2) + "</addressLine2>";
            if (AddressLine3 != null)
                xml += "\r\n<addressLine3>" + SecurityElement.Escape(AddressLine3) + "</addressLine3>";
            if (City != null) xml += "\r\n<city>" + SecurityElement.Escape(City) + "</city>";
            if (State != null) xml += "\r\n<state>" + SecurityElement.Escape(State) + "</state>";
            if (Zip != null) xml += "\r\n<zip>" + SecurityElement.Escape(Zip) + "</zip>";
            if (_countrySpecified) xml += "\r\n<country>" + _countryField + "</country>";
            if (Email != null) xml += "\r\n<email>" + SecurityElement.Escape(Email) + "</email>";
            if (Phone != null) xml += "\r\n<phone>" + SecurityElement.Escape(Phone) + "</phone>";
            return xml;
        }
    }

    public enum CountryTypeEnum
    {
        USA,
        AF,
        AX,
        AL,
        DZ,
        AS,
        AD,
        AO,
        AI,
        AQ,
        AG,
        AR,
        AM,
        AW,
        AU,
        AT,
        AZ,
        BS,
        BH,
        BD,
        BB,
        BY,
        BE,
        BZ,
        BJ,
        BM,
        BT,
        BO,
        BQ,
        BA,
        BW,
        BV,
        BR,
        IO,
        BN,
        BG,
        BF,
        BI,
        KH,
        CM,
        CA,
        CV,
        KY,
        CF,
        TD,
        CL,
        CN,
        CX,
        CC,
        CO,
        KM,
        CG,
        CD,
        CK,
        CR,
        CI,
        HR,
        CU,
        CW,
        CY,
        CZ,
        DK,
        DJ,
        DM,
        DO,
        TL,
        EC,
        EG,
        SV,
        GQ,
        ER,
        EE,
        ET,
        FK,
        FO,
        FJ,
        FI,
        FR,
        GF,
        PF,
        TF,
        GA,
        GM,
        GE,
        DE,
        GH,
        GI,
        GR,
        GL,
        GD,
        GP,
        GU,
        GT,
        GG,
        GN,
        GW,
        GY,
        HT,
        HM,
        HN,
        HK,
        HU,
        IS,
        IN,
        ID,
        IR,
        IQ,
        IE,
        IM,
        IL,
        IT,
        JM,
        JP,
        JE,
        JO,
        KZ,
        KE,
        KI,
        KP,
        KR,
        KW,
        KG,
        LA,
        LV,
        LB,
        LS,
        LR,
        LY,
        LI,
        LT,
        LU,
        MO,
        MK,
        MG,
        MW,
        MY,
        MV,
        ML,
        MT,
        MH,
        MQ,
        MR,
        MU,
        YT,
        MX,
        FM,
        MD,
        MC,
        MN,
        MS,
        MA,
        MZ,
        MM,
        NA,
        NR,
        NP,
        NL,
        AN,
        NC,
        NZ,
        NI,
        NE,
        NG,
        NU,
        NF,
        MP,
        NO,
        OM,
        PK,
        PW,
        PS,
        PA,
        PG,
        PY,
        PE,
        PH,
        PN,
        PL,
        PT,
        PR,
        QA,
        RE,
        RO,
        RU,
        RW,
        BL,
        KN,
        LC,
        MF,
        VC,
        WS,
        SM,
        ST,
        SA,
        SN,
        SC,
        SL,
        SG,
        SX,
        SK,
        SI,
        SB,
        SO,
        ZA,
        GS,
        ES,
        LK,
        SH,
        PM,
        SD,
        SR,
        SJ,
        SZ,
        SE,
        CH,
        SY,
        TW,
        TJ,
        TZ,
        TH,
        TG,
        TK,
        TO,
        TT,
        TN,
        TR,
        TM,
        TC,
        TV,
        UG,
        UA,
        AE,
        GB,
        US,
        UM,
        UY,
        UZ,
        VU,
        VA,
        VE,
        VN,
        VG,
        VI,
        WF,
        EH,
        YE,
        ZM,
        ZW,
        RS,
        ME,
    }

    public class FraudCheckType
    {
        public String AuthenticationValue;
        public String AuthenticationTransactionId;
        public String CustomerIpAddress;
        private bool _authenticatedByMerchantField;
        private bool _authenticatedByMerchantSet;

        public bool AuthenticatedByMerchant
        {
            get { return _authenticatedByMerchantField; }
            set
            {
                _authenticatedByMerchantField = value;
                _authenticatedByMerchantSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (AuthenticationValue != null)
                xml += "\r\n<authenticationValue>" + SecurityElement.Escape(AuthenticationValue) +
                       "</authenticationValue>";
            if (AuthenticationTransactionId != null)
                xml += "\r\n<authenticationTransactionId>" + SecurityElement.Escape(AuthenticationTransactionId) +
                       "</authenticationTransactionId>";
            if (CustomerIpAddress != null)
                xml += "\r\n<customerIpAddress>" + SecurityElement.Escape(CustomerIpAddress) + "</customerIpAddress>";
            if (_authenticatedByMerchantSet)
                xml += "\r\n<authenticatedByMerchant>" + _authenticatedByMerchantField + "</authenticatedByMerchant>";
            return xml;
        }
    }

    public class AdvancedFraudChecksType
    {
        public string ThreatMetrixSessionId;
        private string _customAttribute1Field;
        private bool _customAttribute1Set;

        public string CustomAttribute1
        {
            get { return _customAttribute1Field; }
            set
            {
                _customAttribute1Field = value;
                _customAttribute1Set = true;
            }
        }

        private string _customAttribute2Field;
        private bool _customAttribute2Set;

        public string CustomAttribute2
        {
            get { return _customAttribute2Field; }
            set
            {
                _customAttribute2Field = value;
                _customAttribute2Set = true;
            }
        }

        private string _customAttribute3Field;
        private bool _customAttribute3Set;

        public string CustomAttribute3
        {
            get { return _customAttribute3Field; }
            set
            {
                _customAttribute3Field = value;
                _customAttribute3Set = true;
            }
        }

        private string _customAttribute4Field;
        private bool _customAttribute4Set;

        public string CustomAttribute4
        {
            get { return _customAttribute4Field; }
            set
            {
                _customAttribute4Field = value;
                _customAttribute4Set = true;
            }
        }

        private string _customAttribute5Field;
        private bool _customAttribute5Set;

        public string CustomAttribute5
        {
            get { return _customAttribute5Field; }
            set
            {
                _customAttribute5Field = value;
                _customAttribute5Set = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (ThreatMetrixSessionId != null)
                xml += "\r\n<threatMetrixSessionId>" + SecurityElement.Escape(ThreatMetrixSessionId) +
                       "</threatMetrixSessionId>";
            if (_customAttribute1Set)
                xml += "\r\n<customAttribute1>" + SecurityElement.Escape(_customAttribute1Field) + "</customAttribute1>";
            if (_customAttribute2Set)
                xml += "\r\n<customAttribute2>" + SecurityElement.Escape(_customAttribute2Field) + "</customAttribute2>";
            if (_customAttribute3Set)
                xml += "\r\n<customAttribute3>" + SecurityElement.Escape(_customAttribute3Field) + "</customAttribute3>";
            if (_customAttribute4Set)
                xml += "\r\n<customAttribute4>" + SecurityElement.Escape(_customAttribute4Field) + "</customAttribute4>";
            if (_customAttribute5Set)
                xml += "\r\n<customAttribute5>" + SecurityElement.Escape(_customAttribute5Field) + "</customAttribute5>";
            return xml;
        }
    }

    public class MposType
    {
        public string Ksn;
        public string FormatId;
        public string EncryptedTrack;
        public int Track1Status;
        public int Track2Status;

        public string Serialize()
        {
            var xml = "";
            if (Ksn != null)
            {
                xml += "\r\n<ksn>" + Ksn + "</ksn>";
            }
            if (FormatId != null)
            {
                xml += "\r\n<formatId>" + FormatId + "</formatId>";
            }
            if (EncryptedTrack != null)
            {
                xml += "\r\n<encryptedTrack>" + SecurityElement.Escape(EncryptedTrack) + "</encryptedTrack>";
            }
            if (Track1Status == 0 || Track1Status == 1)
            {
                xml += "\r\n<track1Status>" + Track1Status + "</track1Status>";
            }
            if (Track2Status == 0 || Track2Status == 1)
            {
                xml += "\r\n<track2Status>" + Track2Status + "</track2Status>";
            }

            return xml;
        }
    }

    public class CardType
    {
        public MethodOfPaymentTypeEnum Type;
        public string Number;
        public string ExpDate;
        public string Track;
        public string CardValidationNum;

        public string Serialize()
        {
            var xml = "";
            if (Track == null)
            {
                xml += "\r\n<type>" + MethodOfPaymentSerializer.Serialize(Type) + "</type>";
                if (Number != null)
                {
                    xml += "\r\n<number>" + SecurityElement.Escape(Number) + "</number>";
                }
                if (ExpDate != null)
                {
                    xml += "\r\n<expDate>" + SecurityElement.Escape(ExpDate) + "</expDate>";
                }
            }
            else
            {
                xml += "\r\n<track>" + SecurityElement.Escape(Track) + "</track>";
            }
            if (CardValidationNum != null)
            {
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            }
            return xml;
        }
    }

    public class VirtualGiftCardType
    {
        public int AccountNumberLength
        {
            get { return _accountNumberLengthField; }
            set
            {
                _accountNumberLengthField = value;
                _accountNumberLengthSet = true;
            }
        }

        private int _accountNumberLengthField;
        private bool _accountNumberLengthSet;

        public string GiftCardBin;

        public String Serialize()
        {
            var xml = "";
            if (_accountNumberLengthSet)
                xml += "\r\n<accountNumberLength>" + _accountNumberLengthField + "</accountNumberLength>";
            if (GiftCardBin != null)
                xml += "\r\n<giftCardBin>" + SecurityElement.Escape(GiftCardBin) + "</giftCardBin>";
            return xml;
        }
    }

    public class AuthReversal : transactionTypeWithReportGroup
    {
        public long LitleTxnId;
        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long SurchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public string PayPalNotes;
        public string ActionReason;

        public override string Serialize()
        {
            var xml = "\r\n<authReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            if (_amountSet)
            {
                xml += "\r\n<amount>" + _amountField + "</amount>";
            }
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (PayPalNotes != null)
            {
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(PayPalNotes) + "</payPalNotes>";
            }
            if (ActionReason != null)
            {
                xml += "\r\n<actionReason>" + SecurityElement.Escape(ActionReason) + "</actionReason>";
            }
            xml += "\r\n</authReversal>";
            return xml;
        }
    }

    public class EcheckVoid : transactionTypeWithReportGroup
    {
        public long LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<echeckVoid";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            xml += "\r\n</echeckVoid>";
            return xml;
        }
    }

    public class AccountUpdate : transactionTypeWithReportGroup
    {
        public string OrderId;
        public CardType Card;
        public CardTokenType Token;

        public override string Serialize()
        {
            var xml = "\r\n<accountUpdate ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";

            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";

            if (Card != null)
            {
                xml += "\r\n<card>";
                xml += Card.Serialize();
                xml += "\r\n</card>";
            }
            else if (Token != null)
            {
                xml += "\r\n<token>";
                xml += Token.Serialize();
                xml += "\r\n</token>";
            }

            xml += "\r\n</accountUpdate>";

            return xml;
        }
    }

    public class AccountUpdateFileRequestData
    {
        public string MerchantId;

        public AccountUpdateFileRequestData()
        {
            MerchantId = Settings.Default.merchantId;
        }

        public AccountUpdateFileRequestData(IDictionary<string, string> config)
        {
            MerchantId = config["merchantId"];
        }

        public DateTime PostDay; //yyyy-MM-dd

        public string Serialize()
        {
            var xml = "\r\n<merchantId>" + SecurityElement.Escape(MerchantId) + "</merchantId>";

            xml += "\r\n<postDay>" + PostDay.ToString("yyyy-MM-dd") + "</postDay>";

            return xml;
        }
    }

    public class Activate : transactionTypeWithReportGroup
    {
        public string OrderId;
        public long Amount;
        public OrderSourceType OrderSource;
        public CardType Card;
        public VirtualGiftCardType VirtualGiftCard;

        public override string Serialize()
        {
            var xml = "\r\n<activate";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            if (Card != null) xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            else if (VirtualGiftCard != null)
                xml += "\r\n<virtualGiftCard>" + VirtualGiftCard.Serialize() + "\r\n</virtualGiftCard>";
            xml += "\r\n</activate>";
            return xml;
        }
    }

    public class Deactivate : transactionTypeWithReportGroup
    {
        public string OrderId;
        public OrderSourceType OrderSource;
        public CardType Card;

        public override string Serialize()
        {
            var xml = "\r\n<deactivate";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            xml += "\r\n</deactivate>";
            return xml;
        }
    }

    public class Load : transactionTypeWithReportGroup
    {
        public string OrderId;
        public long Amount;
        public OrderSourceType OrderSource;
        public CardType Card;

        public override string Serialize()
        {
            var xml = "\r\n<load";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            xml += "\r\n</load>";
            return xml;
        }
    }

    public class Unload : transactionTypeWithReportGroup
    {
        public string OrderId;
        public long Amount;
        public OrderSourceType OrderSource;
        public CardType Card;

        public override string Serialize()
        {
            var xml = "\r\n<unload";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            xml += "\r\n</unload>";
            return xml;
        }
    }

    public class BalanceInquiry : transactionTypeWithReportGroup
    {
        public string OrderId;
        public OrderSourceType OrderSource;
        public CardType Card;

        public override string Serialize()
        {
            var xml = "\r\n<balanceInquiry";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            xml += "\r\n</balanceInquiry>";
            return xml;
        }
    }

    public class LoadReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<loadReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</loadReversal>";
            return xml;
        }
    }

    public class UnloadReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<unloadReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</unloadReversal>";
            return xml;
        }
    }

    public class DeactivateReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<deactivateReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</deactivateReversal>";
            return xml;
        }
    }

    public class ActivateReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<activateReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</activateReversal>";
            return xml;
        }
    }

    public class RefundReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<refundReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</refundReversal>";
            return xml;
        }
    }

    public class DepositReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<depositReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</depositReversal>";
            return xml;
        }
    }

    public class ApplepayType
    {
        public string Data;
        public ApplepayHeaderType Header;
        public string Signature;
        public string Version;

        public string Serialize()
        {
            var xml = "";
            if (Data != null) xml += "\r\n<data>" + SecurityElement.Escape(Data) + "</data>";
            if (Header != null) xml += "\r\n<header>" + Header.Serialize() + "</header>";
            if (Signature != null) xml += "\r\n<signature>" + SecurityElement.Escape(Signature) + "</signature>";
            if (Version != null) xml += "\r\n<version>" + SecurityElement.Escape(Version) + "</version>";
            return xml;
        }
    }

    public class ApplepayHeaderType
    {
        public string ApplicationData;
        public string EphemeralPublicKey;
        public string PublicKeyHash;
        public string TransactionId;

        public string Serialize()
        {
            var xml = "";
            if (ApplicationData != null)
                xml += "\r\n<applicationData>" + SecurityElement.Escape(ApplicationData) + "</applicationData>";
            if (EphemeralPublicKey != null)
                xml += "\r\n<ephemeralPublicKey>" + SecurityElement.Escape(EphemeralPublicKey) + "</ephemeralPublicKey>";
            if (PublicKeyHash != null)
                xml += "\r\n<publicKeyHash>" + SecurityElement.Escape(PublicKeyHash) + "</publicKeyHash>";
            if (TransactionId != null)
                xml += "\r\n<transactionId>" + SecurityElement.Escape(TransactionId) + "</transactionId>";
            return xml;
        }
    }

    public class Wallet
    {
        public WalletWalletSourceType WalletSourceType;
        public string WalletSourceTypeId;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<walletSourceType>" + WalletSourceType + "</walletSourceType>";
            if (WalletSourceTypeId != null)
                xml += "\r\n<walletSourceTypeId>" + SecurityElement.Escape(WalletSourceTypeId) + "</walletSourceTypeId>";
            return xml;
        }
    }

    public enum WalletWalletSourceType
    {
        MasterPass
    }

    public class FraudCheck : transactionTypeWithReportGroup
    {
        public AdvancedFraudChecksType AdvancedFraudChecks;

        private Contact _billToAddressField;
        private bool _billToAddressSet;

        public Contact BillToAddress
        {
            get { return _billToAddressField; }
            set
            {
                _billToAddressField = value;
                _billToAddressSet = true;
            }
        }

        private Contact _shipToAddressField;
        private bool _shipToAddressSet;

        public Contact ShipToAddress
        {
            get { return _shipToAddressField; }
            set
            {
                _shipToAddressField = value;
                _shipToAddressSet = true;
            }
        }

        private int _amountField;
        private bool _amountSet;

        public int Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "";
            if (AdvancedFraudChecks != null)
                xml += "\r\n<advancedFraudChecks>" + AdvancedFraudChecks.Serialize() + "</advancedFraudChecks>";
            if (_billToAddressSet) xml += "\r\n<billToAddress>" + _billToAddressField.Serialize() + "</billToAddress>";
            if (_shipToAddressSet) xml += "\r\n<shipToAddress>" + _shipToAddressField.Serialize() + "</shipToAddress>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            return xml;
        }
    }
}