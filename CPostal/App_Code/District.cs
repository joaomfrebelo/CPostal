using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for Distrito
    /// </summary>
    [DataContract]
    public class District
    {

        /// <summary>
        /// Base query of view v_distrito (district)
        /// </summary>
        public static string BSql = "SELECT * FROM v_distrito";

        public District()
        {

        }

        /// <summary>
        /// Column of the district table
        /// </summary>
        enum Column
        {
            dd, //District ID
            distrito // distric name
        }

        /// <summary>
        /// ID of the district
        /// </summary>
        [DataMember]
        public string dd { get; set; }

        /// <summary>
        /// District name
        /// </summary>
        [DataMember]
        public string district { get; set; }

        /// <summary>
        /// Serach fpr district
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        protected static List<District> ExecuteQuery(string sql, List<MySqlParameter> param, int limit, int offset)
        {

            List<District> l = new List<District>();
            CpMySql my = new CpMySql();
            MySqlDataReader r = my.ExecuteCommand(sql, param, limit, offset);
            while (r.Read())
            {
                District d = new District();
                d.dd = r.GetString(r.GetOrdinal(District.Column.dd.ToString()));
                d.district = r.GetString(r.GetOrdinal(District.Column.distrito.ToString()));
                l.Add(d);
            }
            my.Command.Dispose();
            r.Close();
            my.Conection.Close();
            return l;
        }

        /// <summary>
        /// Get all districts
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static List<District> GetAll(int limit, int offset)
        {
            return District.ExecuteQuery(BSql, new List<MySqlParameter>(), limit, offset);
        }

        /// <summary>
        /// Search district
        /// </summary>
        /// <param name="district"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static List<District> SearchDistrict(string district, int limit, int offset) {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", District.Column.distrito.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + District.Column.distrito.ToString(), "%" + district.Trim().Replace(" ", "%") + "%"));

            return District.ExecuteQuery(sql, lp, limit, offset);
        }

        /// <summary>
        /// Get the district
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<District> GetDistrict(string dd, int limit, int offset, string key)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` = @{0})", District.Column.dd.ToString())) 
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + District.Column.dd.ToString(), dd));

            return District.ExecuteQuery(sql, lp, limit, offset);
        }


    }
}