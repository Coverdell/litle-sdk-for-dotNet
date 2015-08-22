using System;

namespace Litle.Sdk
{
    public class LitleTime
    {
        public virtual string GetCurrentTime(String format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}