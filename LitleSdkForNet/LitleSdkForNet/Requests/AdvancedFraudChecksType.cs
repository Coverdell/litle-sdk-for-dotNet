using System.Security;

namespace Litle.Sdk.Requests
{
    public class AdvancedFraudChecksType
    {
        public string ThreatMetrixSessionId;
        private string _customAttribute1Field;
        private bool _customAttribute1Set;

        public string CustomAttribute1
        {
            get { return _customAttribute1Field; }
            set
            {
                _customAttribute1Field = value;
                _customAttribute1Set = true;
            }
        }

        private string _customAttribute2Field;
        private bool _customAttribute2Set;

        public string CustomAttribute2
        {
            get { return _customAttribute2Field; }
            set
            {
                _customAttribute2Field = value;
                _customAttribute2Set = true;
            }
        }

        private string _customAttribute3Field;
        private bool _customAttribute3Set;

        public string CustomAttribute3
        {
            get { return _customAttribute3Field; }
            set
            {
                _customAttribute3Field = value;
                _customAttribute3Set = true;
            }
        }

        private string _customAttribute4Field;
        private bool _customAttribute4Set;

        public string CustomAttribute4
        {
            get { return _customAttribute4Field; }
            set
            {
                _customAttribute4Field = value;
                _customAttribute4Set = true;
            }
        }

        private string _customAttribute5Field;
        private bool _customAttribute5Set;

        public string CustomAttribute5
        {
            get { return _customAttribute5Field; }
            set
            {
                _customAttribute5Field = value;
                _customAttribute5Set = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (ThreatMetrixSessionId != null)
                xml += "\r\n<threatMetrixSessionId>" + SecurityElement.Escape(ThreatMetrixSessionId) +
                       "</threatMetrixSessionId>";
            if (_customAttribute1Set)
                xml += "\r\n<customAttribute1>" + SecurityElement.Escape(_customAttribute1Field) + "</customAttribute1>";
            if (_customAttribute2Set)
                xml += "\r\n<customAttribute2>" + SecurityElement.Escape(_customAttribute2Field) + "</customAttribute2>";
            if (_customAttribute3Set)
                xml += "\r\n<customAttribute3>" + SecurityElement.Escape(_customAttribute3Field) + "</customAttribute3>";
            if (_customAttribute4Set)
                xml += "\r\n<customAttribute4>" + SecurityElement.Escape(_customAttribute4Field) + "</customAttribute4>";
            if (_customAttribute5Set)
                xml += "\r\n<customAttribute5>" + SecurityElement.Escape(_customAttribute5Field) + "</customAttribute5>";
            return xml;
        }
    }
}