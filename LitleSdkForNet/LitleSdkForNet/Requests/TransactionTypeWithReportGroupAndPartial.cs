using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class TransactionTypeWithReportGroupAndPartial : TransactionType
    {
        public string ReportGroup;
        private bool _partialField;
        protected bool PartialSet;

        public bool Partial
        {
            get { return _partialField; }
            set
            {
                _partialField = value;
                PartialSet = true;
            }
        }
    }
}