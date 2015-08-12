using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemsChoiceType4", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {
        Amount,
        BillToAddress,
        CustomBilling,
        Echeck,
        EcheckOrEcheckToken,
        EcheckToken,
        LitleTxnId,
        MerchantData,
        OrderId,
        OrderSource,
        ShipToAddress,
        Verify,
    }
}