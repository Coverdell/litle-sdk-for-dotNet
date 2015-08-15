using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class UnloadReversal : TransactionTypeWithReportGroup
    {
        public String LitleTxnId { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<unloadReversal";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</unloadReversal>";
            return xml;
        }
    }
}