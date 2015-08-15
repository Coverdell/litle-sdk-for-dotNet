using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckCredit : TransactionTypeWithReportGroup
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
        public OrderSourceType OrderSource { get; set; }
        public Contact BillToAddress { get; set; }
        public EcheckType Echeck { get; set; }

        [Obsolete]
        public EcheckTokenType Token
        {
            get { return EcheckToken; }
            set { EcheckToken = value; }
        }

        public EcheckTokenType EcheckToken { get; set; }

        public MerchantDataType MerchantData { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<echeckCredit";
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
}