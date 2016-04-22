using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names;
            int age;
            string fname;
            string lname;
            Console.Write("Enter your first and last name: ");
            string fullName = Console.ReadLine();
            names = fullName.Split(' ');
            fname = names[0];
            lname = names[1];
            Console.WriteLine("Your name in last,first format is {0}, {1}", lname, fname);

            Console.Write("How old are you? ");
            string ageStr = Console.ReadLine();
            age = int.Parse(ageStr);
            if (age < 25)
            {
                Console.WriteLine("I envy you");
            }
            else if (age < 40)
            {
                Console.WriteLine("Life is starting to weigh you down");
            }
            else
            {
                Console.WriteLine("How's that hairline treating you?");
            }
        }
    }
}
