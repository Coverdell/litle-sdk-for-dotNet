using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class Sale : TransactionTypeWithReportGroup
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

        public string OrderId { get; set; }
        public long Amount { get; set; }
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

        public OrderSourceType OrderSource { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public Contact BillToAddress { get; set; }
        public Contact ShipToAddress { get; set; }
        public CardType Card { get; set; }
        public MposType Mpos { get; set; }
        public PayPal Paypal { get; set; }
        public CardTokenType Token { get; set; }
        public CardPaypageType Paypage { get; set; }
        public ApplepayType Applepay { get; set; }
        public BillMeLaterRequest BillMeLaterRequest { get; set; }
        public FraudCheckType CardholderAuthentication { get; set; }
        public CustomBilling CustomBilling { get; set; }
        private GovtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public GovtTaxTypeEnum TaxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public EnhancedData EnhancedData { get; set; }
        public ProcessingInstructions ProcessingInstructions { get; set; }
        public Pos Pos { get; set; }
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

        public string PayPalNotes { get; set; }
        public AmexAggregatorData AmexAggregatorData { get; set; }
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

        public HealthcareIIAS HealthcareIIAS { get; set; }
        public FilteringType Filtering { get; set; }
        public MerchantDataType MerchantData { get; set; }
        public RecyclingRequestType RecyclingRequest { get; set; }
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

        public RecurringRequest RecurringRequest { get; set; }
        public LitleInternalRecurringRequest LitleInternalRecurringRequest { get; set; }
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

        public AdvancedFraudChecksType AdvancedFraudChecks { get; set; }
        public Wallet Wallet { get; set; }

        public override String Serialize()
        {
            var xml = "\r\n<sale";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
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
}