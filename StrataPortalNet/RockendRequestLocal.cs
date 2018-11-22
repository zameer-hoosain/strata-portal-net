/*using Rockend.WebAccess.RockendMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceReference1
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Rockend.WebAccess.RockendMessage")]
    public class RockendRequest
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string ActionName
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string ApplicationCode
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string ApplicationKey
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ApplicationKeySpecified
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public object Body
        {
            get
            {
                return BodyXml?.DeserializeFromXML();
            }
            set
            {
                BodyXml = value.SerializeToXML();
            }
        }

        public T BodyAs<T>() where T : class
        {
            return BodyXml?.DeserializeFromXML<T>();
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string BodyXml
        {
            get;
            protected set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string ServiceKey
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ServiceKeySpecified
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string ServicePassword
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string SessionID
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public int TimeoutMS
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeoutMSSpecified
        {
            get;
            set;
        }
    }
}
*/
using Rockend.iStrata.StrataCommon.Request;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Rockend.WebAccess.RockendMessage
{
    [DataContract]
    [XmlInclude(typeof(LoginRequest))]
    [KnownType(typeof(LoginRequest))]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Rockend.WebAccess.RockendMessage")]
    public class RockendRequest
    {
        [DataMember(Order = 0)]
        public string ActionName { get; set; }

        [DataMember(Order = 1)]
        public string ApplicationCode { get; set; }

        [DataMember(Order = 2)]
        public int ApplicationKey { get; set; }

        [DataMember(Order = 3)]
        public string BodyXml { get; set; }

        [DataMember(Order = 4)]
        public int ServiceKey { get; set; }

        [DataMember(Order = 5)]
        public string ServicePassword { get; set; }


        [DataMember (Order =6)]
        public string SessionID { get; set; }

        [DataMember (Order =7)]
        public int TimeoutMS { get; set; }

#if !NETFX_CORE
        [IgnoreDataMember]
        public object Body
        {
            get
            {
                return null;
            }
            set
            {
                BodyXml = value.SerializeToXML();
            }
        }

        public T BodyAs<T>() where T : class
        {
            return BodyXml?.DeserializeFromXML<T>();
        }
#endif
    }
}
