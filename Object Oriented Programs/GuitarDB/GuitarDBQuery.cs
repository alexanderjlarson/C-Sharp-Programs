/* this class allows us to use MySqlDatabase in a way
 * that is specific to our collection of guitars. It
 * frees us from polluting the application-agnostic
 * MySqlDatabase class
 * 
 * Features:
 * 1. Can insert a new guitar into the database
 * 2. Delete a guitar given its nickname
 * 3. Clear the list of guitars (delete them all)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Database245;
using GuitarCollection;

namespace GuitarDB
{
    class GuitarDBQuery
    {
        public MySqlDatabase mysql;
        public GuitarDBQuery()
        {
            mysql = null;
        }
        public GuitarDBQuery(string server, string db, string uid, string pwd)
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

        public static string GetInsertQuery(string tableName, string nickName,
            string manufName, string modelName, int yearMade)
        {
            return string.Format("insert into {0} values ('{1}','{2}','{3}',{4});", tableName,
                nickName, manufName, modelName, yearMade);
        }
        public bool InsertGuitar(string tableName, string nickName, string manufName, string modelName, int yearMade, ref string errmsg)
        {
            string query = GetInsertQuery(tableName, nickName, manufName, modelName, yearMade);
            return mysql.Execute(query, ref errmsg);
        }

        public static string GetDeleteQuery(string tableName, string nickName)
        {
            return string.Format("delete from {0} where NickName = '{1}';", tableName, nickName);
        }
        public bool DeleteGuitar(string tableName, string nickName, ref string errmsg)
        {
            string query = GetDeleteQuery(tableName, nickName);
            return mysql.Execute(query, ref errmsg);
        }

        public static string GetDeleteAllQuery(string tableName)
        {
            return string.Format("delete from {0};", tableName);
        }
        public bool DeleteAllGuitars(string tableName, ref string errmsg)
        {
            string query = GetDeleteAllQuery(tableName);
            return mysql.Execute(query, ref errmsg);
        }

        /* the following function, ParseResults, takes MySqlReader produced, for example,
         * by MySqlDatabase's Select function, and flows that data in the reader into 
         * a List<string>[]. Each List<string> in that array represents an entire column.
         * In this guitar example, we have four columns. So, we will dimension the array to have
         * four columns. 
         */
        public static List<string>[] ParseResults(MySqlDataReader dr)
        {
            const int COLCOUNT = 4;
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
                    results[0].Add("" + dr["NickName"]);
                    results[1].Add("" + dr["ManufName"]);
                    results[2].Add("" + dr["ModelName"]);
                    results[3].Add("" + dr["YearMade"]);
                }
                dr.Close();
            }
            else
            {
                results = null;
            }
            return results;
        }
        public List<string>[] SelectGuitarsAsStrings(string query, ref string errmsg)
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
        public List<Guitar> SelectAsGuitars(string query, ref string errmsg)
        {
            MySqlDataReader dr = mysql.Select(query, ref errmsg);
            if (dr != null)
            {
                return ParseGuitars(dr);
            }
            else
            {
                return null;
            }
        }
        public List<Guitar> ParseGuitars(MySqlDataReader dr)
        {
            List<Guitar> results;
            List<string>[] strings = ParseResults(dr);
            if (strings != null)
            {
                results = new List<Guitar>();
                for (int i = 0; i < strings[0].Count; i++)
                {
                    results.Add(new Guitar(strings[0][i], strings[1][i], strings[2][i], int.Parse(strings[3][i]));
                }
                return results;
            }
            else
            {
                return null;
            }
        }
    }
}
