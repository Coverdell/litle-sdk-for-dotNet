using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckRedeposit : BaseRequestTransactionEcheckRedeposit
    {
        //litleTxnIdField and set are in super
        public EcheckType Echeck { get; set; }
        public EcheckTokenType Token { get; set; }
        public MerchantDataType MerchantData { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<echeckRedeposit";
            xml += " id=\"" + ID + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + CustomerId + "\"";
            }
            xml += " reportGroup=\"" + ReportGroup + "\">";
            if (LitleTxnId.HasValue) xml += "\r\n<litleTxnId>" + LitleTxnId + "</litleTxnId>";
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