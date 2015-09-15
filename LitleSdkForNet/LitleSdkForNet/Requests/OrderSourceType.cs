using System.Xml.Serialization;

namespace Litle.Sdk.Requests
{
    public enum OrderSourceType
    {
        [XmlEnum("ecommerce")]
        Ecommerce,
        [XmlEnum("installment")]
        Installment,
        [XmlEnum("mailorder")]
        Mailorder,
        [XmlEnum("recurring")]
        Recurring,
        [XmlEnum("retail")]
        Retail,
        [XmlEnum("telephone")]
        Telephone,
        [XmlEnum("3dsAuthenticated")]
        Item3DsAuthenticated,
        [XmlEnum("3dsAttempted")]
        Item3DsAttempted,
        [XmlEnum("recurringtel")]
        Recurringtel,
        [XmlEnum("echeckppd")]
        Echeckppd,
        [XmlEnum("applepay")]
        Applepay
    }
}