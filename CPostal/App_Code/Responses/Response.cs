using System.Runtime.Serialization;

namespace joaomfrebelo.ptpostalcode
{

    /// <summary>
    /// Summary description for Response
    /// </summary>
    [DataContract]
    public class Response
    {

        public string Key {get; set; }

        public enum EStatus
        {
            OK,
            ERROR
        }

        private EStatus _status { get; set; }

        [DataMember]
        public string status
        {
            get
            {
                return _status.ToString();
            }
            private set { }
        }


        [DataMember]
        public string error { get; set; }

        [DataMember]
        public Credit credit { get; set; }

        public Response(string key)
        {
            this.Key = key;
            error = "";
            credit = new Credit();
        }

        public Response()
        {
            this.Key = "";
            error = "";
            credit = new Credit();
        }

        public void SetStatus(EStatus s)
        {
            _status = s;
        }

        public EStatus GetStatus()
        {
            return _status;
        }


        public bool EqualsEStatus(EStatus s1, EStatus s2)
        {
            return s1.Equals(s2);
        }

    }
}