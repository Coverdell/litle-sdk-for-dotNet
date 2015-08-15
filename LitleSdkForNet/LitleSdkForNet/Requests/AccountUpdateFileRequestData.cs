using System;
using System.Collections.Generic;
using System.Security;
using Litle.Sdk.Properties;

namespace Litle.Sdk.Requests
{
    public class AccountUpdateFileRequestData
    {
        public string MerchantId { get; set; }
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
            var xml = "\r\n<merchantId>" + SecurityElement.Escape(MerchantId) + "</merchantId>";
            xml += "\r\n<postDay>" + PostDay.ToString("yyyy-MM-dd") + "</postDay>";
            return xml;
        }
    }
}