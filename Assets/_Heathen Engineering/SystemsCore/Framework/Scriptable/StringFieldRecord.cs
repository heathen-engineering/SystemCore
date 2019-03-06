using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class StringFieldRecord
    {
        [System.Xml.Serialization.XmlAttribute("xml:space")]
        public string SpacePreserve = "preserve";
        [System.Xml.Serialization.XmlAttribute()]
        public uint Id { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }

}
