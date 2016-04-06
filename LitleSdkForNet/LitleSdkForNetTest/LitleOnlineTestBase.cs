using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test
{
    internal class LitleOnlineTestBase
    {
        protected LitleOnline Litle;
        protected Dictionary<string, string> Config { get; private set; }
        protected IDictionary<string, StringBuilder> Cache { get; private set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            Cache = SetupCache();
            Config = SetupConfig();
            Litle = new LitleOnline(Cache, Config);
        }

        protected virtual Dictionary<string, string> SetupConfig() => LitleOnline.DefaultConfig;
        protected virtual IDictionary<string, StringBuilder> SetupCache() => new Dictionary<string, StringBuilder>();

        protected void SetupCommunications(string regex, string response)
        {
            var mock = new Mock<Communications>(Cache);
            mock.Setup(communications =>
                    communications.HttpPost(It.IsRegex(regex, RegexOptions.Singleline), 
                    It.IsAny<Dictionary<string, string>>()))
                .Returns(response);

            Litle.setCommunication(mock.Object);
        }
    }
}