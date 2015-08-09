using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class FraudCheck : TransactionTypeWithReportGroup
    {
        public AdvancedFraudChecksType AdvancedFraudChecks;

        private Contact _billToAddressField;
        private bool _billToAddressSet;

        public Contact BillToAddress
        {
            get { return _billToAddressField; }
            set
            {
                _billToAddressField = value;
                _billToAddressSet = true;
            }
        }

        private Contact _shipToAddressField;
        private bool _shipToAddressSet;

        public Contact ShipToAddress
        {
            get { return _shipToAddressField; }
            set
            {
                _shipToAddressField = value;
                _shipToAddressSet = true;
            }
        }

        private int _amountField;
        private bool _amountSet;

        public int Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "";
            if (AdvancedFraudChecks != null)
                xml += "\r\n<advancedFraudChecks>" + AdvancedFraudChecks.Serialize() + "</advancedFraudChecks>";
            if (_billToAddressSet) xml += "\r\n<billToAddress>" + _billToAddressField.Serialize() + "</billToAddress>";
            if (_shipToAddressSet) xml += "\r\n<shipToAddress>" + _shipToAddressField.Serialize() + "</shipToAddress>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            return xml;
        }
    }
}