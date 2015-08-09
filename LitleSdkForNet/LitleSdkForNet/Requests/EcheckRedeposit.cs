namespace Litle.Sdk.Requests
{
    public class EcheckRedeposit : baseRequestTransactionEcheckRedeposit
    {
        //litleTxnIdField and set are in super
        public EcheckType Echeck;
        public EcheckTokenType Token;
        public MerchantDataType MerchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckRedeposit";
            xml += " id=\"" + id + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + customerId + "\"";
            }
            xml += " reportGroup=\"" + reportGroup + "\">";
            if (litleTxnIdSet) xml += "\r\n<litleTxnId>" + litleTxnIdField + "</litleTxnId>";
            if (Echeck != null) xml += "\r\n<echeck>" + Echeck.Serialize() + "</echeck>";
            else if (Token != null) xml += "\r\n<echeckToken>" + Token.Serialize() + "</echeckToken>";
            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>" + MerchantData.Serialize() + "\r\n</merchantData>";
            }
            xml += "\r\n</echeckRedeposit>";
            return xml;
        }
    }
}