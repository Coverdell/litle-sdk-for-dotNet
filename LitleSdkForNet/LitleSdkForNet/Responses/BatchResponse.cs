using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("batchResponse")]
    [LitleXmlRoot("batchResponse")]
    public class BatchResponse
    {
        [XmlElement("id")]
        public string ID { get; set; }
        [XmlElement("litleBatchId")]
        public long LitleBatchId { get; set; }
        [XmlElement("merchantId")]
        public string MerchantId { get; set; }

        private XmlReader _originalXmlReader;
        private XmlReader _accountUpdateResponseReader;
        private XmlReader _authorizationResponseReader;
        private XmlReader _authReversalResponseReader;
        private XmlReader _captureResponseReader;
        private XmlReader _captureGivenAuthResponseReader;
        private XmlReader _creditResponseReader;
        private XmlReader _forceCaptureResponseReader;
        private XmlReader _echeckCreditResponseReader;
        private XmlReader _echeckRedepositResponseReader;
        private XmlReader _echeckSalesResponseReader;
        private XmlReader _echeckVerificationResponseReader;
        private XmlReader _saleResponseReader;
        private XmlReader _registerTokenResponseReader;
        private XmlReader _updateCardValidationNumOnTokenResponseReader;
        private XmlReader _cancelSubscriptionResponseReader;
        private XmlReader _updateSubscriptionResponseReader;
        private XmlReader _createPlanResponseReader;
        private XmlReader _updatePlanResponseReader;
        private XmlReader _activateResponseReader;
        private XmlReader _deactivateResponseReader;
        private XmlReader _loadResponseReader;
        private XmlReader _echeckPreNoteSaleResponseReader;
        private XmlReader _echeckPreNoteCreditResponseReader;
        private XmlReader _unloadResponseReader;
        private XmlReader _balanceInquiryResponseReader;
        private XmlReader _submerchantCreditResponseReader;
        private XmlReader _payFacCreditResponseReader;
        private XmlReader _vendorCreditResponseReader;
        private XmlReader _reserveCreditResponseReader;
        private XmlReader _physicalCheckCreditResponseReader;
        private XmlReader _submerchantDebitResponseReader;
        private XmlReader _payFacDebitResponseReader;
        private XmlReader _vendorDebitResponseReader;
        private XmlReader _reserveDebitResponseReader;
        private XmlReader _physicalCheckDebitResponseReader;

        public BatchResponse()
        {
        }

        public BatchResponse(XmlReader xmlReader, string filePath)
        {
            ReadXml(xmlReader, filePath);
        }

        public void SetAccountUpdateResponseReader(XmlReader xmlReader)
        {
            _accountUpdateResponseReader = xmlReader;
        }

        public void SetAuthorizationResponseReader(XmlReader xmlReader)
        {
            _authorizationResponseReader = xmlReader;
        }

        public void SetAuthReversalResponseReader(XmlReader xmlReader)
        {
            _authReversalResponseReader = xmlReader;
        }

        public void SetCaptureResponseReader(XmlReader xmlReader)
        {
            _captureResponseReader = xmlReader;
        }

        public void SetCaptureGivenAuthResponseReader(XmlReader xmlReader)
        {
            _captureGivenAuthResponseReader = xmlReader;
        }

        public void SetCreditResponseReader(XmlReader xmlReader)
        {
            _creditResponseReader = xmlReader;
        }

        public void SetForceCaptureResponseReader(XmlReader xmlReader)
        {
            _forceCaptureResponseReader = xmlReader;
        }

        public void SetEcheckCreditResponseReader(XmlReader xmlReader)
        {
            _echeckCreditResponseReader = xmlReader;
        }

        public void SetEcheckRedepositResponseReader(XmlReader xmlReader)
        {
            _echeckRedepositResponseReader = xmlReader;
        }

        public void SetEcheckSalesResponseReader(XmlReader xmlReader)
        {
            _echeckSalesResponseReader = xmlReader;
        }

        public void SetEcheckVerificationResponseReader(XmlReader xmlReader)
        {
            _echeckVerificationResponseReader = xmlReader;
        }

        public void SetSaleResponseReader(XmlReader xmlReader)
        {
            _saleResponseReader = xmlReader;
        }

        public void SetRegisterTokenResponseReader(XmlReader xmlReader)
        {
            _registerTokenResponseReader = xmlReader;
        }

        public void SetUpdateCardValidationNumOnTokenResponseReader(XmlReader xmlReader)
        {
            _updateCardValidationNumOnTokenResponseReader = xmlReader;
        }

        public void SetCancelSubscriptionResponseReader(XmlReader xmlReader)
        {
            _cancelSubscriptionResponseReader = xmlReader;
        }

        public void SetUpdateSubscriptionResponseReader(XmlReader xmlReader)
        {
            _updateSubscriptionResponseReader = xmlReader;
        }

        public void SetCreatePlanResponseReader(XmlReader xmlReader)
        {
            _createPlanResponseReader = xmlReader;
        }

        public void SetUpdatePlanResponseReader(XmlReader xmlReader)
        {
            _updatePlanResponseReader = xmlReader;
        }

        public void SetActivateResponseReader(XmlReader xmlReader)
        {
            _activateResponseReader = xmlReader;
        }

        public void SetDeactivateResponseReader(XmlReader xmlReader)
        {
            _deactivateResponseReader = xmlReader;
        }

        public void SetLoadResponseReader(XmlReader xmlReader)
        {
            _loadResponseReader = xmlReader;
        }

        public void SetEcheckPreNoteSaleResponseReader(XmlReader xmlReader)
        {
            _echeckPreNoteSaleResponseReader = xmlReader;
        }

        public void SetEcheckPreNoteCreditResponseReader(XmlReader xmlReader)
        {
            _echeckPreNoteCreditResponseReader = xmlReader;
        }

        public void SetUnloadResponseReader(XmlReader xmlReader)
        {
            _unloadResponseReader = xmlReader;
        }

        public void SetBalanceInquiryResponseReader(XmlReader xmlReader)
        {
            _balanceInquiryResponseReader = xmlReader;
        }

        public void SetSubmerchantCreditResponseReader(XmlReader xmlReader)
        {
            _submerchantCreditResponseReader = xmlReader;
        }

        public void SetPayFacCreditResponseReader(XmlReader xmlReader)
        {
            _payFacCreditResponseReader = xmlReader;
        }

        public void SetReserveCreditResponseReader(XmlReader xmlReader)
        {
            _reserveCreditResponseReader = xmlReader;
        }

        public void SetVendorCreditResponseReader(XmlReader xmlReader)
        {
            _vendorCreditResponseReader = xmlReader;
        }

        public void SetPhysicalCheckCreditResponseReader(XmlReader xmlReader)
        {
            _physicalCheckCreditResponseReader = xmlReader;
        }

        public void SetSubmerchantDebitResponseReader(XmlReader xmlReader)
        {
            _submerchantDebitResponseReader = xmlReader;
        }

        public void SetPayFacDebitResponseReader(XmlReader xmlReader)
        {
            _payFacDebitResponseReader = xmlReader;
        }

        public void SetReserveDebitResponseReader(XmlReader xmlReader)
        {
            _reserveDebitResponseReader = xmlReader;
        }

        public void SetVendorDebitResponseReader(XmlReader xmlReader)
        {
            _vendorDebitResponseReader = xmlReader;
        }

        public void SetPhysicalCheckDebitResponseReader(XmlReader xmlReader)
        {
            _physicalCheckDebitResponseReader = xmlReader;
        }

        public void ReadXml(XmlReader reader, string filePath)
        {
            ID = reader.GetAttribute("id");
            LitleBatchId = Int64.Parse(reader.GetAttribute("litleBatchId"));
            MerchantId = reader.GetAttribute("merchantId");

            _originalXmlReader = reader;
            _accountUpdateResponseReader = new XmlTextReader(filePath);
            _authorizationResponseReader = new XmlTextReader(filePath);
            _authReversalResponseReader = new XmlTextReader(filePath);
            _captureResponseReader = new XmlTextReader(filePath);
            _captureGivenAuthResponseReader = new XmlTextReader(filePath);
            _creditResponseReader = new XmlTextReader(filePath);
            _forceCaptureResponseReader = new XmlTextReader(filePath);
            _echeckCreditResponseReader = new XmlTextReader(filePath);
            _echeckRedepositResponseReader = new XmlTextReader(filePath);
            _echeckSalesResponseReader = new XmlTextReader(filePath);
            _echeckVerificationResponseReader = new XmlTextReader(filePath);
            _saleResponseReader = new XmlTextReader(filePath);
            _registerTokenResponseReader = new XmlTextReader(filePath);
            _updateCardValidationNumOnTokenResponseReader = new XmlTextReader(filePath);
            _cancelSubscriptionResponseReader = new XmlTextReader(filePath);
            _updateSubscriptionResponseReader = new XmlTextReader(filePath);
            _createPlanResponseReader = new XmlTextReader(filePath);
            _updatePlanResponseReader = new XmlTextReader(filePath);
            _activateResponseReader = new XmlTextReader(filePath);
            _deactivateResponseReader = new XmlTextReader(filePath);
            _loadResponseReader = new XmlTextReader(filePath);
            _echeckPreNoteSaleResponseReader = new XmlTextReader(filePath);
            _echeckPreNoteCreditResponseReader = new XmlTextReader(filePath);
            _unloadResponseReader = new XmlTextReader(filePath);
            _balanceInquiryResponseReader = new XmlTextReader(filePath);
            _submerchantCreditResponseReader = new XmlTextReader(filePath);
            _payFacCreditResponseReader = new XmlTextReader(filePath);
            _reserveCreditResponseReader = new XmlTextReader(filePath);
            _vendorCreditResponseReader = new XmlTextReader(filePath);
            _physicalCheckCreditResponseReader = new XmlTextReader(filePath);
            _submerchantDebitResponseReader = new XmlTextReader(filePath);
            _payFacDebitResponseReader = new XmlTextReader(filePath);
            _reserveDebitResponseReader = new XmlTextReader(filePath);
            _vendorDebitResponseReader = new XmlTextReader(filePath);
            _physicalCheckDebitResponseReader = new XmlTextReader(filePath);

            if (!_accountUpdateResponseReader.ReadToFollowing("accountUpdateResponse"))
            {
                _accountUpdateResponseReader.Close();
            }
            if (!_authorizationResponseReader.ReadToFollowing("authorizationResponse"))
            {
                _authorizationResponseReader.Close();
            }
            if (!_authReversalResponseReader.ReadToFollowing("authReversalResponse"))
            {
                _authReversalResponseReader.Close();
            }
            if (!_captureResponseReader.ReadToFollowing("captureResponse"))
            {
                _captureResponseReader.Close();
            }
            if (!_captureGivenAuthResponseReader.ReadToFollowing("captureGivenAuthResponse"))
            {
                _captureGivenAuthResponseReader.Close();
            }
            if (!_creditResponseReader.ReadToFollowing("creditResponse"))
            {
                _creditResponseReader.Close();
            }
            if (!_forceCaptureResponseReader.ReadToFollowing("forceCaptureResponse"))
            {
                _forceCaptureResponseReader.Close();
            }
            if (!_echeckCreditResponseReader.ReadToFollowing("echeckCreditResponse"))
            {
                _echeckCreditResponseReader.Close();
            }
            if (!_echeckRedepositResponseReader.ReadToFollowing("echeckRedepositResponse"))
            {
                _echeckRedepositResponseReader.Close();
            }
            if (!_echeckSalesResponseReader.ReadToFollowing("echeckSalesResponse"))
            {
                _echeckSalesResponseReader.Close();
            }
            if (!_echeckVerificationResponseReader.ReadToFollowing("echeckVerificationResponse"))
            {
                _echeckVerificationResponseReader.Close();
            }
            if (!_saleResponseReader.ReadToFollowing("saleResponse"))
            {
                _saleResponseReader.Close();
            }
            if (!_registerTokenResponseReader.ReadToFollowing("registerTokenResponse"))
            {
                _registerTokenResponseReader.Close();
            }
            if (!_updateCardValidationNumOnTokenResponseReader.ReadToFollowing("updateCardValidationNumOnTokenResponse"))
            {
                _updateCardValidationNumOnTokenResponseReader.Close();
            }
            if (!_cancelSubscriptionResponseReader.ReadToFollowing("cancelSubscriptionResponse"))
            {
                _cancelSubscriptionResponseReader.Close();
            }
            if (!_updateSubscriptionResponseReader.ReadToFollowing("updateSubscriptionResponse"))
            {
                _updateSubscriptionResponseReader.Close();
            }
            if (!_createPlanResponseReader.ReadToFollowing("createPlanResponse"))
            {
                _createPlanResponseReader.Close();
            }
            if (!_updatePlanResponseReader.ReadToFollowing("updatePlanResponse"))
            {
                _updatePlanResponseReader.Close();
            }
            if (!_activateResponseReader.ReadToFollowing("activateResponse"))
            {
                _activateResponseReader.Close();
            }
            if (!_loadResponseReader.ReadToFollowing("loadResponse"))
            {
                _loadResponseReader.Close();
            }
            if (!_deactivateResponseReader.ReadToFollowing("deactivateResponse"))
            {
                _deactivateResponseReader.Close();
            }
            if (!_echeckPreNoteSaleResponseReader.ReadToFollowing("echeckPreNoteSaleResponse"))
            {
                _echeckPreNoteSaleResponseReader.Close();
            }
            if (!_echeckPreNoteCreditResponseReader.ReadToFollowing("echeckPreNoteCreditResponse"))
            {
                _echeckPreNoteCreditResponseReader.Close();
            }
            if (!_unloadResponseReader.ReadToFollowing("unloadResponse"))
            {
                _unloadResponseReader.Close();
            }
            if (!_balanceInquiryResponseReader.ReadToFollowing("balanceInquiryResponse"))
            {
                _balanceInquiryResponseReader.Close();
            }
            if (!_submerchantCreditResponseReader.ReadToFollowing("submerchantCreditResponse"))
            {
                _submerchantCreditResponseReader.Close();
            }
            if (!_payFacCreditResponseReader.ReadToFollowing("payFacCreditResponse"))
            {
                _payFacCreditResponseReader.Close();
            }
            if (!_vendorCreditResponseReader.ReadToFollowing("vendorCreditResponse"))
            {
                _vendorCreditResponseReader.Close();
            }
            if (!_reserveCreditResponseReader.ReadToFollowing("reserveCreditResponse"))
            {
                _reserveCreditResponseReader.Close();
            }
            if (!_physicalCheckCreditResponseReader.ReadToFollowing("physicalCheckCreditResponse"))
            {
                _physicalCheckCreditResponseReader.Close();
            }
            if (!_submerchantDebitResponseReader.ReadToFollowing("submerchantDebitResponse"))
            {
                _submerchantDebitResponseReader.Close();
            }
            if (!_payFacDebitResponseReader.ReadToFollowing("payFacDebitResponse"))
            {
                _payFacDebitResponseReader.Close();
            }
            if (!_vendorDebitResponseReader.ReadToFollowing("vendorDebitResponse"))
            {
                _vendorDebitResponseReader.Close();
            }
            if (!_reserveDebitResponseReader.ReadToFollowing("reserveDebitResponse"))
            {
                _reserveDebitResponseReader.Close();
            }
            if (!_physicalCheckDebitResponseReader.ReadToFollowing("physicalCheckDebitResponse"))
            {
                _physicalCheckDebitResponseReader.Close();
            }
        }

        public virtual AccountUpdateResponse NextAccountUpdateResponse()
        {
            if (_accountUpdateResponseReader.ReadState == ReadState.Closed) return null;
            var response = _accountUpdateResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (AccountUpdateResponse));
            var reader = new StringReader(response);
            var i = (AccountUpdateResponse) serializer.Deserialize(reader);

            if (!_accountUpdateResponseReader.ReadToFollowing("accountUpdateResponse"))
            {
                _accountUpdateResponseReader.Close();
            }

            return i;
        }

        public virtual AuthorizationResponse NextAuthorizationResponse()
        {
            if (_authorizationResponseReader.ReadState == ReadState.Closed) return null;
            var response = _authorizationResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (AuthorizationResponse));
            var reader = new StringReader(response);
            var i = (AuthorizationResponse) serializer.Deserialize(reader);

            if (!_authorizationResponseReader.ReadToFollowing("authorizationResponse"))
            {
                _authorizationResponseReader.Close();
            }

            return i;
        }

        public virtual AuthReversalResponse NextAuthReversalResponse()
        {
            if (_authReversalResponseReader.ReadState == ReadState.Closed) return null;
            var response = _authReversalResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (AuthReversalResponse));
            var reader = new StringReader(response);
            var i = (AuthReversalResponse) serializer.Deserialize(reader);

            if (!_authReversalResponseReader.ReadToFollowing("authReversalResponse"))
            {
                _authReversalResponseReader.Close();
            }

            return i;
        }

        public virtual CaptureResponse NextCaptureResponse()
        {
            if (_captureResponseReader.ReadState == ReadState.Closed) return null;
            var response = _captureResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CaptureResponse));
            var reader = new StringReader(response);
            var i = (CaptureResponse) serializer.Deserialize(reader);

            if (!_captureResponseReader.ReadToFollowing("captureResponse"))
            {
                _captureResponseReader.Close();
            }

            return i;
        }

        public virtual CaptureGivenAuthResponse NextCaptureGivenAuthResponse()
        {
            if (_captureGivenAuthResponseReader.ReadState == ReadState.Closed) return null;
            var response = _captureGivenAuthResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CaptureGivenAuthResponse));
            var reader = new StringReader(response);
            var i = (CaptureGivenAuthResponse) serializer.Deserialize(reader);

            if (!_captureGivenAuthResponseReader.ReadToFollowing("captureGivenAuthResponse"))
            {
                _captureGivenAuthResponseReader.Close();
            }

            return i;
        }

        public virtual CreditResponse NextCreditResponse()
        {
            if (_creditResponseReader.ReadState == ReadState.Closed) return null;
            var response = _creditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CreditResponse));
            var reader = new StringReader(response);
            var i = (CreditResponse) serializer.Deserialize(reader);

            if (!_creditResponseReader.ReadToFollowing("creditResponse"))
            {
                _creditResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckCreditResponse NextEcheckCreditResponse()
        {
            if (_echeckCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckCreditResponse));
            var reader = new StringReader(response);
            var i = (EcheckCreditResponse) serializer.Deserialize(reader);

            if (!_echeckCreditResponseReader.ReadToFollowing("echeckCreditResponse"))
            {
                _echeckCreditResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckRedepositResponse NextEcheckRedepositResponse()
        {
            if (_echeckRedepositResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckRedepositResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckRedepositResponse));
            var reader = new StringReader(response);
            var i = (EcheckRedepositResponse) serializer.Deserialize(reader);

            if (!_echeckRedepositResponseReader.ReadToFollowing("echeckRedepositResponse"))
            {
                _echeckRedepositResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckSalesResponse NextEcheckSalesResponse()
        {
            if (_echeckSalesResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckSalesResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckSalesResponse));
            var reader = new StringReader(response);
            var i = (EcheckSalesResponse) serializer.Deserialize(reader);

            if (!_echeckSalesResponseReader.ReadToFollowing("echeckSalesResponse"))
            {
                _echeckSalesResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckVerificationResponse NextEcheckVerificationResponse()
        {
            if (_echeckVerificationResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckVerificationResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckVerificationResponse));
            var reader = new StringReader(response);
            var i = (EcheckVerificationResponse) serializer.Deserialize(reader);

            if (!_echeckVerificationResponseReader.ReadToFollowing("echeckVerificationResponse"))
            {
                _echeckVerificationResponseReader.Close();
            }

            return i;
        }

        public virtual ForceCaptureResponse NextForceCaptureResponse()
        {
            if (_forceCaptureResponseReader.ReadState == ReadState.Closed) return null;
            string response = _forceCaptureResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ForceCaptureResponse));
            var reader = new StringReader(response);
            var i = (ForceCaptureResponse) serializer.Deserialize(reader);

            if (!_forceCaptureResponseReader.ReadToFollowing("forceCaptureResponse"))
            {
                _forceCaptureResponseReader.Close();
            }

            return i;
        }

        public virtual RegisterTokenResponse NextRegisterTokenResponse()
        {
            if (_registerTokenResponseReader.ReadState == ReadState.Closed) return null;
            string response = _registerTokenResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (RegisterTokenResponse));
            var reader = new StringReader(response);
            var i = (RegisterTokenResponse) serializer.Deserialize(reader);

            if (!_registerTokenResponseReader.ReadToFollowing("registerTokenResponse"))
            {
                _registerTokenResponseReader.Close();
            }

            return i;
        }

        public virtual SaleResponse NextSaleResponse()
        {
            if (_saleResponseReader.ReadState == ReadState.Closed) return null;
            string response = _saleResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (SaleResponse));
            var reader = new StringReader(response);
            var i = (SaleResponse) serializer.Deserialize(reader);

            if (!_saleResponseReader.ReadToFollowing("saleResponse"))
            {
                _saleResponseReader.Close();
            }

            return i;
        }

        public virtual UpdateCardValidationNumOnTokenResponse NextUpdateCardValidationNumOnTokenResponse()
        {
            if (_updateCardValidationNumOnTokenResponseReader.ReadState == ReadState.Closed) return null;
            string response = _updateCardValidationNumOnTokenResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UpdateCardValidationNumOnTokenResponse));
            var reader = new StringReader(response);
            var i =
                (UpdateCardValidationNumOnTokenResponse) serializer.Deserialize(reader);

            if (
                !_updateCardValidationNumOnTokenResponseReader.ReadToFollowing(
                    "updateCardValidationNumOnTokenResponse"))
            {
                _updateCardValidationNumOnTokenResponseReader.Close();
            }

            return i;
        }

        public virtual UpdateSubscriptionResponse NextUpdateSubscriptionResponse()
        {
            if (_updateSubscriptionResponseReader.ReadState == ReadState.Closed) return null;
            string response = _updateSubscriptionResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UpdateSubscriptionResponse));
            var reader = new StringReader(response);
            var i = (UpdateSubscriptionResponse) serializer.Deserialize(reader);

            if (!_updateSubscriptionResponseReader.ReadToFollowing("updateSubscriptionResponse"))
            {
                _updateSubscriptionResponseReader.Close();
            }

            return i;
        }

        public virtual CancelSubscriptionResponse NextCancelSubscriptionResponse()
        {
            if (_cancelSubscriptionResponseReader.ReadState == ReadState.Closed) return null;
            string response = _cancelSubscriptionResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CancelSubscriptionResponse));
            var reader = new StringReader(response);
            var i = (CancelSubscriptionResponse) serializer.Deserialize(reader);

            if (!_cancelSubscriptionResponseReader.ReadToFollowing("cancelSubscriptionResponse"))
            {
                _cancelSubscriptionResponseReader.Close();
            }

            return i;
        }

        public virtual CreatePlanResponse NextCreatePlanResponse()
        {
            if (_createPlanResponseReader.ReadState == ReadState.Closed) return null;
            string response = _createPlanResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (CreatePlanResponse));
            var reader = new StringReader(response);
            var i = (CreatePlanResponse) serializer.Deserialize(reader);

            if (!_createPlanResponseReader.ReadToFollowing("createPlanResponse"))
            {
                _createPlanResponseReader.Close();
            }

            return i;
        }

        public virtual UpdatePlanResponse NextUpdatePlanResponse()
        {
            if (_updatePlanResponseReader.ReadState == ReadState.Closed) return null;
            string response = _updatePlanResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UpdatePlanResponse));
            var reader = new StringReader(response);
            var i = (UpdatePlanResponse) serializer.Deserialize(reader);

            if (!_updatePlanResponseReader.ReadToFollowing("updatePlanResponse"))
            {
                _updatePlanResponseReader.Close();
            }

            return i;
        }

        public virtual ActivateResponse NextActivateResponse()
        {
            if (_activateResponseReader.ReadState == ReadState.Closed) return null;
            string response = _activateResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ActivateResponse));
            var reader = new StringReader(response);
            var i = (ActivateResponse) serializer.Deserialize(reader);

            if (!_activateResponseReader.ReadToFollowing("activateResponse"))
            {
                _activateResponseReader.Close();
            }

            return i;
        }

        public virtual DeactivateResponse NextDeactivateResponse()
        {
            if (_deactivateResponseReader.ReadState == ReadState.Closed) return null;
            string response = _deactivateResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (DeactivateResponse));
            var reader = new StringReader(response);
            var i = (DeactivateResponse) serializer.Deserialize(reader);

            if (!_deactivateResponseReader.ReadToFollowing("deactivateResponse"))
            {
                _deactivateResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckPreNoteSaleResponse NextEcheckPreNoteSaleResponse()
        {
            if (_echeckPreNoteSaleResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckPreNoteSaleResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckPreNoteSaleResponse));
            var reader = new StringReader(response);
            var i = (EcheckPreNoteSaleResponse) serializer.Deserialize(reader);

            if (!_echeckPreNoteSaleResponseReader.ReadToFollowing("echeckPreNoteSaleResponse"))
            {
                _echeckPreNoteSaleResponseReader.Close();
            }

            return i;
        }

        public virtual EcheckPreNoteCreditResponse NextEcheckPreNoteCreditResponse()
        {
            if (_echeckPreNoteCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _echeckPreNoteCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (EcheckPreNoteCreditResponse));
            var reader = new StringReader(response);
            var i = (EcheckPreNoteCreditResponse) serializer.Deserialize(reader);

            if (!_echeckPreNoteCreditResponseReader.ReadToFollowing("echeckPreNoteCreditResponse"))
            {
                _echeckPreNoteCreditResponseReader.Close();
            }

            return i;
        }

        public virtual LoadResponse NextLoadResponse()
        {
            if (_loadResponseReader.ReadState == ReadState.Closed) return null;
            string response = _loadResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (LoadResponse));
            var reader = new StringReader(response);
            var i = (LoadResponse) serializer.Deserialize(reader);

            if (!_loadResponseReader.ReadToFollowing("loadResponse"))
            {
                _loadResponseReader.Close();
            }

            return i;
        }

        public virtual UnloadResponse NextUnloadResponse()
        {
            if (_unloadResponseReader.ReadState == ReadState.Closed) return null;
            string response = _unloadResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (UnloadResponse));
            var reader = new StringReader(response);
            var i = (UnloadResponse) serializer.Deserialize(reader);

            if (!_unloadResponseReader.ReadToFollowing("unloadResponse"))
            {
                _unloadResponseReader.Close();
            }

            return i;
        }

        public virtual BalanceInquiryResponse NextBalanceInquiryResponse()
        {
            if (_balanceInquiryResponseReader.ReadState == ReadState.Closed) return null;
            string response = _balanceInquiryResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (BalanceInquiryResponse));
            var reader = new StringReader(response);
            var i = (BalanceInquiryResponse) serializer.Deserialize(reader);

            if (!_balanceInquiryResponseReader.ReadToFollowing("balanceInquiryResponse"))
            {
                _balanceInquiryResponseReader.Close();
            }

            return i;
        }

        public virtual SubmerchantCreditResponse NextSubmerchantCreditResponse()
        {
            if (_submerchantCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _submerchantCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (SubmerchantCreditResponse));
            var reader = new StringReader(response);
            var i = (SubmerchantCreditResponse) serializer.Deserialize(reader);

            if (!_submerchantCreditResponseReader.ReadToFollowing("submerchantCreditResponse"))
            {
                _submerchantCreditResponseReader.Close();
            }

            return i;
        }

        public virtual PayFacCreditResponse NextPayFacCreditResponse()
        {
            if (_payFacCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _payFacCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PayFacCreditResponse));
            var reader = new StringReader(response);
            var i = (PayFacCreditResponse) serializer.Deserialize(reader);

            if (!_payFacCreditResponseReader.ReadToFollowing("payFacCreditResponse"))
            {
                _payFacCreditResponseReader.Close();
            }

            return i;
        }

        public virtual VendorCreditResponse NextVendorCreditResponse()
        {
            if (_vendorCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _vendorCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (VendorCreditResponse));
            var reader = new StringReader(response);
            var i = (VendorCreditResponse) serializer.Deserialize(reader);

            if (!_vendorCreditResponseReader.ReadToFollowing("vendorCreditResponse"))
            {
                _vendorCreditResponseReader.Close();
            }

            return i;
        }

        public virtual ReserveCreditResponse NextReserveCreditResponse()
        {
            if (_reserveCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _reserveCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ReserveCreditResponse));
            var reader = new StringReader(response);
            var i = (ReserveCreditResponse) serializer.Deserialize(reader);

            if (!_reserveCreditResponseReader.ReadToFollowing("reserveCreditResponse"))
            {
                _reserveCreditResponseReader.Close();
            }

            return i;
        }

        public virtual PhysicalCheckCreditResponse NextPhysicalCheckCreditResponse()
        {
            if (_physicalCheckCreditResponseReader.ReadState == ReadState.Closed) return null;
            string response = _physicalCheckCreditResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PhysicalCheckCreditResponse));
            var reader = new StringReader(response);
            var i = (PhysicalCheckCreditResponse) serializer.Deserialize(reader);

            if (!_physicalCheckCreditResponseReader.ReadToFollowing("physicalCheckCreditResponse"))
            {
                _physicalCheckCreditResponseReader.Close();
            }

            return i;
        }

        public virtual SubmerchantDebitResponse NextSubmerchantDebitResponse()
        {
            if (_submerchantDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _submerchantDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (SubmerchantDebitResponse));
            var reader = new StringReader(response);
            var i = (SubmerchantDebitResponse) serializer.Deserialize(reader);

            if (!_submerchantDebitResponseReader.ReadToFollowing("submerchantDebitResponse"))
            {
                _submerchantDebitResponseReader.Close();
            }

            return i;
        }

        public virtual PayFacDebitResponse NextPayFacDebitResponse()
        {
            if (_payFacDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _payFacDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PayFacDebitResponse));
            var reader = new StringReader(response);
            var i = (PayFacDebitResponse) serializer.Deserialize(reader);

            if (!_payFacDebitResponseReader.ReadToFollowing("payFacDebitResponse"))
            {
                _payFacDebitResponseReader.Close();
            }

            return i;
        }

        public virtual VendorDebitResponse NextVendorDebitResponse()
        {
            if (_vendorDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _vendorDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (VendorDebitResponse));
            var reader = new StringReader(response);
            var i = (VendorDebitResponse) serializer.Deserialize(reader);

            if (!_vendorDebitResponseReader.ReadToFollowing("vendorDebitResponse"))
            {
                _vendorDebitResponseReader.Close();
            }

            return i;
        }

        public virtual ReserveDebitResponse NextReserveDebitResponse()
        {
            if (_reserveDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _reserveDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (ReserveDebitResponse));
            var reader = new StringReader(response);
            var i = (ReserveDebitResponse) serializer.Deserialize(reader);

            if (!_reserveDebitResponseReader.ReadToFollowing("reserveDebitResponse"))
            {
                _reserveDebitResponseReader.Close();
            }

            return i;
        }

        public virtual PhysicalCheckDebitResponse NextPhysicalCheckDebitResponse()
        {
            if (_physicalCheckDebitResponseReader.ReadState == ReadState.Closed) return null;
            string response = _physicalCheckDebitResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (PhysicalCheckDebitResponse));
            var reader = new StringReader(response);
            var i = (PhysicalCheckDebitResponse) serializer.Deserialize(reader);

            if (!_physicalCheckDebitResponseReader.ReadToFollowing("physicalCheckDebitResponse"))
            {
                _physicalCheckDebitResponseReader.Close();
            }

            return i;
        }
    }
}