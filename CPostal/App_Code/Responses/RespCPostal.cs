using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace joaomfrebelo.ptpostalcode
{

    /// <summary>
    /// Summary description for RespCPostal
    /// </summary>
    [DataContract]
    public class RespPostalCode : Response
    {
        public RespPostalCode(string key)
            : base(key)
        {
            
        }

        public RespPostalCode()
            : base()
        {

        }

        [DataMember]
        public CPostal Cpostal { get; set; }

    }
}