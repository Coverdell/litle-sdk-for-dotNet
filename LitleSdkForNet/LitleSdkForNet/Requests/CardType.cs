using System.Security;

namespace Litle.Sdk.Requests
{
    public class CardType
    {
        public MethodOfPaymentTypeEnum Type;
        public string Number;
        public string ExpDate;
        public string Track;
        public string CardValidationNum;

        public string Serialize()
        {
            var xml = "";
            if (Track == null)
            {
                xml += "\r\n<type>" + MethodOfPaymentSerializer.Serialize(Type) + "</type>";
                if (Number != null)
                {
                    xml += "\r\n<number>" + SecurityElement.Escape(Number) + "</number>";
                }
                if (ExpDate != null)
                {
                    xml += "\r\n<expDate>" + SecurityElement.Escape(ExpDate) + "</expDate>";
                }
            }
            else
            {
                xml += "\r\n<track>" + SecurityElement.Escape(Track) + "</track>";
            }
            if (CardValidationNum != null)
            {
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            }
            return xml;
        }
    }
}