using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("litleOnlineRequest")]
    [LitleXmlRoot("litleOnlineRequest")]
    public class LitleOnlineRequest
    {
        [XmlAttribute("merchantId")]
        public string MerchantId { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlAttribute("merchantSdk")]
        public string MerchantSdk { get; set; }
        [XmlElement("authentication")]
        public Authentication Authentication { get; set; }
        [XmlElement("authorization")]
        public Authorization Authorization { get; set; }
        [XmlElement("capture")]
        public Capture Capture { get; set; }
        [XmlElement("credit")]
        public Credit Credit { get; set; }
        [XmlElement("voidTxn")]
        public VoidTxn VoidTxn { get; set; }
        [XmlElement("sale")]
        public Sale Sale { get; set; }
        [XmlElement("authReversal")]
        public AuthReversal AuthReversal { get; set; }
        [XmlElement("echeckCredit")]
        public EcheckCredit EcheckCredit { get; set; }
        [XmlElement("echeckVerification")]
        public EcheckVerification EcheckVerification { get; set; }
        [XmlElement("echeckSale")]
        public EcheckSale EcheckSale { get; set; }
        [XmlElement("registerTokenRequest")]
        public RegisterTokenRequestType RegisterTokenRequest { get; set; }
        [XmlElement("forceCapture")]
        public ForceCapture ForceCapture { get; set; }
        [XmlElement("captureGivenAuth")]
        public CaptureGivenAuth CaptureGivenAuth { get; set; }
        [XmlElement("echeckRedeposit")]
        public EcheckRedeposit EcheckRedeposit { get; set; }
        [XmlElement("echeckVoid")]
        public EcheckVoid EcheckVoid { get; set; }
        [XmlElement("updateCardValidationNumOnToken")]
        public UpdateCardValidationNumOnToken UpdateCardValidationNumOnToken { get; set; }
        [XmlElement("updateSubscription")]
        public UpdateSubscription UpdateSubscription { get; set; }
        [XmlElement("cancelSubscription")]
        public CancelSubscription CancelSubscription { get; set; }
        [XmlElement("activate")]
        public Activate Activate { get; set; }
        [XmlElement("deactivate")]
        public Deactivate Deactivate { get; set; }
        [XmlElement("load")]
        public Load Load { get; set; }
        [XmlElement("unload")]
        public Unload Unload { get; set; }
        [XmlElement("balanceInquiry")]
        public BalanceInquiry BalanceInquiry { get; set; }
        [XmlElement("createPlan")]
        public CreatePlan CreatePlan { get; set; }
        [XmlElement("updatePlan")]
        public UpdatePlan UpdatePlan { get; set; }
        [XmlElement("refundReversal")]
        public RefundReversal RefundReversal { get; set; }
        [XmlElement("loadReversal")]
        public LoadReversal LoadReversal { get; set; }
        [XmlElement("depositReversal")]
        public DepositReversal DepositReversal { get; set; }
        [XmlElement("activateReversal")]
        public ActivateReversal ActivateReversal { get; set; }
        [XmlElement("deactivateReversal")]
        public DeactivateReversal DeactivateReversal { get; set; }
        [XmlElement("unloadReversal")]
        public UnloadReversal UnloadReversal { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}