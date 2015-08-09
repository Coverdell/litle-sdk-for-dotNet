using System;

namespace Litle.Sdk.Requests
{
    public class LitleTime
    {
        public virtual String GetCurrentTime(String format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}