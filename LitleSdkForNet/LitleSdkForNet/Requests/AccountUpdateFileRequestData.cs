using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Litle.Sdk.Properties;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("accountUpdateFileRequestData")]
    public class AccountUpdateFileRequestData
    {
        [XmlElement("merchantId")]
        public string MerchantId { get; set; }
        [XmlElement("postDay", DataType = "date")]
        public DateTime PostDay { get; set; } //yyyy-MM-dd

        public AccountUpdateFileRequestData()
        {
            MerchantId = Settings.Default.merchantId;
        }

        public AccountUpdateFileRequestData(IDictionary<string, string> config)
        {
            MerchantId = config["merchantId"];
        }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}