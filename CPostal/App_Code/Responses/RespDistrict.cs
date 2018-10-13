using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace joaomfrebelo.ptpostalcode
{

    /// <summary>
    /// Summary description for RespDistrict
    /// </summary>
    [DataContract]
    public class RespDistrict : Response
    {

        [DataMember]
        public District district { get; set; }

        public RespDistrict(string key)
            : base(key)
        {
            
        }

        public RespDistrict()
            : base()
        {

        }

    }
}