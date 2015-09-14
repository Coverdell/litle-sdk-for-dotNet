using System.Collections.Generic;
using Litle.Sdk.Properties;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using Litle.Sdk.Test.Unit;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestAuth : TestBase
    {
        private readonly Dictionary<string, string> _config = new Dictionary<string, string>
        {
            {"url", "https://www.testlitle.com/sandbox/communicator/online"},
            {"reportGroup", "Default Report Group"},
            {"username", "DOTNET"},
            {"version", "8.13"},
            {"timeout", "65"},
            {"merchantId", "101"},
            {"password", "TESTCASE"},
            {"printxml", "true"},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort},
            {"logFile", Settings.Default.logFile},
            {"neuterAccountNums", "true"}
        };

        public override void SetUpLitle()
        {
            Litle = new LitleOnline(_config);
        }

        [Test]
        public void SimpleAuthWithCard()
        {
            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "414100000000000000",
                    ExpDate = "1210"
                },
                CustomBilling = new CustomBilling {Phone = "1112223333"}
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }

        [Test]
        public void SimpleAuthWithMpos()
        {
            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                Mpos = new MposType
                {
                    Ksn = "77853211300008E00016",
                    EncryptedTrack =
                        "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD",
                    FormatId = "30",
                    Track1Status = 0,
                    Track2Status = 0
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }

        [Test]
        public void AuthWithAmpersand()
        {
            var authorization = new Authorization
            {
                ID = "",
                OrderId = "1",
                Amount = 10010,
                OrderSource = OrderSourceType.Ecommerce,
                BillToAddress = new Contact
                {
                    Name = "John & Jane Smith",
                    AddressLine1 = "1 Main St.",
                    City = "Burlington",
                    State = "MA",
                    Zip = "01803-3747",
                    Country = CountryTypeEnum.US
                },
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "4457010000000009",
                    ExpDate = "0112",
                    CardValidationNum = "349"
                }
            };
            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }

        [Test]
        public void SimpleAuthWithPaypal()
        {
            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "123456",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Paypal = new PayPal {PayerId = "1234", Token = "1234", TransactionId = "123456"}
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void SimpleAuthWithApplepayAndSecondaryAmountAndWallet()
        {
            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "123456",
                Amount = 110,
                SecondaryAmount = 50,
                OrderSource = OrderSourceType.Applepay,
                Applepay = new ApplepayType
                {
                    Header = new ApplepayHeaderType
                    {
                        ApplicationData = "454657413164",
                        EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        TransactionId = "1234"
                    },
                    Data = "user",
                    Signature = "sign",
                    Version = "1"
                },
                Wallet = new Wallet
                {
                    WalletSourceTypeId = "123",
                    WalletSourceType = WalletWalletSourceType.MasterPass
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("Insufficient Funds", response.Message);
            Assert.AreEqual("110", response.ApplepayResponse.TransactionAmount);
        }

        [Test]
        public void PosWithoutCapabilityAndEntryMode()
        {
            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Pos = new Pos {CardholderId = PosCardholderIdTypeEnum.Pin},
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "4100000000000002",
                    ExpDate = "1210"
                }
            };

            try
            {
                Litle.Authorize(authorization);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void TrackData()
        {
            var authorization = new Authorization
            {
                ID = "AX54321678",
                ReportGroup = "RG27",
                OrderId = "12z58743y1",
                Amount = 12522L,
                OrderSource = OrderSourceType.Retail,
                BillToAddress = new Contact {Zip = "95032"},
                Card = new CardType
                {
                    Track = "%B40000001^Doe/JohnP^06041...?;40001=0604101064200?"
                },
                Pos = new Pos
                {
                    Capability = PosCapabilityTypeEnum.Magstripe,
                    EntryMode = PosEntryModeTypeEnum.Completeread,
                    CardholderId = PosCardholderIdTypeEnum.Signature
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void TestAuthHandleSpecialCharacters()
        {
            var authorization = new Authorization
            {
                ReportGroup = "<'&\">",
                OrderId = "123456",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Paypal = new PayPal
                {
                    PayerId = "1234",
                    Token = "1234",
                    TransactionId = "123456"
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void TestNotHavingTheLogFileSettingShouldDefaultItsValueToNull()
        {
            _config.Remove("logFile");

            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "414100000000000000",
                    ExpDate = "1210"
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }

        [Test]
        public void TestNeuterAccountNumsShouldDefaultToFalse()
        {
            _config.Remove("neuterAccountNums");

            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "414100000000000000",
                    ExpDate = "1210"
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }

        [Test]
        public void TestPrintxmlShouldDefaultToFalse()
        {
            _config.Remove("printxml");

            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "414100000000000000",
                    ExpDate = "1210"
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }

        [Test]
        public void TestWithAdvancedFraudCheck()
        {
            _config.Remove("printxml");

            var authorization = new Authorization
            {
                ReportGroup = "Planets",
                OrderId = "12344",
                Amount = 106,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "414100000000000000",
                    ExpDate = "1210"
                },
                AdvancedFraudChecks = new AdvancedFraudChecksType
                {
                    ThreatMetrixSessionId = "800",
                    CustomAttribute1 = "testAttribute1",
                    CustomAttribute2 = "testAttribute2",
                    CustomAttribute3 = "testAttribute3",
                    CustomAttribute4 = "testAttribute4",
                    CustomAttribute5 = "testAttribute5"
                }
            };

            var response = Litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
        }
    }
}