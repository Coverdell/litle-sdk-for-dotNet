using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class AuthReversal : TransactionTypeWithReportGroup
    {
        public long LitleTxnId { get; set; }
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

        public string PayPalNotes { get; set; }
        public string ActionReason { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<authReversal";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
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
}