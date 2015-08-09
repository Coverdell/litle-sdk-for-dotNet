using System;
using System.Globalization;

namespace Litle.Sdk.Requests
{
    public static class XmlUtil
    {
        public static string ToXsdDate(DateTime dateTime)
        {
            var year = dateTime.Year.ToString(CultureInfo.InvariantCulture);
            var month = dateTime.Month.ToString(CultureInfo.InvariantCulture);
            if (dateTime.Month < 10)
            {
                month = "0" + month;
            }
            var day = dateTime.Day.ToString(CultureInfo.InvariantCulture);
            if (dateTime.Day < 10)
            {
                day = "0" + day;
            }
            return year + "-" + month + "-" + day;
        }
    }
}