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
            for (int r = 0; r < results[0].Count; r++)
            {
                for (int c = 0; c < results.Length; c++)
                {
                    Console.Write(results[c][r] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
