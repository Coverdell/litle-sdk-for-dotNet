using System.IO;
using System.Text;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestStreamExtensions
    {
        [Test]
        public void CloneStream()
        {
            const string value = "Test Stream Data.";
            var bytes = Encoding.UTF8.GetBytes(value);
            var sourceStream = new MemoryStream(bytes);
            var clonedStream = sourceStream.Clone();

            Assert.AreEqual(0, sourceStream.Position);
            Assert.AreEqual(0, clonedStream.Position);

            using (var reader = new StreamReader(sourceStream))
            {
                var sourceResult = reader.ReadToEnd();
                reader.Close();
                Assert.IsFalse(sourceStream.CanRead);
                Assert.IsTrue(clonedStream.CanRead);
                Assert.AreEqual(0, clonedStream.Position);
                Assert.AreEqual(value, sourceResult);
            }

            using (var reader = new StreamReader(clonedStream))
            {
                var clonedResult = reader.ReadToEnd();
                reader.Close();
                Assert.IsFalse(clonedStream.CanRead);
                Assert.AreEqual(value, clonedResult);
            }
        }

        [Test]
        public void CloneStreamFromNonZeroPosition()
        {
            const string value = "Test Stream Data.";
            var bytes = Encoding.UTF8.GetBytes(value);
            var sourceStream = new MemoryStream(bytes);

            Assert.AreEqual(0, sourceStream.Position);

            using (var reader = new StreamReader(sourceStream))
            {
                var buffer = new byte[bytes.Length];
                var halfLength = bytes.Length >> 1;
                sourceStream.Read(buffer, 0, halfLength);

                var clonedStream = sourceStream.Clone();
                Assert.AreEqual(halfLength, clonedStream.Position);

                reader.Close();
                Assert.IsFalse(sourceStream.CanRead);
                Assert.IsTrue(clonedStream.CanRead);
                using (var cloneReader = new StreamReader(clonedStream))
                {
                    var clonedResult = cloneReader.ReadToEnd();
                    cloneReader.Close();
                    Assert.IsFalse(clonedStream.CanRead);
                    Assert.AreEqual(value.Substring(halfLength, bytes.Length - halfLength), clonedResult);
                }
            }
        }
    }
}
