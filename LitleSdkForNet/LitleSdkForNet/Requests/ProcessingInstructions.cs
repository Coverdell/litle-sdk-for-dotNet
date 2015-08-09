namespace Litle.Sdk.Requests
{
    public class ProcessingInstructions
    {
        private bool _bypassVelocityCheckField;
        private bool _bypassVelocityCheckSet;

        public bool BypassVelocityCheck
        {
            get { return _bypassVelocityCheckField; }
            set
            {
                _bypassVelocityCheckField = value;
                _bypassVelocityCheckSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_bypassVelocityCheckSet)
                xml += "\r\n<bypassVelocityCheck>" + _bypassVelocityCheckField.ToString().ToLower() +
                       "</bypassVelocityCheck>";
            return xml;
        }
    }
}