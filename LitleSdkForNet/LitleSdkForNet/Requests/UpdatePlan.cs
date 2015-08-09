using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class UpdatePlan : RecurringTransactionType
    {
        public string PlanCode;

        private bool _activeField;
        private bool _activeSet;

        public bool Active
        {
            get { return _activeField; }
            set
            {
                _activeField = value;
                _activeSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<updatePlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            if (_activeSet) xml += "\r\n<active>" + _activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</updatePlan>";
            return xml;
        }
    }
}