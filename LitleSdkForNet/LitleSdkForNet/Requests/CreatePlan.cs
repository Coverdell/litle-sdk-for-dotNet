using System;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class CreatePlan : RecurringTransactionType
    {
        public string PlanCode { get; set; }
        public string Name { get; set; }

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

        public IntervalType IntervalType { get; set; }
        public long Amount { get; set; }

        public int NumberOfPaymentsField { get; set; }
        public bool NumberOfPaymentsSet { get; set; }

        public int NumberOfPayments
        {
            get { return NumberOfPaymentsField; }
            set
            {
                NumberOfPaymentsField = value;
                NumberOfPaymentsSet = true;
            }
        }

        public int TrialNumberOfIntervalsField { get; set; }
        public bool TrialNumberOfIntervalsSet { get; set; }

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
            var intervalTypeAttribute = EnumUtility.GetXmlEnum(
                IntervalType.ToString(), typeof(IntervalType));
            var trialIntervalTypeAttribute = EnumUtility.GetXmlEnum(
                TrialIntervalType.ToString(), typeof(TrialIntervalType));
            var xml = "\r\n<createPlan>";
            xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            if (_descriptionSet)
                xml += "\r\n<description>" + SecurityElement.Escape(_descriptionField) + "</description>";
            xml += "\r\n<intervalType>" + intervalTypeAttribute.Name + "</intervalType>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            if (NumberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + NumberOfPaymentsField + "</numberOfPayments>";
            if (TrialNumberOfIntervalsSet)
                xml += "\r\n<trialNumberOfIntervals>" + TrialNumberOfIntervalsField + "</trialNumberOfIntervals>";
            if (_trialIntervalTypeSet)
                xml += "\r\n<trialIntervalType>" + trialIntervalTypeAttribute.Name + "</trialIntervalType>";
            if (_activeSet) xml += "\r\n<active>" + _activeField.ToString().ToLower() + "</active>";
            xml += "\r\n</createPlan>";
            return xml;
        }
    }
}