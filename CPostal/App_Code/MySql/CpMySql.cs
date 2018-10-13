using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace joaomfrebelo.ptpostalcode
{
    /// <summary>
    /// Summary description for MySql
    /// </summary>
    public class CpMySql
    {

        public MySqlConnection Conection { get; set; }

        public MySqlCommand Command { get; set; }

        private static string _connString { get; set; }

        public static string ConnString
        {
            get
            {
                if (_connString == null)
                {
                    _connString = System.Configuration.ConfigurationManager.
                                  ConnectionStrings["cpostal"].ConnectionString;
                }
                return _connString;
            }
        }

        public static string GetLimit(int limit, int offset)
        {
            if (limit > 100 || limit == 0)
            {
                limit = 100;
            }
            return String.Format(" LIMIT {0}, {1} ", offset, limit);
        }


        public MySqlConnection CreateConn() {
            Conection = new MySqlConnection(ConnString);
            return Conection;
        }

       
        public MySqlDataReader ExecuteCommand(string sql, List<MySqlParameter> param ,int limit,  int offset)
        {
            StringBuilder sqlLimit = new StringBuilder(sql)
                .Append(CpMySql.GetLimit(limit, offset));

            this.CreateConn().Open();
            Command = new MySqlCommand(sqlLimit.ToString(), Conection);

            foreach (MySqlParameter p in param)
            {
                Command.Parameters.Add(p);
            }
            
            return Command.ExecuteReader();
            
        }


    }
}