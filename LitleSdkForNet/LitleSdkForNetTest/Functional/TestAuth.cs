using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestAuth : LitleOnlineTestBase
    {
        protected override Dictionary<string, string> SetupConfig() => new Dictionary<string, string>
        {
            {"url", "https://www.testlitle.com/sandbox/communicator/online"},
            {"reportGroup", "Default Report Group"},
            {"username", "DOTNET"},
            {"version", "8.13"},
            {"timeout", "5000"},
            {"merchantId", "101"},
            {"password", "TESTCASE"},
            {"printxml", "true"},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort},
            {"logFile", Settings.Default.logFile},
            {"neuterAccountNums", "true"}
        };

        [Test]
        public void SimpleAuthWithCard()
        {
            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "414100000000000000",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void SimpleAuthWithMpos()
        {
            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                mpos = new mposType
                {
                    ksn = "77853211300008E00016",
                    encryptedTrack =
                        "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD",
                    formatId = "30",
                    track1Status = 0,
                    track2Status = 0
                }
            });
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void AuthWithAmpersand()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "1",
                amount = 10010,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "John & Jane Smith",
                    addressLine1 = "1 Main St.",
                    city = "Burlington",
                    state = "MA",
                    zip = "01803-3747",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010000000009",
                    expDate = "0112",
                    cardValidationNum = "349"
                }
            });
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void SimpleAuthWithPaypal()
        {
            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "123456",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                paypal = new payPal
                {
                    payerId = "1234",
                    token = "1234",
                    transactionId = "123456"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleAuthWithApplepayAndSecondaryAmountAndWallet()
        {
            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "123456",
                amount = 110,
                secondaryAmount = 50,
                orderSource = orderSourceType.applepay,
                applepay = new applepayType
                {
                    header = new applepayHeaderType
                    {
                        applicationData = "454657413164",
                        ephemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        publicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        transactionId = "1234"
                    },
                    data = "user",
                    signature = "sign",
                    version = "1"
                },
                wallet = new wallet
                {
                    walletSourceTypeId = "123",
                    walletSourceType = walletWalletSourceType.MasterPass
                }
            });
            Assert.AreEqual("Insufficient Funds", response.message);
            Assert.AreEqual("110", response.applepayResponse.transactionAmount);
        }

        [Test]
        public void PosWithoutCapabilityAndEntryMode()
        {
            try //TODO: Should the test fail if the concern is successfully executed?
            {
                Litle.Authorize(new authorization
                {
                    reportGroup = "Planets",
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    pos = new pos {cardholderId = posCardholderIdTypeEnum.pin},
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                });
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void TrackData()
        {
            var response = Litle.Authorize(new authorization
            {
                id = "AX54321678",
                reportGroup = "RG27",
                orderId = "12z58743y1",
                amount = 12522L,
                orderSource = orderSourceType.retail,
                billToAddress = new contact {zip = "95032"},
                card = new cardType {track = "%B40000001^Doe/JohnP^06041...?;40001=0604101064200?"},
                pos = new pos
                {
                    capability = posCapabilityTypeEnum.magstripe,
                    entryMode = posEntryModeTypeEnum.completeread,
                    cardholderId = posCardholderIdTypeEnum.signature
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void TestAuthHandleSpecialCharacters()
        {
            var response = Litle.Authorize(new authorization
            {
                reportGroup = "<'&\">",
                orderId = "123456",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                paypal = new payPal
                {
                    payerId = "1234",
                    token = "1234",
                    transactionId = "123456"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void TestNotHavingTheLogFileSettingShouldDefaultItsValueToNull()
        {
            Config.Remove("logFile");

            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "414100000000000000",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("000", response.response);
            //TODO: What asserts test what the method name describes?
        }

        [Test]
        public void TestNeuterAccountNumsShouldDefaultToFalse()
        {
            Config.Remove("neuterAccountNums");

            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "414100000000000000",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("000", response.response);
            //TODO: What asserts test what the method name describes?
        }

        [Test]
        public void TestPrintxmlShouldDefaultToFalse()
        {
            Config.Remove("printxml");

            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "414100000000000000",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("000", response.response);
            //TODO: What asserts test what the method name describes?
        }

        [Test]
        public void TestWithAdvancedFraudCheck()
        {
            Config.Remove("printxml");

            var response = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "414100000000000000",
                    expDate = "1210"
                },
                advancedFraudChecks = new advancedFraudChecksType
                {
                    threatMetrixSessionId = "800",
                    customAttribute1 = "testAttribute1",
                    customAttribute2 = "testAttribute2",
                    customAttribute3 = "testAttribute3",
                    customAttribute4 = "testAttribute4",
                    customAttribute5 = "testAttribute5"
                }
            });
            Assert.AreEqual("000", response.response);
            //TODO: What asserts test what the method name describes?
        }
    }
}