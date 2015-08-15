using System.Security;

namespace Litle.Sdk.Requests
{
    public class CardTokenType
    {
        public string LitleToken { get; set; }
        public string ExpDate { get; set; }
        public string CardValidationNum { get; set; }
        private MethodOfPaymentTypeEnum _typeField;
        private bool _typeSet;

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set
            {
                _typeField = value;
                _typeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "\r\n<litleToken>" + SecurityElement.Escape(LitleToken) + "</litleToken>";
            if (ExpDate != null) xml += "\r\n<expDate>" + SecurityElement.Escape(ExpDate) + "</expDate>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            if (_typeSet) xml += "\r\n<type>" + MethodOfPaymentSerializer.Serialize(_typeField) + "</type>";
            return xml;
        }
    }
}