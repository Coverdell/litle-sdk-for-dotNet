using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestXmlFieldsUnserializer
    {

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
        }

        [Test]
        public void TestAuthorizationResponseContainsGiftCardResponse()
        {
            String xml = "<authorizationResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></authorizationResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(AuthorizationResponse));
            StringReader reader = new StringReader(xml);
            AuthorizationResponse authorizationResponse = (AuthorizationResponse)serializer.Deserialize(reader);

            Assert.NotNull(authorizationResponse.GiftCardResponse);
        }

        [Test]
        public void TestAuthReversalResponseContainsGiftCardResponse()
        {
            String xml = "<authReversalResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></authReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(AuthReversalResponse));
            StringReader reader = new StringReader(xml);
            AuthReversalResponse authReversalResponse = (AuthReversalResponse)serializer.Deserialize(reader);

            Assert.NotNull(authReversalResponse.GiftCardResponse);
        }

        [Test]
        public void TestCaptureResponseContainsGiftCardResponse()
        {
            String xml = "<captureResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></captureResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CaptureResponse));
            StringReader reader = new StringReader(xml);
            CaptureResponse captureResponse = (CaptureResponse)serializer.Deserialize(reader);

            Assert.NotNull(captureResponse.GiftCardResponse);
        }

        [Test]
        public void TestCaptureResponseContainsFraudResult()
        {
            String xml = "<captureResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></captureResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CaptureResponse));
            StringReader reader = new StringReader(xml);
            CaptureResponse captureResponse = (CaptureResponse)serializer.Deserialize(reader);

            Assert.NotNull(captureResponse.FraudResult);
        }

        [Test]
        public void TestForceCaptureResponseContainsGiftCardResponse()
        {
            String xml = "<forceCaptureResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></forceCaptureResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(ForceCaptureResponse));
            StringReader reader = new StringReader(xml);
            ForceCaptureResponse forceCaptureResponse = (ForceCaptureResponse)serializer.Deserialize(reader);

            Assert.NotNull(forceCaptureResponse.GiftCardResponse);
        }

        [Test]
        public void TestForceCaptureResponseContainsFraudResult()
        {
            String xml = "<forceCaptureResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></forceCaptureResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(ForceCaptureResponse));
            StringReader reader = new StringReader(xml);
            ForceCaptureResponse forceCaptureResponse = (ForceCaptureResponse)serializer.Deserialize(reader);

            Assert.NotNull(forceCaptureResponse.FraudResult);
        }

        [Test]
        public void TestCaptureGivenAuthResponseContainsGiftCardResponse()
        {
            String xml = "<captureGivenAuthResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></captureGivenAuthResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CaptureGivenAuthResponse));
            StringReader reader = new StringReader(xml);
            CaptureGivenAuthResponse captureGivenAuthResponse = (CaptureGivenAuthResponse)serializer.Deserialize(reader);

            Assert.NotNull(captureGivenAuthResponse.GiftCardResponse);
        }

        [Test]
        public void TestCaptureGivenAuthResponseContainsFraudResult()
        {
            String xml = "<captureGivenAuthResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></captureGivenAuthResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CaptureGivenAuthResponse));
            StringReader reader = new StringReader(xml);
            CaptureGivenAuthResponse captureGivenAuthResponse = (CaptureGivenAuthResponse)serializer.Deserialize(reader);

            Assert.NotNull(captureGivenAuthResponse.FraudResult);
        }

        [Test]
        public void TestSaleResponseContainsGiftCardResponse()
        {
            String xml = "<saleResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></saleResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(SaleResponse));
            StringReader reader = new StringReader(xml);
            SaleResponse saleResponse = (SaleResponse)serializer.Deserialize(reader);

            Assert.NotNull(saleResponse.GiftCardResponse);
        }

        [Test]
        public void TestCreditResponseContainsGiftCardResponse()
        {
            String xml = "<creditResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></creditResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CreditResponse));
            StringReader reader = new StringReader(xml);
            CreditResponse creditResponse = (CreditResponse)serializer.Deserialize(reader);

            Assert.NotNull(creditResponse.GiftCardResponse);
        }

        [Test]
        public void TestCreditResponseContainsFraudResult()
        {
            String xml = "<creditResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></creditResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CreditResponse));
            StringReader reader = new StringReader(xml);
            CreditResponse creditResponse = (CreditResponse)serializer.Deserialize(reader);

            Assert.NotNull(creditResponse.FraudResult);
        }

        [Test]
        public void TestActivateResponse()
        {
            String xml = "<activateResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" duplicate=\"true\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></activateResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(ActivateResponse));
            StringReader reader = new StringReader(xml);
            ActivateResponse activateResponse = (ActivateResponse)serializer.Deserialize(reader);

            Assert.AreEqual("A", activateResponse.ReportGroup);
            Assert.AreEqual("3", activateResponse.ID);
            Assert.AreEqual("4", activateResponse.CustomerId);
            Assert.IsTrue(activateResponse.Duplicate);
            Assert.AreEqual("1", activateResponse.LitleTxnId);
            Assert.AreEqual("2", activateResponse.OrderId);
            Assert.AreEqual("000", activateResponse.Response);
            Assert.AreEqual(new DateTime(2013,9,5,14,23,45), activateResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013,9,5), activateResponse.PostDate);
            Assert.AreEqual("Approved", activateResponse.Message);
            Assert.NotNull(activateResponse.FraudResult);
            Assert.NotNull(activateResponse.GiftCardResponse);
        }

        [Test]
        public void TestLoadResponse()
        {
            String xml = "<loadResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" duplicate=\"true\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></loadResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(LoadResponse));
            StringReader reader = new StringReader(xml);
            LoadResponse loadResponse = (LoadResponse)serializer.Deserialize(reader);

            Assert.AreEqual("A", loadResponse.ReportGroup);
            Assert.AreEqual("3", loadResponse.ID);
            Assert.AreEqual("4", loadResponse.CustomerId);
            Assert.IsTrue(loadResponse.Duplicate);
            Assert.AreEqual("1", loadResponse.LitleTxnId);
            Assert.AreEqual("2", loadResponse.OrderId);
            Assert.AreEqual("000", loadResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), loadResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), loadResponse.PostDate);
            Assert.AreEqual("Approved", loadResponse.Message);
            Assert.NotNull(loadResponse.FraudResult);
            Assert.NotNull(loadResponse.GiftCardResponse);
        }

        [Test]
        public void TestUnloadResponse()
        {
            String xml = "<unloadResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" duplicate=\"true\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></unloadResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(UnloadResponse));
            StringReader reader = new StringReader(xml);
            UnloadResponse unloadResponse = (UnloadResponse)serializer.Deserialize(reader);

            Assert.AreEqual("A", unloadResponse.ReportGroup);
            Assert.AreEqual("3", unloadResponse.ID);
            Assert.AreEqual("4", unloadResponse.CustomerId);
            Assert.IsTrue(unloadResponse.Duplicate);
            Assert.AreEqual("1", unloadResponse.LitleTxnId);
            Assert.AreEqual("2", unloadResponse.OrderId);
            Assert.AreEqual("000", unloadResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), unloadResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), unloadResponse.PostDate);
            Assert.AreEqual("Approved", unloadResponse.Message);
            Assert.NotNull(unloadResponse.FraudResult);
            Assert.NotNull(unloadResponse.GiftCardResponse);
        }

        [Test]
        public void TestGiftCardResponse()
        {
            String xml = "<balanceInquiryResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" xmlns=\"http://www.litle.com/schema\"><giftCardResponse><availableBalance>1</availableBalance><beginningBalance>2</beginningBalance><endingBalance>3</endingBalance><cashBackAmount>4</cashBackAmount></giftCardResponse></balanceInquiryResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(BalanceInquiryResponse));
            StringReader reader = new StringReader(xml);
            BalanceInquiryResponse balanceInquiryResponse = (BalanceInquiryResponse)serializer.Deserialize(reader);
            GiftCardResponse giftCardResponse = balanceInquiryResponse.GiftCardResponse;

            Assert.AreEqual("1", giftCardResponse.AvailableBalance);
            Assert.AreEqual("2", giftCardResponse.BeginningBalance);
            Assert.AreEqual("3", giftCardResponse.EndingBalance);
            Assert.AreEqual("4", giftCardResponse.CashBackAmount);
        }

        [Test]
        public void TestBalanceInquiryResponse()
        {
            String xml = "<balanceInquiryResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></balanceInquiryResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(BalanceInquiryResponse));
            StringReader reader = new StringReader(xml);
            BalanceInquiryResponse balanceInquiryResponse = (BalanceInquiryResponse)serializer.Deserialize(reader);

            Assert.AreEqual("A", balanceInquiryResponse.ReportGroup);
            Assert.AreEqual("3", balanceInquiryResponse.ID);
            Assert.AreEqual("4", balanceInquiryResponse.CustomerId);
            Assert.AreEqual("1", balanceInquiryResponse.LitleTxnId);
            Assert.AreEqual("2", balanceInquiryResponse.OrderId);
            Assert.AreEqual("000", balanceInquiryResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), balanceInquiryResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), balanceInquiryResponse.PostDate);
            Assert.AreEqual("Approved", balanceInquiryResponse.Message);
            Assert.NotNull(balanceInquiryResponse.FraudResult);
            Assert.NotNull(balanceInquiryResponse.GiftCardResponse);
        }

        [Test]
        public void TestDeactivateResponse()
        {
            String xml = "<deactivateResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></deactivateResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(DeactivateResponse));
            StringReader reader = new StringReader(xml);
            DeactivateResponse deactivateResponse = (DeactivateResponse)serializer.Deserialize(reader);

            Assert.AreEqual("A", deactivateResponse.ReportGroup);
            Assert.AreEqual("3", deactivateResponse.ID);
            Assert.AreEqual("4", deactivateResponse.CustomerId);
            Assert.AreEqual("1", deactivateResponse.LitleTxnId);
            Assert.AreEqual("2", deactivateResponse.OrderId);
            Assert.AreEqual("000", deactivateResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), deactivateResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), deactivateResponse.PostDate);
            Assert.AreEqual("Approved", deactivateResponse.Message);
            Assert.NotNull(deactivateResponse.FraudResult);
            Assert.NotNull(deactivateResponse.GiftCardResponse);
        }

        [Test]
        public void TestCreatePlanResponse()
        {
            String xml = @"
<createPlanResponse xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<response>000</response>
<message>Approved</message>
<responseTime>2013-09-05T14:23:45</responseTime>
<planCode>thePlan</planCode>
</createPlanResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(CreatePlanResponse));
            StringReader reader = new StringReader(xml);
            CreatePlanResponse createPlanResponse = (CreatePlanResponse)serializer.Deserialize(reader);

            Assert.AreEqual("1", createPlanResponse.LitleTxnId);
            Assert.AreEqual("000", createPlanResponse.Response);
            Assert.AreEqual("Approved", createPlanResponse.Message);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), createPlanResponse.ResponseTime);
            Assert.AreEqual("thePlan", createPlanResponse.PlanCode);
        }

        [Test]
        public void TestUpdatePlanResponse()
        {
            String xml = @"
<updatePlanResponse xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<response>000</response>
<message>Approved</message>
<responseTime>2013-09-05T14:23:45</responseTime>
<planCode>thePlan</planCode>
</updatePlanResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(UpdatePlanResponse));
            StringReader reader = new StringReader(xml);
            UpdatePlanResponse updatePlanResponse = (UpdatePlanResponse)serializer.Deserialize(reader);

            Assert.AreEqual("1", updatePlanResponse.LitleTxnId);
            Assert.AreEqual("000", updatePlanResponse.Response);
            Assert.AreEqual("Approved", updatePlanResponse.Message);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), updatePlanResponse.ResponseTime);
            Assert.AreEqual("thePlan", updatePlanResponse.PlanCode);
        }

        [Test]
        public void TestUpdateSubscriptionResponseCanContainTokenResponse()
        {
            String xml = @"
<updateSubscriptionResponse xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<response>000</response>
<message>Approved</message>
<responseTime>2013-09-05T14:23:45</responseTime>
<subscriptionId>123</subscriptionId>
<tokenResponse>
<litleToken>123456</litleToken>
</tokenResponse>
</updateSubscriptionResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(UpdateSubscriptionResponse));
            StringReader reader = new StringReader(xml);
            UpdateSubscriptionResponse updateSubscriptionResponse = (UpdateSubscriptionResponse)serializer.Deserialize(reader);
            Assert.AreEqual("123", updateSubscriptionResponse.SubscriptionId);
            Assert.AreEqual("123456", updateSubscriptionResponse.TokenResponse.LitleToken);
        }

        [Test]
        public void TestEnhancedAuthResponseCanContainVirtualAccountNumber()
        {
            String xml = @"
<enhancedAuthResponse xmlns=""http://www.litle.com/schema"">
<virtualAccountNumber>true</virtualAccountNumber>
</enhancedAuthResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(EnhancedAuthResponse));
            StringReader reader = new StringReader(xml);
            EnhancedAuthResponse enhancedAuthResponse = (EnhancedAuthResponse)serializer.Deserialize(reader);
            Assert.IsTrue(enhancedAuthResponse.VirtualAccountNumber);
        }

        [Test]
        public void TestEnhancedAuthResponseWithCardProductType()
        {
            String xml = @"
<enhancedAuthResponse xmlns=""http://www.litle.com/schema"">
<virtualAccountNumber>true</virtualAccountNumber>
<cardProductType>COMMERCIAL</cardProductType>
</enhancedAuthResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(EnhancedAuthResponse));
            StringReader reader = new StringReader(xml);
            EnhancedAuthResponse enhancedAuthResponse = (EnhancedAuthResponse)serializer.Deserialize(reader);
            Assert.IsTrue(enhancedAuthResponse.VirtualAccountNumber);
            Assert.AreEqual(CardProductTypeEnum.Commercial, enhancedAuthResponse.CardProductType);
        }

        [Test]
        public void TestEnhancedAuthResponseWithNullableEnumFields()
        {
            String xml = @"
<enhancedAuthResponse xmlns=""http://www.litle.com/schema"">
<virtualAccountNumber>1</virtualAccountNumber>
</enhancedAuthResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(EnhancedAuthResponse));
            StringReader reader = new StringReader(xml);
            EnhancedAuthResponse enhancedAuthResponse = (EnhancedAuthResponse)serializer.Deserialize(reader);
            Assert.IsTrue(enhancedAuthResponse.VirtualAccountNumber);
            Assert.IsNull(enhancedAuthResponse.CardProductType);
            Assert.IsNull(enhancedAuthResponse.Affluence);
        }

        [Test]
        public void TestAuthReversalResponseCanContainGiftCardResponse()
        {
            String xml = @"
<authReversalResponse xmlns=""http://www.litle.com/schema"" id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<postDate>2013-09-05</postDate>
<message>Foo</message>
<giftCardResponse>
<availableBalance>5</availableBalance>
</giftCardResponse>
</authReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(AuthReversalResponse));
            StringReader reader = new StringReader(xml);
            AuthReversalResponse authReversalResponse = (AuthReversalResponse)serializer.Deserialize(reader);
            Assert.AreEqual("theId", authReversalResponse.ID);
            Assert.AreEqual("theCustomerId", authReversalResponse.CustomerId);
            Assert.AreEqual("theReportGroup", authReversalResponse.ReportGroup);
            Assert.AreEqual(1, authReversalResponse.LitleTxnId);
            Assert.AreEqual("2", authReversalResponse.OrderId);
            Assert.AreEqual("000", authReversalResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), authReversalResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), authReversalResponse.PostDate);
            Assert.AreEqual("Foo", authReversalResponse.Message);
            Assert.AreEqual("5", authReversalResponse.GiftCardResponse.AvailableBalance);
        }

        [Test]
        public void TestDepositReversalResponseCanContainGiftCardResponse()
        {
            String xml = @"
<depositReversalResponse xmlns=""http://www.litle.com/schema"" id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<postDate>2013-09-05</postDate>
<message>Foo</message>
<giftCardResponse>
<availableBalance>5</availableBalance>
</giftCardResponse>
</depositReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(DepositReversalResponse));
            StringReader reader = new StringReader(xml);
            DepositReversalResponse depositReversalResponse = (DepositReversalResponse)serializer.Deserialize(reader);
            Assert.AreEqual("theId", depositReversalResponse.ID);
            Assert.AreEqual("theCustomerId", depositReversalResponse.CustomerId);
            Assert.AreEqual("theReportGroup", depositReversalResponse.ReportGroup);
            Assert.AreEqual("1", depositReversalResponse.LitleTxnId);
            Assert.AreEqual("2", depositReversalResponse.OrderId);
            Assert.AreEqual("000", depositReversalResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), depositReversalResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), depositReversalResponse.PostDate);
            Assert.AreEqual("Foo", depositReversalResponse.Message);
            Assert.AreEqual("5", depositReversalResponse.GiftCardResponse.AvailableBalance);
        }

        [Test]
        public void TestActivateReversalResponseCanContainGiftCardResponse()
        {
            String xml = @"
<activateReversalResponse xmlns=""http://www.litle.com/schema"" id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<postDate>2013-09-05</postDate>
<message>Foo</message>
<giftCardResponse>
<availableBalance>5</availableBalance>
</giftCardResponse>
</activateReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(ActivateReversalResponse));
            StringReader reader = new StringReader(xml);
            ActivateReversalResponse activateReversalResponse = (ActivateReversalResponse)serializer.Deserialize(reader);
            Assert.AreEqual("theId", activateReversalResponse.ID);
            Assert.AreEqual("theCustomerId", activateReversalResponse.CustomerId);
            Assert.AreEqual("theReportGroup", activateReversalResponse.ReportGroup);
            Assert.AreEqual("1", activateReversalResponse.LitleTxnId);
            Assert.AreEqual("2", activateReversalResponse.OrderId);
            Assert.AreEqual("000", activateReversalResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), activateReversalResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), activateReversalResponse.PostDate);
            Assert.AreEqual("Foo", activateReversalResponse.Message);
            Assert.AreEqual("5", activateReversalResponse.GiftCardResponse.AvailableBalance);
        }

        [Test]
        public void TestDeactivateReversalResponseCanContainGiftCardResponse()
        {
            String xml = @"
<deactivateReversalResponse xmlns=""http://www.litle.com/schema"" id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<postDate>2013-09-05</postDate>
<message>Foo</message>
<giftCardResponse>
<availableBalance>5</availableBalance>
</giftCardResponse>
</deactivateReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(DeactivateReversalResponse));
            StringReader reader = new StringReader(xml);
            DeactivateReversalResponse deactivateReversalResponse = (DeactivateReversalResponse)serializer.Deserialize(reader);
            Assert.AreEqual("theId", deactivateReversalResponse.ID);
            Assert.AreEqual("theCustomerId", deactivateReversalResponse.CustomerId);
            Assert.AreEqual("theReportGroup", deactivateReversalResponse.ReportGroup);
            Assert.AreEqual("1", deactivateReversalResponse.LitleTxnId);
            Assert.AreEqual("2", deactivateReversalResponse.OrderId);
            Assert.AreEqual("000", deactivateReversalResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), deactivateReversalResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), deactivateReversalResponse.PostDate);
            Assert.AreEqual("Foo", deactivateReversalResponse.Message);
            Assert.AreEqual("5", deactivateReversalResponse.GiftCardResponse.AvailableBalance);
        }

        [Test]
        public void TestLoadReversalResponseCanContainGiftCardResponse()
        {
            String xml = @"
<loadReversalResponse xmlns=""http://www.litle.com/schema"" id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<postDate>2013-09-05</postDate>
<message>Foo</message>
<giftCardResponse>
<availableBalance>5</availableBalance>
</giftCardResponse>
</loadReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(LoadReversalResponse));
            StringReader reader = new StringReader(xml);
            LoadReversalResponse loadReversalResponse = (LoadReversalResponse)serializer.Deserialize(reader);
            Assert.AreEqual("theId", loadReversalResponse.ID);
            Assert.AreEqual("theCustomerId", loadReversalResponse.CustomerId);
            Assert.AreEqual("theReportGroup", loadReversalResponse.ReportGroup);
            Assert.AreEqual("1", loadReversalResponse.LitleTxnId);
            Assert.AreEqual("2", loadReversalResponse.OrderId);
            Assert.AreEqual("000", loadReversalResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), loadReversalResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), loadReversalResponse.PostDate);
            Assert.AreEqual("Foo", loadReversalResponse.Message);
            Assert.AreEqual("5", loadReversalResponse.GiftCardResponse.AvailableBalance);
        }

        [Test]
        public void TestUnloadReversalResponseCanContainGiftCardResponse()
        {
            String xml = @"
<unloadReversalResponse xmlns=""http://www.litle.com/schema"" id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<postDate>2013-09-05</postDate>
<message>Foo</message>
<giftCardResponse>
<availableBalance>5</availableBalance>
</giftCardResponse>
</unloadReversalResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(UnloadReversalResponse));
            StringReader reader = new StringReader(xml);
            UnloadReversalResponse unloadReversalResponse = (UnloadReversalResponse)serializer.Deserialize(reader);
            Assert.AreEqual("theId", unloadReversalResponse.ID);
            Assert.AreEqual("theCustomerId", unloadReversalResponse.CustomerId);
            Assert.AreEqual("theReportGroup", unloadReversalResponse.ReportGroup);
            Assert.AreEqual("1", unloadReversalResponse.LitleTxnId);
            Assert.AreEqual("2", unloadReversalResponse.OrderId);
            Assert.AreEqual("000", unloadReversalResponse.Response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), unloadReversalResponse.ResponseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), unloadReversalResponse.PostDate);
            Assert.AreEqual("Foo", unloadReversalResponse.Message);
            Assert.AreEqual("5", unloadReversalResponse.GiftCardResponse.AvailableBalance);
        }

        [Test]
        public void TestActivateResponseCanContainVirtualGiftCardResponse()
        {
            String xml = @"
<activateResponse reportGroup=""A"" id=""3"" customerId=""4"" duplicate=""true"" xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<message>Approved</message>
<virtualGiftCardResponse>
<accountNumber>123</accountNumber>
</virtualGiftCardResponse>
</activateResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(ActivateResponse));
            StringReader reader = new StringReader(xml);
            ActivateResponse activateResponse = (ActivateResponse)serializer.Deserialize(reader);

            Assert.AreEqual("123",activateResponse.VirtualGiftCardResponse.AccountNumber);
        }

        [Test]
        public void TestVirtualGiftCardResponse()
        {
            String xml = @"
<activateResponse reportGroup=""A"" id=""3"" customerId=""4"" duplicate=""true"" xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<message>Approved</message>
<virtualGiftCardResponse>
<accountNumber>123</accountNumber>
<cardValidationNum>abc</cardValidationNum>
</virtualGiftCardResponse>
</activateResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(ActivateResponse));
            StringReader reader = new StringReader(xml);
            ActivateResponse activateResponse = (ActivateResponse)serializer.Deserialize(reader);

            Assert.AreEqual("123", activateResponse.VirtualGiftCardResponse.AccountNumber);
            Assert.AreEqual("abc", activateResponse.VirtualGiftCardResponse.CardValidationNum);
        }

        [Test]
        public void TestAccountUpdaterResponse()
        {
            String xml = @"
<authorizationResponse xmlns=""http://www.litle.com/schema"">
<accountUpdater>
<extendedCardResponse>
<message>TheMessage</message>
<code>TheCode</code>
</extendedCardResponse>
<newCardInfo>
<type>VI</type>
<number>4100000000000000</number>
<expDate>1000</expDate>
</newCardInfo>
<originalCardInfo>
<type>MC</type>
<number>5300000000000000</number>
<expDate>1100</expDate>
</originalCardInfo>
</accountUpdater>
</authorizationResponse>";
            XmlSerializer serializer = new XmlSerializer(typeof(AuthorizationResponse));
            StringReader reader = new StringReader(xml);
            AuthorizationResponse authorizationResponse = (AuthorizationResponse)serializer.Deserialize(reader);
            Assert.AreEqual("TheMessage", authorizationResponse.AccountUpdater.ExtendedCardResponse.Message);
            Assert.AreEqual("TheCode", authorizationResponse.AccountUpdater.ExtendedCardResponse.Code);
            Assert.AreEqual(MethodOfPaymentTypeEnum.VI, authorizationResponse.AccountUpdater.NewCardInfo.Type);
            Assert.AreEqual("4100000000000000", authorizationResponse.AccountUpdater.NewCardInfo.Number);
            Assert.AreEqual("1000", authorizationResponse.AccountUpdater.NewCardInfo.ExpDate);
            Assert.AreEqual(MethodOfPaymentTypeEnum.MC, authorizationResponse.AccountUpdater.OriginalCardInfo.Type);
            Assert.AreEqual("5300000000000000", authorizationResponse.AccountUpdater.OriginalCardInfo.Number);
            Assert.AreEqual("1100", authorizationResponse.AccountUpdater.OriginalCardInfo.ExpDate);
        }
    }
}
