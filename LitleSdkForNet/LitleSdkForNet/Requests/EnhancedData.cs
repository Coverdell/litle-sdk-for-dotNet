using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("enhancedData")]
    public class EnhancedData
    {
        [XmlElement("customerReference")]
        public string CustomerReference { get; set; }
        [XmlElement("salesTax")]
        public long? SalesTax { get; set; }
        [XmlElement("deliveryType")]
        public EnhancedDataDeliveryType? DeliveryType { get; set; }
        [XmlElement("taxExempt")]
        public bool? TaxExempt { get; set; }
        [XmlElement("discountAmount")]
        public long? DiscountAmount { get; set; }
        [XmlElement("shippingAmount")]
        public long? ShippingAmount { get; set; }
        [XmlElement("dutyAmount")]
        public long? DutyAmount { get; set; }
        [XmlElement("shopFromPostalCode")]
        public string ShipFromPostalCode { get; set; }
        [XmlElement("destinationPostalCode")]
        public string DestinationPostalCode { get; set; }
        [XmlElement("destinationCountry")]
        public CountryTypeEnum? DestinationCountry { get; set; }
        [XmlElement("invoiceReferenceNumber")]
        public string InvoiceReferenceNumber { get; set; }
        [XmlElement("orderDate")]
        public DateTime? OrderDate { get; set; }
        [XmlArray("detailTax")]
        public List<DetailTax> DetailTaxes { get; set; }
        [XmlArray("lineItem")]
        public List<LineItemData> LineItems { get; set; }

        public EnhancedData()
        {
            LineItems = new List<LineItemData>();
            DetailTaxes = new List<DetailTax>();
        }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}