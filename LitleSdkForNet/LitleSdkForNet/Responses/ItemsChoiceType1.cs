using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
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