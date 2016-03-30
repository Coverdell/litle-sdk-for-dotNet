using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Litle.Sdk.Test
{
    internal class LitleRequestTestBase
    {
        protected litleRequest Litle { get; private set; }
        protected IDictionary<string, StringBuilder> Cache { get; private set; }
        protected Dictionary<string, string> Config { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Config = SetupConfig();
            Cache = SetupCache();
            Litle = new litleRequest(Cache, Config);
        }

        protected virtual IDictionary<string, StringBuilder> SetupCache() => new Dictionary<string, StringBuilder>();
        protected virtual Dictionary<string, string> SetupConfig() => litleRequest.DefaultConfig;

        #region Helper Methods

        protected static void AssertWhileNext<TResponse>(Func<TResponse> nextResponse, Action<TResponse> onNext)
        {
            var response = nextResponse();
            while (response != null)
            {
                onNext(response);
                response = nextResponse();
            }
        }

        protected static void AssertWhileNextAtLeastOnce<TResponse>(Func<TResponse> nextResponse, Action<TResponse> onNext)
        {
            var response = nextResponse();
            Assert.NotNull(response);
            while (response != null)
            {
                onNext(response);
                response = nextResponse();
            }
        }

        protected static void AssertNextResponse<TResponse>(string expectedResponse,
            Func<TResponse> nextResponse, Func<TResponse, string> getResponseText)
        {
            AssertWhileNext(nextResponse, response =>
            {
                var responseText = getResponseText(response);
                Assert.AreEqual(expectedResponse, responseText);
            });
        }

        protected static void AssertNextResponseAtLeastOnce<TResponse>(string expectedResponse,
            Func<TResponse> nextResponse, Func<TResponse, string> getResponseText)
        {
            AssertWhileNextAtLeastOnce(nextResponse, response =>
            {
                var responseText = getResponseText(response);
                Assert.AreEqual(expectedResponse, responseText);
            });
        }

        protected static void AssertAddThrowsWhenNull<TItem>(Action<TItem> addAction, TItem authorization)
            where TItem : class
        {
            addAction(authorization);
            try //TODO: Should code fail if the concern is successfully executed?
            {
                addAction(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }

        #endregion Helper Methods
    }
}