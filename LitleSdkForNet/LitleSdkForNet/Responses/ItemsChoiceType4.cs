using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("ItemsChoiceType4", IncludeInSchema = false)]
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