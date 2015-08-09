using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckVerification : TransactionTypeWithReportGroup
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
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\"";
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
}