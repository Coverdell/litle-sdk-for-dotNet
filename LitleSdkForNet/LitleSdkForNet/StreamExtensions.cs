using System.IO;

namespace Litle.Sdk
{
    public static class StreamExtensions
    {
        public static MemoryStream Clone(this MemoryStream source)
        {
            var result = new MemoryStream();
            var position = source.Position;
            source.Seek(0, SeekOrigin.Begin);
            source.CopyTo(result);
            source.Seek(position, SeekOrigin.Begin);
            result.Seek(position, SeekOrigin.Begin);
            return result;
        }
    }
}