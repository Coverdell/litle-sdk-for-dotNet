using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private bool _accTypeSet;

        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set
            {
                _accTypeField = value;
                _accTypeSet = true;
            }
        }

        public string AccNum { get; set; }
        public string RoutingNum { get; set; }
        public string CheckNum { get; set; }
        public string CcdPaymentInformation { get; set; }

        public string Serialize()
        {
            var xml = "";
            var accTypeName = _accTypeField.ToString();
            var attributes =
                (XmlEnumAttribute[])
                    typeof (EcheckAccountTypeEnum).GetMember(_accTypeField.ToString())[0].GetCustomAttributes(
                        typeof (XmlEnumAttribute), false);
            if (attributes.Length > 0) accTypeName = attributes[0].Name;
            if (_accTypeSet) xml += "\r\n<accType>" + accTypeName + "</accType>";
            if (AccNum != null) xml += "\r\n<accNum>" + SecurityElement.Escape(AccNum) + "</accNum>";
            if (RoutingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(RoutingNum) + "</routingNum>";
            if (CheckNum != null) xml += "\r\n<checkNum>" + SecurityElement.Escape(CheckNum) + "</checkNum>";
            if (CcdPaymentInformation != null)
                xml += "\r\n<ccdPaymentInformation>" + SecurityElement.Escape(CcdPaymentInformation) +
                       "</ccdPaymentInformation>";
            return xml;
        }
    }
}