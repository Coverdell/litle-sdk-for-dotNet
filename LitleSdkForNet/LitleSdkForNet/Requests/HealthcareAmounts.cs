namespace Litle.Sdk.Requests
{
    public class HealthcareAmounts
    {
        private int _totalHealthcareAmountField;
        private bool _totalHealthcareAmountSet;

        public int TotalHealthcareAmount
        {
            get { return _totalHealthcareAmountField; }
            set
            {
                _totalHealthcareAmountField = value;
                _totalHealthcareAmountSet = true;
            }
        }

        private int _rxAmountField;
        private bool _rxAmountSet;

        public int RxAmount
        {
            get { return _rxAmountField; }
            set
            {
                _rxAmountField = value;
                _rxAmountSet = true;
            }
        }

        private int _visionAmountField;
        private bool _visionAmountSet;

        public int VisionAmount
        {
            get { return _visionAmountField; }
            set
            {
                _visionAmountField = value;
                _visionAmountSet = true;
            }
        }

        private int _clinicOtherAmountField;
        private bool _clinicOtherAmountSet;

        public int ClinicOtherAmount
        {
            get { return _clinicOtherAmountField; }
            set
            {
                _clinicOtherAmountField = value;
                _clinicOtherAmountSet = true;
            }
        }

        private int _dentalAmountField;
        private bool _dentalAmountSet;

        public int DentalAmount
        {
            get { return _dentalAmountField; }
            set
            {
                _dentalAmountField = value;
                _dentalAmountSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (_totalHealthcareAmountSet)
                xml += "\r\n<totalHealthcareAmount>" + _totalHealthcareAmountField + "</totalHealthcareAmount>";
            if (_rxAmountSet) xml += "\r\n<RxAmount>" + _rxAmountField + "</RxAmount>";
            if (_visionAmountSet) xml += "\r\n<visionAmount>" + _visionAmountField + "</visionAmount>";
            if (_clinicOtherAmountSet)
                xml += "\r\n<clinicOtherAmount>" + _clinicOtherAmountField + "</clinicOtherAmount>";
            if (_dentalAmountSet) xml += "\r\n<dentalAmount>" + _dentalAmountField + "</dentalAmount>";
            return xml;
        }
    }
}