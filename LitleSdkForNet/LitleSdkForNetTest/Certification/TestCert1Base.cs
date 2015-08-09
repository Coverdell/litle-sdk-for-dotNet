using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    class TestCert1Base
    {
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void setUp()
        {
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("url", "https://www.testlitle.com/sandbox/communicator/online");
            config.Add("reportGroup", "Default Report Group");
            config.Add("username", "DOTNET");
            config.Add("version", "9.00");
            config.Add("timeout", "65");
            config.Add("merchantId", "101");
            config.Add("password", "TESTCASE");
            config.Add("printxml", "true");
            config.Add("logFile", null);
            config.Add("neuterAccountNums", null);
            config.Add("proxyHost", Properties.Settings.Default.proxyHost);
            config.Add("proxyPort", Properties.Settings.Default.proxyPort);
            litle = new LitleOnline(config);
        }


        [Test]
        public void Test1Auth()
        {
           
            Authorization authorization = new Authorization();
            authorization.OrderId = "1";
            authorization.Amount = 10010;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "John Smith";
            contact.AddressLine1 = "1 Main St.";
            contact.City = "Burlington";
            contact.State = "MA";
            contact.Zip = "01803-3747";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();            
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010000000009";
            card.ExpDate = "0112";
            card.CardValidationNum = "349";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("11111 ", response.AuthCode);
            Assert.AreEqual("01", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

            Capture capture = new Capture();
            capture.LitleTxnId = response.LitleTxnId;
            CaptureResponse captureResponse = litle.Capture(capture);
            Assert.AreEqual("000", captureResponse.Response);
            Assert.AreEqual("Approved", captureResponse.Message);

            Credit credit = new Credit();
            credit.LitleTxnId = captureResponse.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn(); 
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void Test1AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "1";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "John Smith";
            contact.AddressLine1 = "1 Main St.";
            contact.City = "Burlington";
            contact.State = "MA";
            contact.Zip = "01803-3747";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010000000009";
            card.ExpDate = "0112";
            card.CardValidationNum = "349";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("11111 ", response.AuthCode);
            Assert.AreEqual("01", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test1Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "1";
            sale.Amount = 10010;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "John Smith";
            contact.AddressLine1 = "1 Main St.";
            contact.City = "Burlington";
            contact.State = "MA";
            contact.Zip = "01803-3747";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010000000009";
            card.ExpDate = "0112";
            card.CardValidationNum = "349";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("11111 ", response.AuthCode);
            Assert.AreEqual("01", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

            Credit credit = new Credit();
            credit.LitleTxnId = response.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);


            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000",voidResponse.Response);
            Assert.AreEqual("Approved",voidResponse.Message);
        }

        [Test]
        public void test2Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "2";
            authorization.Amount = 20020;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Mike J. Hammer";
            contact.AddressLine1 = "2 Main St.";
            contact.AddressLine2 = "Apt. 222";
            contact.City = "Riverside";
            contact.State = "RI";
            contact.Zip = "02915";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010000000003";
            card.ExpDate = "0212";
            card.CardValidationNum = "261";
            authorization.Card = card;
            FraudCheckType authenticationvalue = new FraudCheckType();
            authenticationvalue.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            authorization.CardholderAuthentication = authenticationvalue;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("22222", response.AuthCode);
            Assert.AreEqual("10", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

            Capture capture = new Capture();
            capture.LitleTxnId = response.LitleTxnId;
            CaptureResponse captureresponse = litle.Capture(capture);
            Assert.AreEqual("000", captureresponse.Response);
            Assert.AreEqual("Approved", captureresponse.Message);

            Credit credit = new Credit();
            credit.LitleTxnId = captureresponse.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000",voidResponse.Response);
            Assert.AreEqual("Approved",voidResponse.Message);
        }

        [Test]
        public void test2AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "2";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Mike J. Hammer";
            contact.AddressLine1 = "2 Main St.";
            contact.AddressLine2 = "Apt. 222";
            contact.City = "Riverside";
            contact.State = "RI";
            contact.Zip = "02915";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010000000003";
            card.ExpDate = "0212";
            card.CardValidationNum = "261";
            authorization.Card = card;
            FraudCheckType authenticationvalue = new FraudCheckType();
            authenticationvalue.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            authorization.CardholderAuthentication = authenticationvalue;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("22222", response.AuthCode);
            Assert.AreEqual("10", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

        }

        [Test]
        public void test2Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "2";
            sale.Amount = 20020;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Mike J. Hammer";
            contact.AddressLine1 = "2 Main St.";
            contact.AddressLine2 = "Apt. 222";
            contact.City = "Riverside";
            contact.State = "RI";
            contact.Zip = "02915";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010000000003";
            card.ExpDate = "0212";
            card.CardValidationNum = "261";
            sale.Card = card;
            FraudCheckType authenticationvalue = new FraudCheckType();
            authenticationvalue.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            sale.CardholderAuthentication = authenticationvalue;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("22222", response.AuthCode);
            Assert.AreEqual("10", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

            Credit credit = new Credit();
            credit.LitleTxnId = response.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test3Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "3";
            authorization.Amount = 30030;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Eileen Jones";
            contact.AddressLine1 = "3 Main St.";
            contact.City = "Bloomfield";
            contact.State = "CT";
            contact.Zip = "06002";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010000000003";
            card.ExpDate = "0312";
            card.CardValidationNum = "758";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("33333", response.AuthCode);
            Assert.AreEqual("10", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

            Capture capture = new Capture();
            capture.LitleTxnId = response.LitleTxnId;
            CaptureResponse captureResponse = litle.Capture(capture);
            Assert.AreEqual("000", captureResponse.Response);
            Assert.AreEqual("Approved", captureResponse.Message);

            Credit credit = new Credit();
            credit.LitleTxnId = captureResponse.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test3AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "3";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Eileen Jones";
            contact.AddressLine1 = "3 Main St.";
            contact.City = "Bloomfield";
            contact.State = "CT";
            contact.Zip = "06002";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010000000003";
            card.ExpDate = "0312";
            card.CardValidationNum = "758";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("33333", response.AuthCode);
            Assert.AreEqual("10", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

        }

        [Test]
        public void test3Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "3";
            sale.Amount = 30030;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Eileen Jones";
            contact.AddressLine1 = "3 Main St.";
            contact.City = "Bloomfield";
            contact.State = "CT";
            contact.Zip = "06002";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010000000003";
            card.ExpDate = "0312";
            card.CardValidationNum = "758";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("33333", response.AuthCode);
            Assert.AreEqual("10", response.FraudResult.AvsResult);
            Assert.AreEqual("M", response.FraudResult.CardValidationResult);

            Credit credit = new Credit();
            credit.LitleTxnId = response.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test4Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "4";
            authorization.Amount = 40040;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Bob Black";
            contact.AddressLine1 = "4 Main St.";
            contact.City = "Laurel";
            contact.State = "MD";
            contact.Zip = "20708";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001000000005";
            card.ExpDate = "0412";
            card.CardValidationNum = "758";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("44444", response.AuthCode);
            Assert.AreEqual("12", response.FraudResult.AvsResult);

            Capture capture = new Capture();
            capture.LitleTxnId = response.LitleTxnId;
            CaptureResponse captureresponse = litle.Capture(capture);
            Assert.AreEqual("000", captureresponse.Response);
            Assert.AreEqual("Approved", captureresponse.Message);

            Credit credit = new Credit();
            credit.LitleTxnId = captureresponse.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test4AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "4";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Bob Black";
            contact.AddressLine1 = "4 Main St.";
            contact.City = "Laurel";
            contact.State = "MD";
            contact.Zip = "20708";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001000000005";
            card.ExpDate = "0412";
            card.CardValidationNum = "758";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("44444", response.AuthCode);
            Assert.AreEqual("12", response.FraudResult.AvsResult);
        }

        [Test]
        public void test4Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "4";
            sale.Amount = 40040;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Bob Black";
            contact.AddressLine1 = "4 Main St.";
            contact.City = "Laurel";
            contact.State = "MD";
            contact.Zip = "20708";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001000000005";
            card.ExpDate = "0412";
            card.CardValidationNum = "758";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("44444", response.AuthCode);
            Assert.AreEqual("12", response.FraudResult.AvsResult);

            Credit credit = new Credit();
            credit.LitleTxnId = response.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test5Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "5";
            authorization.Amount = 50050;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010200000007";
            card.ExpDate = "0512";
            card.CardValidationNum = "463";
            authorization.Card = card;
            FraudCheckType authenticationvalue = new FraudCheckType();
            authenticationvalue.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            authorization.CardholderAuthentication = authenticationvalue;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("55555 ", response.AuthCode);
            Assert.AreEqual("32", response.FraudResult.AvsResult);
            Assert.AreEqual("N", response.FraudResult.CardValidationResult);

            Capture capture = new Capture();
            capture.LitleTxnId = response.LitleTxnId;
            CaptureResponse captureresponse = litle.Capture(capture);
            Assert.AreEqual("000", captureresponse.Response);
            Assert.AreEqual("Approved", captureresponse.Message);

            Credit credit = new Credit();
            credit.LitleTxnId = captureresponse.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test5AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "5";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010200000007";
            card.ExpDate = "0512";
            card.CardValidationNum = "463";
            authorization.Card = card;
            FraudCheckType authenticationvalue = new FraudCheckType();
            authenticationvalue.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            authorization.CardholderAuthentication = authenticationvalue;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("55555 ", response.AuthCode);
            Assert.AreEqual("32", response.FraudResult.AvsResult);
            Assert.AreEqual("N", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test5Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "5";
            sale.Amount = 50050;
            sale.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010200000007";
            card.ExpDate = "0512";
            card.CardValidationNum = "463";
            sale.Card = card;
            FraudCheckType authenticationvalue = new FraudCheckType();
            authenticationvalue.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            sale.CardholderAuthentication = authenticationvalue;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("55555 ", response.AuthCode);
            Assert.AreEqual("32", response.FraudResult.AvsResult);
            Assert.AreEqual("N", response.FraudResult.CardValidationResult);

            Credit credit = new Credit();
            credit.LitleTxnId = response.LitleTxnId;
            CreditResponse creditResponse = litle.Credit(credit);
            Assert.AreEqual("000", creditResponse.Response);
            Assert.AreEqual("Approved", creditResponse.Message);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = creditResponse.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("000", voidResponse.Response);
            Assert.AreEqual("Approved", voidResponse.Message);
        }

        [Test]
        public void test6Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "6";
            authorization.Amount = 60060;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Joe Green";
            contact.AddressLine1 = "6 Main St.";
            contact.City = "Derry";
            contact.State = "NH";
            contact.Zip = "03038";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010100000008";
            card.ExpDate = "0612";
            card.CardValidationNum = "992";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("110", response.Response);
            Assert.AreEqual("Insufficient Funds", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("P", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test6Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "6";
            sale.Amount = 60060;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Joe Green";
            contact.AddressLine1 = "6 Main St.";
            contact.City = "Derry";
            contact.State = "NH";
            contact.Zip = "03038";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010100000008";
            card.ExpDate = "0612";
            card.CardValidationNum = "992";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("110", response.Response);
            Assert.AreEqual("Insufficient Funds", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("P", response.FraudResult.CardValidationResult);

            VoidTxn newvoid = new VoidTxn();
            newvoid.LitleTxnId = response.LitleTxnId;
            LitleOnlineResponseTransactionResponseVoidResponse voidResponse = litle.DoVoid(newvoid);
            Assert.AreEqual("360", voidResponse.Response);
            Assert.AreEqual("No transaction found with specified litleTxnId", voidResponse.Message);
        }

        [Test]
        public void test7Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "7";
            authorization.Amount = 70070;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Jane Murray";
            contact.AddressLine1 = "7 Main St.";
            contact.City = "Amesbury";
            contact.State = "MA";
            contact.Zip = "01913";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010100000002";
            card.ExpDate = "0712";
            card.CardValidationNum = "251";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("301", response.Response);
            Assert.AreEqual("Invalid Account Number", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("N", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test7AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "7";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Jane Murray";
            contact.AddressLine1 = "7 Main St.";
            contact.City = "Amesbury";
            contact.State = "MA";
            contact.Zip = "01913";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010100000002";
            card.ExpDate = "0712";
            card.CardValidationNum = "251";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("301", response.Response);
            Assert.AreEqual("Invalid Account Number", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("N", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test7Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "7";
            sale.Amount = 70070;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Jane Murray";
            contact.AddressLine1 = "7 Main St.";
            contact.City = "Amesbury";
            contact.State = "MA";
            contact.Zip = "01913";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010100000002";
            card.ExpDate = "0712";
            card.CardValidationNum = "251";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("301", response.Response);
            Assert.AreEqual("Invalid Account Number", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("N", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test8Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "8";
            authorization.Amount = 80080;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Mark Johnson";
            contact.AddressLine1 = "8 Main St.";
            contact.City = "Manchester";
            contact.State = "NH";
            contact.Zip = "03101";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010100000002";
            card.ExpDate = "0812";
            card.CardValidationNum = "184";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("123", response.Response);
            Assert.AreEqual("Call Discover", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("P", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test8AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "8";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Mark Johnson";
            contact.AddressLine1 = "8 Main St.";
            contact.City = "Manchester";
            contact.State = "NH";
            contact.Zip = "03101";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010100000002";
            card.ExpDate = "0812";
            card.CardValidationNum = "184";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("123", response.Response);
            Assert.AreEqual("Call Discover", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("P", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test8Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "8";
            sale.Amount = 80080;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "Mark Johnson";
            contact.AddressLine1 = "8 Main St.";
            contact.City = "Manchester";
            contact.State = "NH";
            contact.Zip = "03101";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010100000002";
            card.ExpDate = "0812";
            card.CardValidationNum = "184";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("123", response.Response);
            Assert.AreEqual("Call Discover", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
            Assert.AreEqual("P", response.FraudResult.CardValidationResult);
        }

        [Test]
        public void test9Auth()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "9";
            authorization.Amount = 90090;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "James Miller";
            contact.AddressLine1 = "9 Main St.";
            contact.City = "Boston";
            contact.State = "MA";
            contact.Zip = "02134";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001010000003";
            card.ExpDate = "0912";
            card.CardValidationNum = "0421";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("303", response.Response);
            Assert.AreEqual("Pick Up Card", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
        }

        [Test]
        public void test9AVS()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "9";
            authorization.Amount = 0;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "James Miller";
            contact.AddressLine1 = "9 Main St.";
            contact.City = "Boston";
            contact.State = "MA";
            contact.Zip = "02134";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001010000003";
            card.ExpDate = "0912";
            card.CardValidationNum = "0421";
            authorization.Card = card;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("303", response.Response);
            Assert.AreEqual("Pick Up Card", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
        }

        [Test]
        public void test9Sale()
        {
            Sale sale = new Sale();
            sale.OrderId = "9";
            sale.Amount = 90090;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "James Miller";
            contact.AddressLine1 = "9 Main St.";
            contact.City = "Boston";
            contact.State = "MA";
            contact.Zip = "02134";
            contact.Country = CountryTypeEnum.US;
            sale.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001010000003";
            card.ExpDate = "0912";
            card.CardValidationNum = "0421";
            sale.Card = card;

            SaleResponse response = litle.Sale(sale);
            Assert.AreEqual("303", response.Response);
            Assert.AreEqual("Pick Up Card", response.Message);
            Assert.AreEqual("34", response.FraudResult.AvsResult);
        }

        [Test]
        public void test10()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "10";
            authorization.Amount = 40000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010140000141";
            card.ExpDate = "0912";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("010", response.Response);
            Assert.AreEqual("Partially Approved", response.Message);
            Assert.AreEqual("32000", response.ApprovedAmount);
        }

        [Test]
        public void test11()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "11";
            authorization.Amount = 60000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010140000004";
            card.ExpDate = "1111";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("010", response.Response);
            Assert.AreEqual("Partially Approved", response.Message);
            Assert.AreEqual("48000", response.ApprovedAmount);
        }

        [Test]
        public void test12()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "12";
            authorization.Amount = 50000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.AX;
            card.Number = "375001014000009";
            card.ExpDate = "0412";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("010", response.Response);
            Assert.AreEqual("Partially Approved", response.Message);
            Assert.AreEqual("40000", response.ApprovedAmount);
        }

        [Test]
        public void test13()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "13";
            authorization.Amount = 15000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.DI;
            card.Number = "6011010140000004";
            card.ExpDate = "0812";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;

            AuthorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("010", response.Response);
            Assert.AreEqual("Partially Approved", response.Message);
            Assert.AreEqual("12000", response.ApprovedAmount);

        }
            
    }
}
