using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseConnector;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DBCollectionManagement
{
    class Program
    {
        public static string host, db, user, pass;

        static int showMenu()
        {
            Console.WriteLine("Here are your choices");
            Console.WriteLine("1. Insert a video game");
            Console.WriteLine("2. Remove a video game");
            Console.WriteLine("3. List video games");
            Console.WriteLine("4. Save video games");
            Console.WriteLine("5. Read video games from file");
            Console.WriteLine("6. Configure database connectivity");
            Console.WriteLine("7. Save video games to a database table");
            Console.WriteLine("8. Load video games from a database table");
            Console.WriteLine("9. Search for a video game in a database table");
            Console.WriteLine("10. Exit");
            Console.WriteLine("Enter your choice");
            return int.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            string errmsg = "";
            string fname;
            string[] stuff = new string[20];
            string[] parts = new string[20];
            int choice;
            string tableName = "";
            string Title;
            int i = 0;
            string[] title, platform, company, year;
            title = new string[20];
            platform = new string[20];
            company = new string[20];
            year = new string[20];
            List<string>[] results;
            MySqlDatabase mysql = new MySqlDatabase();
            GamesDBQuery dbq = new GamesDBQuery();
            do
            {
                choice = showMenu();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Enter the title: ");
                        title[i] = Console.ReadLine();
                        Console.WriteLine("Enter the platform: ");
                        platform[i] = Console.ReadLine();
                        Console.WriteLine("Enter the company name: ");
                        company[i] = Console.ReadLine();
                        Console.WriteLine("Enter the year released: ");
                        year[i] = Console.ReadLine();
                        i++;
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Enter title of video game to delete: ");
                        Title = Console.ReadLine();
                        for(int j = 0; j < title.Length; j++)
                        {
                            if (title[j] == Title)
                            {
                                title[j] = null;
                                platform[j] = null;
                                company[j] = null;
                                year[j] = null;
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        for (int j = 0; j < title.Length; j++)
                        {
                            if (title[j] != null && title[j] != "")
                            {
                                Console.WriteLine(title[j] + ", " + platform[j] + ", " + company[j] + ", " + year[j]);
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter file name to save to.");
                        fname = Console.ReadLine();
                        Serializer.SaveToBinary(title, platform, company, year, fname);
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Enter file name to read from.");
                        fname = Console.ReadLine();
                        stuff = Serializer.LoadFromBinary(fname);
                        if (stuff != null)
                        {
                            for (int j = 0; j < stuff.Length; j++)
                            {
                                parts = stuff[j].Split(' ');
                                if (parts[0] != "")
                                {
                                    title[j] = parts[0];
                                    platform[j] = parts[1];
                                    company[j] = parts[2];
                                    year[j] = parts[3];
                                    i++;
                                }
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine();
                        Console.Write("Enter the name of the database server: ");
                        host = Console.ReadLine();
                        Console.Write("Enter the name of the database on server {0}: ", host);
                        db = Console.ReadLine();
                        Console.Write("Enter the user name for database {0}: ", host);
                        user = Console.ReadLine();
                        Console.Write("Enter the password for database {0}: ", host);
                        pass = Console.ReadLine();
                        dbq = new GamesDBQuery(host, db, user, pass);
                        if (dbq.OpenConnection(ref errmsg))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Connection to {0}.{1} successful!", host, db);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error: " + errmsg);
                            Console.WriteLine();
                        }
                        break;
                    case 7:
                        Console.WriteLine();
                        Console.WriteLine("The current database is {0}.{1}.", host, db);
                        Console.Write("Enter name of table you want to add to: ");
                        tableName = Console.ReadLine();
                        for (int j = 0; j < title.Length; j++)
                        {
                            if (title[j] != null && title[j] != "")
                            {
                                dbq.InsertGame(tableName, title[j], platform[j], year[j], company[j], ref errmsg);
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 8:
                        Console.WriteLine();
                        Console.WriteLine("The current database is {0}.{1}.", host, db);
                        Console.Write("Enter name of table you want to read from: ");
                        tableName = Console.ReadLine();
                        results = dbq.SelectAsStrings("select * from " + tableName, ref errmsg);
                        if (results != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Your video game collection was successfully loaded.");
                            Console.WriteLine();
                            DBOutput.WriteTabulatedData(results);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("An error occured " + errmsg);
                            Console.WriteLine();
                        }
                        break;
                    case 9:
                        Console.WriteLine();
                        Console.Write("Enter name of table you want to read from: ");
                        tableName = Console.ReadLine();
                        Console.Write("Enter the Title of the Video Game to find: ");
                        Title = Console.ReadLine();
                        results = dbq.SelectAsStrings("select * from " + tableName + " where Title='"+Title+"';", ref errmsg);
                        if (results != null)
                        {
                            Console.WriteLine();
                            DBOutput.WriteTabulatedData(results);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("An error occured " + errmsg);
                            Console.WriteLine();
                        }
                        break;
                }
            } while (choice != 10);
        }
    }
}
