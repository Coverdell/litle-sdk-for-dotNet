using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("ItemsChoiceType1", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {
        AmexAggregatorData,
        Amount,
        BillMeLaterRequest,
        BillToAddress,
        Card,
        CustomBilling,
        EnhancedData,
        LitleTxnId,
        MerchantData,
        OrderId,
        OrderSource,
        Paypage,
        Paypal,
        Pos,
        ProcessingInstructions,
        TaxType,
        Token,
    }
}