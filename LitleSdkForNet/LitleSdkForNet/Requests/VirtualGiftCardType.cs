using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class VirtualGiftCardType
    {
        public int AccountNumberLength
        {
            get { return _accountNumberLengthField; }
            set
            {
                _accountNumberLengthField = value;
                _accountNumberLengthSet = true;
            }
        }

        private int _accountNumberLengthField;
        private bool _accountNumberLengthSet;

        public string GiftCardBin { get; set; }

        public String Serialize()
        {
            var xml = "";
            if (_accountNumberLengthSet)
                xml += "\r\n<accountNumberLength>" + _accountNumberLengthField + "</accountNumberLength>";
            if (GiftCardBin != null)
                xml += "\r\n<giftCardBin>" + SecurityElement.Escape(GiftCardBin) + "</giftCardBin>";
            return xml;
        }
    }
}