using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mailMerge
{
    class Program
    {
        static string stripPunctuation(string str, ref string punct)
        {
            string result = str;
            punct = "";
            if (Char.IsPunctuation(str[str.Length - 1]))
            {
                punct = str.Substring(str.Length - 1);
                result = str.Substring(0, str.Length - 1);
            }
            return result;
        }
        static void Main(string[] args)
        {
            const int CAP = 10;
            const string PATH = @"c:\users\wsguest\desktop\";
            string fname; //user will enter the file manes into this
            string[] names = new string[CAP];
            int nameCount = 0;
            string[] events = new string[CAP];
            int eventCount = 0;
            int lineCount = 0;
            Console.Write("Enter the name of the file of recipients: ");
            fname = Console.ReadLine();
            TextReader tr = new StreamReader(PATH + fname);
            while ((names[nameCount] = tr.ReadLine()) != null)
            {
                nameCount++;
            }
            tr.Close();
            Console.Write("Enter the name of the file of events: ");
            fname = Console.ReadLine();
            tr = new StreamReader(PATH + fname);
            while ((events[eventCount] = tr.ReadLine()) != null)
            {
                eventCount++;
            }
            tr.Close();
            Console.Write("Enter the name of the document to merger: ");
            fname = Console.ReadLine();
            tr = new StreamReader(PATH + fname);
            string name;
            string ev;
            Random rnd = new Random();
            name = names[rnd.Next(nameCount)];
            ev = events[rnd.Next(eventCount)];
            string line;
            string[] parts;
            string tokenNoPunct;
            string punct = "";
            while ((line = tr.ReadLine()) != null)
            {
                parts = line.Split(' ');
                foreach (string part in parts)
                {
                    //Or line = line.Trim();
                    if (!(part.Equals("")))
                    {
                        tokenNoPunct = stripPunctuation(part, ref punct);
                        if (tokenNoPunct.Equals("<name>"))
                        {
                            Console.Write(names[rnd.Next(nameCount)]);
                        }
                        else if (tokenNoPunct.Equals("<event>"))
                        {
                            Console.Write(ev);
                        }
                        else
                        {
                            Console.Write(tokenNoPunct);
                        }
                        Console.Write(punct + " ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
