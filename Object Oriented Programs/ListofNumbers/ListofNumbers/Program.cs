using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListofNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers;
            string[] inputs;
            Console.WriteLine("Enter a list of integers seperated by spaces. ");
            inputs = Console.ReadLine().Split(' ');
            numbers = new int[inputs.Length];
            int sum = 0;
            float avg;
            float med;
            int midPos;
            try
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    numbers[i] = int.Parse(inputs[i]);
                    sum = sum + numbers[i];
                }
                avg = (float)sum / numbers.Length;
                midPos = numbers.Length / 2;
                Console.WriteLine("The average was {0}.", avg);
                Array.Sort(numbers);
                if (numbers.Length % 2 != 0) //odd number of numbers
                {
                    med = numbers[midPos];
                }
                else
                {
                    med = (numbers[midPos] + numbers[midPos - 1]) / 2;
                }
                Console.WriteLine("The median was {0}.", med);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Everything you type has to be an integer.");
            }
        }
    }
}
