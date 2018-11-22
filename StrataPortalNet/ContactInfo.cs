using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rockend.iStrata.StrataCommon.BusinessEntities
{
    public class ContactInfo
    {
        public int ContactID { get; set; }
        
        public string contactType { get; set; }
        
        public string Name { get; set; }
        
        public string WebAccessUsername { get; set; }
        
        public string WebAccessPassword { get; set; }
        
        public string WebAccessEnabled { get; set; }

    }
}
