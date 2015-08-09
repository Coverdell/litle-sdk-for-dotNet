using System.Collections.Generic;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class LineItemData
    {
        private int _itemSeqenceNumberField;
        private bool _itemSequenceNumberSet;

        public int ItemSequenceNumber
        {
            get { return _itemSeqenceNumberField; }
            set
            {
                _itemSeqenceNumberField = value;
                _itemSequenceNumberSet = true;
            }
        }

        public string ItemDescription;
        public string ProductCode;
        public string Quantity;
        public string UnitOfMeasure;
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

        private long _lineItemTotalField;
        private bool _lineItemTotalSet;

        public long LineItemTotal
        {
            get { return _lineItemTotalField; }
            set
            {
                _lineItemTotalField = value;
                _lineItemTotalSet = true;
            }
        }

        private long _lineItemTotalWithTaxField;
        private bool _lineItemTotalWithTaxSet;

        public long LineItemTotalWithTax
        {
            get { return _lineItemTotalWithTaxField; }
            set
            {
                _lineItemTotalWithTaxField = value;
                _lineItemTotalWithTaxSet = true;
            }
        }

        private long _itemDiscountAmountField;
        private bool _itemDiscountAmountSet;

        public long ItemDiscountAmount
        {
            get { return _itemDiscountAmountField; }
            set
            {
                _itemDiscountAmountField = value;
                _itemDiscountAmountSet = true;
            }
        }

        public string CommodityCode;
        public string UnitCost;
        public List<DetailTax> DetailTaxes;

        public LineItemData()
        {
            DetailTaxes = new List<DetailTax>();
        }

        public string Serialize()
        {
            var xml = "";
            if (_itemSequenceNumberSet)
                xml += "\r\n<itemSequenceNumber>" + _itemSeqenceNumberField + "</itemSequenceNumber>";
            if (ItemDescription != null)
                xml += "\r\n<itemDescription>" + SecurityElement.Escape(ItemDescription) + "</itemDescription>";
            if (ProductCode != null)
                xml += "\r\n<productCode>" + SecurityElement.Escape(ProductCode) + "</productCode>";
            if (Quantity != null) xml += "\r\n<quantity>" + SecurityElement.Escape(Quantity) + "</quantity>";
            if (UnitOfMeasure != null)
                xml += "\r\n<unitOfMeasure>" + SecurityElement.Escape(UnitOfMeasure) + "</unitOfMeasure>";
            if (_taxAmountSet) xml += "\r\n<taxAmount>" + _taxAmountField + "</taxAmount>";
            if (_lineItemTotalSet) xml += "\r\n<lineItemTotal>" + _lineItemTotalField + "</lineItemTotal>";
            if (_lineItemTotalWithTaxSet)
                xml += "\r\n<lineItemTotalWithTax>" + _lineItemTotalWithTaxField + "</lineItemTotalWithTax>";
            if (_itemDiscountAmountSet)
                xml += "\r\n<itemDiscountAmount>" + _itemDiscountAmountField + "</itemDiscountAmount>";
            if (CommodityCode != null)
                xml += "\r\n<commodityCode>" + SecurityElement.Escape(CommodityCode) + "</commodityCode>";
            if (UnitCost != null) xml += "\r\n<unitCost>" + SecurityElement.Escape(UnitCost) + "</unitCost>";
            foreach (var detailTax in DetailTaxes)
            {
                if (detailTax != null) xml += "\r\n<detailTax>" + detailTax.Serialize() + "</detailTax>";
            }
            return xml;
        }
    }
}