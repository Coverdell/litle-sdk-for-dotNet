using System;
using System.Security.Cryptography;

namespace Litle.Sdk
{
    public static class RandomGen
    {
        private static readonly RNGCryptoServiceProvider Global = new RNGCryptoServiceProvider();
        private static Random _local;

        public static int NextInt()
        {
            if (_local != null) return _local.Next();
            var buffer = new byte[8];
            Global.GetBytes(buffer);
            _local = new Random(BitConverter.ToInt32(buffer, 0));

            return _local.Next();
        }

        public static string NextString(int length)
        {
            var result = "";

            for (var i = 0; i < length; i++)
            {
                result += Convert.ToChar(NextInt()%('Z' - 'A') + 'A');
            }

            return result;
        }
    }
}