using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/* Algorithm:
 * Read the names file into an array of strings called names. Keep track of how many (nameCount)
 * Read the events file into an array of strings called events. Keep track of how many (eventCount)
 * Read the document file into an array of strings called lines. Keep track of how many (lineCount)
 * for each name
 *      for each event
 *          for each line
 *              plug in the name and event
 *              output to screen.
 *              split the line into tokens
 *              for each token
 *                  test if it's a place holder
 *                  if it's a name placeholder, print the current name
 *                  if it's an event placeholder, print the current event
 *                  otherwise, just print the token.
 *              next token
 *           next line
 *       next event
 *  next name
 */
namespace mailMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CAP = 10;
            const string PATH = @"c:\users\wsguest\desktop\";
            string fname; //user will enter the file manes into this
            string[] names = new string[CAP];
            int nameCount = 0;
            string[] events = new string[CAP];
            int eventCount = 0;
            string[] lines = new string[CAP];
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
            while ((lines[lineCount] = tr.ReadLine()) != null)
            {
                lineCount++;
            }
            tr.Close();
            string[] parts;
            for (int n = 0; n < nameCount; n++)
            {
                for (int e = 0; e < eventCount; e++)
                {
                    for (int i = 0; i < lineCount; i++)
                    {
                        parts = lines[i].Split(' ');
                        for (int p = 0; p < parts.Length; p++)
                        {
                            if (parts[p].Equals("<name>"))
                            {
                                Console.Write(names[n]);
                            }
                            else if (parts[p].Equals("<event>"))
                            {
                                Console.Write(events[e]);
                            }
                            else
                            {
                                Console.Write(parts[p]);
                            }
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Done");

        }
    }
}
