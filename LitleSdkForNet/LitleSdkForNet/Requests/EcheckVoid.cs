using System.Security;

namespace Litle.Sdk.Requests
{
    public class EcheckVoid : transactionTypeWithReportGroup
    {
        public long LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<echeckVoid";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            xml += "\r\n</echeckVoid>";
            return xml;
        }
    }
}