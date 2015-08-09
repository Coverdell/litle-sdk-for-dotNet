using System.Security;

namespace Litle.Sdk.Requests
{
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
}