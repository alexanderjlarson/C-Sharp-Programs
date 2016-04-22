using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers separated by a space, and I'll print their sum: ");
            string response = Console.ReadLine();
            string[] vals = response.Split(' ');
            try
            {
                int first = int.Parse(vals[0]);
                int second = int.Parse(vals[1]);
                int sum = first + second;
                Console.WriteLine("here is the sum : {0}.", sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following error happened.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("I wish I lived in Florida.");
            }
        }
    }
}
