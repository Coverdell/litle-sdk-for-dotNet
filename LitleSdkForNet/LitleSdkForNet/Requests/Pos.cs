using System.Security;

namespace Litle.Sdk.Requests
{
    public class Pos
    {
        private posCapabilityTypeEnum _capabilityField;
        private bool _capabilitySet;

        public posCapabilityTypeEnum Capability
        {
            get { return _capabilityField; }
            set
            {
                _capabilityField = value;
                _capabilitySet = true;
            }
        }

        private posEntryModeTypeEnum _entryModeField;
        private bool _entryModeSet;

        public posEntryModeTypeEnum EntryMode
        {
            get { return _entryModeField; }
            set
            {
                _entryModeField = value;
                _entryModeSet = true;
            }
        }

        private posCardholderIdTypeEnum _cardholderIdField;
        private bool _cardholderIdSet;

        public posCardholderIdTypeEnum CardholderId
        {
            get { return _cardholderIdField; }
            set
            {
                _cardholderIdField = value;
                _cardholderIdSet = true;
            }
        }

        public string TerminalId;

        private posCatLevelEnum _catLevelField;
        private bool _catLevelSet;

        public posCatLevelEnum CatLevel
        {
            get { return _catLevelField; }
            set
            {
                _catLevelField = value;
                _catLevelSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_capabilitySet) xml += "\r\n<capability>" + _capabilityField + "</capability>";
            if (_entryModeSet) xml += "\r\n<entryMode>" + _entryModeField + "</entryMode>";
            if (_cardholderIdSet) xml += "\r\n<cardholderId>" + _cardholderIdField + "</cardholderId>";
            if (TerminalId != null) xml += "\r\n<terminalId>" + SecurityElement.Escape(TerminalId) + "</terminalId>";
            if (_catLevelSet) xml += "\r\n<catLevel>" + _catLevelField.Serialize() + "</catLevel>";
            return xml;
        }
    }
}