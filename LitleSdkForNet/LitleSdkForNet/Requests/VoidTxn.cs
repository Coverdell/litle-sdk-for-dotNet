using System.Security;

namespace Litle.Sdk.Requests
{
    public class VoidTxn : transactionTypeWithReportGroup
    {
        public long LitleTxnId;
        public ProcessingInstructions ProcessingInstructions;

        public override string Serialize()
        {
            var xml = "\r\n<void";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";
            xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
            if (ProcessingInstructions != null)
                xml += "\r\n<processingInstructions>" + ProcessingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            xml += "\r\n</void>";

            return xml;
        }
    }
}