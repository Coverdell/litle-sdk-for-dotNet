namespace Litle.Sdk.Requests
{
    public class FilteringType
    {
        private bool _prepaidField;
        private bool _prepaidSet;

        public bool Prepaid
        {
            get { return _prepaidField; }
            set
            {
                _prepaidField = value;
                _prepaidSet = true;
            }
        }

        private bool _internationalField;
        private bool _internationalSet;

        public bool International
        {
            get { return _internationalField; }
            set
            {
                _internationalField = value;
                _internationalSet = true;
            }
        }

        private bool _chargebackField;
        private bool _chargebackSet;

        public bool Chargeback
        {
            get { return _chargebackField; }
            set
            {
                _chargebackField = value;
                _chargebackSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_prepaidSet) xml += "\r\n<prepaid>" + _prepaidField.ToString().ToLower() + "</prepaid>";
            if (_internationalSet)
                xml += "\r\n<international>" + _internationalField.ToString().ToLower() + "</international>";
            if (_chargebackSet) xml += "\r\n<chargeback>" + _chargebackField.ToString().ToLower() + "</chargeback>";
            return xml;
        }
    }
}