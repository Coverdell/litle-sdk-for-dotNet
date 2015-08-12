using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemsChoiceType3", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType3
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
    }
}