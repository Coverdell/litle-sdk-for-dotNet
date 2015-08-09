using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class ActivateReversal : transactionTypeWithReportGroup
    {
        public String LitleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<activateReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(LitleTxnId) + "</litleTxnId>";
            xml += "\r\n</activateReversal>";
            return xml;
        }
    }
}