using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class litleOnlineRequest
    {
        public string merchantId;
        public string merchantSdk;
        public authentication authentication;
        public authorization authorization;
        public capture capture;
        public credit credit;
        public voidTxn voidTxn;
        public sale sale;
        public authReversal authReversal;
        public echeckCredit echeckCredit;
        public echeckVerification echeckVerification;
        public echeckSale echeckSale;
        public registerTokenRequestType registerTokenRequest;
        public forceCapture forceCapture;
        public captureGivenAuth captureGivenAuth;
        public echeckRedeposit echeckRedeposit;
        public echeckVoid echeckVoid;
        public updateCardValidationNumOnToken updateCardValidationNumOnToken;
        public updateSubscription updateSubscription;
        public cancelSubscription cancelSubscription;
        public activate activate;
        public deactivate deactivate;
        public load load;
        public unload unload;
        public balanceInquiry balanceInquiry;
        public createPlan createPlan;
        public updatePlan updatePlan;
        public refundReversal refundReversal;
        public loadReversal loadReversal;
        public depositReversal depositReversal;
        public activateReversal activateReversal;
        public deactivateReversal deactivateReversal;
        public unloadReversal unloadReversal;

        public string Serialize()
        {
            var xml = "<?xml version='1.0' encoding='utf-8'?>\r\n<litleOnlineRequest merchantId=\"" + merchantId +
                      "\" version=\"9.3\" merchantSdk=\"" + merchantSdk + "\" xmlns=\"http://www.litle.com/schema\">"
                      + authentication.Serialize();

            if (authorization != null) xml += authorization.Serialize();
            else if (capture != null) xml += capture.Serialize();
            else if (credit != null) xml += credit.Serialize();
            else if (voidTxn != null) xml += voidTxn.Serialize();
            else if (sale != null) xml += sale.Serialize();
            else if (authReversal != null) xml += authReversal.Serialize();
            else if (echeckCredit != null) xml += echeckCredit.Serialize();
            else if (echeckVerification != null) xml += echeckVerification.Serialize();
            else if (echeckSale != null) xml += echeckSale.Serialize();
            else if (registerTokenRequest != null) xml += registerTokenRequest.Serialize();
            else if (forceCapture != null) xml += forceCapture.Serialize();
            else if (captureGivenAuth != null) xml += captureGivenAuth.Serialize();
            else if (echeckRedeposit != null) xml += echeckRedeposit.Serialize();
            else if (echeckVoid != null) xml += echeckVoid.Serialize();
            else if (updateCardValidationNumOnToken != null) xml += updateCardValidationNumOnToken.Serialize();
            else if (updateSubscription != null) xml += updateSubscription.Serialize();
            else if (cancelSubscription != null) xml += cancelSubscription.Serialize();
            else if (activate != null) xml += activate.Serialize();
            else if (deactivate != null) xml += deactivate.Serialize();
            else if (load != null) xml += load.Serialize();
            else if (unload != null) xml += unload.Serialize();
            else if (balanceInquiry != null) xml += balanceInquiry.Serialize();
            else if (createPlan != null) xml += createPlan.Serialize();
            else if (updatePlan != null) xml += updatePlan.Serialize();
            else if (refundReversal != null) xml += refundReversal.Serialize();
            else if (loadReversal != null) xml += loadReversal.Serialize();
            else if (depositReversal != null) xml += depositReversal.Serialize();
            else if (activateReversal != null) xml += activateReversal.Serialize();
            else if (deactivateReversal != null) xml += deactivateReversal.Serialize();
            else if (unloadReversal != null) xml += unloadReversal.Serialize();
            xml += "\r\n</litleOnlineRequest>";

            return xml;
        }
    }


    public class authentication
    {
        public string user;
        public string password;

        public string Serialize() =>
            $"\r\n<authentication>\r\n<user>{SecurityElement.Escape(user)}</user>"
            + $"\r\n<password>{SecurityElement.Escape(password)}</password>\r\n</authentication>";
    }

    public class customerInfo
    {
        public string ssn;
        public DateTime dob;
        public DateTime customerRegistrationDate;

        private customerInfoCustomerType _customerTypeField;
        private bool _customerTypeSet;

        public customerInfoCustomerType customerType
        {
            get { return _customerTypeField; }
            set
            {
                _customerTypeField = value;
                _customerTypeSet = true;
            }
        }

        private long _incomeAmountField;
        private bool _incomeAmountSet;

        public long incomeAmount
        {
            get { return _incomeAmountField; }
            set
            {
                _incomeAmountField = value;
                _incomeAmountSet = true;
            }
        }

        private currencyCodeEnum _incomeCurrencyField;
        private bool _incomeCurrencySet;

        public currencyCodeEnum incomeCurrency
        {
            get { return _incomeCurrencyField; }
            set
            {
                _incomeCurrencyField = value;
                _incomeCurrencySet = true;
            }
        }

        private bool _customerCheckingAccountField;
        private bool _customerCheckingAccountSet;

        public bool customerCheckingAccount
        {
            get { return _customerCheckingAccountField; }
            set
            {
                _customerCheckingAccountField = value;
                _customerCheckingAccountSet = true;
            }
        }

        private bool _customerSavingAccountField;
        private bool _customerSavingAccountSet;

        public bool customerSavingAccount
        {
            get { return _customerSavingAccountField; }
            set
            {
                _customerSavingAccountField = value;
                _customerSavingAccountSet = true;
            }
        }

        public string employerName;
        public string customerWorkTelephone;

        private customerInfoResidenceStatus _residenceStatusField;
        private bool _residenceStatusSet;

        public customerInfoResidenceStatus residenceStatus
        {
            get { return _residenceStatusField; }
            set
            {
                _residenceStatusField = value;
                _residenceStatusSet = true;
            }
        }

        private int _yearsAtResidenceField;
        private bool _yearsAtResidenceSet;

        public int yearsAtResidence
        {
            get { return _yearsAtResidenceField; }
            set
            {
                _yearsAtResidenceField = value;
                _yearsAtResidenceSet = true;
            }
        }

        private int _yearsAtEmployerField;
        private bool _yearsAtEmployerSet;

        public int yearsAtEmployer
        {
            get { return _yearsAtEmployerField; }
            set
            {
                _yearsAtEmployerField = value;
                _yearsAtEmployerSet = true;
            }
        }


        public customerInfo()
        {
            incomeCurrency = currencyCodeEnum.USD;
        }

        public string Serialize()
        {
            var xml = "";
            if (ssn != null)
            {
                xml += "\r\n<ssn>" + SecurityElement.Escape(ssn) + "</ssn>";
            }
            xml += "\r\n<dob>" + XmlUtil.toXsdDate(dob) + "</dob>";
            xml += "\r\n<customerRegistrationDate>" + XmlUtil.toXsdDate(customerRegistrationDate) +
                   "</customerRegistrationDate>";
            if (_customerTypeSet)
            {
                xml += "\r\n<customerType>" + _customerTypeField + "</customerType>";
            }
            if (_incomeAmountSet)
            {
                xml += "\r\n<incomeAmount>" + _incomeAmountField + "</incomeAmount>";
            }
            if (_incomeCurrencySet)
            {
                xml += "\r\n<incomeCurrency>" + _incomeCurrencyField + "</incomeCurrency>";
            }
            if (_customerCheckingAccountSet)
            {
                xml += "\r\n<customerCheckingAccount>" + _customerCheckingAccountField.ToString().ToLower() +
                       "</customerCheckingAccount>";
            }
            if (_customerSavingAccountSet)
            {
                xml += "\r\n<customerSavingAccount>" + _customerSavingAccountField.ToString().ToLower() +
                       "</customerSavingAccount>";
            }
            if (employerName != null)
            {
                xml += "\r\n<employerName>" + SecurityElement.Escape(employerName) + "</employerName>";
            }
            if (customerWorkTelephone != null)
            {
                xml += "\r\n<customerWorkTelephone>" + SecurityElement.Escape(customerWorkTelephone) +
                       "</customerWorkTelephone>";
            }
            if (_residenceStatusSet)
            {
                xml += "\r\n<residenceStatus>" + _residenceStatusField + "</residenceStatus>";
            }
            if (_yearsAtResidenceSet)
            {
                xml += "\r\n<yearsAtResidence>" + _yearsAtResidenceField + "</yearsAtResidence>";
            }
            if (_yearsAtEmployerSet)
            {
                xml += "\r\n<yearsAtEmployer>" + _yearsAtEmployerField + "</yearsAtEmployer>";
            }
            return xml;
        }
    }

    public enum customerInfoCustomerType
    {
        /// <remarks />
        New,
        Existing
    }

    public enum currencyCodeEnum
    {
        /// <remarks />
        AUD,
        CAD,
        CHF,
        DKK,
        EUR,
        GBP,
        HKD,
        JPY,
        NOK,
        NZD,
        SEK,
        SGD,
        USD
    }

    public enum customerInfoResidenceStatus
    {
        /// <remarks />
        Own,
        Rent,
        Other
    }

    public class enhancedData
    {
        public string customerReference;
        private long _salesTaxField;
        private bool _salesTaxSet;

        public long salesTax
        {
            get { return _salesTaxField; }
            set
            {
                _salesTaxField = value;
                _salesTaxSet = true;
            }
        }

        private enhancedDataDeliveryType _deliveryTypeField;
        private bool _deliveryTypeSet;

        public enhancedDataDeliveryType deliveryType
        {
            get { return _deliveryTypeField; }
            set
            {
                _deliveryTypeField = value;
                _deliveryTypeSet = true;
            }
        }

        public bool taxExemptField;
        public bool taxExemptSet;

        public bool taxExempt
        {
            get { return taxExemptField; }
            set
            {
                taxExemptField = value;
                taxExemptSet = true;
            }
        }

        private long _discountAmountField;
        private bool _discountAmountSet;

        public long discountAmount
        {
            get { return _discountAmountField; }
            set
            {
                _discountAmountField = value;
                _discountAmountSet = true;
            }
        }

        private long _shippingAmountField;
        private bool _shippingAmountSet;

        public long shippingAmount
        {
            get { return _shippingAmountField; }
            set
            {
                _shippingAmountField = value;
                _shippingAmountSet = true;
            }
        }

        private long _dutyAmountField;
        private bool _dutyAmountSet;

        public long dutyAmount
        {
            get { return _dutyAmountField; }
            set
            {
                _dutyAmountField = value;
                _dutyAmountSet = true;
            }
        }

        public string shipFromPostalCode;
        public string destinationPostalCode;

        private countryTypeEnum _destinationCountryCodeField;
        private bool _destinationCountryCodeSet;

        public countryTypeEnum destinationCountry
        {
            get { return _destinationCountryCodeField; }
            set
            {
                _destinationCountryCodeField = value;
                _destinationCountryCodeSet = true;
            }
        }

        public string invoiceReferenceNumber;

        private DateTime _orderDateField;
        private bool _orderDateSet;

        public DateTime orderDate
        {
            get { return _orderDateField; }
            set
            {
                _orderDateField = value;
                _orderDateSet = true;
            }
        }

        public List<detailTax> detailTaxes;
        public List<lineItemData> lineItems;

        public enhancedData()
        {
            lineItems = new List<lineItemData>();
            detailTaxes = new List<detailTax>();
        }

        public string Serialize()
        {
            var xml = "";
            if (customerReference != null)
                xml += "\r\n<customerReference>" + SecurityElement.Escape(customerReference) + "</customerReference>";
            if (_salesTaxSet) xml += "\r\n<salesTax>" + _salesTaxField + "</salesTax>";
            if (_deliveryTypeSet) xml += "\r\n<deliveryType>" + _deliveryTypeField + "</deliveryType>";
            if (taxExemptSet) xml += "\r\n<taxExempt>" + taxExemptField.ToString().ToLower() + "</taxExempt>";
            if (_discountAmountSet) xml += "\r\n<discountAmount>" + _discountAmountField + "</discountAmount>";
            if (_shippingAmountSet) xml += "\r\n<shippingAmount>" + _shippingAmountField + "</shippingAmount>";
            if (_dutyAmountSet) xml += "\r\n<dutyAmount>" + _dutyAmountField + "</dutyAmount>";
            if (shipFromPostalCode != null)
                xml += "\r\n<shipFromPostalCode>" + SecurityElement.Escape(shipFromPostalCode) + "</shipFromPostalCode>";
            if (destinationPostalCode != null)
                xml += "\r\n<destinationPostalCode>" + SecurityElement.Escape(destinationPostalCode) +
                       "</destinationPostalCode>";
            if (_destinationCountryCodeSet)
                xml += "\r\n<destinationCountryCode>" + _destinationCountryCodeField + "</destinationCountryCode>";
            if (invoiceReferenceNumber != null)
                xml += "\r\n<invoiceReferenceNumber>" + SecurityElement.Escape(invoiceReferenceNumber) +
                       "</invoiceReferenceNumber>";
            if (_orderDateSet) xml += "\r\n<orderDate>" + XmlUtil.toXsdDate(_orderDateField) + "</orderDate>";
            xml = detailTaxes.Aggregate(xml, (current, detailTax) =>
                $"{current}\r\n<detailTax>{detailTax.Serialize()}\r\n</detailTax>");
            return lineItems.Aggregate(xml, (current, lineItem) =>
                $"{current}\r\n<lineItemData>{lineItem.Serialize()}\r\n</lineItemData>");
        }
    }

    public class voidTxn : transactionTypeWithReportGroup
    {
        public long litleTxnId;
        public processingInstructions processingInstructions;

        public override string Serialize()
        {
            var xml = "\r\n<void";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";
            xml += "\r\n<litleTxnId>" + litleTxnId + "</litleTxnId>";
            if (processingInstructions != null)
                xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            xml += "\r\n</void>";

            return xml;
        }
    }

    public class lineItemData
    {
        private int _itemSeqenceNumberField;
        private bool _itemSequenceNumberSet;

        public int itemSequenceNumber
        {
            get { return _itemSeqenceNumberField; }
            set
            {
                _itemSeqenceNumberField = value;
                _itemSequenceNumberSet = true;
            }
        }

        public string itemDescription;
        public string productCode;
        public string quantity;
        public string unitOfMeasure;

        private long _taxAmountField;
        private bool _taxAmountSet;

        public long taxAmount
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

        public long lineItemTotal
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

        public long lineItemTotalWithTax
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

        public long itemDiscountAmount
        {
            get { return _itemDiscountAmountField; }
            set
            {
                _itemDiscountAmountField = value;
                _itemDiscountAmountSet = true;
            }
        }

        public string commodityCode;
        public string unitCost;
        public List<detailTax> detailTaxes;

        public lineItemData()
        {
            detailTaxes = new List<detailTax>();
        }

        public string Serialize()
        {
            var xml = "";
            if (_itemSequenceNumberSet)
                xml += "\r\n<itemSequenceNumber>" + _itemSeqenceNumberField + "</itemSequenceNumber>";
            if (itemDescription != null)
                xml += "\r\n<itemDescription>" + SecurityElement.Escape(itemDescription) + "</itemDescription>";
            if (productCode != null)
                xml += "\r\n<productCode>" + SecurityElement.Escape(productCode) + "</productCode>";
            if (quantity != null) xml += "\r\n<quantity>" + SecurityElement.Escape(quantity) + "</quantity>";
            if (unitOfMeasure != null)
                xml += "\r\n<unitOfMeasure>" + SecurityElement.Escape(unitOfMeasure) + "</unitOfMeasure>";
            if (_taxAmountSet) xml += "\r\n<taxAmount>" + _taxAmountField + "</taxAmount>";
            if (_lineItemTotalSet) xml += "\r\n<lineItemTotal>" + _lineItemTotalField + "</lineItemTotal>";
            if (_lineItemTotalWithTaxSet)
                xml += "\r\n<lineItemTotalWithTax>" + _lineItemTotalWithTaxField + "</lineItemTotalWithTax>";
            if (_itemDiscountAmountSet)
                xml += "\r\n<itemDiscountAmount>" + _itemDiscountAmountField + "</itemDiscountAmount>";
            if (commodityCode != null)
                xml += "\r\n<commodityCode>" + SecurityElement.Escape(commodityCode) + "</commodityCode>";
            if (unitCost != null) xml += "\r\n<unitCost>" + SecurityElement.Escape(unitCost) + "</unitCost>";
            return detailTaxes.Where(detailTax => detailTax != null).Aggregate(xml, (current, detailTax) => 
                current + "\r\n<detailTax>" + detailTax.Serialize() + "</detailTax>");
        }
    }
    
    public class detailTax
    {
        private bool _taxIncludedInTotalField;
        private bool _taxIncludedInTotalSet;

        public bool taxIncludedInTotal
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

        public long taxAmount
        {
            get { return _taxAmountField; }
            set
            {
                _taxAmountField = value;
                _taxAmountSet = true;
            }
        }

        public string taxRate;

        private taxTypeIdentifierEnum _taxTypeIdentifierField;
        private bool _taxTypeIdentifierSet;

        public taxTypeIdentifierEnum taxTypeIdentifier
        {
            get { return _taxTypeIdentifierField; }
            set
            {
                _taxTypeIdentifierField = value;
                _taxTypeIdentifierSet = true;
            }
        }

        public string cardAcceptorTaxId;

        public string Serialize()
        {
            var xml = "";
            if (_taxIncludedInTotalSet)
                xml += "\r\n<taxIncludedInTotal>" + _taxIncludedInTotalField.ToString().ToLower() +
                       "</taxIncludedInTotal>";
            if (_taxAmountSet) xml += "\r\n<taxAmount>" + _taxAmountField + "</taxAmount>";
            if (taxRate != null) xml += "\r\n<taxRate>" + SecurityElement.Escape(taxRate) + "</taxRate>";
            if (_taxTypeIdentifierSet)
                xml += "\r\n<taxTypeIdentifier>" + _taxTypeIdentifierField + "</taxTypeIdentifier>";
            if (cardAcceptorTaxId != null)
                xml += "\r\n<cardAcceptorTaxId>" + SecurityElement.Escape(cardAcceptorTaxId) + "</cardAcceptorTaxId>";
            return xml;
        }
    }

    public class transactionTypeWithReportGroupAndPartial : transactionType
    {
        public string reportGroup;
        private bool _partialField;
        protected bool PartialSet;

        public bool partial
        {
            get { return _partialField; }
            set
            {
                _partialField = value;
                PartialSet = true;
            }
        }
    }

    public class capture : transactionTypeWithReportGroupAndPartial
    {
        public long litleTxnId;
        private long _amountField;
        private bool _amountSet;

        public long amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long surchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public enhancedData enhancedData;
        public processingInstructions processingInstructions;
        private bool _payPalOrderCompleteField;
        private bool _payPalOrderCompleteSet;

        public bool payPalOrderComplete
        {
            get { return _payPalOrderCompleteField; }
            set
            {
                _payPalOrderCompleteField = value;
                _payPalOrderCompleteSet = true;
            }
        }

        public string payPalNotes;

        public override string Serialize()
        {
            var xml = "\r\n<capture";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            if (PartialSet)
            {
                xml += " partial=\"" + partial.ToString().ToLower() + "\"";
            }
            xml += ">";
            xml += "\r\n<litleTxnId>" + litleTxnId + "</litleTxnId>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (enhancedData != null) xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "\r\n</enhancedData>";
            if (processingInstructions != null)
                xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            if (_payPalOrderCompleteSet)
                xml += "\r\n<payPalOrderComplete>" + _payPalOrderCompleteField.ToString().ToLower() +
                       "</payPalOrderComplete>";
            if (payPalNotes != null)
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(payPalNotes) + "</payPalNotes>";
            xml += "\r\n</capture>";

            return xml;
        }
    }

    public class echeckCredit : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long litleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long secondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        public customBilling customBilling;
        public string orderId;
        public orderSourceType orderSource;
        public contact billToAddress;
        public echeckType echeck;

        [Obsolete]
        public echeckTokenType token
        {
            get { return echeckToken; }
            set { echeckToken = value; }
        }

        public echeckTokenType echeckToken;
        public merchantDataType merchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckCredit";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
                if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (customBilling != null)
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "</customBilling>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
                xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
                if (billToAddress != null)
                    xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "</billToAddress>";
                if (echeck != null) xml += "\r\n<echeck>" + echeck.Serialize() + "</echeck>";
                else if (echeckToken != null) xml += "\r\n<echeckToken>" + echeckToken.Serialize() + "</echeckToken>";
                if (customBilling != null)
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "</customBilling>";
                if (merchantData != null) xml += "\r\n<merchantData>" + merchantData.Serialize() + "</merchantData>";
            }
            xml += "\r\n</echeckCredit>";
            return xml;
        }
    }

    public class echeckSale : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long litleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long secondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        public customBilling customBilling;
        public string orderId;

        private bool _verifyField;
        private bool _verifySet;

        public bool verify
        {
            get { return _verifyField; }
            set
            {
                _verifyField = value;
                _verifySet = true;
            }
        }

        public orderSourceType orderSource;
        public contact billToAddress;
        public contact shipToAddress;
        public echeckType echeck;
        public echeckTokenType token;
        public merchantDataType merchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckSale";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
                if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
                // let sandbox do the validation for secondaryAmount
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (customBilling != null)
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "</customBilling>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
                if (_verifySet) xml += "\r\n<verify>" + (_verifyField ? "true" : "false") + "</verify>";
                xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
                if (billToAddress != null)
                    xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "</billToAddress>";
                if (shipToAddress != null)
                    xml += "\r\n<shipToAddress>" + shipToAddress.Serialize() + "</shipToAddress>";
                if (echeck != null) xml += "\r\n<echeck>" + echeck.Serialize() + "</echeck>";
                else if (token != null) xml += "\r\n<echeckToken>" + token.Serialize() + "</echeckToken>";
                if (customBilling != null)
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "</customBilling>";
                if (merchantData != null) xml += "\r\n<merchantData>" + merchantData.Serialize() + "</merchantData>";
            }
            xml += "\r\n</echeckSale>";
            return xml;
        }
    }


    public class echeckVerification : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long litleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        public string orderId;
        private long _amountField;
        private bool _amountSet;

        public long amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        public orderSourceType orderSource;
        public contact billToAddress;
        public echeckType echeck;
        public echeckTokenType token;
        public merchantDataType merchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckVerification";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet) xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
            xml += "\r\n<orderId>" + orderId + "</orderId>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            if (billToAddress != null) xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "</billToAddress>";
            if (echeck != null) xml += "\r\n<echeck>" + echeck.Serialize() + "</echeck>";
            else if (token != null) xml += "\r\n<echeckToken>" + token.Serialize() + "</echeckToken>";
            if (merchantData != null) xml += "\r\n<merchantData>" + merchantData.Serialize() + "</merchantData>";
            xml += "\r\n</echeckVerification>";
            return xml;
        }
    }

    public class registerTokenRequestType : transactionTypeWithReportGroup
    {
        public string orderId;
        public string accountNumber;
        public echeckForTokenType echeckForToken;
        public string paypageRegistrationId;
        public string cardValidationNum;
        public applepayType applepay;

        public override string Serialize()
        {
            var xml = "\r\n<registerTokenRequest";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            xml += "\r\n<orderId>" + orderId + "</orderId>";
            if (accountNumber != null) xml += "\r\n<accountNumber>" + accountNumber + "</accountNumber>";
            else if (echeckForToken != null)
                xml += "\r\n<echeckForToken>" + echeckForToken.Serialize() + "</echeckForToken>";
            else if (paypageRegistrationId != null)
                xml += "\r\n<paypageRegistrationId>" + paypageRegistrationId + "</paypageRegistrationId>";
            else if (applepay != null) xml += "\r\n<applepay>" + applepay.Serialize() + "\r\n</applepay>";
            if (cardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + cardValidationNum + "</cardValidationNum>";
            xml += "\r\n</registerTokenRequest>";
            return xml;
        }
    }

    public class updateCardValidationNumOnToken : transactionTypeWithReportGroup
    {
        public string orderId;
        public string litleToken;
        public string cardValidationNum;

        public override string Serialize()
        {
            var xml = "\r\n<updateCardValidationNumOnToken";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (orderId != null) xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            if (litleToken != null) xml += "\r\n<litleToken>" + SecurityElement.Escape(litleToken) + "</litleToken>";
            if (cardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(cardValidationNum) + "</cardValidationNum>";
            xml += "\r\n</updateCardValidationNumOnToken>";
            return xml;
        }
    }

    public class echeckForTokenType
    {
        public string accNum;
        public string routingNum;

        public string Serialize()
        {
            var xml = string.Empty;
            if (accNum != null) xml += "\r\n<accNum>" + SecurityElement.Escape(accNum) + "</accNum>";
            if (routingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(routingNum) + "</routingNum>";
            return xml;
        }
    }

    public class credit : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long litleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long secondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long surchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public customBilling customBilling;
        public enhancedData enhancedData;
        public processingInstructions processingInstructions;
        public string orderId;
        public orderSourceType orderSource;
        public contact billToAddress;
        public cardType card;
        public mposType mpos;
        public cardTokenType token;
        public cardPaypageType paypage;
        public payPal paypal;

        private taxTypeIdentifierEnum _taxTypeField;
        private bool _taxTypeSet;

        public taxTypeIdentifierEnum taxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public billMeLaterRequest billMeLaterRequest;
        public pos pos;
        public amexAggregatorData amexAggregatorData;
        public merchantDataType merchantData;
        public string payPalNotes;
        public string actionReason;

        public override string Serialize()
        {
            var xml = "\r\n<credit";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
                if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
                if (customBilling != null)
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "</customBilling>";
                if (enhancedData != null) xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "</enhancedData>";
                if (processingInstructions != null)
                    xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                           "</processingInstructions>";
                if (pos != null) xml += "\r\n<pos>" + pos.Serialize() + "</pos>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
                xml += "\r\n<amount>" + _amountField + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
                if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
                if (billToAddress != null)
                    xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "</billToAddress>";
                if (card != null) xml += "\r\n<card>" + card.Serialize() + "</card>";
                else if (token != null) xml += "\r\n<token>" + token.Serialize() + "</token>";
                else if (mpos != null) xml += "\r\n<mpos>" + mpos.Serialize() + "</mpos>";
                else if (paypage != null) xml += "\r\n<paypage>" + paypage.Serialize() + "</paypage>";
                else if (paypal != null)
                {
                    xml += "\r\n<paypal>";
                    if (paypal.payerId != null)
                        xml += "\r\n<payerId>" + SecurityElement.Escape(paypal.payerId) + "</payerId>";
                    else if (paypal.payerEmail != null)
                        xml += "\r\n<payerEmail>" + SecurityElement.Escape(paypal.payerEmail) + "</payerEmail>";
                    xml += "\r\n</paypal>";
                }
                if (customBilling != null)
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "</customBilling>";
                if (_taxTypeSet) xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
                if (billMeLaterRequest != null)
                    xml += "\r\n<billMeLaterRequest>" + billMeLaterRequest.Serialize() + "</billMeLaterRequest>";
                if (enhancedData != null) xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "</enhancedData>";
                if (processingInstructions != null)
                    xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                           "</processingInstructions>";
                if (pos != null) xml += "\r\n<pos>" + pos.Serialize() + "</pos>";
                if (amexAggregatorData != null)
                    xml += "\r\n<amexAggregatorData>" + amexAggregatorData.Serialize() + "</amexAggregatorData>";
                if (merchantData != null) xml += "\r\n<merchantData>" + merchantData.Serialize() + "</merchantData>";
            }
            if (payPalNotes != null)
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(payPalNotes) + "</payPalNotes>";
            if (actionReason != null)
                xml += "\r\n<actionReason>" + SecurityElement.Escape(actionReason) + "</actionReason>";
            xml += "\r\n</credit>";
            return xml;
        }
    }

    public class echeckType
    {
        private echeckAccountTypeEnum _accTypeField;
        private bool _accTypeSet;

        public echeckAccountTypeEnum accType
        {
            get { return _accTypeField; }
            set
            {
                _accTypeField = value;
                _accTypeSet = true;
            }
        }

        public string accNum;
        public string routingNum;
        public string checkNum;
        public string ccdPaymentInformation;

        public string Serialize()
        {
            var xml = string.Empty;
            var accTypeName = _accTypeField.ToString();
            var attributes =
                (XmlEnumAttribute[])
                    typeof (echeckAccountTypeEnum).GetMember(_accTypeField.ToString())[0].GetCustomAttributes(
                        typeof (XmlEnumAttribute), false);
            if (attributes.Length > 0) accTypeName = attributes[0].Name;
            if (_accTypeSet) xml += "\r\n<accType>" + accTypeName + "</accType>";
            if (accNum != null) xml += "\r\n<accNum>" + SecurityElement.Escape(accNum) + "</accNum>";
            if (routingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(routingNum) + "</routingNum>";
            if (checkNum != null) xml += "\r\n<checkNum>" + SecurityElement.Escape(checkNum) + "</checkNum>";
            if (ccdPaymentInformation != null)
                xml += "\r\n<ccdPaymentInformation>" + SecurityElement.Escape(ccdPaymentInformation) +
                       "</ccdPaymentInformation>";
            return xml;
        }
    }

    public class echeckTokenType
    {
        public string litleToken;
        public string routingNum;

        private echeckAccountTypeEnum _accTypeField;
        private bool _accTypeSet;

        public echeckAccountTypeEnum accType
        {
            get { return _accTypeField; }
            set
            {
                _accTypeField = value;
                _accTypeSet = true;
            }
        }

        public string checkNum;

        public string Serialize()
        {
            var xml = "";
            if (litleToken != null) xml += "\r\n<litleToken>" + SecurityElement.Escape(litleToken) + "</litleToken>";
            if (routingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(routingNum) + "</routingNum>";
            if (_accTypeSet) xml += "\r\n<accType>" + _accTypeField + "</accType>";
            if (checkNum != null) xml += "\r\n<checkNum>" + SecurityElement.Escape(checkNum) + "</checkNum>";
            return xml;
        }
    }
    
    public class pos
    {
        private posCapabilityTypeEnum _capabilityField;
        private bool _capabilitySet;

        public posCapabilityTypeEnum capability
        {
            get { return _capabilityField; }
            set
            {
                _capabilityField = value;
                _capabilitySet = true;
            }
        }

        private posEntryModeTypeEnum _entryModeField;
        private bool _entryModeSet;

        public posEntryModeTypeEnum entryMode
        {
            get { return _entryModeField; }
            set
            {
                _entryModeField = value;
                _entryModeSet = true;
            }
        }

        private posCardholderIdTypeEnum _cardholderIdField;
        private bool _cardholderIdSet;

        public posCardholderIdTypeEnum cardholderId
        {
            get { return _cardholderIdField; }
            set
            {
                _cardholderIdField = value;
                _cardholderIdSet = true;
            }
        }

        public string terminalId;

        private posCatLevelEnum _catLevelField;
        private bool _catLevelSet;

        public posCatLevelEnum catLevel
        {
            get { return _catLevelField; }
            set
            {
                _catLevelField = value;
                _catLevelSet = true;
            }
        }

        public string Serialize()
        {
            var xml = string.Empty;
            if (_capabilitySet) xml += "\r\n<capability>" + _capabilityField + "</capability>";
            if (_entryModeSet) xml += "\r\n<entryMode>" + _entryModeField + "</entryMode>";
            if (_cardholderIdSet) xml += "\r\n<cardholderId>" + _cardholderIdField + "</cardholderId>";
            if (terminalId != null) xml += "\r\n<terminalId>" + SecurityElement.Escape(terminalId) + "</terminalId>";
            if (_catLevelSet) xml += "\r\n<catLevel>" + _catLevelField.Serialize() + "</catLevel>";
            return xml;
        }
    }

    public class payPal
    {
        public string payerId;
        public string payerEmail;
        public string token;
        public string transactionId;

        public string Serialize()
        {
            var xml = string.Empty;
            if (payerId != null) xml += "\r\n<payerId>" + SecurityElement.Escape(payerId) + "</payerId>";
            if (payerEmail != null) xml += "\r\n<payerEmail>" + SecurityElement.Escape(payerEmail) + "</payerEmail>";
            if (token != null) xml += "\r\n<token>" + SecurityElement.Escape(token) + "</token>";
            if (transactionId != null)
                xml += "\r\n<transactionId>" + SecurityElement.Escape(transactionId) + "</transactionId>";
            return xml;
        }
    }

    public class merchantDataType
    {
        public string campaign;
        public string affiliate;
        public string merchantGroupingId;

        public string Serialize()
        {
            var xml = string.Empty;
            if (campaign != null) xml += "\r\n<campaign>" + SecurityElement.Escape(campaign) + "</campaign>";
            if (affiliate != null) xml += "\r\n<affiliate>" + SecurityElement.Escape(affiliate) + "</affiliate>";
            if (merchantGroupingId != null)
                xml += "\r\n<merchantGroupingId>" + SecurityElement.Escape(merchantGroupingId) + "</merchantGroupingId>";
            return xml;
        }
    }

    public class cardTokenType
    {
        public string litleToken;
        public string expDate;
        public string cardValidationNum;

        private methodOfPaymentTypeEnum _typeField;
        private bool _typeSet;

        public methodOfPaymentTypeEnum type
        {
            get { return _typeField; }
            set
            {
                _typeField = value;
                _typeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "\r\n<litleToken>" + SecurityElement.Escape(litleToken) + "</litleToken>";
            if (expDate != null) xml += "\r\n<expDate>" + SecurityElement.Escape(expDate) + "</expDate>";
            if (cardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(cardValidationNum) + "</cardValidationNum>";
            if (_typeSet) xml += "\r\n<type>" + methodOfPaymentSerializer.Serialize(_typeField) + "</type>";
            return xml;
        }
    }

    public class cardPaypageType
    {
        public string paypageRegistrationId;
        public string expDate;
        public string cardValidationNum;

        private methodOfPaymentTypeEnum _typeField;
        private bool _typeSet;

        public methodOfPaymentTypeEnum type
        {
            get { return _typeField; }
            set
            {
                _typeField = value;
                _typeSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "\r\n<paypageRegistrationId>" + SecurityElement.Escape(paypageRegistrationId) +
                      "</paypageRegistrationId>";
            if (expDate != null) xml += "\r\n<expDate>" + SecurityElement.Escape(expDate) + "</expDate>";
            if (cardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(cardValidationNum) + "</cardValidationNum>";
            if (_typeSet) xml += "\r\n<type>" + methodOfPaymentSerializer.Serialize(_typeField) + "</type>";
            return xml;
        }
    }

    public class billMeLaterRequest
    {
        private long _bmlMerchantIdField;
        private bool _bmlMerchantIdSet;

        public long bmlMerchantId
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

        public long bmlProductType
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

        public int termsAndConditions
        {
            get { return _termsAndConditionsField; }
            set
            {
                _termsAndConditionsField = value;
                _termsAndConditionsSet = true;
            }
        }

        public string preapprovalNumber;

        private int _merchantPromotionalCodeField;
        private bool _merchantPromotionalCodeSet;

        public int merchantPromotionalCode
        {
            get { return _merchantPromotionalCodeField; }
            set
            {
                _merchantPromotionalCodeField = value;
                _merchantPromotionalCodeSet = true;
            }
        }

        public string virtualAuthenticationKeyPresenceIndicator;
        public string virtualAuthenticationKeyData;

        private int _itemCategoryCodeField;
        private bool _itemCategoryCodeSet;

        public int itemCategoryCode
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
            var xml = string.Empty;
            if (_bmlMerchantIdSet) xml += "\r\n<bmlMerchantId>" + _bmlMerchantIdField + "</bmlMerchantId>";
            if (_bmlProductTypeSet) xml += "\r\n<bmlProductType>" + _bmlProductTypeField + "</bmlProductType>";
            if (_termsAndConditionsSet)
                xml += "\r\n<termsAndConditions>" + _termsAndConditionsField + "</termsAndConditions>";
            if (preapprovalNumber != null)
                xml += "\r\n<preapprovalNumber>" + SecurityElement.Escape(preapprovalNumber) + "</preapprovalNumber>";
            if (_merchantPromotionalCodeSet)
                xml += "\r\n<merchantPromotionalCode>" + _merchantPromotionalCodeField + "</merchantPromotionalCode>";
            if (virtualAuthenticationKeyPresenceIndicator != null)
                xml += "\r\n<virtualAuthenticationKeyPresenceIndicator>" +
                       SecurityElement.Escape(virtualAuthenticationKeyPresenceIndicator) +
                       "</virtualAuthenticationKeyPresenceIndicator>";
            if (virtualAuthenticationKeyData != null)
                xml += "\r\n<virtualAuthenticationKeyData>" + SecurityElement.Escape(virtualAuthenticationKeyData) +
                       "</virtualAuthenticationKeyData>";
            if (_itemCategoryCodeSet) xml += "\r\n<itemCategoryCode>" + _itemCategoryCodeField + "</itemCategoryCode>";
            return xml;
        }
    }

    public class customBilling
    {
        public string phone;
        public string city;
        public string url;
        public string descriptor;

        public string Serialize()
        {
            var xml = string.Empty;
            if (phone != null) xml += "\r\n<phone>" + SecurityElement.Escape(phone) + "</phone>";
            else if (city != null) xml += "\r\n<city>" + SecurityElement.Escape(city) + "</city>";
            else if (url != null) xml += "\r\n<url>" + SecurityElement.Escape(url) + "</url>";
            if (descriptor != null) xml += "\r\n<descriptor>" + SecurityElement.Escape(descriptor) + "</descriptor>";
            return xml;
        }
    }

    public class amexAggregatorData
    {
        public string sellerId;
        public string sellerMerchantCategoryCode;

        public string Serialize()
        {
            var xml = string.Empty;
            xml += "\r\n<sellerId>" + SecurityElement.Escape(sellerId) + "</sellerId>";
            xml += "\r\n<sellerMerchantCategoryCode>" + SecurityElement.Escape(sellerMerchantCategoryCode) +
                   "</sellerMerchantCategoryCode>";
            return xml;
        }
    }

    public class processingInstructions
    {
        private bool _bypassVelocityCheckField;
        private bool _bypassVelocityCheckSet;

        public bool bypassVelocityCheck
        {
            get { return _bypassVelocityCheckField; }
            set
            {
                _bypassVelocityCheckField = value;
                _bypassVelocityCheckSet = true;
            }
        }

        public string Serialize()
        {
            var xml = string.Empty;
            if (_bypassVelocityCheckSet)
                xml += "\r\n<bypassVelocityCheck>" + _bypassVelocityCheckField.ToString().ToLower() +
                       "</bypassVelocityCheck>";
            return xml;
        }
    }

    public class echeckRedeposit : baseRequestTransactionEcheckRedeposit
    {
        //litleTxnIdField and set are in super
        public echeckType echeck;
        public echeckTokenType token;
        public merchantDataType merchantData;

        public override string Serialize()
        {
            var xml = "\r\n<echeckRedeposit";
            xml += " id=\"" + id + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + customerId + "\"";
            }
            xml += " reportGroup=\"" + reportGroup + "\">";
            if (litleTxnIdSet) xml += "\r\n<litleTxnId>" + litleTxnIdField + "</litleTxnId>";
            if (echeck != null) xml += "\r\n<echeck>" + echeck.Serialize() + "</echeck>";
            else if (token != null) xml += "\r\n<echeckToken>" + token.Serialize() + "</echeckToken>";
            if (merchantData != null)
            {
                xml += "\r\n<merchantData>" + merchantData.Serialize() + "\r\n</merchantData>";
            }
            xml += "\r\n</echeckRedeposit>";
            return xml;
        }
    }

    public class authorization : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long litleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        public string orderId;
        public long amount;

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long secondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long surchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public orderSourceType orderSource;
        public customerInfo customerInfo;
        public contact billToAddress;
        public contact shipToAddress;
        public cardType card;
        public mposType mpos;
        public payPal paypal;
        public cardTokenType token;
        public cardPaypageType paypage;
        public applepayType applepay;
        public billMeLaterRequest billMeLaterRequest;
        public fraudCheckType cardholderAuthentication;
        public processingInstructions processingInstructions;
        public pos pos;
        public customBilling customBilling;

        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum taxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public enhancedData enhancedData;
        public amexAggregatorData amexAggregatorData;

        private bool _allowPartialAuthField;
        private bool _allowPartialAuthSet;

        public bool allowPartialAuth
        {
            get { return _allowPartialAuthField; }
            set
            {
                _allowPartialAuthField = value;
                _allowPartialAuthSet = true;
            }
        }

        public healthcareIIAS healthcareIIAS;
        public filteringType filtering;
        public merchantDataType merchantData;
        public recyclingRequestType recyclingRequest;

        private bool _fraudFilterOverrideField;
        private bool _fraudFilterOverrideSet;

        public bool fraudFilterOverride
        {
            get { return _fraudFilterOverrideField; }
            set
            {
                _fraudFilterOverrideField = value;
                _fraudFilterOverrideSet = true;
            }
        }

        public recurringRequest recurringRequest;

        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool debtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public advancedFraudChecksType advancedFraudChecks;
        public wallet wallet;

        public override string Serialize()
        {
            var xml = "\r\n<authorization";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (_litleTxnIdSet)
            {
                xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
            }
            else
            {
                xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
                xml += "\r\n<amount>" + amount + "</amount>";
                if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
                if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
                if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";

                if (customerInfo != null)
                {
                    xml += "\r\n<customerInfo>" + customerInfo.Serialize() + "\r\n</customerInfo>";
                }
                if (billToAddress != null)
                {
                    xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "\r\n</billToAddress>";
                }
                if (shipToAddress != null)
                {
                    xml += "\r\n<shipToAddress>" + shipToAddress.Serialize() + "\r\n</shipToAddress>";
                }
                if (card != null)
                {
                    xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
                }
                else if (paypal != null)
                {
                    xml += "\r\n<paypal>" + paypal.Serialize() + "\r\n</paypal>";
                }
                else if (mpos != null)
                {
                    xml += "\r\n<mpos>" + mpos.Serialize() + "\r\n</mpos>";
                }
                else if (token != null)
                {
                    xml += "\r\n<token>" + token.Serialize() + "\r\n</token>";
                }
                else if (paypage != null)
                {
                    xml += "\r\n<paypage>" + paypage.Serialize() + "\r\n</paypage>";
                }
                else if (applepay != null)
                {
                    xml += "\r\n<applepay>" + applepay.Serialize() + "\r\n</applepay>";
                }
                if (billMeLaterRequest != null)
                {
                    xml += "\r\n<billMeLaterRequest>" + billMeLaterRequest.Serialize() + "\r\n</billMeLaterRequest>";
                }
                if (cardholderAuthentication != null)
                {
                    xml += "\r\n<cardholderAuthentication>" + cardholderAuthentication.Serialize() +
                           "\r\n</cardholderAuthentication>";
                }
                if (processingInstructions != null)
                {
                    xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                           "\r\n</processingInstructions>";
                }
                if (pos != null)
                {
                    xml += "\r\n<pos>" + pos.Serialize() + "\r\n</pos>";
                }
                if (customBilling != null)
                {
                    xml += "\r\n<customBilling>" + customBilling.Serialize() + "\r\n</customBilling>";
                }
                if (_taxTypeSet)
                {
                    xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
                }
                if (enhancedData != null)
                {
                    xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "\r\n</enhancedData>";
                }
                if (amexAggregatorData != null)
                {
                    xml += "\r\n<amexAggregatorData>" + amexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
                }
                if (_allowPartialAuthSet)
                {
                    xml += "\r\n<allowPartialAuth>" + _allowPartialAuthField.ToString().ToLower() + "</allowPartialAuth>";
                }
                if (healthcareIIAS != null)
                {
                    xml += "\r\n<healthcareIIAS>" + healthcareIIAS.Serialize() + "\r\n</healthcareIIAS>";
                }
                if (filtering != null)
                {
                    xml += "\r\n<filtering>" + filtering.Serialize() + "\r\n</filtering>";
                }
                if (merchantData != null)
                {
                    xml += "\r\n<merchantData>" + merchantData.Serialize() + "\r\n</merchantData>";
                }
                if (recyclingRequest != null)
                {
                    xml += "\r\n<recyclingRequest>" + recyclingRequest.Serialize() + "\r\n</recyclingRequest>";
                }
                if (_fraudFilterOverrideSet)
                    xml += "\r\n<fraudFilterOverride>" + _fraudFilterOverrideField.ToString().ToLower() +
                           "</fraudFilterOverride>";
                if (recurringRequest != null)
                {
                    xml += "\r\n<recurringRequest>" + recurringRequest.Serialize() + "\r\n</recurringRequest>";
                }
                if (_debtRepaymentSet)
                    xml += "\r\n<debtRepayment>" + debtRepayment.ToString().ToLower() + "</debtRepayment>";
                if (advancedFraudChecks != null)
                {
                    xml += "\r\n<advancedFraudChecks>" + advancedFraudChecks.Serialize() + "\r\n</advancedFraudChecks>";
                }
                if (wallet != null)
                {
                    xml += "\r\n<wallet>" + wallet.Serialize() + "\r\n</wallet>";
                }
            }

            xml += "\r\n</authorization>";
            return xml;
        }
    }

    public class sale : transactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private bool _litleTxnIdSet;

        public long litleTxnId
        {
            get { return _litleTxnIdField; }
            set
            {
                _litleTxnIdField = value;
                _litleTxnIdSet = true;
            }
        }

        public string orderId;
        public long amount;

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long secondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long surchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public orderSourceType orderSource;
        public customerInfo customerInfo;
        public contact billToAddress;
        public contact shipToAddress;
        public cardType card;
        public mposType mpos;
        public payPal paypal;
        public cardTokenType token;
        public cardPaypageType paypage;
        public applepayType applepay;
        public billMeLaterRequest billMeLaterRequest;
        public fraudCheckType cardholderAuthentication;
        public customBilling customBilling;

        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum taxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public enhancedData enhancedData;
        public processingInstructions processingInstructions;
        public pos pos;

        private bool _payPalOrderCompleteField;
        private bool _payPalOrderCompleteSet;

        public bool payPalOrderComplete
        {
            get { return _payPalOrderCompleteField; }
            set
            {
                _payPalOrderCompleteField = value;
                _payPalOrderCompleteSet = true;
            }
        }

        public string payPalNotes;
        public amexAggregatorData amexAggregatorData;

        private bool _allowPartialAuthField;
        private bool _allowPartialAuthSet;

        public bool allowPartialAuth
        {
            get { return _allowPartialAuthField; }
            set
            {
                _allowPartialAuthField = value;
                _allowPartialAuthSet = true;
            }
        }

        public healthcareIIAS healthcareIIAS;
        public filteringType filtering;
        public merchantDataType merchantData;
        public recyclingRequestType recyclingRequest;

        private bool _fraudFilterOverrideField;
        private bool _fraudFilterOverrideSet;

        public bool fraudFilterOverride
        {
            get { return _fraudFilterOverrideField; }
            set
            {
                _fraudFilterOverrideField = value;
                _fraudFilterOverrideSet = true;
            }
        }

        public recurringRequest recurringRequest;
        public litleInternalRecurringRequest litleInternalRecurringRequest;

        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool debtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public advancedFraudChecksType advancedFraudChecks;
        public wallet wallet;

        public override string Serialize()
        {
            var xml = "\r\n<sale";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (_litleTxnIdSet) xml += "\r\n<litleTxnId>" + _litleTxnIdField + "</litleTxnId>";
            xml += "\r\n<orderId>" + orderId + "</orderId>";
            xml += "\r\n<amount>" + amount + "</amount>";
            if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            if (customerInfo != null)
            {
                xml += "\r\n<customerInfo>" + customerInfo.Serialize() + "\r\n</customerInfo>";
            }
            if (billToAddress != null)
            {
                xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "\r\n</billToAddress>";
            }
            if (shipToAddress != null)
            {
                xml += "\r\n<shipToAddress>" + shipToAddress.Serialize() + "\r\n</shipToAddress>";
            }
            if (card != null)
            {
                xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            }
            else if (paypal != null)
            {
                xml += "\r\n<paypal>" + paypal.Serialize() + "\r\n</paypal>";
            }
            else if (token != null)
            {
                xml += "\r\n<token>" + token.Serialize() + "\r\n</token>";
            }
            else if (mpos != null)
            {
                xml += "\r\n<mpos>" + mpos.Serialize() + "</mpos>";
            }
            else if (paypage != null)
            {
                xml += "\r\n<paypage>" + paypage.Serialize() + "\r\n</paypage>";
            }
            else if (applepay != null)
            {
                xml += "\r\n<applepay>" + applepay.Serialize() + "\r\n</applepay>";
            }
            if (billMeLaterRequest != null)
            {
                xml += "\r\n<billMeLaterRequest>" + billMeLaterRequest.Serialize() + "\r\n</billMeLaterRequest>";
            }
            if (cardholderAuthentication != null)
            {
                xml += "\r\n<cardholderAuthentication>" + cardholderAuthentication.Serialize() +
                       "\r\n</cardholderAuthentication>";
            }
            if (customBilling != null)
            {
                xml += "\r\n<customBilling>" + customBilling.Serialize() + "\r\n</customBilling>";
            }
            if (_taxTypeSet)
            {
                xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
            }
            if (enhancedData != null)
            {
                xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "\r\n</enhancedData>";
            }
            if (processingInstructions != null)
            {
                xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            }
            if (pos != null)
            {
                xml += "\r\n<pos>" + pos.Serialize() + "\r\n</pos>";
            }
            if (_payPalOrderCompleteSet)
                xml += "\r\n<payPalOrderCompleteSet>" + _payPalOrderCompleteField.ToString().ToLower() +
                       "</payPalOrderCompleteSet>";
            if (payPalNotes != null)
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(payPalNotes) + "</payPalNotes>";
            if (amexAggregatorData != null)
            {
                xml += "\r\n<amexAggregatorData>" + amexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
            }
            if (_allowPartialAuthSet)
            {
                xml += "\r\n<allowPartialAuth>" + _allowPartialAuthField.ToString().ToLower() + "</allowPartialAuth>";
            }
            if (healthcareIIAS != null)
            {
                xml += "\r\n<healthcareIIAS>" + healthcareIIAS.Serialize() + "\r\n</healthcareIIAS>";
            }
            if (filtering != null)
            {
                xml += "\r\n<filtering>" + filtering.Serialize() + "\r\n</filtering>";
            }
            if (merchantData != null)
            {
                xml += "\r\n<merchantData>" + merchantData.Serialize() + "\r\n</merchantData>";
            }
            if (recyclingRequest != null)
            {
                xml += "\r\n<recyclingRequest>" + recyclingRequest.Serialize() + "\r\n</recyclingRequest>";
            }
            if (_fraudFilterOverrideSet)
                xml += "\r\n<fraudFilterOverride>" + _fraudFilterOverrideField.ToString().ToLower() +
                       "</fraudFilterOverride>";
            if (recurringRequest != null)
            {
                xml += "\r\n<recurringRequest>" + recurringRequest.Serialize() + "\r\n</recurringRequest>";
            }
            if (litleInternalRecurringRequest != null)
            {
                xml += "\r\n<litleInternalRecurringRequest>" + litleInternalRecurringRequest.Serialize() +
                       "\r\n</litleInternalRecurringRequest>";
            }
            if (_debtRepaymentSet)
                xml += "\r\n<debtRepayment>" + debtRepayment.ToString().ToLower() + "</debtRepayment>";
            if (advancedFraudChecks != null)
                xml += "\r\n<advancedFraudChecks>" + advancedFraudChecks.Serialize() + "\r\n</advancedFraudChecks>";
            if (wallet != null)
            {
                xml += "\r\n<wallet>" + wallet.Serialize() + "\r\n</wallet>";
            }
            xml += "\r\n</sale>";
            return xml;
        }
    }

    public class forceCapture : transactionTypeWithReportGroup
    {
        public string orderId;
        public long amount;

        private bool _secondaryAmountSet;
        private long _secondaryAmountField;

        public long secondaryAmount
        {
            get { return _secondaryAmountField; }
            set
            {
                _secondaryAmountField = value;
                _secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long surchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public orderSourceType orderSource;
        public contact billToAddress;
        public cardType card;
        public mposType mpos;
        public cardTokenType token;
        public cardPaypageType paypage;
        public customBilling customBilling;

        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum taxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public enhancedData enhancedData;
        public processingInstructions processingInstructions;
        public pos pos;
        public amexAggregatorData amexAggregatorData;
        public merchantDataType merchantData;

        private bool _debtRepaymentField;
        private bool _debtRepaymentSet;

        public bool debtRepayment
        {
            get { return _debtRepaymentField; }
            set
            {
                _debtRepaymentField = value;
                _debtRepaymentSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "\r\n<forceCapture";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            xml += "\r\n<amount>" + amount + "</amount>";
            if (_secondaryAmountSet) xml += "\r\n<secondaryAmount>" + _secondaryAmountField + "</secondaryAmount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            if (billToAddress != null)
            {
                xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "\r\n</billToAddress>";
            }
            if (card != null)
            {
                xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            }
            else if (token != null)
            {
                xml += "\r\n<token>" + token.Serialize() + "\r\n</token>";
            }
            else if (mpos != null)
            {
                xml += "\r\n<mpos>" + mpos.Serialize() + "</mpos>";
            }
            else if (paypage != null)
            {
                xml += "\r\n<paypage>" + paypage.Serialize() + "\r\n</paypage>";
            }
            if (customBilling != null)
            {
                xml += "\r\n<customBilling>" + customBilling.Serialize() + "\r\n</customBilling>";
            }
            if (_taxTypeSet)
            {
                xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
            }
            if (enhancedData != null)
            {
                xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "\r\n</enhancedData>";
            }
            if (processingInstructions != null)
            {
                xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            }
            if (pos != null)
            {
                xml += "\r\n<pos>" + pos.Serialize() + "\r\n</pos>";
            }
            if (amexAggregatorData != null)
            {
                xml += "\r\n<amexAggregatorData>" + amexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
            }
            if (merchantData != null)
            {
                xml += "\r\n<merchantData>" + merchantData.Serialize() + "\r\n</merchantData>";
            }
            if (_debtRepaymentSet)
                xml += "\r\n<debtRepayment>" + debtRepayment.ToString().ToLower() + "</debtRepayment>";
            xml += "\r\n</forceCapture>";
            return xml;
        }
    }

    public class captureGivenAuth : transactionTypeWithReportGroup
    {
        public string orderId;
        public authInformation authInformation;
        public long amount;
        private bool secondaryAmountSet;
        private long secondaryAmountField;

        public long secondaryAmount
        {
            get { return secondaryAmountField; }
            set
            {
                secondaryAmountField = value;
                secondaryAmountSet = true;
            }
        }

        private bool _surchargeAmountSet;
        private long _surchargeAmountField;

        public long surchargeAmount
        {
            get { return _surchargeAmountField; }
            set
            {
                _surchargeAmountField = value;
                _surchargeAmountSet = true;
            }
        }

        public orderSourceType orderSource;
        public contact billToAddress;
        public contact shipToAddress;
        public cardType card;
        public mposType mpos;
        public cardTokenType token;
        public cardPaypageType paypage;
        public customBilling customBilling;

        private govtTaxTypeEnum _taxTypeField;
        private bool _taxTypeSet;

        public govtTaxTypeEnum taxType
        {
            get { return _taxTypeField; }
            set
            {
                _taxTypeField = value;
                _taxTypeSet = true;
            }
        }

        public billMeLaterRequest billMeLaterRequest;
        public enhancedData enhancedData;
        public processingInstructions processingInstructions;
        public pos pos;
        public amexAggregatorData amexAggregatorData;
        public merchantDataType merchantData;
        private bool debtRepaymentField;
        private bool debtRepaymentSet;

        public bool debtRepayment
        {
            get { return debtRepaymentField; }
            set
            {
                debtRepaymentField = value;
                debtRepaymentSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "\r\n<captureGivenAuth";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            if (authInformation != null)
                xml += "\r\n<authInformation>" + authInformation.Serialize() + "\r\n</authInformation>";
            xml += "\r\n<amount>" + amount + "</amount>";
            if (secondaryAmountSet) xml += "\r\n<secondaryAmount>" + secondaryAmountField + "</secondaryAmount>";
            if (_surchargeAmountSet) xml += "\r\n<surchargeAmount>" + _surchargeAmountField + "</surchargeAmount>";
            if (orderSource != null) xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            if (billToAddress != null)
            {
                xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "\r\n</billToAddress>";
            }
            if (shipToAddress != null)
            {
                xml += "\r\n<shipToAddress>" + shipToAddress.Serialize() + "\r\n</shipToAddress>";
            }
            if (card != null)
            {
                xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            }
            else if (token != null)
            {
                xml += "\r\n<token>" + token.Serialize() + "\r\n</token>";
            }
            else if (mpos != null)
            {
                xml += "\r\n<mpos>" + mpos.Serialize() + "</mpos>";
            }
            else if (paypage != null)
            {
                xml += "\r\n<paypage>" + paypage.Serialize() + "\r\n</paypage>";
            }
            if (customBilling != null)
            {
                xml += "\r\n<customBilling>" + customBilling.Serialize() + "\r\n</customBilling>";
            }
            if (_taxTypeSet)
            {
                xml += "\r\n<taxType>" + _taxTypeField + "</taxType>";
            }
            if (billMeLaterRequest != null)
            {
                xml += "\r\n<billMeLaterRequest>" + billMeLaterRequest.Serialize() + "\r\n</billMeLaterRequest>";
            }
            if (enhancedData != null)
            {
                xml += "\r\n<enhancedData>" + enhancedData.Serialize() + "\r\n</enhancedData>";
            }
            if (processingInstructions != null)
            {
                xml += "\r\n<processingInstructions>" + processingInstructions.Serialize() +
                       "\r\n</processingInstructions>";
            }
            if (pos != null)
            {
                xml += "\r\n<pos>" + pos.Serialize() + "\r\n</pos>";
            }
            if (amexAggregatorData != null)
            {
                xml += "\r\n<amexAggregatorData>" + amexAggregatorData.Serialize() + "\r\n</amexAggregatorData>";
            }
            if (merchantData != null)
            {
                xml += "\r\n<merchantData>" + merchantData.Serialize() + "\r\n</merchantData>";
            }
            if (debtRepaymentSet)
                xml += "\r\n<debtRepayment>" + debtRepayment.ToString().ToLower() + "</debtRepayment>";
            xml += "\r\n</captureGivenAuth>";
            return xml;
        }
    }

    public class cancelSubscription : recurringTransactionType
    {
        private long subscriptionIdField;
        private bool subscriptionIdSet;

        public long subscriptionId
        {
            get { return subscriptionIdField; }
            set
            {
                subscriptionIdField = value;
                subscriptionIdSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "\r\n<cancelSubscription>";
            if (subscriptionIdSet) xml += "\r\n<subscriptionId>" + subscriptionIdField + "</subscriptionId>";
            xml += "\r\n</cancelSubscription>";
            return xml;
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum intervalType
    {
        ANNUAL,
        SEMIANNUAL,
        QUARTERLY,
        MONTHLY,
        WEEKLY
    }

    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum trialIntervalType
    {
        MONTH,
        DAY
    }

    public class createPlan : recurringTransactionType
    {
        public string planCode;
        public string name;

        private string descriptionField;
        private bool descriptionSet;

        public string description
        {
            get { return descriptionField; }
            set
            {
                descriptionField = value;
                descriptionSet = true;
            }
        }

        public intervalType intervalType;
        public long amount;

        public int numberOfPaymentsField;
        public bool numberOfPaymentsSet;

        public int numberOfPayments
        {
            get { return numberOfPaymentsField; }
            set
            {
                numberOfPaymentsField = value;
                numberOfPaymentsSet = true;
            }
        }

        public int trialNumberOfIntervalsField;
        public bool trialNumberOfIntervalsSet;

        public int trialNumberOfIntervals
        {
            get { return trialNumberOfIntervalsField; }
            set
            {
                trialNumberOfIntervalsField = value;
                trialNumberOfIntervalsSet = true;
            }
        }

        private trialIntervalType trialIntervalTypeField;
        private bool trialIntervalTypeSet;

        public trialIntervalType trialIntervalType
        {
            get { return trialIntervalTypeField; }
            set
            {
                trialIntervalTypeField = value;
                trialIntervalTypeSet = true;
            }
        }

        private bool activeField;
        private bool activeSet;

        public bool active
        {
            get { return activeField; }
            set
            {
                activeField = value;
                activeSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "\r\n<createPlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(planCode) + "</planCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(name) + "</name>";
            if (descriptionSet)
                xml += "\r\n<description>" + SecurityElement.Escape(descriptionField) + "</description>";
            xml += "\r\n<intervalType>" + intervalType + "</intervalType>";
            xml += "\r\n<amount>" + amount + "</amount>";
            if (numberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + numberOfPaymentsField + "</numberOfPayments>";
            if (trialNumberOfIntervalsSet)
                xml += "\r\n<trialNumberOfIntervals>" + trialNumberOfIntervalsField + "</trialNumberOfIntervals>";
            if (trialIntervalTypeSet)
                xml += "\r\n<trialIntervalType>" + trialIntervalTypeField + "</trialIntervalType>";
            if (activeSet) xml += "\r\n<active>" + activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</createPlan>";
            return xml;
        }
    }

    public class updatePlan : recurringTransactionType
    {
        public string planCode;

        private bool activeField;
        private bool activeSet;

        public bool active
        {
            get { return activeField; }
            set
            {
                activeField = value;
                activeSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "\r\n<updatePlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(planCode) + "</planCode>";
            if (activeSet) xml += "\r\n<active>" + activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</updatePlan>";
            return xml;
        }
    }

    public class updateSubscription : recurringTransactionType
    {
        private long subscriptionIdField;
        private bool subscriptionIdSet;

        public long subscriptionId
        {
            get { return subscriptionIdField; }
            set
            {
                subscriptionIdField = value;
                subscriptionIdSet = true;
            }
        }

        public string planCode;
        public contact billToAddress;
        public cardType card;
        public cardTokenType token;
        public cardPaypageType paypage;
        private DateTime billingDateField;
        private bool billingDateSet;

        public DateTime billingDate
        {
            get { return billingDateField; }
            set
            {
                billingDateField = value;
                billingDateSet = true;
            }
        }

        public List<createDiscount> createDiscounts;
        public List<updateDiscount> updateDiscounts;
        public List<deleteDiscount> deleteDiscounts;
        public List<createAddOn> createAddOns;
        public List<updateAddOn> updateAddOns;
        public List<deleteAddOn> deleteAddOns;

        public updateSubscription()
        {
            createDiscounts = new List<createDiscount>();
            updateDiscounts = new List<updateDiscount>();
            deleteDiscounts = new List<deleteDiscount>();
            createAddOns = new List<createAddOn>();
            updateAddOns = new List<updateAddOn>();
            deleteAddOns = new List<deleteAddOn>();
        }

        public override string Serialize()
        {
            var xml = "\r\n<updateSubscription>";
            if (subscriptionIdSet) xml += "\r\n<subscriptionId>" + subscriptionIdField + "</subscriptionId>";
            if (planCode != null) xml += "\r\n<planCode>" + SecurityElement.Escape(planCode) + "</planCode>";
            if (billToAddress != null)
                xml += "\r\n<billToAddress>" + billToAddress.Serialize() + "\r\n</billToAddress>";
            if (card != null) xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            else if (token != null) xml += "\r\n<token>" + token.Serialize() + "\r\n</token>";
            else if (paypage != null) xml += "\r\n<paypage>" + paypage.Serialize() + "\r\n</paypage>";
            if (billingDateSet) xml += "\r\n<billingDate>" + XmlUtil.toXsdDate(billingDateField) + "</billingDate>";
            foreach (var createDiscount in createDiscounts)
            {
                xml += "\r\n<createDiscount>" + createDiscount.Serialize() + "\r\n</createDiscount>";
            }
            foreach (var updateDiscount in updateDiscounts)
            {
                xml += "\r\n<updateDiscount>" + updateDiscount.Serialize() + "\r\n</updateDiscount>";
            }
            foreach (var deleteDiscount in deleteDiscounts)
            {
                xml += "\r\n<deleteDiscount>" + deleteDiscount.Serialize() + "\r\n</deleteDiscount>";
            }
            foreach (var createAddOn in createAddOns)
            {
                xml += "\r\n<createAddOn>" + createAddOn.Serialize() + "\r\n</createAddOn>";
            }
            foreach (var updateAddOn in updateAddOns)
            {
                xml += "\r\n<updateAddOn>" + updateAddOn.Serialize() + "\r\n</updateAddOn>";
            }
            foreach (var deleteAddOn in deleteAddOns)
            {
                xml += "\r\n<deleteAddOn>" + deleteAddOn.Serialize() + "\r\n</deleteAddOn>";
            }
            xml += "\r\n</updateSubscription>";
            return xml;
        }
    }

    public partial class fraudResult
    {
        public string Serialize()
        {
            var xml = "";
            if (avsResult != null) xml += "\r\n<avsResult>" + SecurityElement.Escape(avsResult) + "</avsResult>";
            if (cardValidationResult != null)
                xml += "\r\n<cardValidationResult>" + SecurityElement.Escape(cardValidationResult) +
                       "</cardValidationResult>";
            if (authenticationResult != null)
                xml += "\r\n<authenticationResult>" + SecurityElement.Escape(authenticationResult) +
                       "</authenticationResult>";
            if (advancedAVSResult != null)
                xml += "\r\n<advancedAVSResult>" + SecurityElement.Escape(advancedAVSResult) + "</advancedAVSResult>";
            return xml;
        }
    }

    public class authInformation
    {
        public DateTime authDate;
        public string authCode;
        public fraudResult fraudResult;
        private long authAmountField;
        private bool authAmountSet;

        public long authAmount
        {
            get { return authAmountField; }
            set
            {
                authAmountField = value;
                authAmountSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (authDate != null) xml += "\r\n<authDate>" + XmlUtil.toXsdDate(authDate) + "</authDate>";
            if (authCode != null) xml += "\r\n<authCode>" + SecurityElement.Escape(authCode) + "</authCode>";
            if (fraudResult != null) xml += "\r\n<fraudResult>" + fraudResult.Serialize() + "</fraudResult>";
            if (authAmountSet) xml += "\r\n<authAmount>" + authAmountField + "</authAmount>";
            return xml;
        }
    }

    public class XmlUtil
    {
        public static string toXsdDate(DateTime dateTime)
        {
            var year = dateTime.Year.ToString();
            var month = dateTime.Month.ToString();
            if (dateTime.Month < 10)
            {
                month = "0" + month;
            }
            var day = dateTime.Day.ToString();
            if (dateTime.Day < 10)
            {
                day = "0" + day;
            }
            return year + "-" + month + "-" + day;
        }
    }

    public class recyclingRequestType
    {
        private recycleByTypeEnum recycleByField;
        private bool recycleBySet;

        public recycleByTypeEnum recycleBy
        {
            get { return recycleByField; }
            set
            {
                recycleByField = value;
                recycleBySet = true;
            }
        }

        public string recycleId;

        public string Serialize()
        {
            var xml = "";
            if (recycleBySet) xml += "\r\n<recycleBy>" + recycleByField + "</recycleBy>";
            if (recycleId != null) xml += "\r\n<recycleId>" + SecurityElement.Escape(recycleId) + "</recycleId>";
            return xml;
        }
    }

    public class litleInternalRecurringRequest
    {
        public string subscriptionId;
        public string recurringTxnId;

        private bool finalPaymentField;
        private bool finalPaymentSet;

        public bool finalPayment
        {
            get { return finalPaymentField; }
            set
            {
                finalPaymentField = value;
                finalPaymentSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (subscriptionId != null)
                xml += "\r\n<subscriptionId>" + SecurityElement.Escape(subscriptionId) + "</subscriptionId>";
            if (recurringTxnId != null)
                xml += "\r\n<recurringTxnId>" + SecurityElement.Escape(recurringTxnId) + "</recurringTxnId>";
            if (finalPaymentSet)
                xml += "\r\n<finalPayment>" + finalPaymentField.ToString().ToLower() + "</finalPayment>";
            return xml;
        }
    }

    public class createDiscount
    {
        public string discountCode;
        public string name;
        public long amount;
        public DateTime startDate;
        public DateTime endDate;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(discountCode) + "</discountCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(name) + "</name>";
            xml += "\r\n<amount>" + amount + "</amount>";
            xml += "\r\n<startDate>" + XmlUtil.toXsdDate(startDate) + "</startDate>";
            xml += "\r\n<endDate>" + XmlUtil.toXsdDate(endDate) + "</endDate>";
            return xml;
        }
    }

    public class updateDiscount
    {
        public string discountCode;

        private string nameField;
        private bool nameSet;

        public string name
        {
            get { return nameField; }
            set
            {
                nameField = value;
                nameSet = true;
            }
        }

        private long amountField;
        private bool amountSet;

        public long amount
        {
            get { return amountField; }
            set
            {
                amountField = value;
                amountSet = true;
            }
        }

        private DateTime startDateField;
        private bool startDateSet;

        public DateTime startDate
        {
            get { return startDateField; }
            set
            {
                startDateField = value;
                startDateSet = true;
            }
        }

        private DateTime endDateField;
        private bool endDateSet;

        public DateTime endDate
        {
            get { return endDateField; }
            set
            {
                endDateField = value;
                endDateSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(discountCode) + "</discountCode>";
            if (nameSet) xml += "\r\n<name>" + SecurityElement.Escape(nameField) + "</name>";
            if (amountSet) xml += "\r\n<amount>" + amountField + "</amount>";
            if (startDateSet) xml += "\r\n<startDate>" + XmlUtil.toXsdDate(startDateField) + "</startDate>";
            if (endDateSet) xml += "\r\n<endDate>" + XmlUtil.toXsdDate(endDateField) + "</endDate>";
            return xml;
        }
    }

    public class deleteDiscount
    {
        public string discountCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(discountCode) + "</discountCode>";
            return xml;
        }
    }

    public class createAddOn
    {
        public string addOnCode;
        public string name;
        public long amount;
        public DateTime startDate;
        public DateTime endDate;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(addOnCode) + "</addOnCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(name) + "</name>";
            xml += "\r\n<amount>" + amount + "</amount>";
            xml += "\r\n<startDate>" + XmlUtil.toXsdDate(startDate) + "</startDate>";
            xml += "\r\n<endDate>" + XmlUtil.toXsdDate(endDate) + "</endDate>";
            return xml;
        }
    }

    public class updateAddOn
    {
        public string addOnCode;

        private string nameField;
        private bool nameSet;

        public string name
        {
            get { return nameField; }
            set
            {
                nameField = value;
                nameSet = true;
            }
        }

        private long amountField;
        private bool amountSet;

        public long amount
        {
            get { return amountField; }
            set
            {
                amountField = value;
                amountSet = true;
            }
        }

        private DateTime startDateField;
        private bool startDateSet;

        public DateTime startDate
        {
            get { return startDateField; }
            set
            {
                startDateField = value;
                startDateSet = true;
            }
        }

        private DateTime endDateField;
        private bool endDateSet;

        public DateTime endDate
        {
            get { return endDateField; }
            set
            {
                endDateField = value;
                endDateSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(addOnCode) + "</addOnCode>";
            if (nameSet) xml += "\r\n<name>" + SecurityElement.Escape(nameField) + "</name>";
            if (amountSet) xml += "\r\n<amount>" + amountField + "</amount>";
            if (startDateSet) xml += "\r\n<startDate>" + XmlUtil.toXsdDate(startDateField) + "</startDate>";
            if (endDateSet) xml += "\r\n<endDate>" + XmlUtil.toXsdDate(endDateField) + "</endDate>";
            return xml;
        }
    }

    public class deleteAddOn
    {
        public string addOnCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(addOnCode) + "</addOnCode>";
            return xml;
        }
    }


    public class subscription
    {
        public string planCode;
        private bool numberOfPaymentsSet;
        private int numberOfPaymentsField;

        public int numberOfPayments
        {
            get { return numberOfPaymentsField; }
            set
            {
                numberOfPaymentsField = value;
                numberOfPaymentsSet = true;
            }
        }

        private bool startDateSet;
        private DateTime startDateField;

        public DateTime startDate
        {
            get { return startDateField; }
            set
            {
                startDateField = value;
                startDateSet = true;
            }
        }

        private bool amountSet;
        private long amountField;

        public long amount
        {
            get { return amountField; }
            set
            {
                amountField = value;
                amountSet = true;
            }
        }

        public List<createDiscount> createDiscounts;
        public List<createAddOn> createAddOns;

        public subscription()
        {
            createDiscounts = new List<createDiscount>();
            createAddOns = new List<createAddOn>();
        }


        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<planCode>" + planCode + "</planCode>";
            if (numberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + numberOfPayments + "</numberOfPayments>";
            if (startDateSet) xml += "\r\n<startDate>" + XmlUtil.toXsdDate(startDateField) + "</startDate>";
            if (amountSet) xml += "\r\n<amount>" + amountField + "</amount>";
            foreach (var createDiscount in createDiscounts)
            {
                xml += "\r\n<createDiscount>" + createDiscount.Serialize() + "\r\n</createDiscount>";
            }
            foreach (var createAddOn in createAddOns)
            {
                xml += "\r\n<createAddOn>" + createAddOn.Serialize() + "\r\n</createAddOn>";
            }

            return xml;
        }
    }


    public class filteringType
    {
        private bool prepaidField;
        private bool prepaidSet;

        public bool prepaid
        {
            get { return prepaidField; }
            set
            {
                prepaidField = value;
                prepaidSet = true;
            }
        }

        private bool internationalField;
        private bool internationalSet;

        public bool international
        {
            get { return internationalField; }
            set
            {
                internationalField = value;
                internationalSet = true;
            }
        }

        private bool chargebackField;
        private bool chargebackSet;

        public bool chargeback
        {
            get { return chargebackField; }
            set
            {
                chargebackField = value;
                chargebackSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (prepaidSet) xml += "\r\n<prepaid>" + prepaidField.ToString().ToLower() + "</prepaid>";
            if (internationalSet)
                xml += "\r\n<international>" + internationalField.ToString().ToLower() + "</international>";
            if (chargebackSet) xml += "\r\n<chargeback>" + chargebackField.ToString().ToLower() + "</chargeback>";
            return xml;
        }
    }

    public class healthcareIIAS
    {
        public healthcareAmounts healthcareAmounts;
        private IIASFlagType IIASFlagField;
        private bool IIASFlagSet;

        public IIASFlagType IIASFlag
        {
            get { return IIASFlagField; }
            set
            {
                IIASFlagField = value;
                IIASFlagSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (healthcareAmounts != null)
                xml += "\r\n<healthcareAmounts>" + healthcareAmounts.Serialize() + "</healthcareAmounts>";
            if (IIASFlagSet) xml += "\r\n<IIASFlag>" + IIASFlagField + "</IIASFlag>";
            return xml;
        }
    }

    public class recurringRequest
    {
        public subscription subscription;

        public string Serialize()
        {
            var xml = "";
            if (subscription != null) xml += "\r\n<subscription>" + subscription.Serialize() + "\r\n</subscription>";
            return xml;
        }
    }


    public class healthcareAmounts
    {
        private int totalHealthcareAmountField;
        private bool totalHealthcareAmountSet;

        public int totalHealthcareAmount
        {
            get { return totalHealthcareAmountField; }
            set
            {
                totalHealthcareAmountField = value;
                totalHealthcareAmountSet = true;
            }
        }

        private int RxAmountField;
        private bool RxAmountSet;

        public int RxAmount
        {
            get { return RxAmountField; }
            set
            {
                RxAmountField = value;
                RxAmountSet = true;
            }
        }

        private int visionAmountField;
        private bool visionAmountSet;

        public int visionAmount
        {
            get { return visionAmountField; }
            set
            {
                visionAmountField = value;
                visionAmountSet = true;
            }
        }

        private int clinicOtherAmountField;
        private bool clinicOtherAmountSet;

        public int clinicOtherAmount
        {
            get { return clinicOtherAmountField; }
            set
            {
                clinicOtherAmountField = value;
                clinicOtherAmountSet = true;
            }
        }

        private int dentalAmountField;
        private bool dentalAmountSet;

        public int dentalAmount
        {
            get { return dentalAmountField; }
            set
            {
                dentalAmountField = value;
                dentalAmountSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (totalHealthcareAmountSet)
                xml += "\r\n<totalHealthcareAmount>" + totalHealthcareAmountField + "</totalHealthcareAmount>";
            if (RxAmountSet) xml += "\r\n<RxAmount>" + RxAmountField + "</RxAmount>";
            if (visionAmountSet) xml += "\r\n<visionAmount>" + visionAmountField + "</visionAmount>";
            if (clinicOtherAmountSet)
                xml += "\r\n<clinicOtherAmount>" + clinicOtherAmountField + "</clinicOtherAmount>";
            if (dentalAmountSet) xml += "\r\n<dentalAmount>" + dentalAmountField + "</dentalAmount>";
            return xml;
        }
    }

    public sealed class orderSourceType
    {
        public static readonly orderSourceType ecommerce = new orderSourceType("ecommerce");
        public static readonly orderSourceType installment = new orderSourceType("installment");
        public static readonly orderSourceType mailorder = new orderSourceType("mailorder");
        public static readonly orderSourceType recurring = new orderSourceType("recurring");
        public static readonly orderSourceType retail = new orderSourceType("retail");
        public static readonly orderSourceType telephone = new orderSourceType("telephone");
        public static readonly orderSourceType item3dsAuthenticated = new orderSourceType("3dsAuthenticated");
        public static readonly orderSourceType item3dsAttempted = new orderSourceType("3dsAttempted");
        public static readonly orderSourceType recurringtel = new orderSourceType("recurringtel");
        public static readonly orderSourceType echeckppd = new orderSourceType("echeckppd");
        public static readonly orderSourceType applepay = new orderSourceType("applepay");

        private orderSourceType(string value)
        {
            this.value = value;
        }

        public string Serialize()
        {
            return value;
        }

        private readonly string value;
    }

    public class contact
    {
        public string name;
        public string firstName;
        public string middleInitial;
        public string lastName;
        public string companyName;
        public string addressLine1;
        public string addressLine2;
        public string addressLine3;
        public string city;
        public string state;
        public string zip;
        private countryTypeEnum countryField;
        private bool countrySpecified;

        public countryTypeEnum country
        {
            get { return countryField; }
            set
            {
                countryField = value;
                countrySpecified = true;
            }
        }

        public string email;
        public string phone;

        public string Serialize()
        {
            var xml = "";
            if (name != null) xml += "\r\n<name>" + SecurityElement.Escape(name) + "</name>";
            if (firstName != null) xml += "\r\n<firstName>" + SecurityElement.Escape(firstName) + "</firstName>";
            if (middleInitial != null)
                xml += "\r\n<middleInitial>" + SecurityElement.Escape(middleInitial) + "</middleInitial>";
            if (lastName != null) xml += "\r\n<lastName>" + SecurityElement.Escape(lastName) + "</lastName>";
            if (companyName != null)
                xml += "\r\n<companyName>" + SecurityElement.Escape(companyName) + "</companyName>";
            if (addressLine1 != null)
                xml += "\r\n<addressLine1>" + SecurityElement.Escape(addressLine1) + "</addressLine1>";
            if (addressLine2 != null)
                xml += "\r\n<addressLine2>" + SecurityElement.Escape(addressLine2) + "</addressLine2>";
            if (addressLine3 != null)
                xml += "\r\n<addressLine3>" + SecurityElement.Escape(addressLine3) + "</addressLine3>";
            if (city != null) xml += "\r\n<city>" + SecurityElement.Escape(city) + "</city>";
            if (state != null) xml += "\r\n<state>" + SecurityElement.Escape(state) + "</state>";
            if (zip != null) xml += "\r\n<zip>" + SecurityElement.Escape(zip) + "</zip>";
            if (countrySpecified) xml += "\r\n<country>" + countryField + "</country>";
            if (email != null) xml += "\r\n<email>" + SecurityElement.Escape(email) + "</email>";
            if (phone != null) xml += "\r\n<phone>" + SecurityElement.Escape(phone) + "</phone>";
            return xml;
        }
    }

    public enum countryTypeEnum
    {
        /// <remarks />
        USA,
        AF,
        AX,
        AL,
        DZ,
        AS,
        AD,
        AO,
        AI,
        AQ,
        AG,
        AR,
        AM,
        AW,
        AU,
        AT,
        AZ,
        BS,
        BH,
        BD,
        BB,
        BY,
        BE,
        BZ,
        BJ,
        BM,
        BT,
        BO,
        BQ,
        BA,
        BW,
        BV,
        BR,
        IO,
        BN,
        BG,
        BF,
        BI,
        KH,
        CM,
        CA,
        CV,
        KY,
        CF,
        TD,
        CL,
        CN,
        CX,
        CC,
        CO,
        KM,
        CG,
        CD,
        CK,
        CR,
        CI,
        HR,
        CU,
        CW,
        CY,
        CZ,
        DK,
        DJ,
        DM,
        DO,
        TL,
        EC,
        EG,
        SV,
        GQ,
        ER,
        EE,
        ET,
        FK,
        FO,
        FJ,
        FI,
        FR,
        GF,
        PF,
        TF,
        GA,
        GM,
        GE,
        DE,
        GH,
        GI,
        GR,
        GL,
        GD,
        GP,
        GU,
        GT,
        GG,
        GN,
        GW,
        GY,
        HT,
        HM,
        HN,
        HK,
        HU,
        IS,
        IN,
        ID,
        IR,
        IQ,
        IE,
        IM,
        IL,
        IT,
        JM,
        JP,
        JE,
        JO,
        KZ,
        KE,
        KI,
        KP,
        KR,
        KW,
        KG,
        LA,
        LV,
        LB,
        LS,
        LR,
        LY,
        LI,
        LT,
        LU,
        MO,
        MK,
        MG,
        MW,
        MY,
        MV,
        ML,
        MT,
        MH,
        MQ,
        MR,
        MU,
        YT,
        MX,
        FM,
        MD,
        MC,
        MN,
        MS,
        MA,
        MZ,
        MM,
        NA,
        NR,
        NP,
        NL,
        AN,
        NC,
        NZ,
        NI,
        NE,
        NG,
        NU,
        NF,
        MP,
        NO,
        OM,
        PK,
        PW,
        PS,
        PA,
        PG,
        PY,
        PE,
        PH,
        PN,
        PL,
        PT,
        PR,
        QA,
        RE,
        RO,
        RU,
        RW,
        BL,
        KN,
        LC,
        MF,
        VC,
        WS,
        SM,
        ST,
        SA,
        SN,
        SC,
        SL,
        SG,
        SX,
        SK,
        SI,
        SB,
        SO,
        ZA,
        GS,
        ES,
        LK,
        SH,
        PM,
        SD,
        SR,
        SJ,
        SZ,
        SE,
        CH,
        SY,
        TW,
        TJ,
        TZ,
        TH,
        TG,
        TK,
        TO,
        TT,
        TN,
        TR,
        TM,
        TC,
        TV,
        UG,
        UA,
        AE,
        GB,
        US,
        UM,
        UY,
        UZ,
        VU,
        VA,
        VE,
        VN,
        VG,
        VI,
        WF,
        EH,
        YE,
        ZM,
        ZW,
        RS,
        ME
    }

    public class fraudCheckType
    {
        public string authenticationValue;
        public string authenticationTransactionId;
        public string customerIpAddress;
        private bool authenticatedByMerchantField;
        private bool authenticatedByMerchantSet;

        public bool authenticatedByMerchant
        {
            get { return authenticatedByMerchantField; }
            set
            {
                authenticatedByMerchantField = value;
                authenticatedByMerchantSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (authenticationValue != null)
                xml += "\r\n<authenticationValue>" + SecurityElement.Escape(authenticationValue) +
                       "</authenticationValue>";
            if (authenticationTransactionId != null)
                xml += "\r\n<authenticationTransactionId>" + SecurityElement.Escape(authenticationTransactionId) +
                       "</authenticationTransactionId>";
            if (customerIpAddress != null)
                xml += "\r\n<customerIpAddress>" + SecurityElement.Escape(customerIpAddress) + "</customerIpAddress>";
            if (authenticatedByMerchantSet)
                xml += "\r\n<authenticatedByMerchant>" + authenticatedByMerchantField + "</authenticatedByMerchant>";
            return xml;
        }
    }

    public class advancedFraudChecksType
    {
        public string threatMetrixSessionId;
        private string customAttribute1Field;
        private bool customAttribute1Set;

        public string customAttribute1
        {
            get { return customAttribute1Field; }
            set
            {
                customAttribute1Field = value;
                customAttribute1Set = true;
            }
        }

        private string customAttribute2Field;
        private bool customAttribute2Set;

        public string customAttribute2
        {
            get { return customAttribute2Field; }
            set
            {
                customAttribute2Field = value;
                customAttribute2Set = true;
            }
        }

        private string customAttribute3Field;
        private bool customAttribute3Set;

        public string customAttribute3
        {
            get { return customAttribute3Field; }
            set
            {
                customAttribute3Field = value;
                customAttribute3Set = true;
            }
        }

        private string customAttribute4Field;
        private bool customAttribute4Set;

        public string customAttribute4
        {
            get { return customAttribute4Field; }
            set
            {
                customAttribute4Field = value;
                customAttribute4Set = true;
            }
        }

        private string customAttribute5Field;
        private bool customAttribute5Set;

        public string customAttribute5
        {
            get { return customAttribute5Field; }
            set
            {
                customAttribute5Field = value;
                customAttribute5Set = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (threatMetrixSessionId != null)
                xml += "\r\n<threatMetrixSessionId>" + SecurityElement.Escape(threatMetrixSessionId) +
                       "</threatMetrixSessionId>";
            if (customAttribute1Set)
                xml += "\r\n<customAttribute1>" + SecurityElement.Escape(customAttribute1Field) + "</customAttribute1>";
            if (customAttribute2Set)
                xml += "\r\n<customAttribute2>" + SecurityElement.Escape(customAttribute2Field) + "</customAttribute2>";
            if (customAttribute3Set)
                xml += "\r\n<customAttribute3>" + SecurityElement.Escape(customAttribute3Field) + "</customAttribute3>";
            if (customAttribute4Set)
                xml += "\r\n<customAttribute4>" + SecurityElement.Escape(customAttribute4Field) + "</customAttribute4>";
            if (customAttribute5Set)
                xml += "\r\n<customAttribute5>" + SecurityElement.Escape(customAttribute5Field) + "</customAttribute5>";
            return xml;
        }
    }

    public class mposType
    {
        public string ksn;
        public string formatId;
        public string encryptedTrack;
        public int track1Status;
        public int track2Status;

        public string Serialize()
        {
            var xml = "";
            if (ksn != null)
            {
                xml += "\r\n<ksn>" + ksn + "</ksn>";
            }
            if (formatId != null)
            {
                xml += "\r\n<formatId>" + formatId + "</formatId>";
            }
            if (encryptedTrack != null)
            {
                xml += "\r\n<encryptedTrack>" + SecurityElement.Escape(encryptedTrack) + "</encryptedTrack>";
            }
            if (track1Status == 0 || track1Status == 1)
            {
                xml += "\r\n<track1Status>" + track1Status + "</track1Status>";
            }
            if (track2Status == 0 || track2Status == 1)
            {
                xml += "\r\n<track2Status>" + track2Status + "</track2Status>";
            }

            return xml;
        }
    }

    public class cardType
    {
        public methodOfPaymentTypeEnum type;
        public string number;
        public string expDate;
        public string track;
        public string cardValidationNum;

        public string Serialize()
        {
            var xml = "";
            if (track == null)
            {
                xml += "\r\n<type>" + methodOfPaymentSerializer.Serialize(type) + "</type>";
                if (number != null)
                {
                    xml += "\r\n<number>" + SecurityElement.Escape(number) + "</number>";
                }
                if (expDate != null)
                {
                    xml += "\r\n<expDate>" + SecurityElement.Escape(expDate) + "</expDate>";
                }
            }
            else
            {
                xml += "\r\n<track>" + SecurityElement.Escape(track) + "</track>";
            }
            if (cardValidationNum != null)
            {
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(cardValidationNum) + "</cardValidationNum>";
            }
            return xml;
        }
    }

    public class virtualGiftCardType
    {
        public int accountNumberLength
        {
            get { return accountNumberLengthField; }
            set
            {
                accountNumberLengthField = value;
                accountNumberLengthSet = true;
            }
        }

        private int accountNumberLengthField;
        private bool accountNumberLengthSet;

        public string giftCardBin;

        public string Serialize()
        {
            var xml = "";
            if (accountNumberLengthSet)
                xml += "\r\n<accountNumberLength>" + accountNumberLengthField + "</accountNumberLength>";
            if (giftCardBin != null)
                xml += "\r\n<giftCardBin>" + SecurityElement.Escape(giftCardBin) + "</giftCardBin>";
            return xml;
        }
    }

    public class authReversal : transactionTypeWithReportGroup
    {
        public long litleTxnId;
        private long amountField;
        private bool amountSet;

        public long amount
        {
            get { return amountField; }
            set
            {
                amountField = value;
                amountSet = true;
            }
        }

        private bool surchargeAmountSet;
        private long surchargeAmountField;

        public long surchargeAmount
        {
            get { return surchargeAmountField; }
            set
            {
                surchargeAmountField = value;
                surchargeAmountSet = true;
            }
        }

        public string payPalNotes;
        public string actionReason;

        public override string Serialize()
        {
            var xml = "\r\n<authReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + litleTxnId + "</litleTxnId>";
            if (amountSet)
            {
                xml += "\r\n<amount>" + amountField + "</amount>";
            }
            if (surchargeAmountSet) xml += "\r\n<surchargeAmount>" + surchargeAmountField + "</surchargeAmount>";
            if (payPalNotes != null)
            {
                xml += "\r\n<payPalNotes>" + SecurityElement.Escape(payPalNotes) + "</payPalNotes>";
            }
            if (actionReason != null)
            {
                xml += "\r\n<actionReason>" + SecurityElement.Escape(actionReason) + "</actionReason>";
            }
            xml += "\r\n</authReversal>";
            return xml;
        }
    }

    public class echeckVoid : transactionTypeWithReportGroup
    {
        public long litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<echeckVoid";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + litleTxnId + "</litleTxnId>";
            xml += "\r\n</echeckVoid>";
            return xml;
        }
    }

    public class accountUpdate : transactionTypeWithReportGroup
    {
        public string orderId;
        public cardType card;
        public cardTokenType token;

        public override string Serialize()
        {
            var xml = "\r\n<accountUpdate ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";

            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";

            if (card != null)
            {
                xml += "\r\n<card>";
                xml += card.Serialize();
                xml += "\r\n</card>";
            }
            else if (token != null)
            {
                xml += "\r\n<token>";
                xml += token.Serialize();
                xml += "\r\n</token>";
            }

            xml += "\r\n</accountUpdate>";

            return xml;
        }
    }

    public class accountUpdateFileRequestData
    {
        public string merchantId;

        public accountUpdateFileRequestData()
        {
            merchantId = Settings.Default.merchantId;
        }

        public accountUpdateFileRequestData(Dictionary<string, string> config)
        {
            merchantId = config["merchantId"];
        }

        public DateTime postDay; //yyyy-MM-dd

        public string Serialize()
        {
            var xml = "\r\n<merchantId>" + SecurityElement.Escape(merchantId) + "</merchantId>";

            if (postDay != null)
            {
                xml += "\r\n<postDay>" + postDay.ToString("yyyy-MM-dd") + "</postDay>";
            }

            return xml;
        }
    }

    public class activate : transactionTypeWithReportGroup
    {
        public string orderId;
        public long amount;
        public orderSourceType orderSource;
        public cardType card;
        public virtualGiftCardType virtualGiftCard;

        public override string Serialize()
        {
            var xml = "\r\n<activate";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            xml += "\r\n<amount>" + amount + "</amount>";
            xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            if (card != null) xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            else if (virtualGiftCard != null)
                xml += "\r\n<virtualGiftCard>" + virtualGiftCard.Serialize() + "\r\n</virtualGiftCard>";
            xml += "\r\n</activate>";
            return xml;
        }
    }

    public class deactivate : transactionTypeWithReportGroup
    {
        public string orderId;
        public orderSourceType orderSource;
        public cardType card;

        public override string Serialize()
        {
            var xml = "\r\n<deactivate";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            xml += "\r\n</deactivate>";
            return xml;
        }
    }

    public class load : transactionTypeWithReportGroup
    {
        public string orderId;
        public long amount;
        public orderSourceType orderSource;
        public cardType card;

        public override string Serialize()
        {
            var xml = "\r\n<load";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            xml += "\r\n<amount>" + amount + "</amount>";
            xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            xml += "\r\n</load>";
            return xml;
        }
    }

    public class unload : transactionTypeWithReportGroup
    {
        public string orderId;
        public long amount;
        public orderSourceType orderSource;
        public cardType card;

        public override string Serialize()
        {
            var xml = "\r\n<unload";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            xml += "\r\n<amount>" + amount + "</amount>";
            xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            xml += "\r\n</unload>";
            return xml;
        }
    }

    public class balanceInquiry : transactionTypeWithReportGroup
    {
        public string orderId;
        public orderSourceType orderSource;
        public cardType card;

        public override string Serialize()
        {
            var xml = "\r\n<balanceInquiry";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";
            xml += "\r\n<orderSource>" + orderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + card.Serialize() + "\r\n</card>";
            xml += "\r\n</balanceInquiry>";
            return xml;
        }
    }

    public class loadReversal : transactionTypeWithReportGroup
    {
        public string litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<loadReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(litleTxnId) + "</litleTxnId>";
            xml += "\r\n</loadReversal>";
            return xml;
        }
    }

    public class unloadReversal : transactionTypeWithReportGroup
    {
        public string litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<unloadReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(litleTxnId) + "</litleTxnId>";
            xml += "\r\n</unloadReversal>";
            return xml;
        }
    }

    public class deactivateReversal : transactionTypeWithReportGroup
    {
        public string litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<deactivateReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(litleTxnId) + "</litleTxnId>";
            xml += "\r\n</deactivateReversal>";
            return xml;
        }
    }

    public class activateReversal : transactionTypeWithReportGroup
    {
        public string litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<activateReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(litleTxnId) + "</litleTxnId>";
            xml += "\r\n</activateReversal>";
            return xml;
        }
    }

    public class refundReversal : transactionTypeWithReportGroup
    {
        public string litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<refundReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(litleTxnId) + "</litleTxnId>";
            xml += "\r\n</refundReversal>";
            return xml;
        }
    }

    public class depositReversal : transactionTypeWithReportGroup
    {
        public string litleTxnId;

        public override string Serialize()
        {
            var xml = "\r\n<depositReversal";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<litleTxnId>" + SecurityElement.Escape(litleTxnId) + "</litleTxnId>";
            xml += "\r\n</depositReversal>";
            return xml;
        }
    }

    public class applepayType
    {
        public string data;
        public applepayHeaderType header;
        public string signature;
        public string version;

        public string Serialize()
        {
            var xml = "";
            if (data != null) xml += "\r\n<data>" + SecurityElement.Escape(data) + "</data>";
            if (header != null) xml += "\r\n<header>" + header.Serialize() + "</header>";
            if (signature != null) xml += "\r\n<signature>" + SecurityElement.Escape(signature) + "</signature>";
            if (version != null) xml += "\r\n<version>" + SecurityElement.Escape(version) + "</version>";
            return xml;
        }
    }

    public class applepayHeaderType
    {
        public string applicationData;
        public string ephemeralPublicKey;
        public string publicKeyHash;
        public string transactionId;

        public string Serialize()
        {
            var xml = "";
            if (applicationData != null)
                xml += "\r\n<applicationData>" + SecurityElement.Escape(applicationData) + "</applicationData>";
            if (ephemeralPublicKey != null)
                xml += "\r\n<ephemeralPublicKey>" + SecurityElement.Escape(ephemeralPublicKey) + "</ephemeralPublicKey>";
            if (publicKeyHash != null)
                xml += "\r\n<publicKeyHash>" + SecurityElement.Escape(publicKeyHash) + "</publicKeyHash>";
            if (transactionId != null)
                xml += "\r\n<transactionId>" + SecurityElement.Escape(transactionId) + "</transactionId>";
            return xml;
        }
    }

    public class wallet
    {
        public walletWalletSourceType walletSourceType;
        public string walletSourceTypeId;

        public string Serialize()
        {
            var xml = "";
            if (walletSourceType != null) xml += "\r\n<walletSourceType>" + walletSourceType + "</walletSourceType>";
            if (walletSourceTypeId != null)
                xml += "\r\n<walletSourceTypeId>" + SecurityElement.Escape(walletSourceTypeId) + "</walletSourceTypeId>";
            return xml;
        }
    }

    public enum walletWalletSourceType
    {
        MasterPass
    }

    public class fraudCheck : transactionTypeWithReportGroup
    {
        public advancedFraudChecksType advancedFraudChecks;

        private contact billToAddressField;
        private bool billToAddressSet;

        public contact billToAddress
        {
            get { return billToAddressField; }
            set
            {
                billToAddressField = value;
                billToAddressSet = true;
            }
        }

        private contact shipToAddressField;
        private bool shipToAddressSet;

        public contact shipToAddress
        {
            get { return shipToAddressField; }
            set
            {
                shipToAddressField = value;
                shipToAddressSet = true;
            }
        }

        private int amountField;
        private bool amountSet;

        public int amount
        {
            get { return amountField; }
            set
            {
                amountField = value;
                amountSet = true;
            }
        }

        public override string Serialize()
        {
            var xml = "";
            if (advancedFraudChecks != null)
                xml += "\r\n<advancedFraudChecks>" + advancedFraudChecks.Serialize() + "</advancedFraudChecks>";
            if (billToAddressSet) xml += "\r\n<billToAddress>" + billToAddressField.Serialize() + "</billToAddress>";
            if (shipToAddressSet) xml += "\r\n<shipToAddress>" + shipToAddressField.Serialize() + "</shipToAddress>";
            if (amountSet) xml += "\r\n<amount>" + amountField + "</amount>";
            return xml;
        }
    }
}
