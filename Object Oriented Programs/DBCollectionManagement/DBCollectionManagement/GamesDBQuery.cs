using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DatabaseConnector;

namespace DBCollectionManagement
{
    class GamesDBQuery
    {
        public MySqlDatabase mysql;
        const int COLCOUNT = 4;
        public GamesDBQuery()
        {
            mysql = null;
        }
        public GamesDBQuery(string server, string db, string uid, string pwd)
        {
            mysql = new MySqlDatabase(server, db, uid, pwd);
        }
        public bool OpenConnection(ref string errmsg)
        {
            return mysql.OpenConnection(ref errmsg);
        }
        public bool CloseConnection(ref string errmsg)
        {
            return mysql.CloseConnection(ref errmsg);
        }
        public static string GetInsertQuery(string tableName, string title, string platfrm, string year, string company)
        {
            return string.Format("insert into {0} values ('{1}','{2}','{3}','{4}');", tableName, title, platfrm, year, company);
        }
        public bool InsertGame(string tableName, string title, string platfrm, string year, string company, ref string errmsg)
        {
            string query = GetInsertQuery(tableName, title, platfrm, year, company);
            return mysql.Execute(query, ref errmsg);
        }
        public static string GetDeleteQuery(string tableName, string title)
        {
            return string.Format("delete from {0} where Title = '{1}';", tableName, title);
        }

        public static List<string>[] ParseResults(MySqlDataReader dr)
        {
            List<string>[] results;
            if (dr != null)
            {
                results = new List<string>[COLCOUNT];
                for (int i = 0; i < COLCOUNT; i++)
                {
                    results[i] = new List<string>();
                }
                while (dr.Read())
                {
                    results[0].Add("" + dr["Title"]);
                    results[1].Add("" + dr["Platform"]);
                    results[2].Add("" + dr["YearReleased"]);
                    results[3].Add("" + dr["CompanyName"]);
                }
                dr.Close();
            }
            else
            {
                results = null;
            }
            return results;
        }
        public List<string>[] SelectAsStrings(string query, ref string errmsg)
        {
            try
            {
                MySqlDataReader dr = mysql.Select(query, ref errmsg);
                if (dr != null)
                {
                    return ParseResults(dr);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
