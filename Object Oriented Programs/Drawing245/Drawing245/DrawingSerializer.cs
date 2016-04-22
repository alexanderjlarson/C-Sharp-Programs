using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Drawing245
{
    class DrawingSerializer
    {
        public static bool SaveToBinary(Drawing d, string fname, ref string msg)
        {
            msg = "";
            try
            {
                Stream st = File.Create(fname);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, d);
                st.Close();
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }
            
        }
        public static Drawing LoadFromBinary(string fname, ref string msg)
        {
            Stream st;
            BinaryFormatter bf;
            Drawing result;
            msg = "";
            try
            {
                st = File.OpenRead(fname);
                bf = new BinaryFormatter();
                result = (Drawing)bf.Deserialize(st);
                st.Close();
                return result;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
        }
    }
}
