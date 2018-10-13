using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    [DataContract]
    public class Credit
    {

        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public int Day { get; set; }

        [DataMember]
        public int Hour { get; set; }

        [DataMember]
        public int Minute { get; set; }

        public Credit(string key)
        {
            Total = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
        }

        public Credit()
        {
            Total = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
        }




    }
}