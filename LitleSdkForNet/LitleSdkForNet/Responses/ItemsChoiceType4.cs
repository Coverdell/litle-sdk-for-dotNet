using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
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