using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestBatchStream : LitleRequestTestBase
    {
        [Test]
        public void SimpleBatch()
        {
            var card = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "4100000000000001",
                expDate = "1210"
            };
            var card2 = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "4242424242424242",
                expDate = "1210"
            };
            var billToAddress = new contact
            {
                name = "Bob",
                city = "Lowell",
                state = "MA",
                email = "litle.com"
            };
            var billToAddress2 = new contact
            {
                name = "Mike",
                city = "Lowell",
                state = "MA",
                email = "litle.com"
            };
            var echeck = new echeckType
            {
                accType = echeckAccountTypeEnum.Checking,
                accNum = "1099999903",
                routingNum = "011201995",
                checkNum = "123455"
            };
            var echeck2 = new echeckType
            {
                accType = echeckAccountTypeEnum.Checking,
                accNum = "1099999903",
                routingNum = "011201995",
                checkNum = "123456"
            };

            var litleBatchRequest = new batchRequest(Cache);
            litleBatchRequest.addAuthorization(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addAuthorization(new authorization
            {
                reportGroup = "Planets",
                orderId = "12345",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addAuthReversal(new authReversal
            {
                litleTxnId = 12345678000L,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addAuthReversal(new authReversal
            {
                litleTxnId = 12345678900L,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addCapture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addCapture(new capture
            {
                litleTxnId = 123456700,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addCaptureGivenAuth(new captureGivenAuth
            {
                amount = 106,
                orderId = "12344",
                authInformation = new authInformation
                {
                    authDate = new DateTime(2002, 10, 9),
                    authCode = "543216",
                    authAmount = 12345
                },
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addCaptureGivenAuth(new captureGivenAuth
            {
                amount = 106,
                orderId = "12344",
                authInformation = new authInformation
                {
                    authDate = new DateTime(2003, 10, 9),
                    authCode = "543216",
                    authAmount = 12345
                },
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addCredit(new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addCredit(new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addEcheckCredit(new echeckCredit
            {
                amount = 12L,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckCredit(new echeckCredit
            {
                amount = 12L,
                orderId = "12346",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addEcheckRedeposit(new echeckRedeposit
            {
                litleTxnId = 123456,
                echeck = echeck
            });
            litleBatchRequest.addEcheckRedeposit(new echeckRedeposit
            {
                litleTxnId = 123457,
                echeck = echeck2
            });
            litleBatchRequest.addEcheckSale(new echeckSale
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckSale(new echeckSale
            {
                amount = 123456,
                orderId = "12346",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addEcheckPreNoteSale(new echeckPreNoteSale
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteSale(new echeckPreNoteSale
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addEcheckPreNoteCredit(new echeckPreNoteCredit
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteCredit(new echeckPreNoteCredit
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addEcheckVerification(new echeckVerification
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckVerification(new echeckVerification
            {
                amount = 123456,
                orderId = "12346",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addForceCapture(new forceCapture
            {
                amount = 106,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addForceCapture(new forceCapture
            {
                amount = 106,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addSale(new sale
            {
                amount = 106,
                litleTxnId = 123456,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addSale(new sale
            {
                amount = 106,
                litleTxnId = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addRegisterTokenRequest(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });
            litleBatchRequest.addRegisterTokenRequest(new registerTokenRequestType
            {
                orderId = "12345",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });
            litleBatchRequest.addUpdateCardValidationNumOnToken(new updateCardValidationNumOnToken
            {
                orderId = "12344",
                cardValidationNum = "123",
                litleToken = "4100000000000001"
            });
            litleBatchRequest.addUpdateCardValidationNumOnToken(new updateCardValidationNumOnToken
            {
                orderId = "12345",
                cardValidationNum = "123",
                litleToken = "4242424242424242"
            });

            Litle.addBatch(litleBatchRequest);
            var litleResponse = Litle.sendToLitleWithStream();
            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);
            AssertWhileNext(litleResponse.nextBatchResponse, litleBatchResponse =>
            {
                AssertNextResponse("000", litleBatchResponse.nextAuthorizationResponse, x => x.response);
                AssertNextResponse("360", litleBatchResponse.nextAuthReversalResponse, x => x.response);
                AssertNextResponse("360", litleBatchResponse.nextCaptureResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextCaptureGivenAuthResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextCreditResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextEcheckCreditResponse, x => x.response);
                AssertNextResponse("360", litleBatchResponse.nextEcheckRedepositResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextEcheckSalesResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextEcheckPreNoteSaleResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextEcheckPreNoteCreditResponse, x => x.response);
                AssertNextResponse("957", litleBatchResponse.nextEcheckVerificationResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextForceCaptureResponse, x => x.response);
                AssertNextResponse("820", litleBatchResponse.nextRegisterTokenResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextSaleResponse, x => x.response);
                AssertNextResponse("823", litleBatchResponse.nextUpdateCardValidationNumOnTokenResponse, x => x.response);
            });
        }

        [Test]
        public void AccountUpdateBatch()
        {
            var card = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "414100000000000000",
                expDate = "1210"
            };

            var litleBatchRequest = new batchRequest(Cache);
            litleBatchRequest.addAccountUpdate(new accountUpdate
            {
                orderId = "1111",
                card = card
            });
            litleBatchRequest.addAccountUpdate(new accountUpdate
            {
                orderId = "1112",
                card = card
            });

            Litle.addBatch(litleBatchRequest);
            var litleResponse = Litle.sendToLitleWithStream();
            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);
            AssertWhileNext(litleResponse.nextBatchResponse, litleBatchResponse =>
                AssertNextResponseAtLeastOnce("301", litleBatchResponse.nextAccountUpdateResponse, x => x.response));
        }
        
        [Test]
        public void RfrBatch()
        {
            var card = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "4242424242424242",
                expDate = "1210"
            };

            var litleBatchRequest = new batchRequest(Cache) {id = "1234567A"};
            litleBatchRequest.addAccountUpdate(new accountUpdate
            {
                orderId = "1111",
                card = card
            });
            litleBatchRequest.addAccountUpdate(new accountUpdate
            {
                orderId = "1112",
                card = card
            });

            Litle.addBatch(litleBatchRequest);
            var litleResponse = Litle.sendToLitleWithStream();
            Assert.NotNull(litleResponse);

            AssertWhileNextAtLeastOnce(litleResponse.nextBatchResponse, litleBatchResponse => 
                AssertNextResponseAtLeastOnce("000", litleBatchResponse.nextAccountUpdateResponse, x => x.response));
            
            var litleRfr = new litleRequest(Cache);
            litleRfr.addRFRRequest(new RFRRequest(Cache)
            {
                accountUpdateFileRequestData = new accountUpdateFileRequestData
                {
                    merchantId = Settings.Default.merchantId,
                    postDay = DateTime.Now
                }
            });

            try //TODO: Why bother if you're just going to ignore the assert failure.
            {
                var litleRfrResponse = litleRfr.sendToLitleWithStream();
                Assert.NotNull(litleRfrResponse);

                AssertWhileNextAtLeastOnce(litleRfrResponse.nextRFRResponse, rfrResponse =>
                {
                    Assert.AreEqual("1", rfrResponse.response);
                    Assert.AreEqual("The account update file is not ready yet.  Please try again later.",
                        rfrResponse.message);
                });
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [Test]
        public void NullBatchData()
        {
            var card = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "414100000000000000",
                expDate = "1210"
            };
            var echeck = new echeckType
            {
                accType = echeckAccountTypeEnum.Checking,
                accNum = "12345657890",
                routingNum = "011201995",
                checkNum = "123455"
            };
            var billToAddress = new contact
            {
                name = "Bob",
                city = "Lowell",
                state = "MA",
                email = "litle.com"
            };

            var litleBatchRequest = new batchRequest(Cache);
            AssertAddThrowsWhenNull(litleBatchRequest.addAuthorization, new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addAuthReversal, new authReversal
            {
                litleTxnId = 12345678000L,
                amount = 106,
                payPalNotes = "Notes"
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addCapture, new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "Notes"
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addCaptureGivenAuth, new captureGivenAuth
            {
                amount = 106,
                orderId = "12344",
                authInformation = new authInformation
                {
                    authDate = new DateTime(2002, 10, 9),
                    authCode = "543216",
                    authAmount = 12345
                },
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addCredit, new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addEcheckCredit, new echeckCredit
            {
                amount = 12L,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addEcheckRedeposit, new echeckRedeposit
            {
                litleTxnId = 123456,
                echeck = echeck
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addEcheckSale, new echeckSale
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addEcheckVerification, new echeckVerification
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addForceCapture, new forceCapture
            {
                amount = 106,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addSale, new sale
            {
                amount = 106,
                litleTxnId = 123456,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            AssertAddThrowsWhenNull(litleBatchRequest.addRegisterTokenRequest, new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });

            try //TODO: What null object would allow this test to be successful?  This seems wrong.
            {
                Litle.addBatch(litleBatchRequest);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }

        [Test]
        public void InvalidCredientialsBatch()
        {
            var echeck = new echeckType
            {
                accType = echeckAccountTypeEnum.Checking,
                accNum = "1099999903",
                routingNum = "011201995",
                checkNum = "123455"
            };
            var billToAddress = new contact
            {
                name = "Bob",
                city = "Lowell",
                state = "MA",
                email = "litle.com"
            };
            var billToAddress2 = new contact
            {
                name = "Mike",
                city = "Lowell",
                state = "MA",
                email = "litle.com"
            };
            var echeck2 = new echeckType
            {
                accType = echeckAccountTypeEnum.Checking,
                accNum = "1099999903",
                routingNum = "011201995",
                checkNum = "123456"
            };
            var card = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "4100000000000001",
                expDate = "1210"
            };
            var card2 = new cardType
            {
                type = methodOfPaymentTypeEnum.VI,
                number = "4242424242424242",
                expDate = "1210"
            };

            var litleBatchRequest = new batchRequest(Cache);
            litleBatchRequest.addAuthorization(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addAuthorization(new authorization
            {
                reportGroup = "Planets",
                orderId = "12345",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addAuthReversal(new authReversal
            {
                litleTxnId = 12345678000L,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addAuthReversal(new authReversal
            {
                litleTxnId = 12345678900L,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addCapture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addCapture(new capture
            {
                litleTxnId = 123456700,
                amount = 106,
                payPalNotes = "Notes"
            });
            litleBatchRequest.addCaptureGivenAuth(new captureGivenAuth
            {
                amount = 106,
                orderId = "12344",
                authInformation = new authInformation
                {
                    authDate = new DateTime(2002, 10, 9),
                    authCode = "543216",
                    authAmount = 12345
                },
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addCaptureGivenAuth(new captureGivenAuth
            {
                amount = 106,
                orderId = "12344",
                authInformation = new authInformation
                {
                    authDate = new DateTime(2003, 10, 9),
                    authCode = "543216",
                    authAmount = 12345
                },
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addCredit(new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addCredit(new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addEcheckCredit(new echeckCredit
            {
                amount = 12L,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckCredit(new echeckCredit
            {
                amount = 12L,
                orderId = "12346",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addEcheckRedeposit(new echeckRedeposit
            {
                litleTxnId = 123456,
                echeck = echeck
            });
            litleBatchRequest.addEcheckRedeposit(new echeckRedeposit
            {
                litleTxnId = 123457,
                echeck = echeck2
            });
            litleBatchRequest.addEcheckSale(new echeckSale
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckSale(new echeckSale
            {
                amount = 123456,
                orderId = "12346",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addEcheckVerification(new echeckVerification
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckVerification(new echeckVerification
            {
                amount = 123456,
                orderId = "12346",
                orderSource = orderSourceType.ecommerce,
                echeck = echeck2,
                billToAddress = billToAddress2
            });
            litleBatchRequest.addForceCapture(new forceCapture
            {
                amount = 106,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addForceCapture(new forceCapture
            {
                amount = 106,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addSale(new sale
            {
                amount = 106,
                litleTxnId = 123456,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = card
            });
            litleBatchRequest.addSale(new sale
            {
                amount = 106,
                litleTxnId = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = card2
            });
            litleBatchRequest.addRegisterTokenRequest(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });
            litleBatchRequest.addRegisterTokenRequest(new registerTokenRequestType
            {
                orderId = "12345",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });

            Litle.addBatch(litleBatchRequest);
            try
            {
                Litle.sendToLitleWithStream(); //TODO: Why even bother if you're just going to capture the exception.
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error establishing a network connection", e.Message);
            }
        }

        [Test]
        public void EcheckPreNoteTestAll()
        {
            var billToAddress = new contact
            {
                name = "Mike",
                city = "Lowell",
                state = "MA",
                email = "litle.com"
            };
            var echeckSuccess = new echeckType
            {
                accType = echeckAccountTypeEnum.Corporate,
                accNum = "1092969901",
                routingNum = "011075150",
                checkNum = "123456"
            };
            var echeckRoutErr = new echeckType
            {
                accType = echeckAccountTypeEnum.Checking,
                accNum = "6099999992",
                routingNum = "053133052",
                checkNum = "123457"
            };
            var echeckAccErr = new echeckType
            {
                accType = echeckAccountTypeEnum.Corporate,
                accNum = "10@2969901",
                routingNum = "011100012",
                checkNum = "123458"
            };

            var litleBatchRequest = new batchRequest(Cache);
            litleBatchRequest.addEcheckPreNoteSale(new echeckPreNoteSale
            {
                orderId = "000",
                orderSource = orderSourceType.ecommerce,
                echeck = echeckSuccess,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteSale(new echeckPreNoteSale
            {
                orderId = "900",
                orderSource = orderSourceType.ecommerce,
                echeck = echeckRoutErr,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteSale(new echeckPreNoteSale
            {
                orderId = "301",
                orderSource = orderSourceType.ecommerce,
                echeck = echeckAccErr,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteCredit(new echeckPreNoteCredit
            {
                orderId = "000",
                orderSource = orderSourceType.ecommerce,
                echeck = echeckSuccess,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteCredit(new echeckPreNoteCredit
            {
                orderId = "900",
                orderSource = orderSourceType.ecommerce,
                echeck = echeckRoutErr,
                billToAddress = billToAddress
            });
            litleBatchRequest.addEcheckPreNoteCredit(new echeckPreNoteCredit
            {
                orderId = "301",
                orderSource = orderSourceType.ecommerce,
                echeck = echeckAccErr,
                billToAddress = billToAddress
            });

            Litle.addBatch(litleBatchRequest);
            var litleResponse = Litle.sendToLitleWithStream();
            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);
            AssertWhileNext(litleResponse.nextBatchResponse, litleBatchResponse =>
            {
                AssertWhileNext(litleBatchResponse.nextEcheckPreNoteSaleResponse,
                    echeckPreNoteSaleResponse => Assert.AreEqual(echeckPreNoteSaleResponse.orderId, echeckPreNoteSaleResponse.response));
                AssertWhileNext(litleBatchResponse.nextEcheckPreNoteCreditResponse,
                    echeckPreNoteCreditResponse => Assert.AreEqual(echeckPreNoteCreditResponse.orderId, echeckPreNoteCreditResponse.response));
            });
        }
        
        [Test]
        public void PfifInstructionTxnTest()
        {
            var memoryStream = new Dictionary<string, StringBuilder>();
            var configOverride = new Dictionary<string, string>
            {
                ["url"] = Settings.Default.url,
                ["reportGroup"] = Settings.Default.reportGroup,
                ["username"] = "BATCHSDKA",
                ["printxml"] = Settings.Default.printxml,
                ["timeout"] = Settings.Default.timeout,
                ["proxyHost"] = Settings.Default.proxyHost,
                ["merchantId"] = "0180",
                ["password"] = "certpass",
                ["proxyPort"] = Settings.Default.proxyPort,
                ["sftpUrl"] = Settings.Default.sftpUrl,
                ["sftpUsername"] = Settings.Default.sftpUsername,
                ["sftpPassword"] = Settings.Default.sftpPassword,
                ["knownHostsFile"] = Settings.Default.knownHostsFile,
                ["onlineBatchUrl"] = Settings.Default.onlineBatchUrl,
                ["onlineBatchPort"] = Settings.Default.onlineBatchPort,
                ["requestDirectory"] = Settings.Default.requestDirectory,
                ["responseDirectory"] = Settings.Default.responseDirectory
            };

            var litleBatchRequest = new batchRequest(memoryStream, configOverride);
            litleBatchRequest.addSubmerchantCredit(new submerchantCredit
            {
                fundingSubmerchantId = "123456",
                submerchantName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Corporate,
                    accNum = "1092969901",
                    routingNum = "011075150",
                    checkNum = "123455"
                }
            });
            litleBatchRequest.addPayFacCredit(new payFacCredit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            });
            litleBatchRequest.addReserveCredit(new reserveCredit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            });
            litleBatchRequest.addVendorCredit(new vendorCredit
            {
                fundingSubmerchantId = "123456",
                vendorName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Corporate,
                    accNum = "1092969901",
                    routingNum = "011075150",
                    checkNum = "123455"
                }
            });
            litleBatchRequest.addPhysicalCheckCredit(new physicalCheckCredit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            });
            litleBatchRequest.addSubmerchantDebit(new submerchantDebit
            {
                fundingSubmerchantId = "123456",
                submerchantName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Corporate,
                    accNum = "1092969901",
                    routingNum = "011075150",
                    checkNum = "123455"
                }
            });
            litleBatchRequest.addPayFacDebit(new payFacDebit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            });
            litleBatchRequest.addReserveDebit(new reserveDebit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            });
            litleBatchRequest.addVendorDebit(new vendorDebit
            {
                fundingSubmerchantId = "123456",
                vendorName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Corporate,
                    accNum = "1092969901",
                    routingNum = "011075150",
                    checkNum = "123455"
                }
            });
            litleBatchRequest.addPhysicalCheckDebit(new physicalCheckDebit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            });

            var litleOverride = new litleRequest(memoryStream, configOverride);
            litleOverride.addBatch(litleBatchRequest);

            var litleResponse = litleOverride.sendToLitleWithStream();
            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);
            AssertWhileNext(litleResponse.nextBatchResponse, litleBatchResponse =>
            {
                AssertNextResponse("000", litleBatchResponse.nextSubmerchantCreditResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextPayFacCreditResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextVendorCreditResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextReserveCreditResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextPhysicalCheckCreditResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextSubmerchantDebitResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextPayFacDebitResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextVendorDebitResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextReserveDebitResponse, x => x.response);
                AssertNextResponse("000", litleBatchResponse.nextPhysicalCheckDebitResponse, x => x.response);
            });
        }
    }
}