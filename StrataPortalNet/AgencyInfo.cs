using System.Runtime.Serialization;

namespace Rockend.iStrata.StrataCommon.BusinessEntities
{
    [DataContract]
    public class AgencyInfo
    {
        [DataMember]
        public int AgencyID { get; set; }
        
        [DataMember]
        public string sClientID { get; set; }
        
        [DataMember]
        public string Name { get; set; }
    }
}
