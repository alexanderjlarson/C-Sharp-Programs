using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicensePlate
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            char[] letters = new char[7];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = Convert.ToChar(rnd.Next(65, 91));
            }
            string plate = new string(letters);
            Console.WriteLine("The new license plate it {0} {1}.", plate.Substring(0,3), plate.Substring(3,4));
        }
    }
}
