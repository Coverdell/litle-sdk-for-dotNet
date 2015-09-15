using System.Collections.Generic;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    class TestBase
    {
        protected LitleOnline Litle { get; set; }

        [TestFixtureSetUp]
        public virtual void SetUpLitle()
        {
            Litle = new LitleOnline();
        }

        protected void MockLitlePost(string regex, string response)
        {
            var mock = new Mock<Communications>();
            mock.Setup(communications =>
                    communications.HttpPost(It.IsRegex(regex, RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(response);
            Litle.SetCommunication(mock.Object);
        }

        protected static string FormMatchExpression(params string[] lines)
        {
            var innerMatch = string.Join(@"[\w\s\S]*", lines);
            return string.Format("{0}{1}{0}", ".*", innerMatch);
        }
    }
}