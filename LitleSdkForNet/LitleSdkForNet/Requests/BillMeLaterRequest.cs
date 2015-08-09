using System.Security;

namespace Litle.Sdk.Requests
{
    public class BillMeLaterRequest
    {
        private long _bmlMerchantIdField;
        private bool _bmlMerchantIdSet;

        public long BmlMerchantId
        {
            get { return _bmlMerchantIdField; }
            set
            {
                _bmlMerchantIdField = value;
                _bmlMerchantIdSet = true;
            }
        }

        private long _bmlProductTypeField;
        private bool _bmlProductTypeSet;

        public long BmlProductType
        {
            get { return _bmlProductTypeField; }
            set
            {
                _bmlProductTypeField = value;
                _bmlProductTypeSet = true;
            }
        }

        private int _termsAndConditionsField;
        private bool _termsAndConditionsSet;

        public int TermsAndConditions
        {
            get { return _termsAndConditionsField; }
            set
            {
                _termsAndConditionsField = value;
                _termsAndConditionsSet = true;
            }
        }

        public string PreapprovalNumber;
        private int _merchantPromotionalCodeField;
        private bool _merchantPromotionalCodeSet;

        public int MerchantPromotionalCode
        {
            get { return _merchantPromotionalCodeField; }
            set
            {
                _merchantPromotionalCodeField = value;
                _merchantPromotionalCodeSet = true;
            }
        }

        public string VirtualAuthenticationKeyPresenceIndicator;
        public string VirtualAuthenticationKeyData;
        private int _itemCategoryCodeField;
        private bool _itemCategoryCodeSet;

        public int ItemCategoryCode
        {
            get { return _itemCategoryCodeField; }
            set
            {
                _itemCategoryCodeField = value;
                _itemCategoryCodeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_bmlMerchantIdSet) xml += "\r\n<bmlMerchantId>" + _bmlMerchantIdField + "</bmlMerchantId>";
            if (_bmlProductTypeSet) xml += "\r\n<bmlProductType>" + _bmlProductTypeField + "</bmlProductType>";
            if (_termsAndConditionsSet)
                xml += "\r\n<termsAndConditions>" + _termsAndConditionsField + "</termsAndConditions>";
            if (PreapprovalNumber != null)
                xml += "\r\n<preapprovalNumber>" + SecurityElement.Escape(PreapprovalNumber) + "</preapprovalNumber>";
            if (_merchantPromotionalCodeSet)
                xml += "\r\n<merchantPromotionalCode>" + _merchantPromotionalCodeField + "</merchantPromotionalCode>";
            if (VirtualAuthenticationKeyPresenceIndicator != null)
                xml += "\r\n<virtualAuthenticationKeyPresenceIndicator>" +
                       SecurityElement.Escape(VirtualAuthenticationKeyPresenceIndicator) +
                       "</virtualAuthenticationKeyPresenceIndicator>";
            if (VirtualAuthenticationKeyData != null)
                xml += "\r\n<virtualAuthenticationKeyData>" + SecurityElement.Escape(VirtualAuthenticationKeyData) +
                       "</virtualAuthenticationKeyData>";
            if (_itemCategoryCodeSet) xml += "\r\n<itemCategoryCode>" + _itemCategoryCodeField + "</itemCategoryCode>";
            return xml;
        }
    }
}