using System;
using System.Xml.Serialization;
using Litle.Sdk.Responses;

namespace Litle.Sdk
{
    public abstract class CommonTransactionTypeWithReportGroup : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }
        [XmlElement("response")]
        public string Response { get; set; }
        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }   
    }

    public abstract class CommonTransactionTypeWithReportGroupAndPostDate : CommonTransactionTypeWithReportGroup
    {
        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate { get; set; }

        [XmlIgnore]
        public bool PostDateSpecified { get; set; }

    }

    public abstract class CommonTransactionTypeWithReportGroupAndFraud : CommonTransactionTypeWithReportGroup
    {
        [XmlElement("fundTransferId")]
        public string FundsTransferId { get; set; }
    }
}