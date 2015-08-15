using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class DetailTax
    {
        private bool _taxIncludedInTotalField;
        private bool _taxIncludedInTotalSet;

        public bool TaxIncludedInTotal
        {
            get { return _taxIncludedInTotalField; }
            set
            {
                _taxIncludedInTotalField = value;
                _taxIncludedInTotalSet = true;
            }
        }

        private long _taxAmountField;
        private bool _taxAmountSet;

        public long TaxAmount
        {
            get { return _taxAmountField; }
            set
            {
                _taxAmountField = value;
                _taxAmountSet = true;
            }
        }

        public string TaxRate { get; set; }
        private TaxTypeIdentifierEnum _taxTypeIdentifierField;
        private bool _taxTypeIdentifierSet;

        public TaxTypeIdentifierEnum TaxTypeIdentifier
        {
            get { return _taxTypeIdentifierField; }
            set
            {
                _taxTypeIdentifierField = value;
                _taxTypeIdentifierSet = true;
            }
        }

        public string CardAcceptorTaxId { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (_taxIncludedInTotalSet)
                xml += "\r\n<taxIncludedInTotal>" + _taxIncludedInTotalField.ToString().ToLower() +
                       "</taxIncludedInTotal>";
            if (_taxAmountSet) xml += "\r\n<taxAmount>" + _taxAmountField + "</taxAmount>";
            if (TaxRate != null) xml += "\r\n<taxRate>" + SecurityElement.Escape(TaxRate) + "</taxRate>";
            if (_taxTypeIdentifierSet)
                xml += "\r\n<taxTypeIdentifier>" + _taxTypeIdentifierField + "</taxTypeIdentifier>";
            if (CardAcceptorTaxId != null)
                xml += "\r\n<cardAcceptorTaxId>" + SecurityElement.Escape(CardAcceptorTaxId) + "</cardAcceptorTaxId>";
            return xml;
        }
    }
}