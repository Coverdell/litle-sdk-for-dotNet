using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class CreateDiscount
    {
        public string DiscountCode { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(DiscountCode) + "</discountCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(StartDate) + "</startDate>";
            xml += "\r\n<endDate>" + XmlUtil.ToXsdDate(EndDate) + "</endDate>";
            return xml;
        }
    }
}