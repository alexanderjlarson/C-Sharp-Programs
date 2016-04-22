using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database245;

namespace GuitarDB
{
    class Program
    {
        static int showMenu()
        {
            Console.WriteLine("Here are your choices");
            Console.WriteLine("1. Insert a guitar");
            Console.WriteLine("2. Remove a guitar");
            Console.WriteLine("3. Remove all guitars");
            Console.WriteLine("4. Report guitars");
            Console.WriteLine("Enter your choice");
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
            List<string>[] results;
            MySqlDatabase mysql = new MySqlDatabase("localhost", "Instruments", "root", "Flyers2013");
            Console.WriteLine("Enter the name of the guitar table: ");
            string tableName = Console.ReadLine();
            if (mysql.OpenConnection(ref errmsg))
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
                            if (mysql.Execute(query, ref errmsg))
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
                            if (mysql.Execute(query, ref errmsg))
                            {
                                Console.WriteLine("Guitar was deleted.");
                            }
                            else
                            {
                                Console.WriteLine("error: " + errmsg);
                            }
                            break;
                        case 3:
                            Console.Write("Are you sure you want to delete all guitars? ");
                            confirm = Console.ReadLine().ToUpper();
                            if (confirm == "Y")
                            {
                                query = GuitarDBQuery.GetClearQuery(tableName);
                                if (mysql.Execute(query, ref errmsg))
                                {
                                    Console.WriteLine("You are guitar-less");
                                }
                                else
                                {
                                    Console.WriteLine("error: " + errmsg);
                                }
                            }
                            break;
                        case 4:
                            results = GuitarDBQuery.ParseResults(mysql.Select("select * from " + tableName + ";", ref errmsg));
                            break;
                    }
                } while (choice != 5);
            }
            else
            {
                Console.WriteLine("Couldn't open database: " + errmsg);
            }
        }
    }
}
