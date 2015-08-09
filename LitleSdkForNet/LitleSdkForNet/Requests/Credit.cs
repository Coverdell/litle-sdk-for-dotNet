using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class Credit : TransactionTypeWithReportGroup
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
        private TaxTypeIdentifierEnum _taxTypeField;
        private bool _taxTypeSet;

        public TaxTypeIdentifierEnum TaxType
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
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\"";
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
}