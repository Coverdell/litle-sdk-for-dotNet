using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckVoid : TransactionTypeWithReportGroup
    {
        public long LitleTxnId { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<echeckVoid";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            xml += "\r\n</echeckVoid>";
            return xml;
        }
    }
}