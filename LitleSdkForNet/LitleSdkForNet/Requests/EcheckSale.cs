using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckSale : TransactionTypeWithReportGroup
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

        public CustomBilling CustomBilling { get; set; }
        public string OrderId { get; set; }
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

        public OrderSourceType OrderSource { get; set; }
        public Contact BillToAddress { get; set; }
        public Contact ShipToAddress { get; set; }
        public EcheckType Echeck { get; set; }
        public EcheckTokenType Token { get; set; }
        public MerchantDataType MerchantData { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<echeckSale";
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
}