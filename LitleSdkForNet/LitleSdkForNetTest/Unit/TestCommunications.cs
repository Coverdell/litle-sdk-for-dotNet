using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;
using System.Xml;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestCommunications
    {
        private Communications objectUnderTest;
        private IDictionary<string, StringBuilder> cache;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            cache = new Dictionary<string, StringBuilder>();
            objectUnderTest = new Communications(cache);
        }

        [Test]
        public void TestSettingProxyPropertiesToNullShouldTurnOffProxy()
        {
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("proxyHost", null);
            config.Add("proxyPort", null);

            Assert.IsFalse(objectUnderTest.isProxyOn(config));
        }

        [Test]
        public void TestNeuterXml()
        {
            var inputXml = @"
                <root>
                    <number>4111 1111 1111 1111</number>
                    <accNum>4111 1111 1111 1111</accNum>
                    <cardValidationNum>111</cardValidationNum>
                    <track>0x1111</track>
                    <routingNum>111111111</routingNum>
                    <checkNum>1111111</checkNum>
                    <password>P@$$w0rd</password>
                    <ssn>111-11-1111</ssn>
                    <cardAcceptorTaxId>111-11-1111</cardAcceptorTaxId>
                </root>";

            objectUnderTest.neuterXML(ref inputXml);

            var doc = new XmlDocument();
            doc.LoadXml(inputXml);
            var node = new Func<string, string>(xPath => doc.SelectSingleNode(xPath)?.InnerText);
            var message = new Func<string, string>(element => $"The \"{element}\" tag wasn't neutered as expected");
            var nodeAssert = new Action<string, string>((element, expectation) => 
                Assert.That(node($"root/{element}"), Is.EqualTo(expectation), message(element)));

            nodeAssert("number", "xxxxxxxxxxxxxxxx");
            nodeAssert("accNum", "xxxxxxxxxx");
            nodeAssert("cardValidationNum", "xxx");
            nodeAssert("track", "0x0000");
            nodeAssert("routingNum", "xxxxxxxxx");
            nodeAssert("checkNum", "xxxxxxxxx");
            nodeAssert("password", "xxxxxxxx");
            nodeAssert("ssn", "xxx-xx-xxxx");
            nodeAssert("cardAcceptorTaxId", "xxxxxxxxx");
        }
    }
}