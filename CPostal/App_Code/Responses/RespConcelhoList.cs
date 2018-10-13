using System.Collections.Generic;
using System.Runtime.Serialization;

namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for RespConcelhoList
    /// </summary>
    public class RespCountyList : Response
    {
        public RespCountyList(string key)
            : base(key)
        {
            County = new List<County>();
        }

        public RespCountyList()
            : base()
        {
            County = new List<County>();
        }

        [DataMember]
        public List<County> County { get; set; }
    }
}