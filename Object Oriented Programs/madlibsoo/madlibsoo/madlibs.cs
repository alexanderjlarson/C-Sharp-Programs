using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MadLibs
{
    class FileLoader
    {
        private string path;
        public FileLoader(string str)
        {
            path = str;
        }
        public FileLoader()
        {
            path = "";
        }
        public string[] LoadFromFile(string fname, ref int count, ref string errmsg)
        {
            string[] result = new string[10];
            count = 0;
            string line;
            TextReader tr;
            try
            {
                tr = new StreamReader(path + fname);
                while ((line = tr.ReadLine()) != null)
                {
                    result[count] = line;
                    count++;
                }
            }
            catch (Exception e)
            {
                errmsg = e.Message;
                return null;
            }
            tr.Close();
            return result;
    }
    class Program
    {
        
        }
        static void Main(string[] args)
        {
            string filename;
            string line;
            string word;
            Random rnd = new Random();
            string[] parts;
            int index;
            char doAgain = (' ');
            string[] snouns;
            int snouncount = 0;
            string[] pnouns;
            int pnouncount = 0;
            string[] sverbs;
            int sverbcount = 0;
            string[] pverbs;
            int pverbcount = 0;
            string[] adjs;
            int adjcount = 0;
            string[] advs;
            int advcount = 0;
            string[] locs;
            int loccount = 0;
            string[] names;
            int namecount = 0;
            string errmsg = "";
            TextReader reader;
            FileLoader loader = new FileLoader(@"c:\temp\");
            
            Console.WriteLine("Enter the name of a file that contains singular nouns: ");
            filename = Console.ReadLine();
            snouns = loader.LoadFromFile(filename, ref snouncount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains plural nouns: ");
            filename = Console.ReadLine();
            pnouns = loader.LoadFromFile(filename, ref pnouncount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains singular verbs: ");
            filename = Console.ReadLine();
            sverbs = loader.LoadFromFile(filename, ref sverbcount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains plural verbs: ");
            filename = Console.ReadLine();
            pverbs = loader.LoadFromFile(filename, ref pverbcount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains adjectives: ");
            filename = Console.ReadLine();
            adjs = loader.LoadFromFile(filename, ref adjcount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains adverbs: ");
            filename = Console.ReadLine();
            advs= loader.LoadFromFile(filename, ref advcount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains locations: ");
            filename = Console.ReadLine();
            locs= loader.LoadFromFile(filename, ref loccount, ref errmsg);
            Console.WriteLine("Enter the name of a file that contains names: ");
            filename = Console.ReadLine();
            names = loader.LoadFromFile(filename, ref namecount, ref errmsg);
            do
            {
                Console.WriteLine("Enter the name of a story file: ");
                filename = Console.ReadLine();
                TextReader tr = new StreamReader(filename);
                while ((line = tr.ReadLine()) != null)
                {
                    parts = line.Split(' ');
                    foreach (string part in parts)
                    {
                        if (part.Equals("<snou>"))
                        {
                            index = rnd.Next(snouncount);
                            Console.Write("{0} ", snouns[index]);
                        }
                        else if (part.Equals("<pnou>"))
                        {
                            index = rnd.Next(pnouncount);
                            Console.Write("{0} ", pnouns[index]);
                        }
                        else if (part.Equals("<svrb>"))
                        {
                            index = rnd.Next(sverbcount);
                            Console.Write("{0} ", sverbs[index]);
                        }
                        else if (part.Equals("<pvrb>"))
                        {
                            index = rnd.Next(pverbcount);
                            Console.Write("{0} ", pverbs[index]);
                        }
                        else if (part.Equals("<adje>"))
                        {
                            index = rnd.Next(adjcount);
                            Console.Write("{0} ", adjs[index]);
                        }
                        else if (part.Equals("<adve>"))
                        {
                            index = rnd.Next(advcount);
                            Console.Write("{0} ", advs[index]);
                        }
                        else if (part.Equals("<loca>"))
                        {
                            index = rnd.Next(loccount);
                            Console.Write("{0} ", locs[index]);
                        }
                        else if (part.Equals("<name>"))
                        {
                            index = rnd.Next(namecount);
                            Console.Write("{0} ", names[index]);
                        }
                        else
                        {
                            Console.Write("{0} ", part);
                        }
                    }
                    Console.WriteLine();
                    Console.Write("Want to load another story file (y or n)? ");
                    doAgain = char.Parse(Console.ReadLine());
                }
                tr.Close();
                tr = null;
            }
            while (doAgain == 'y');
            if (doAgain == 'n')
            {
                Console.WriteLine("Bye!");
            }
            Console.WriteLine();
        }
    }
}

