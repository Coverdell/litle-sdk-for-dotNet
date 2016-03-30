using System;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestXmlFieldsUnserializer
    {
        private static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof (T));
            var reader = new StringReader(xml);
            var authorizationResponse = (T) serializer.Deserialize(reader);
            return authorizationResponse;
        }

        [Test]
        public void TestAuthorizationResponseContainsGiftCardResponse()
        {
            var authorizationResponse = Deserialize<authorizationResponse>(
                "<authorizationResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></authorizationResponse>");

            Assert.NotNull(authorizationResponse.giftCardResponse);
        }

        [Test]
        public void TestAuthReversalResponseContainsGiftCardResponse()
        {
            var authReversalResponse = Deserialize<authReversalResponse>(
                "<authReversalResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></authReversalResponse>");

            Assert.NotNull(authReversalResponse.giftCardResponse);
        }

        [Test]
        public void TestCaptureResponseContainsGiftCardResponse()
        {
            var captureResponse = Deserialize<captureResponse>(
                "<captureResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></captureResponse>");

            Assert.NotNull(captureResponse.giftCardResponse);
        }

        [Test]
        public void TestCaptureResponseContainsFraudResult()
        {
            var captureResponse = Deserialize<captureResponse>(
                "<captureResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></captureResponse>");

            Assert.NotNull(captureResponse.fraudResult);
        }

        [Test]
        public void TestForceCaptureResponseContainsGiftCardResponse()
        {
            var forceCaptureResponse =
                Deserialize<forceCaptureResponse>(
                    "<forceCaptureResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></forceCaptureResponse>");

            Assert.NotNull(forceCaptureResponse.giftCardResponse);
        }

        [Test]
        public void TestForceCaptureResponseContainsFraudResult()
        {
            var forceCaptureResponse = Deserialize<forceCaptureResponse>(
                "<forceCaptureResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></forceCaptureResponse>");

            Assert.NotNull(forceCaptureResponse.fraudResult);
        }

        [Test]
        public void TestCaptureGivenAuthResponseContainsGiftCardResponse()
        {
            var captureGivenAuthResponse = Deserialize<captureGivenAuthResponse>(
                "<captureGivenAuthResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></captureGivenAuthResponse>");

            Assert.NotNull(captureGivenAuthResponse.giftCardResponse);
        }

        [Test]
        public void TestCaptureGivenAuthResponseContainsFraudResult()
        {
            var captureGivenAuthResponse = Deserialize<captureGivenAuthResponse>(
                "<captureGivenAuthResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></captureGivenAuthResponse>");

            Assert.NotNull(captureGivenAuthResponse.fraudResult);
        }

        [Test]
        public void TestSaleResponseContainsGiftCardResponse()
        {
            var saleResponse = Deserialize<saleResponse>(
                "<saleResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></saleResponse>");

            Assert.NotNull(saleResponse.giftCardResponse);
        }

        [Test]
        public void TestCreditResponseContainsGiftCardResponse()
        {
            var creditResponse = Deserialize<creditResponse>(
                "<creditResponse xmlns=\"http://www.litle.com/schema\"><giftCardResponse></giftCardResponse></creditResponse>");

            Assert.NotNull(creditResponse.giftCardResponse);
        }

        [Test]
        public void TestCreditResponseContainsFraudResult()
        {
            var creditResponse = Deserialize<creditResponse>(
                "<creditResponse xmlns=\"http://www.litle.com/schema\"><fraudResult></fraudResult></creditResponse>");

            Assert.NotNull(creditResponse.fraudResult);
        }

        [Test]
        public void TestActivateResponse()
        {
            var activateResponse = Deserialize<activateResponse>(
                "<activateResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" duplicate=\"true\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></activateResponse>");

            Assert.AreEqual("A", activateResponse.reportGroup);
            Assert.AreEqual("3", activateResponse.id);
            Assert.AreEqual("4", activateResponse.customerId);
            Assert.IsTrue(activateResponse.duplicate);
            Assert.AreEqual("1", activateResponse.litleTxnId);
            Assert.AreEqual("2", activateResponse.orderId);
            Assert.AreEqual("000", activateResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), activateResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), activateResponse.postDate);
            Assert.AreEqual("Approved", activateResponse.message);
            Assert.NotNull(activateResponse.fraudResult);
            Assert.NotNull(activateResponse.giftCardResponse);
        }

        [Test]
        public void TestLoadResponse()
        {
            var loadResponse = Deserialize<loadResponse>(
                "<loadResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" duplicate=\"true\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></loadResponse>");

            Assert.AreEqual("A", loadResponse.reportGroup);
            Assert.AreEqual("3", loadResponse.id);
            Assert.AreEqual("4", loadResponse.customerId);
            Assert.IsTrue(loadResponse.duplicate);
            Assert.AreEqual("1", loadResponse.litleTxnId);
            Assert.AreEqual("2", loadResponse.orderId);
            Assert.AreEqual("000", loadResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), loadResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), loadResponse.postDate);
            Assert.AreEqual("Approved", loadResponse.message);
            Assert.NotNull(loadResponse.fraudResult);
            Assert.NotNull(loadResponse.giftCardResponse);
        }

        [Test]
        public void TestUnloadResponse()
        {
            var unloadResponse = Deserialize<unloadResponse>(
                "<unloadResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" duplicate=\"true\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></unloadResponse>");

            Assert.AreEqual("A", unloadResponse.reportGroup);
            Assert.AreEqual("3", unloadResponse.id);
            Assert.AreEqual("4", unloadResponse.customerId);
            Assert.IsTrue(unloadResponse.duplicate);
            Assert.AreEqual("1", unloadResponse.litleTxnId);
            Assert.AreEqual("2", unloadResponse.orderId);
            Assert.AreEqual("000", unloadResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), unloadResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), unloadResponse.postDate);
            Assert.AreEqual("Approved", unloadResponse.message);
            Assert.NotNull(unloadResponse.fraudResult);
            Assert.NotNull(unloadResponse.giftCardResponse);
        }

        [Test]
        public void TestGiftCardResponse()
        {
            var balanceInquiryResponse = Deserialize<balanceInquiryResponse>(
                "<balanceInquiryResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" xmlns=\"http://www.litle.com/schema\"><giftCardResponse><availableBalance>1</availableBalance><beginningBalance>2</beginningBalance><endingBalance>3</endingBalance><cashBackAmount>4</cashBackAmount></giftCardResponse></balanceInquiryResponse>");
            var giftCardResponse = balanceInquiryResponse.giftCardResponse;

            Assert.AreEqual("1", giftCardResponse.availableBalance);
            Assert.AreEqual("2", giftCardResponse.beginningBalance);
            Assert.AreEqual("3", giftCardResponse.endingBalance);
            Assert.AreEqual("4", giftCardResponse.cashBackAmount);
        }

        [Test]
        public void TestBalanceInquiryResponse()
        {
            var balanceInquiryResponse = Deserialize<balanceInquiryResponse>(
                "<balanceInquiryResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></balanceInquiryResponse>");

            Assert.AreEqual("A", balanceInquiryResponse.reportGroup);
            Assert.AreEqual("3", balanceInquiryResponse.id);
            Assert.AreEqual("4", balanceInquiryResponse.customerId);
            Assert.AreEqual("1", balanceInquiryResponse.litleTxnId);
            Assert.AreEqual("2", balanceInquiryResponse.orderId);
            Assert.AreEqual("000", balanceInquiryResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), balanceInquiryResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), balanceInquiryResponse.postDate);
            Assert.AreEqual("Approved", balanceInquiryResponse.message);
            Assert.NotNull(balanceInquiryResponse.fraudResult);
            Assert.NotNull(balanceInquiryResponse.giftCardResponse);
        }

        [Test]
        public void TestDeactivateResponse()
        {
            var deactivateResponse = Deserialize<deactivateResponse>(
                "<deactivateResponse reportGroup=\"A\" id=\"3\" customerId=\"4\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>1</litleTxnId><orderId>2</orderId><response>000</response><responseTime>2013-09-05T14:23:45</responseTime><postDate>2013-09-05</postDate><message>Approved</message><fraudResult></fraudResult><giftCardResponse></giftCardResponse></deactivateResponse>");

            Assert.AreEqual("A", deactivateResponse.reportGroup);
            Assert.AreEqual("3", deactivateResponse.id);
            Assert.AreEqual("4", deactivateResponse.customerId);
            Assert.AreEqual("1", deactivateResponse.litleTxnId);
            Assert.AreEqual("2", deactivateResponse.orderId);
            Assert.AreEqual("000", deactivateResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), deactivateResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), deactivateResponse.postDate);
            Assert.AreEqual("Approved", deactivateResponse.message);
            Assert.NotNull(deactivateResponse.fraudResult);
            Assert.NotNull(deactivateResponse.giftCardResponse);
        }

        [Test]
        public void TestCreatePlanResponse()
        {
            var createPlanResponse = Deserialize<createPlanResponse>(@"
<createPlanResponse xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<response>000</response>
<message>Approved</message>
<responseTime>2013-09-05T14:23:45</responseTime>
<planCode>thePlan</planCode>
</createPlanResponse>");

            Assert.AreEqual("1", createPlanResponse.litleTxnId);
            Assert.AreEqual("000", createPlanResponse.response);
            Assert.AreEqual("Approved", createPlanResponse.message);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), createPlanResponse.responseTime);
            Assert.AreEqual("thePlan", createPlanResponse.planCode);
        }

        [Test]
        public void TestUpdatePlanResponse()
        {
            var updatePlanResponse = Deserialize<updatePlanResponse>(@"
<updatePlanResponse xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<response>000</response>
<message>Approved</message>
<responseTime>2013-09-05T14:23:45</responseTime>
<planCode>thePlan</planCode>
</updatePlanResponse>");

            Assert.AreEqual("1", updatePlanResponse.litleTxnId);
            Assert.AreEqual("000", updatePlanResponse.response);
            Assert.AreEqual("Approved", updatePlanResponse.message);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), updatePlanResponse.responseTime);
            Assert.AreEqual("thePlan", updatePlanResponse.planCode);
        }

        [Test]
        public void TestUpdateSubscriptionResponseCanContainTokenResponse()
        {
            var updateSubscriptionResponse = Deserialize<updateSubscriptionResponse>(@"
<updateSubscriptionResponse xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<response>000</response>
<message>Approved</message>
<responseTime>2013-09-05T14:23:45</responseTime>
<subscriptionId>123</subscriptionId>
<tokenResponse>
<litleToken>123456</litleToken>
</tokenResponse>
</updateSubscriptionResponse>");

            Assert.AreEqual("123", updateSubscriptionResponse.subscriptionId);
            Assert.AreEqual("123456", updateSubscriptionResponse.tokenResponse.litleToken);
        }

        [Test]
        public void TestEnhancedAuthResponseCanContainVirtualAccountNumber()
        {
            var enhancedAuthResponse = Deserialize<enhancedAuthResponse>(@"
<enhancedAuthResponse xmlns=""http://www.litle.com/schema"">
<virtualAccountNumber>true</virtualAccountNumber>
</enhancedAuthResponse>");

            Assert.IsTrue(enhancedAuthResponse.virtualAccountNumber);
        }

        [Test]
        public void TestEnhancedAuthResponseWithCardProductType()
        {
            var enhancedAuthResponse = Deserialize<enhancedAuthResponse>(@"
<enhancedAuthResponse xmlns=""http://www.litle.com/schema"">
<virtualAccountNumber>true</virtualAccountNumber>
<cardProductType>COMMERCIAL</cardProductType>
</enhancedAuthResponse>");

            Assert.IsTrue(enhancedAuthResponse.virtualAccountNumber);
            Assert.AreEqual(cardProductTypeEnum.COMMERCIAL, enhancedAuthResponse.cardProductType);
        }

        [Test]
        public void TestEnhancedAuthResponseWithNullableEnumFields()
        {
            var enhancedAuthResponse = Deserialize<enhancedAuthResponse>(@"
<enhancedAuthResponse xmlns=""http://www.litle.com/schema"">
<virtualAccountNumber>1</virtualAccountNumber>
</enhancedAuthResponse>");

            Assert.IsTrue(enhancedAuthResponse.virtualAccountNumber);
            Assert.IsNull(enhancedAuthResponse.cardProductType);
            Assert.IsNull(enhancedAuthResponse.affluence);
        }

        [Test]
        public void TestAuthReversalResponseCanContainGiftCardResponse()
        {
            var authReversalResponse = Deserialize<authReversalResponse>(@"
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
</authReversalResponse>");

            Assert.AreEqual("theId", authReversalResponse.id);
            Assert.AreEqual("theCustomerId", authReversalResponse.customerId);
            Assert.AreEqual("theReportGroup", authReversalResponse.reportGroup);
            Assert.AreEqual(1, authReversalResponse.litleTxnId);
            Assert.AreEqual("2", authReversalResponse.orderId);
            Assert.AreEqual("000", authReversalResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), authReversalResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), authReversalResponse.postDate);
            Assert.AreEqual("Foo", authReversalResponse.message);
            Assert.AreEqual("5", authReversalResponse.giftCardResponse.availableBalance);
        }

        [Test]
        public void TestDepositReversalResponseCanContainGiftCardResponse()
        {
            var depositReversalResponse = Deserialize<depositReversalResponse>(@"
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
</depositReversalResponse>");

            Assert.AreEqual("theId", depositReversalResponse.id);
            Assert.AreEqual("theCustomerId", depositReversalResponse.customerId);
            Assert.AreEqual("theReportGroup", depositReversalResponse.reportGroup);
            Assert.AreEqual("1", depositReversalResponse.litleTxnId);
            Assert.AreEqual("2", depositReversalResponse.orderId);
            Assert.AreEqual("000", depositReversalResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), depositReversalResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), depositReversalResponse.postDate);
            Assert.AreEqual("Foo", depositReversalResponse.message);
            Assert.AreEqual("5", depositReversalResponse.giftCardResponse.availableBalance);
        }

        [Test]
        public void TestActivateReversalResponseCanContainGiftCardResponse()
        {
            var activateReversalResponse = Deserialize<activateReversalResponse>(@"
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
</activateReversalResponse>");

            Assert.AreEqual("theId", activateReversalResponse.id);
            Assert.AreEqual("theCustomerId", activateReversalResponse.customerId);
            Assert.AreEqual("theReportGroup", activateReversalResponse.reportGroup);
            Assert.AreEqual("1", activateReversalResponse.litleTxnId);
            Assert.AreEqual("2", activateReversalResponse.orderId);
            Assert.AreEqual("000", activateReversalResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), activateReversalResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), activateReversalResponse.postDate);
            Assert.AreEqual("Foo", activateReversalResponse.message);
            Assert.AreEqual("5", activateReversalResponse.giftCardResponse.availableBalance);
        }

        [Test]
        public void TestDeactivateReversalResponseCanContainGiftCardResponse()
        {
            var deactivateReversalResponse = Deserialize<deactivateReversalResponse>(@"
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
</deactivateReversalResponse>");

            Assert.AreEqual("theId", deactivateReversalResponse.id);
            Assert.AreEqual("theCustomerId", deactivateReversalResponse.customerId);
            Assert.AreEqual("theReportGroup", deactivateReversalResponse.reportGroup);
            Assert.AreEqual("1", deactivateReversalResponse.litleTxnId);
            Assert.AreEqual("2", deactivateReversalResponse.orderId);
            Assert.AreEqual("000", deactivateReversalResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), deactivateReversalResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), deactivateReversalResponse.postDate);
            Assert.AreEqual("Foo", deactivateReversalResponse.message);
            Assert.AreEqual("5", deactivateReversalResponse.giftCardResponse.availableBalance);
        }

        [Test]
        public void TestLoadReversalResponseCanContainGiftCardResponse()
        {
            var loadReversalResponse = Deserialize<loadReversalResponse>(@"
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
</loadReversalResponse>");

            Assert.AreEqual("theId", loadReversalResponse.id);
            Assert.AreEqual("theCustomerId", loadReversalResponse.customerId);
            Assert.AreEqual("theReportGroup", loadReversalResponse.reportGroup);
            Assert.AreEqual("1", loadReversalResponse.litleTxnId);
            Assert.AreEqual("2", loadReversalResponse.orderId);
            Assert.AreEqual("000", loadReversalResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), loadReversalResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), loadReversalResponse.postDate);
            Assert.AreEqual("Foo", loadReversalResponse.message);
            Assert.AreEqual("5", loadReversalResponse.giftCardResponse.availableBalance);
        }

        [Test]
        public void TestUnloadReversalResponseCanContainGiftCardResponse()
        {
            var unloadReversalResponse = Deserialize<unloadReversalResponse>(@"
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
</unloadReversalResponse>");

            Assert.AreEqual("theId", unloadReversalResponse.id);
            Assert.AreEqual("theCustomerId", unloadReversalResponse.customerId);
            Assert.AreEqual("theReportGroup", unloadReversalResponse.reportGroup);
            Assert.AreEqual("1", unloadReversalResponse.litleTxnId);
            Assert.AreEqual("2", unloadReversalResponse.orderId);
            Assert.AreEqual("000", unloadReversalResponse.response);
            Assert.AreEqual(new DateTime(2013, 9, 5, 14, 23, 45), unloadReversalResponse.responseTime);
            Assert.AreEqual(new DateTime(2013, 9, 5), unloadReversalResponse.postDate);
            Assert.AreEqual("Foo", unloadReversalResponse.message);
            Assert.AreEqual("5", unloadReversalResponse.giftCardResponse.availableBalance);
        }

        [Test]
        public void TestActivateResponseCanContainVirtualGiftCardResponse()
        {
            var activateResponse = Deserialize<activateResponse>(@"
<activateResponse reportGroup=""A"" id=""3"" customerId=""4"" duplicate=""true"" xmlns=""http://www.litle.com/schema"">
<litleTxnId>1</litleTxnId>
<orderId>2</orderId>
<response>000</response>
<responseTime>2013-09-05T14:23:45</responseTime>
<message>Approved</message>
<virtualGiftCardResponse>
<accountNumber>123</accountNumber>
</virtualGiftCardResponse>
</activateResponse>");

            Assert.AreEqual("123", activateResponse.virtualGiftCardResponse.accountNumber);
        }

        [Test]
        public void TestVirtualGiftCardResponse()
        {
            var activateResponse = Deserialize<activateResponse>(@"
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
</activateResponse>");

            Assert.AreEqual("123", activateResponse.virtualGiftCardResponse.accountNumber);
            Assert.AreEqual("abc", activateResponse.virtualGiftCardResponse.cardValidationNum);
        }

        [Test]
        public void TestAccountUpdaterResponse()
        {
            var authorizationResponse = Deserialize<authorizationResponse>(@"
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
</authorizationResponse>");

            Assert.AreEqual("TheMessage", authorizationResponse.accountUpdater.extendedCardResponse.message);
            Assert.AreEqual("TheCode", authorizationResponse.accountUpdater.extendedCardResponse.code);
            Assert.AreEqual(methodOfPaymentTypeEnum.VI, authorizationResponse.accountUpdater.newCardInfo.type);
            Assert.AreEqual("4100000000000000", authorizationResponse.accountUpdater.newCardInfo.number);
            Assert.AreEqual("1000", authorizationResponse.accountUpdater.newCardInfo.expDate);
            Assert.AreEqual(methodOfPaymentTypeEnum.MC, authorizationResponse.accountUpdater.originalCardInfo.type);
            Assert.AreEqual("5300000000000000", authorizationResponse.accountUpdater.originalCardInfo.number);
            Assert.AreEqual("1100", authorizationResponse.accountUpdater.originalCardInfo.expDate);
        }
    }
}