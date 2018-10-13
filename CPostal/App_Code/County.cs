using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace joaomfrebelo.ptpostalcode {
    /// <summary>
    /// Summary description for Concelho
    /// </summary>
    [DataContract]
    public class County
    {
        /// <summary>
        /// Base query
        /// </summary>
        public static string BSql = "SELECT * FROM v_concelho";

        enum Column
        {
            dd, // distric id
            cc, // county id, always a sub id of dd, starts always at 01 for each dd
            distrito, // district name
            concelho // county name
        }

        [DataMember]
        public string dd { get; set; }

        [DataMember]
        public string cc { get; set; }

        [DataMember]
        public string district { get; set; }

        [DataMember]
        public string county { get; set; }


        protected static List<County> ExecuteQuery(string sql, List<MySqlParameter> param, int limit, int offset)
        {

            List<County> l = new List<County>();
            CpMySql my = new CpMySql();
            MySqlDataReader r = my.ExecuteCommand(sql, param, limit, offset);
            while (r.Read())
            {
                County d = new County
                {
                    dd = r.GetString(r.GetOrdinal(County.Column.dd.ToString())),
                    district = r.GetString(r.GetOrdinal(County.Column.distrito.ToString())),
                    cc = r.GetString(r.GetOrdinal(County.Column.cc.ToString())),
                    county = r.GetString(r.GetOrdinal(County.Column.concelho.ToString()))
                };
                l.Add(d);
            }
            my.Command.Dispose();
            r.Close();
            my.Conection.Close();
            return l;
        }

        public static List<County> GetAll(int limit, int offset)
        {
            return County.ExecuteQuery(BSql, new List<MySqlParameter>(), limit, offset);
        }

        public static List<County> SearchCounty(string county, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", County.Column.concelho.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + County.Column.concelho.ToString(), "%" + county.Trim().Replace(" ", "%") + "%"));

            return County.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<County> SearchCountyOfDistrict(string dd, string concelho, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", County.Column.concelho.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", County.Column.dd.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + County.Column.concelho.ToString(), "%" + concelho.Trim().Replace(" ", "%") + "%"));
            lp.Add(new MySqlParameter("@" + County.Column.dd.ToString(), dd));

            return County.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<County> GetCounty(string dd, string cc, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` = @{0})", County.Column.cc.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", County.Column.dd.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + County.Column.cc.ToString(), cc));
            lp.Add(new MySqlParameter("@" + County.Column.dd.ToString(), dd));

            return County.ExecuteQuery(sql, lp, limit, offset);
        }


    }
}