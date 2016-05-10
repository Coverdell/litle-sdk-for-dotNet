using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;


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


    }
}
