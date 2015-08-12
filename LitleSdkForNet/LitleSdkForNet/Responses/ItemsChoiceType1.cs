using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemsChoiceType1", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
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