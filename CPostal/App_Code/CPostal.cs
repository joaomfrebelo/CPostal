using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for CPostal
    /// </summary>
    [DataContract]
    public class CPostal
    {

        /// <summary>
        /// Base query
        /// </summary>
        public static string BSql = "SELECT * FROM v_cpostal";

        enum Column
        {
            dd, // District id
            distrito, // district name
            cc, // County id is a sub id of dd, starts always in 01 for each dd
            concelho, // County name
            cod_localidade, // cod locality
            localidade, //locality name
            cp4, // 4 digit code (first code)
            cp3, // 3 digit code (second code)
            morada, // address
            troco, 
            porta,
            cliente,
            cod_arteria,
            art_tipo,
            pri_prep,
            art_titulo,
            seg_prep,
            art_desig,
            art_local,
            cpalf
        }

        [DataMember]
        public string dd { get; set; }

        [DataMember]
        public string distrito { get; set; }

        [DataMember]
        public string cc { get; set; }

        [DataMember]
        public string concelho { get; set; }

        [DataMember]
        public string cod_localidade { get; set; }

        [DataMember]
        public string localidade { get; set; }

        [DataMember]
        public string cp4 { get; set; }

        [DataMember]
        public string cp3 { get; set; }

        [DataMember]
        public string morada { get; set; }

        [DataMember]
        public string troco { get; set; }

        [DataMember]
        public string porta { get; set; }

        [DataMember]
        public string cliente { get; set; }

        [DataMember]
        public string cod_arteria { get; set; }

        [DataMember]
        public string art_tipo { get; set; }

        [DataMember]
        public string pri_prep { get; set; }

        [DataMember]
        public string art_titulo { get; set; }

        [DataMember]
        public string seg_prep { get; set; }

        [DataMember]
        public string art_desig { get; set; }

        [DataMember]
        public string art_local { get; set; }

        [DataMember]
        public string cpalf { get; set; }

        public CPostal()
        {
            dd = "";
            distrito = "";
            cc = "";
            concelho = "";
            cod_localidade = "";
            localidade = "";
            cp4 = "";
            cp3 = "";
            morada = "";
            troco = "";
            porta = "";
            cliente = "";
            cod_arteria = "";
            art_tipo = "";
            pri_prep = "";
            art_titulo = "";
            seg_prep = "";
            art_desig = "";
            art_local = "";
            cpalf = "";
        }

        /// <summary>
        /// Serach fpr distrito
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        protected static List<CPostal> ExecuteQuery(string sql, List<MySqlParameter> param, int limit, int offset)
        {

            List<CPostal> l = new List<CPostal>();
            CpMySql my = new CpMySql();
            MySqlDataReader r = my.ExecuteCommand(sql, param, limit, offset);
            while (r.Read())
            {
                CPostal c = new CPostal
                {
                    art_desig = r.GetString(r.GetOrdinal(CPostal.Column.art_desig.ToString())),
                    art_local = r.GetString(r.GetOrdinal(CPostal.Column.art_local.ToString())),
                    art_tipo = r.GetString(r.GetOrdinal(CPostal.Column.art_tipo.ToString())),
                    art_titulo = r.GetString(r.GetOrdinal(CPostal.Column.art_titulo.ToString())),
                    cc = r.GetString(r.GetOrdinal(CPostal.Column.cc.ToString())),
                    cliente = r.GetString(r.GetOrdinal(CPostal.Column.cliente.ToString())),
                    cod_arteria = r.GetString(r.GetOrdinal(CPostal.Column.cod_arteria.ToString())),
                    cod_localidade = r.GetString(r.GetOrdinal(CPostal.Column.cod_localidade.ToString())),
                    concelho = r.GetString(r.GetOrdinal(CPostal.Column.concelho.ToString())),
                    cp3 = r.GetString(r.GetOrdinal(CPostal.Column.cp3.ToString())),
                    cp4 = r.GetString(r.GetOrdinal(CPostal.Column.cp4.ToString())),
                    cpalf = r.GetString(r.GetOrdinal(CPostal.Column.cpalf.ToString())),
                    dd = r.GetString(r.GetOrdinal(CPostal.Column.dd.ToString())),
                    distrito = r.GetString(r.GetOrdinal(CPostal.Column.distrito.ToString())),
                    localidade = r.GetString(r.GetOrdinal(CPostal.Column.localidade.ToString())),
                    morada = r.GetString(r.GetOrdinal(CPostal.Column.morada.ToString())),
                    porta = r.GetString(r.GetOrdinal(CPostal.Column.porta.ToString())),
                    pri_prep = r.GetString(r.GetOrdinal(CPostal.Column.pri_prep.ToString())),
                    seg_prep = r.GetString(r.GetOrdinal(CPostal.Column.seg_prep.ToString())),
                    troco = r.GetString(r.GetOrdinal(CPostal.Column.troco.ToString()))
                };
                l.Add(c);
            }
            my.Command.Dispose();
            r.Close();
            my.Conection.Close();
            return l;
        }

        /// <summary>
        /// Get a client from database
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static List<CPostal> GetClient(string client)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.cliente.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.cliente.ToString(), client));

            return CPostal.ExecuteQuery(sql, lp, 1, 0);
        }

        /// <summary>
        /// Get from a postal code
        /// </summary>
        /// <param name="cp4"></param>
        /// <param name="cp3"></param>
        /// <returns></returns>
        public static List<CPostal> GetCPostal(string cp4, string cp3)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.cp4.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.cp3.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.cp4.ToString(), cp4));
            lp.Add(new MySqlParameter("@" + CPostal.Column.cp3.ToString(), cp3));

            return CPostal.ExecuteQuery(sql, lp, 1, 0);
        }

        /// <summary>
        /// Serach for an address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<CPostal> SearchByAddress(string address, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.morada.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.morada.ToString(), "%" + address.Trim().Replace(' ', '%') + "%"));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

        /// <summary>
        /// Seach address of concelho
        /// </summary>
        /// <param name="concelho"></param>
        /// <param name="address"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static List<CPostal> SearchAddressOfCounty(string concelho, string address, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.concelho.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.morada.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.concelho.ToString(), concelho));
            lp.Add(new MySqlParameter("@" + CPostal.Column.morada.ToString(), "%" + address.Trim().Replace(' ', '%') + "%"));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<CPostal> SearchByCpostal(string cp, int limit, int offset)
        {
            string p1 = "p";
            string sql = new StringBuilder(BSql)
                         .Append(" WHERE ")
                         .Append(string.Format("(CONCAT(`{0}`,`{1}`) like @{2})", CPostal.Column.cp4, CPostal.Column.cp3, p1))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + p1, "%" + Regex.Replace(cp.Trim().Replace("-","%").Replace(" ", "%"), @"\s?\D?", "") + "%"));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<CPostal> SearchByDdAddress(string dd, string address, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.morada.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.dd.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.morada.ToString(), "%" + address.Trim().Replace(' ', '%') + "%"));
            lp.Add(new MySqlParameter("@" + CPostal.Column.dd.ToString(), dd));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<CPostal> SearchByDdAddress(string dd, string cc, string address, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.morada.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.dd.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.cc.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.morada.ToString(), "%" + address.Trim().Replace(' ', '%') + "%"));
            lp.Add(new MySqlParameter("@" + CPostal.Column.dd.ToString(), dd));
            lp.Add(new MySqlParameter("@" + CPostal.Column.cc.ToString(), cc));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }
        
        public static List<CPostal> SearchByDisAddress(string distrito, string address, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.morada.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.distrito.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.morada.ToString(), "%" + address.Trim().Replace(' ', '%') + "%"));
            lp.Add(new MySqlParameter("@" + CPostal.Column.distrito.ToString(), distrito));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<CPostal> SearchByDisConAddress(string distrito, string concelho, string address, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.morada.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.concelho.ToString()))
                          .Append(" AND ")
                          .Append(string.Format("(`{0}` = @{0})", CPostal.Column.distrito.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.morada.ToString(), "%" + address.Trim().Replace(' ', '%') + "%"));
            lp.Add(new MySqlParameter("@" + CPostal.Column.concelho.ToString(), concelho));
            lp.Add(new MySqlParameter("@" + CPostal.Column.distrito.ToString(), distrito));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }
        
        public static List<CPostal> SerachByCliente(string cliente, int limit, int offset){
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(string.Format("(`{0}` like @{0})", CPostal.Column.cliente.ToString()))
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            lp.Add(new MySqlParameter("@" + CPostal.Column.cliente.ToString(), "%" + cliente.Trim().Replace(' ', '%') + "%"));

            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

        public static List<CPostal> Search(string searchString, int limit, int offset)
        {
            string sql = new StringBuilder(BSql)
                          .Append(" WHERE ")
                          .Append(searchString)
                         .ToString();
            List<MySqlParameter> lp = new List<MySqlParameter>();
            
            return CPostal.ExecuteQuery(sql, lp, limit, offset);
        }

    }
}



