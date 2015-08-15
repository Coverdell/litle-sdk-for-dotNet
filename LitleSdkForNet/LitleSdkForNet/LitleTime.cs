using System;

namespace Litle.Sdk
{
    public class LitleTime
    {
        public virtual String GetCurrentTime(String format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}