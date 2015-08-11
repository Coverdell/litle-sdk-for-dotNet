using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("enhancedAuthResponseFundingSource", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class EnhancedAuthResponseFundingSource
    {
        private FundingSourceTypeEnum _typeField;
        private string _availableBalanceField;
        private string _reloadableField;
        private string _prepaidCardTypeField;

        [XmlElement("type")]
        public FundingSourceTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        [XmlElement("availableBalance")]
        public string AvailableBalance
        {
            get { return _availableBalanceField; }
            set { _availableBalanceField = value; }
        }

        [XmlElement("reloadable")]
        public string Reloadable
        {
            get { return _reloadableField; }
            set { _reloadableField = value; }
        }

        [XmlElement("prepaidCardType")]
        public string PrepaidCardType
        {
            get { return _prepaidCardTypeField; }
            set { _prepaidCardTypeField = value; }
        }
    }
}