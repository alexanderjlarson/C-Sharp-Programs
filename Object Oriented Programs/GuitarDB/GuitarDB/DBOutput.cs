using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuitarDB
{
    class DBOutput
    {
        public static void WriteTabulatedData(List<string>[] results)
        {
            for (int i = 0; i < results[0].Count; i++)
            {
                for (int c = 0; c < results.Length; c++)
                {
                    Console.Write(results[c][i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
