using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class ForceCapture : TransactionTypeWithReportGroup
    {
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
        public Contact BillToAddress { get; set; }
        public CardType Card { get; set; }
        public MposType Mpos { get; set; }
        public CardTokenType Token { get; set; }
        public CardPaypageType Paypage { get; set; }
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
        public AmexAggregatorData AmexAggregatorData { get; set; }
        public MerchantDataType MerchantData { get; set; }
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
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
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
}