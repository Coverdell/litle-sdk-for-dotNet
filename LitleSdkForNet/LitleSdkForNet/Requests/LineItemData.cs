using System.Collections.Generic;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("lineItemData")]
    public class LineItemData
    {
        [XmlElement("itemSequenceNumber")]
        public int? ItemSequenceNumber { get; set; }
        [XmlElement("itemDescription")]
        public string ItemDescription { get; set; }
        [XmlElement("productCode")]
        public string ProductCode { get; set; }
        [XmlElement("quantity")]
        public string Quantity { get; set; }
        [XmlElement("unitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlElement("taxAmount")]
        public long? TaxAmount { get; set; }
        [XmlElement("lineItemTotal")]
        public long? LineItemTotal { get; set; }
        [XmlElement("lineItemTotalWithTax")]
        public long? LineItemTotalWithTax { get; set; }
        [XmlElement("itemDiscountAmount")]
        public long? ItemDiscountAmount { get; set; }
        [XmlElement("commodityCode")]
        public string CommodityCode { get; set; }
        [XmlElement("unitCost")]
        public string UnitCost { get; set; }
        [XmlArray("detailTax")]
        public List<DetailTax> DetailTaxes { get; set; }

        public LineItemData()
        {
            DetailTaxes = new List<DetailTax>();
        }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}