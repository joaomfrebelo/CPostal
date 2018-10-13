using System.Collections.Generic;
using System.Runtime.Serialization;

namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for RespCPostalList
    /// </summary>
    public class RespCPostalList :Response
{
        public RespCPostalList(string key)
                : base(key)
        {
            Cpostal = new List<CPostal>();
        }

        public RespCPostalList()
            : base()
        {

        }

        [DataMember]
        public List<CPostal> Cpostal { get; set; }
    }
}