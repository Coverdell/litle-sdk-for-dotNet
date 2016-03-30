using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert1Base : LitleOnlineTestBase
    {
        protected override Dictionary<string, string> SetupConfig() => new Dictionary<string, string>
        {
            {"url", "https://www.testlitle.com/sandbox/communicator/online"},
            {"reportGroup", "Default Report Group"},
            {"username", "DOTNET"},
            {"version", "9.00"},
            {"timeout", Settings.Default.timeout},
            {"merchantId", "101"},
            {"password", "TESTCASE"},
            {"printxml", "true"},
            {"logFile", null},
            {"neuterAccountNums", null},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort}
        };

        [Test]
        public void Test1Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "1",
                amount = 10010,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "John Smith",
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
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("11111 ", response.authCode);
            Assert.AreEqual("01", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);

            var captureResponse = Litle.Capture(new capture {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", captureResponse.response);
            Assert.AreEqual("Approved", captureResponse.message);

            var creditResponse = Litle.Credit(new credit {litleTxnId = captureResponse.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test1Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "1",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "John Smith",
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
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("11111 ", response.authCode);
            Assert.AreEqual("01", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test1Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "1",
                amount = 10010,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "John Smith",
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
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("11111 ", response.authCode);
            Assert.AreEqual("01", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);

            var creditResponse = Litle.Credit(new credit {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test2Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "2",
                amount = 20020,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mike J. Hammer",
                    addressLine1 = "2 Main St.",
                    addressLine2 = "Apt. 222",
                    city = "Riverside",
                    state = "RI",
                    zip = "02915",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010000000003",
                    expDate = "0212",
                    cardValidationNum = "261"
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("22222", response.authCode);
            Assert.AreEqual("10", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);

            var captureresponse = Litle.Capture(new capture {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", captureresponse.response);
            Assert.AreEqual("Approved", captureresponse.message);

            var creditResponse = Litle.Credit(new credit {litleTxnId = captureresponse.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test2Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "2",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mike J. Hammer",
                    addressLine1 = "2 Main St.",
                    addressLine2 = "Apt. 222",
                    city = "Riverside",
                    state = "RI",
                    zip = "02915",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010000000003",
                    expDate = "0212",
                    cardValidationNum = "261"
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("22222", response.authCode);
            Assert.AreEqual("10", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test2Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "2",
                amount = 20020,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mike J. Hammer",
                    addressLine1 = "2 Main St.",
                    addressLine2 = "Apt. 222",
                    city = "Riverside",
                    state = "RI",
                    zip = "02915",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010000000003",
                    expDate = "0212",
                    cardValidationNum = "261"
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("22222", response.authCode);
            Assert.AreEqual("10", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);

            var creditResponse = Litle.Credit(new credit {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test3Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "3",
                amount = 30030,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Eileen Jones",
                    addressLine1 = "3 Main St.",
                    city = "Bloomfield",
                    state = "CT",
                    zip = "06002",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010000000003",
                    expDate = "0312",
                    cardValidationNum = "758"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("33333", response.authCode);
            Assert.AreEqual("10", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);

            var captureResponse = Litle.Capture(new capture {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", captureResponse.response);
            Assert.AreEqual("Approved", captureResponse.message);

            var creditResponse = Litle.Credit(new credit {litleTxnId = captureResponse.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test3Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "3",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Eileen Jones",
                    addressLine1 = "3 Main St.",
                    city = "Bloomfield",
                    state = "CT",
                    zip = "06002",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010000000003",
                    expDate = "0312",
                    cardValidationNum = "758"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("33333", response.authCode);
            Assert.AreEqual("10", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test3Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "3",
                amount = 30030,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Eileen Jones",
                    addressLine1 = "3 Main St.",
                    city = "Bloomfield",
                    state = "CT",
                    zip = "06002",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010000000003",
                    expDate = "0312",
                    cardValidationNum = "758"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("33333", response.authCode);
            Assert.AreEqual("10", response.fraudResult.avsResult);
            Assert.AreEqual("M", response.fraudResult.cardValidationResult);

            var creditResponse = Litle.Credit(new credit {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test4Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "4",
                amount = 40040,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Bob Black",
                    addressLine1 = "4 Main St.",
                    city = "Laurel",
                    state = "MD",
                    zip = "20708",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001000000005",
                    expDate = "0412",
                    cardValidationNum = "758"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("44444", response.authCode);
            Assert.AreEqual("12", response.fraudResult.avsResult);

            var captureresponse = Litle.Capture(new capture {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", captureresponse.response);
            Assert.AreEqual("Approved", captureresponse.message);

            var creditResponse = Litle.Credit(new credit {litleTxnId = captureresponse.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test4Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "4",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Bob Black",
                    addressLine1 = "4 Main St.",
                    city = "Laurel",
                    state = "MD",
                    zip = "20708",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001000000005",
                    expDate = "0412",
                    cardValidationNum = "758"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("44444", response.authCode);
            Assert.AreEqual("12", response.fraudResult.avsResult);
        }

        [Test]
        public void Test4Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "4",
                amount = 40040,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Bob Black",
                    addressLine1 = "4 Main St.",
                    city = "Laurel",
                    state = "MD",
                    zip = "20708",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001000000005",
                    expDate = "0412",
                    cardValidationNum = "758"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("44444", response.authCode);
            Assert.AreEqual("12", response.fraudResult.avsResult);

            var creditResponse = Litle.Credit(new credit {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test5Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "5",
                amount = 50050,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010200000007",
                    expDate = "0512",
                    cardValidationNum = "463"
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("55555 ", response.authCode);
            Assert.AreEqual("32", response.fraudResult.avsResult);
            Assert.AreEqual("N", response.fraudResult.cardValidationResult);

            var captureresponse = Litle.Capture(new capture {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", captureresponse.response);
            Assert.AreEqual("Approved", captureresponse.message);

            var creditResponse = Litle.Credit(new credit {litleTxnId = captureresponse.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test5Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "5",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010200000007",
                    expDate = "0512",
                    cardValidationNum = "463"
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("55555 ", response.authCode);
            Assert.AreEqual("32", response.fraudResult.avsResult);
            Assert.AreEqual("N", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test5Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "5",
                amount = 50050,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010200000007",
                    expDate = "0512",
                    cardValidationNum = "463"
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("55555 ", response.authCode);
            Assert.AreEqual("32", response.fraudResult.avsResult);
            Assert.AreEqual("N", response.fraudResult.cardValidationResult);

            var creditResponse = Litle.Credit(new credit {litleTxnId = response.litleTxnId});
            Assert.AreEqual("000", creditResponse.response);
            Assert.AreEqual("Approved", creditResponse.message);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = creditResponse.litleTxnId});
            Assert.AreEqual("000", voidResponse.response);
            Assert.AreEqual("Approved", voidResponse.message);
        }

        [Test]
        public void Test6Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "6",
                amount = 60060,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Joe Green",
                    addressLine1 = "6 Main St.",
                    city = "Derry",
                    state = "NH",
                    zip = "03038",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010100000008",
                    expDate = "0612",
                    cardValidationNum = "992"
                }
            });
            Assert.AreEqual("110", response.response);
            Assert.AreEqual("Insufficient Funds", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("P", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test6Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "6",
                amount = 60060,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Joe Green",
                    addressLine1 = "6 Main St.",
                    city = "Derry",
                    state = "NH",
                    zip = "03038",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010100000008",
                    expDate = "0612",
                    cardValidationNum = "992"
                }
            });
            Assert.AreEqual("110", response.response);
            Assert.AreEqual("Insufficient Funds", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("P", response.fraudResult.cardValidationResult);

            var voidResponse = Litle.DoVoid(new voidTxn {litleTxnId = response.litleTxnId});
            Assert.AreEqual("360", voidResponse.response);
            Assert.AreEqual("No transaction found with specified litleTxnId", voidResponse.message);
        }

        [Test]
        public void Test7Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "7",
                amount = 70070,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Jane Murray",
                    addressLine1 = "7 Main St.",
                    city = "Amesbury",
                    state = "MA",
                    zip = "01913",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010100000002",
                    expDate = "0712",
                    cardValidationNum = "251"
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("N", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test7Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "7",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Jane Murray",
                    addressLine1 = "7 Main St.",
                    city = "Amesbury",
                    state = "MA",
                    zip = "01913",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010100000002",
                    expDate = "0712",
                    cardValidationNum = "251"
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("N", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test7Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "7",
                amount = 70070,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Jane Murray",
                    addressLine1 = "7 Main St.",
                    city = "Amesbury",
                    state = "MA",
                    zip = "01913",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010100000002",
                    expDate = "0712",
                    cardValidationNum = "251"
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("N", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test8Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "8",
                amount = 80080,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mark Johnson",
                    addressLine1 = "8 Main St.",
                    city = "Manchester",
                    state = "NH",
                    zip = "03101",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010100000002",
                    expDate = "0812",
                    cardValidationNum = "184"
                }
            });
            Assert.AreEqual("123", response.response);
            Assert.AreEqual("Call Discover", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("P", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test8Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "8",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mark Johnson",
                    addressLine1 = "8 Main St.",
                    city = "Manchester",
                    state = "NH",
                    zip = "03101",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010100000002",
                    expDate = "0812",
                    cardValidationNum = "184"
                }
            });
            Assert.AreEqual("123", response.response);
            Assert.AreEqual("Call Discover", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("P", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test8Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "8",
                amount = 80080,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mark Johnson",
                    addressLine1 = "8 Main St.",
                    city = "Manchester",
                    state = "NH",
                    zip = "03101",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010100000002",
                    expDate = "0812",
                    cardValidationNum = "184"
                }
            });
            Assert.AreEqual("123", response.response);
            Assert.AreEqual("Call Discover", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
            Assert.AreEqual("P", response.fraudResult.cardValidationResult);
        }

        [Test]
        public void Test9Auth()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "9",
                amount = 90090,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "James Miller",
                    addressLine1 = "9 Main St.",
                    city = "Boston",
                    state = "MA",
                    zip = "02134",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001010000003",
                    expDate = "0912",
                    cardValidationNum = "0421"
                }
            });
            Assert.AreEqual("303", response.response);
            Assert.AreEqual("Pick Up Card", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
        }

        [Test]
        public void Test9Avs()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "9",
                amount = 0,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "James Miller",
                    addressLine1 = "9 Main St.",
                    city = "Boston",
                    state = "MA",
                    zip = "02134",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001010000003",
                    expDate = "0912",
                    cardValidationNum = "0421"
                }
            });
            Assert.AreEqual("303", response.response);
            Assert.AreEqual("Pick Up Card", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
        }

        [Test]
        public void Test9Sale()
        {
            var response = Litle.Sale(new sale
            {
                orderId = "9",
                amount = 90090,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "James Miller",
                    addressLine1 = "9 Main St.",
                    city = "Boston",
                    state = "MA",
                    zip = "02134",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001010000003",
                    expDate = "0912",
                    cardValidationNum = "0421"
                }
            });
            Assert.AreEqual("303", response.response);
            Assert.AreEqual("Pick Up Card", response.message);
            Assert.AreEqual("34", response.fraudResult.avsResult);
        }

        [Test]
        public void Test10()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "10",
                amount = 40000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4457010140000141",
                    expDate = "0912"
                },
                allowPartialAuth = true
            });
            Assert.AreEqual("010", response.response);
            Assert.AreEqual("Partially Approved", response.message);
            Assert.AreEqual("32000", response.approvedAmount);
        }

        [Test]
        public void Test11()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "11",
                amount = 60000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.MC,
                    number = "5112010140000004",
                    expDate = "1111"
                },
                allowPartialAuth = true
            });
            Assert.AreEqual("010", response.response);
            Assert.AreEqual("Partially Approved", response.message);
            Assert.AreEqual("48000", response.approvedAmount);
        }

        [Test]
        public void Test12()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "12",
                amount = 50000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.AX,
                    number = "375001014000009",
                    expDate = "0412"
                },
                allowPartialAuth = true
            });
            Assert.AreEqual("010", response.response);
            Assert.AreEqual("Partially Approved", response.message);
            Assert.AreEqual("40000", response.approvedAmount);
        }

        [Test]
        public void Test13()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "13",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.DI,
                    number = "6011010140000004",
                    expDate = "0812"
                },
                allowPartialAuth = true
            });
            Assert.AreEqual("010", response.response);
            Assert.AreEqual("Partially Approved", response.message);
            Assert.AreEqual("12000", response.approvedAmount);
        }
    }
}