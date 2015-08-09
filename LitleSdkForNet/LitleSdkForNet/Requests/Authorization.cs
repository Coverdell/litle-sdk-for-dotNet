using System;
using System.Security;

namespace Litle.Sdk.Requests
{
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
}