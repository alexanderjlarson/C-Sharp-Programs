using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Database245;

namespace GuitarDB
{
    class Program
    {
        static int showMenu()
        {
            Console.WriteLine("Here are your choices: ");
            Console.WriteLine("1. Insert a guitar.");
            Console.WriteLine("2. Remove a guitar.");
            Console.WriteLine("3. Remove all guitars.");
            Console.WriteLine("4. Report guitars.");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            string errmsg = "";
            string query;
            int choice;
            string nick, manuf, model;
            int year;
            string confirm;
            GuitarDBQuery dbq = new GuitarDBQuery("localhost", "Instruments", "root", "Flyers2013");
            //MySqlDatabase mysql = new MySqlDatabase("localhost", "Instruments", "root", "");
            Console.Write("Enter the name of the guitar table: ");
            string tableName = Console.ReadLine();
            List<string>[] results;
            if (dbq.OpenConnection(ref errmsg))
            {
                do
                {
                    choice = showMenu();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter NickName: ");
                            nick = Console.ReadLine();
                            Console.WriteLine("Enter manufacturer: ");
                            manuf = Console.ReadLine();
                            Console.WriteLine("Enter model: ");
                            model = Console.ReadLine();
                            Console.WriteLine("Enter year: ");
                            year = int.Parse(Console.ReadLine());
                            query = GuitarDBQuery.GetInsertQuery(tableName, nick, manuf, model, year);
                            if (dbq.InsertGuitar(tableName, nick, manuf, model, year, ref errmsg))
                            {
                                Console.WriteLine("Guitar was added.");
                            }
                            else
                            {
                                Console.WriteLine("Error: " + errmsg);
                            }
                            break;
                        case 2:
                            Console.Write("Enter name of guitar to delete: ");
                            nick = Console.ReadLine();
                            query = GuitarDBQuery.GetDeleteQuery(tableName, nick);
                            if (dbq.DeleteGuitar(tableName, nick, ref errmsg))
                            {
                                Console.WriteLine("Guitar was deleted.");
                            }
                            else
                            {
                                Console.WriteLine("error: " + errmsg);
                            }
                            break;
                        case 3:
                            Console.Write("Are you sure you want to remove all guitars? ");
                            confirm = Console.ReadLine().ToUpper();
                            if (confirm == "Y") {
                                query = GuitarDBQuery.GetDeleteAllQuery(tableName);
                                if (dbq.DeleteAllGuitars(tableName,ref errmsg)) {
                                    Console.WriteLine("You are guitar-less.");
                                } else {
                                    Console.WriteLine("Error: " + errmsg);
                                }
                            }
                            break;
                        case 4:
                            results = dbq.SelectGuitarsAsStrings("select * from " + tableName,ref errmsg));
                            if (results != null)
                            {
                                DBOutput.WriteTabulatedData(results);
                            }
                            else
                            {
                                Console.WriteLine("An error occurred " + errmsg);
                            }
                            break;
                    }
                } while (choice != 5);
            }
            else
            {
                Console.WriteLine("Couldn't open database: " + errmsg);
            }
            Console.WriteLine("Have a nice day.");
            Console.ReadKey();
        }
    }
}
