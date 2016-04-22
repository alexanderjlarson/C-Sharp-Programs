using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            Console.Write("Enter full path for log file: ");
            fileName = Console.ReadLine();
            TextWriter tw = new StreamWriter(fileName);
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(10);
                tw.WriteLine("System ok at {0}.", DateTime.Now);
            }
            
            tw.Close();
            TextReader tr = new StreamReader(fileName);
            string lineRead;
            string[] contents = new string[1000];
            int counter = 0;
            while ((lineRead = tr.ReadLine()) != null)
            {
                contents[counter] = lineRead;
                counter++;
                Console.WriteLine(lineRead);
            }
            tr.Close();
            Console.WriteLine("Done");
            Console.WriteLine("Here's a randomly chosen line: ");
            Random rnd = new Random();
            Console.WriteLine(contents[rnd.Next(counter)]);

        }
    }
}
