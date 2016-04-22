using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DBCollectionManagement
{
    class Serializer
    {
        public static bool SaveToBinary(string[] title, string[] platform, string[] company, string[] year, string fname)
        {
            string[] result;
            result = new string[20];
            for (int i = 0; i < title.Length; i++)
            {
                result[i] = title[i] + " " + platform[i] + " " + company[i] + " " + year[i];
            }
            string msg = "";
            try
            {
                Stream st = File.Create(fname);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, result);
                st.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error: " + e);
                return false;
            }
        }
        public static string[] LoadFromBinary(string fname)
        {
            Stream st;
            BinaryFormatter bf;
            string[] result = new string[20];
            try
            {
                st = File.OpenRead(fname);
                bf = new BinaryFormatter();
                result = (string[])bf.Deserialize(st);
                st.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error: " + e);
                return null;
            }
        }
    }
}
