using System.Runtime.Serialization;

namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for RespCounty
    /// </summary>
    public class RespCounty : Response
    {
        public RespCounty(string key)
            : base(key)
        {
            
        }

        public RespCounty()
            : base()
        {

        }

        [DataMember]
        public County County { get; set; }
    }
}