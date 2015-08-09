using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class EnhancedAuthResponseFundingSource
    {
        private FundingSourceTypeEnum _typeField;
        private string _availableBalanceField;
        private string _reloadableField;
        private string _prepaidCardTypeField;

        public FundingSourceTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string AvailableBalance
        {
            get { return _availableBalanceField; }
            set { _availableBalanceField = value; }
        }

        public string Reloadable
        {
            get { return _reloadableField; }
            set { _reloadableField = value; }
        }

        public string PrepaidCardType
        {
            get { return _prepaidCardTypeField; }
            set { _prepaidCardTypeField = value; }
        }
    }
}