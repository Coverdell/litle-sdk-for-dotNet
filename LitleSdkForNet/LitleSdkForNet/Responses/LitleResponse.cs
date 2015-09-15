using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("litleResponse")]
    public class LitleResponse
    {
        [XmlElement("id")]
        public string ID { get; set; }
        [XmlElement("litleBatchId")]
        public long LitleBatchId { get; set; }
        [XmlElement("litleSessionId")]
        public long LitleSessionId { get; set; }
        [XmlElement("merchantId")]
        public string MerchantId { get; set; }
        [XmlElement("response")]
        public string Response { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }

        private XmlReader _originalXmlReader;
        private XmlReader _batchResponseReader;
        private XmlReader _rfrResponseReader;
        private string _filePath;

        public LitleResponse()
        {
        }

        public LitleResponse(string filePath)
        {
            var reader = new XmlTextReader(filePath);
            ReadXml(reader, filePath);
        }

        public LitleResponse(XmlReader reader, string filePath)
        {
            ReadXml(reader, filePath);
        }

        public void SetBatchResponseReader(XmlReader xmlReader)
        {
            _batchResponseReader = xmlReader;
        }

        public void SetRfrResponseReader(XmlReader xmlReader)
        {
            _rfrResponseReader = xmlReader;
        }

        public void ReadXml(XmlReader reader, string filePath)
        {
            if (reader.ReadToFollowing("litleResponse"))
            {
                Version = reader.GetAttribute("version");
                Message = reader.GetAttribute("message");
                Response = reader.GetAttribute("response");

                var rawLitleSessionId = reader.GetAttribute("litleSessionId");
                if (rawLitleSessionId != null)
                {
                    LitleSessionId = Int64.Parse(rawLitleSessionId);
                }
            }
            else
            {
                reader.Close();
            }

            _originalXmlReader = reader;
            _filePath = filePath;

            _batchResponseReader = new XmlTextReader(filePath);
            if (!_batchResponseReader.ReadToFollowing("batchResponse"))
            {
                _batchResponseReader.Close();
            }

            _rfrResponseReader = new XmlTextReader(filePath);
            if (!_rfrResponseReader.ReadToFollowing("RFRResponse"))
            {
                _rfrResponseReader.Close();
            }
        }

        public virtual BatchResponse NextBatchResponse()
        {
            if (_batchResponseReader.ReadState == ReadState.Closed) return null;
            var litleBatchResponse = new BatchResponse(_batchResponseReader, _filePath);
            if (!_batchResponseReader.ReadToFollowing("batchResponse"))
            {
                _batchResponseReader.Close();
            }

            return litleBatchResponse;
        }

        public virtual RFRResponse NextRFRResponse()
        {
            if (_rfrResponseReader.ReadState == ReadState.Closed) return null;
            var response = _rfrResponseReader.ReadOuterXml();
            var serializer = new XmlSerializer(typeof (RFRResponse));
            var reader = new StringReader(response);
            var rfrResponse = (RFRResponse) serializer.Deserialize(reader);

            if (!_rfrResponseReader.ReadToFollowing("RFRResponse"))
            {
                _rfrResponseReader.Close();
            }

            return rfrResponse;
        }
    }
}