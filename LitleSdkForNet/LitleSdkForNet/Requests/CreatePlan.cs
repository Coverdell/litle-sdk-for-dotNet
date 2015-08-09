using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class CreatePlan : RecurringTransactionType
    {
        public string PlanCode;
        public string Name;

        private string _descriptionField;
        private bool _descriptionSet;

        public string Description
        {
            get { return _descriptionField; }
            set
            {
                _descriptionField = value;
                _descriptionSet = true;
            }
        }

        public IntervalType IntervalType;
        public long Amount;

        public int NumberOfPaymentsField;
        public bool NumberOfPaymentsSet;

        public int NumberOfPayments
        {
            get { return NumberOfPaymentsField; }
            set
            {
                NumberOfPaymentsField = value;
                NumberOfPaymentsSet = true;
            }
        }

        public int TrialNumberOfIntervalsField;
        public bool TrialNumberOfIntervalsSet;

        public int TrialNumberOfIntervals
        {
            get { return TrialNumberOfIntervalsField; }
            set
            {
                TrialNumberOfIntervalsField = value;
                TrialNumberOfIntervalsSet = true;
            }
        }

        private TrialIntervalType _trialIntervalTypeField;
        private bool _trialIntervalTypeSet;

        public TrialIntervalType TrialIntervalType
        {
            get { return _trialIntervalTypeField; }
            set
            {
                _trialIntervalTypeField = value;
                _trialIntervalTypeSet = true;
            }
        }

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
            var xml = "\r\n<createPlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            if (_descriptionSet)
                xml += "\r\n<description>" + SecurityElement.Escape(_descriptionField) + "</description>";
            xml += "\r\n<intervalType>" + IntervalType + "</intervalType>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            if (NumberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + NumberOfPaymentsField + "</numberOfPayments>";
            if (TrialNumberOfIntervalsSet)
                xml += "\r\n<trialNumberOfIntervals>" + TrialNumberOfIntervalsField + "</trialNumberOfIntervals>";
            if (_trialIntervalTypeSet)
                xml += "\r\n<trialIntervalType>" + _trialIntervalTypeField + "</trialIntervalType>";
            if (_activeSet) xml += "\r\n<active>" + _activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</createPlan>";
            return xml;
        }
    }
}