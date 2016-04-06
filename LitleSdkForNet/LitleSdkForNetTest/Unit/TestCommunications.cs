using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCommunications
    {
        [Test]
        public void TestSettingProxyPropertiesToNullShouldTurnOffProxy()
        {
            var config = new Dictionary<string, string> {{"proxyHost", null}, {"proxyPort", null}};
            var communications = new Communications(new Dictionary<string, StringBuilder>());
            Assert.IsFalse(communications.isProxyOn(config));
        }
    }
}