using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert2AuthEnhanced : LitleOnlineTestBase
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
            {"logFile", null},
            {"neuterAccountNums", null},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort}
        };

        [Test]
        public void Test14()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "14",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010200000247",
                    expDate = "0812"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("2000", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("NO", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("GIFT", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test15()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "15",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5500000254444445",
                    expDate = "0312"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("2000", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test16()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "16",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5592106621450897",
                    expDate = "0312"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("0", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test17()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "17",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5590409551104142",
                    expDate = "0312"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("6500", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test18()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "18",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5587755665222179",
                    expDate = "0312"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("12200", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test19()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "19",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5445840176552850",
                    expDate = "0312"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("20000", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test20()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "20",
                amount = 3000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5390016478904678",
                    expDate = "0312"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("10050", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void Test21()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "21",
                amount = 5000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010201000246",
                    expDate = "0912"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.AFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void Test22()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "22",
                amount = 5000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010202000245",
                    expDate = "1111"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.MASSAFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void Test23()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "23",
                amount = 5000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010201000109",
                    expDate = "0412"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.AFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void Test24()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "24",
                amount = 5000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010202000108",
                    expDate = "0812"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.MASSAFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void Test25()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "25",
                amount = 5000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100204446270000",
                    expDate = "1112"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("BRA", response.enhancedAuthResponse.issuerCountry);
        }

        [Test]
        public void Test26()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "26",
                amount = 18698,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5194560012341234",
                    expDate = "1212"
                },
                allowPartialAuth = true,
                healthcareIIAS = new healthcareIIAS
                {
                    healthcareAmounts = new healthcareAmounts {totalHealthcareAmount = 20000},
                    IIASFlag = IIASFlagType.Y
                }
            });
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void Test27()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "27",
                amount = 18698,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5194560012341234",
                    expDate = "1212"
                },
                allowPartialAuth = true,
                healthcareIIAS = new healthcareIIAS
                {
                    healthcareAmounts = new healthcareAmounts
                    {
                        totalHealthcareAmount = 15000,
                        RxAmount = 16000
                    },
                    IIASFlag = IIASFlagType.Y
                }
            });
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void Test28()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "28",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5194560012341234",
                    expDate = "1212"
                },
                allowPartialAuth = true,
                healthcareIIAS = new healthcareIIAS
                {
                    healthcareAmounts = new healthcareAmounts
                    {
                        totalHealthcareAmount = 15000,
                        RxAmount = 3698
                    },
                    IIASFlag = IIASFlagType.Y
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test29()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "29",
                amount = 18699,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4024720001231239",
                    expDate = "1212"
                },
                allowPartialAuth = true,
                healthcareIIAS = new healthcareIIAS
                {
                    healthcareAmounts = new healthcareAmounts
                    {
                        totalHealthcareAmount = 31000,
                        RxAmount = 1000,
                        visionAmount = 19901,
                        clinicOtherAmount = 9050,
                        dentalAmount = 1049
                    },
                    IIASFlag = IIASFlagType.Y
                }
            });
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void Test30()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "30",
                amount = 20000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4024720001231239",
                    expDate = "1212"
                },
                allowPartialAuth = true,
                healthcareIIAS = new healthcareIIAS
                {
                    healthcareAmounts = new healthcareAmounts
                    {
                        totalHealthcareAmount = 20000,
                        RxAmount = 1000,
                        visionAmount = 19901,
                        clinicOtherAmount = 9050,
                        dentalAmount = 1049
                    },
                    IIASFlag = IIASFlagType.Y
                }
            });
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void Test31()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "31",
                amount = 25000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4024720001231239",
                    expDate = "1212"
                },
                allowPartialAuth = true,
                healthcareIIAS = new healthcareIIAS
                {
                    healthcareAmounts = new healthcareAmounts
                    {
                        totalHealthcareAmount = 18699,
                        RxAmount = 1000,
                        visionAmount = 15099
                    },
                    IIASFlag = IIASFlagType.Y
                }
            });
            Assert.AreEqual("010", response.response);
            Assert.AreEqual("Partially Approved", response.message);
            Assert.AreEqual("18699", response.approvedAmount);
        }
    }
}