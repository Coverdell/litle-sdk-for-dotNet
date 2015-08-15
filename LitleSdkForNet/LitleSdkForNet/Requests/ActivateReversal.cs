using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    [Serializable]
    public class ActivateReversal : TransactionTypeWithReportGroup
    {
        public string LitleTxnId { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<activateReversal";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</activateReversal>";
            return xml;
        }
    }
}