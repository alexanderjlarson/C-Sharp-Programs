using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            name = "Alex Larson";
            string otherName;
            otherName = new string('m', 10);
            Console.WriteLine(name);
            Console.WriteLine(otherName);

            if (name.Equals(otherName))
            {
                Console.WriteLine("They are equal.");
            }
            else
            {
                Console.WriteLine("They are not equal.");
            }

            string fullName = name.Insert(5, "Taco ");
            Console.WriteLine(fullName);
            fullName = fullName.Replace("Taco", "J");
            Console.WriteLine(fullName);

            string middleInitial = fullName.Substring(5, 1);
            Console.WriteLine(middleInitial);

            int spaceLoc = fullName.IndexOf(' ');
            Console.WriteLine("Space found at {0}", spaceLoc);

            Console.WriteLine("We'll now determine the number of words in two different ways.");
            Console.WriteLine("First using split.");
            string[] names;
            names = fullName.Split(' ');
            foreach (string s in names)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("There are {0} words in fullName.", names.Length);

            Console.WriteLine("A second way, this time using indexOf repeatedly.");
            int counter = 0;
            spaceLoc = fullName.IndexOf(' ');
            while (spaceLoc >= 0)
            {
                counter = counter + 1;
                spaceLoc = fullName.IndexOf(' ', spaceLoc + 1);
            }
            counter++;
            Console.WriteLine("Using indexOf, we found {0} words.", counter);

            Console.WriteLine("Here is a third and final way to count the number of words.");
            Console.WriteLine("Search character by character for where there are spaces.");
            counter = 0;
            foreach(char c in fullName)
            {
                if (c == ' ')
                {
                    counter++;
                }
            }
            counter++;
            Console.WriteLine("Searching char by char, we found {0} words.", counter);

            Console.Write("Give me a position number, and I'll tell what character is there: ");
            int pos = int.Parse(Console.ReadLine());
            Console.WriteLine("The character at position {0} is {1}.", pos, fullName[pos]);

        }
    }
}
