using System.Security;

namespace Litle.Sdk.Requests
{
    public class RecyclingRequestType
    {
        private recycleByTypeEnum _recycleByField;
        private bool _recycleBySet;

        public recycleByTypeEnum RecycleBy
        {
            get { return _recycleByField; }
            set
            {
                _recycleByField = value;
                _recycleBySet = true;
            }
        }

        public string RecycleId;

        public string Serialize()
        {
            var xml = "";
            if (_recycleBySet) xml += "\r\n<recycleBy>" + _recycleByField + "</recycleBy>";
            if (RecycleId != null) xml += "\r\n<recycleId>" + SecurityElement.Escape(RecycleId) + "</recycleId>";
            return xml;
        }
    }
}