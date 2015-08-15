using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class RecyclingRequestType
    {
        private RecycleByTypeEnum _recycleByField;
        private bool _recycleBySet;

        public RecycleByTypeEnum RecycleBy
        {
            get { return _recycleByField; }
            set
            {
                _recycleByField = value;
                _recycleBySet = true;
            }
        }

        public string RecycleId { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (_recycleBySet) xml += "\r\n<recycleBy>" + _recycleByField + "</recycleBy>";
            if (RecycleId != null) xml += "\r\n<recycleId>" + SecurityElement.Escape(RecycleId) + "</recycleId>";
            return xml;
        }
    }
}