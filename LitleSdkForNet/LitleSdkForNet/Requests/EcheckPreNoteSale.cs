using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckPreNoteSale : TransactionTypeWithReportGroup
    {
        /// <remarks />
        public string OrderId { get; set; }

        /// <remarks />
        public OrderSourceType OrderSource { get; set; }

        /// <remarks />
        public Contact BillToAddress { get; set; }

        /// <remarks />
        public EcheckType Echeck { get; set; }

        /// <remarks />
        public MerchantDataType MerchantData { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<echeckPreNoteSale ";

            if (ID != null)
            {
                xml += "id=\"" + SecurityElement.Escape(ID) + "\" ";
            }
            if (CustomerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(CustomerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";

            if (OrderSource != null)
            {
                xml += "\r\n<orderSource>";
                xml += OrderSource.Serialize();
                xml += "</orderSource>";
            }

            if (BillToAddress != null)
            {
                xml += "\r\n<billToAddress>";
                xml += BillToAddress.Serialize();
                xml += "\r\n</billToAddress>";
            }

            if (Echeck != null)
            {
                xml += "\r\n<echeck>";
                xml += Echeck.Serialize();
                xml += "\r\n</echeck>";
            }

            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>";
                xml += MerchantData.Serialize();
                xml += "\r\n</merchantData>";
            }

            xml += "\r\n</echeckPreNoteSale>";

            return xml;
        }
    }
}