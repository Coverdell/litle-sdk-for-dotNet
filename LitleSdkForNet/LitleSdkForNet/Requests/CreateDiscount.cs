using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class CreateDiscount
    {
        public string DiscountCode;
        public string Name;
        public long Amount;
        public DateTime StartDate;
        public DateTime EndDate;

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