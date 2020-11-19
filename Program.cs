using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of multipliers to display:");
            string input = Console.ReadLine();
            int inputInteger;
            if (!int.TryParse(input, out inputInteger))
            {
                Console.WriteLine("Invalid number entered. Please restart and try again.");
                Console.ReadKey();
                return;
            }
            int max = (int)Math.Floor(Math.Sqrt(int.MaxValue));
            if (inputInteger < 1 || inputInteger > max)
            {
                Console.WriteLine("Please enter a value between {0} and {1}", 1, max);
                Console.ReadKey();
                return;
            }
            long[,] multiplicationTable = new long[inputInteger, inputInteger];
            PopulateMultiplicationTable(inputInteger, multiplicationTable);
            DisplayMultiplicationTable(inputInteger, multiplicationTable);
            Console.ReadKey();
        }

        private static void DisplayMultiplicationTable(int inputInteger, long[,] multiplicationTable)
        {
            int fieldLength = multiplicationTable[inputInteger - 1, inputInteger - 1].ToString().Length;
            string formatString = "{0," + fieldLength + "}";
            Console.WriteLine("The multiplication table for {0} is:", inputInteger);
            for (int y = 0; y <= inputInteger; y++)
            {
                for (int x = 0; x <= inputInteger; x++)
                {
                    if (y == 0 && x == 0)
                        Console.Write(string.Format(formatString, ""));
                    else if (x == 0)
                        Console.Write(string.Format(formatString, y));
                    else if (y == 0)
                        Console.Write(string.Format(" " + formatString, x));
                    else
                        Console.Write(string.Format(" " + formatString, multiplicationTable[x - 1, y - 1]));
                }
                Console.WriteLine();
            }
        }

        private static void PopulateMultiplicationTable(int inputInteger, long[,] multiplicationTable)
        {
            for (int y = 1; y <= inputInteger; y++)
                for (int x = 1; x <= inputInteger; x++)
                    multiplicationTable[x - 1, y - 1] = (long)x * (long)y;
        }
    }
}
