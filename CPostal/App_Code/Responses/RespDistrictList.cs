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
    public class RespDistrictList : Response
    {


        [DataMember]
        public List<District> District { get; set; }

        public RespDistrictList(string key)
            : base(key)
        {
            District = new List<District>();
        }

        public RespDistrictList()
            : base ()
        {
            District = new List<District>();
        }



    }
}