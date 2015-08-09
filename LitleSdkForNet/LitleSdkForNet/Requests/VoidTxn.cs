using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class VoidTxn : TransactionTypeWithReportGroup
    {
        public long LitleTxnId;
        public ProcessingInstructions ProcessingInstructions;

        public override string Serialize()
        {
            var xml = "\r\n<void";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\"";
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