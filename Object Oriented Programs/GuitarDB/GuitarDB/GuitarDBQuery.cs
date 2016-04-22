using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace GuitarDB
{
    class GuitarDBQuery
    {
        static const int COLCOUNT = 4;
        public static string GetInsertQuery(string tableName, string nickName, string manufName, string modelName, int yearMade)
        {
            return string.Format("insert into {0} values ('{1}','{2}','{3}',{4});", tableName, nickName, manufName, modelName, yearMade);
        }

        public static string GetDeleteQuery(string tableName, string nickName)
        {
            return string.Format("delete from {0} where NickName = '{1}';", tableName, nickName);
        }

        public static string GetClearQuery(string tableName)
        {
            return string.Format("delete from {0};", tableName);
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
    }
}
