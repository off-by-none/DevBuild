using System;

namespace Lab2._2_TableOfPowers
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont = "y";

            while (cont == "y" || cont == "yes" || cont == "y ")
            {
                Console.Clear();
                Console.Write("Learn your squares and cubes!\n\n");
                Console.Write("Enter a positive integer greater than zero: ");
                int.TryParse(Console.ReadLine(), out int num);

                if (num <= 0)
                {
                    Console.WriteLine("Not a valid input.");
                    Console.WriteLine("Please enter a positive integer greater than zero.");
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }

                if (num > 1290)
                {
                    Console.WriteLine("Input is too large when cubed.");
                    Console.WriteLine("Please enter a smaller integer.");
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }

                Console.Write("\nNumber\t\tSquared\t\tCubed\n");
                Console.Write("=======\t\t=======\t\t=======\n");

                for (int i = 1; i <= num; i++)
                {
                    Console.WriteLine($"{i, 7}\t\t{(int)Math.Pow(i, 2), 7}\t\t{(int)Math.Pow(i, 3), 7}");
                }

                Console.Write("\nContinue? (y/n): ");
                cont = Console.ReadLine().ToLower();
            }
        }
    }
}
