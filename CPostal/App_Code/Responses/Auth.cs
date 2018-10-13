using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Auth
    {
        public Auth()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static bool VerifyKey(string key)
        {
            if (key.Equals("free"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static Object GetRespAuth4Key(Response r)
        {
            
            if (VerifyKey(r.Key))
            {
                r.SetStatus(Response.EStatus.OK);
                r.credit = new Credit(r.Key);
            }
            else
            {
                r.SetStatus(Response.EStatus.ERROR);
                r.error = "KEY ERROR";
                r.credit = new Credit();
            }
           

            return r;
        }

        public static RespPostalCode GetRespCPostalAuth4Key(string key)
        {
            return (RespPostalCode)GetRespAuth4Key(new RespPostalCode(key));
        }

        public static RespCPostalList GetRespCPostalListAuth4Key(string key)
        {
            return (RespCPostalList)GetRespAuth4Key(new RespCPostalList(key));
        }

        public static RespDistrictList GetRespDistrictListAuth4Key(string key)
        {
            return (RespDistrictList)GetRespAuth4Key(new RespDistrictList(key));
        }

        public static RespDistrict GetRespDistrictAuth4Key(string key)
        {
            return (RespDistrict)GetRespAuth4Key(new RespDistrict(key));
        }

        public static RespCounty GetRespCountyAuth4Key(string key)
        {
            return (RespCounty)GetRespAuth4Key(new RespCounty(key));
        }

        public static RespCountyList GetRespCountyListAuth4Key(string key)
        {
            return (RespCountyList)GetRespAuth4Key(new RespCountyList(key));
        }

    }

    


}