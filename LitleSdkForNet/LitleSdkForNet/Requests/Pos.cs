using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class Pos
    {
        private PosCapabilityTypeEnum _capabilityField;
        private bool _capabilitySet;

        public PosCapabilityTypeEnum Capability
        {
            get { return _capabilityField; }
            set
            {
                _capabilityField = value;
                _capabilitySet = true;
            }
        }

        private PosEntryModeTypeEnum _entryModeField;
        private bool _entryModeSet;

        public PosEntryModeTypeEnum EntryMode
        {
            get { return _entryModeField; }
            set
            {
                _entryModeField = value;
                _entryModeSet = true;
            }
        }

        private PosCardholderIdTypeEnum _cardholderIdField;
        private bool _cardholderIdSet;

        public PosCardholderIdTypeEnum CardholderId
        {
            get { return _cardholderIdField; }
            set
            {
                _cardholderIdField = value;
                _cardholderIdSet = true;
            }
        }

        public string TerminalId;

        private PosCatLevelEnum _catLevelField;
        private bool _catLevelSet;

        public PosCatLevelEnum CatLevel
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