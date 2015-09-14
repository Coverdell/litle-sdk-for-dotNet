using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("transactionRequest")]
    public class TransactionRequest
    {
        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}