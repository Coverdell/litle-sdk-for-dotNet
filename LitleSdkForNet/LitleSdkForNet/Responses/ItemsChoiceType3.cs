namespace Litle.Sdk.Responses
{
    [LitleXmlType("ItemsChoiceType3", IncludeInSchema = false)]
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