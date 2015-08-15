using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class HealthcareIIAS
    {
        public HealthcareAmounts HealthcareAmounts { get; set; }
        private IIASFlagType _iiasFlagField;
        private bool _iiasFlagSet;

        public IIASFlagType IIASFlag
        {
            get { return _iiasFlagField; }
            set
            {
                _iiasFlagField = value;
                _iiasFlagSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (HealthcareAmounts != null)
                xml += "\r\n<healthcareAmounts>" + HealthcareAmounts.Serialize() + "</healthcareAmounts>";
            if (_iiasFlagSet) xml += "\r\n<IIASFlag>" + _iiasFlagField + "</IIASFlag>";
            return xml;
        }
    }
}