using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("recurringTransactionType", Namespace = "http://www.litle.com/schema")]
    public class RecurringTransactionType : TransactionRequest
    {
    }
}