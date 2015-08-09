using System.Security;

namespace Litle.Sdk.Requests
{
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
}