using System;

namespace Lab2._1_RoomCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double length;
            double width;
            double height;
            string cont = "y";
            
            Console.WriteLine("Welcome to Grand Circus' Room Detail Generator!");

            while (cont == "y")
            {
                Console.Write("\nEnter Length (feet): ");
                string l = Console.ReadLine();
                length = double.Parse(l);

                Console.Write("Enter Width (feet): ");
                string w = Console.ReadLine();
                width = double.Parse(w);

                Console.Write("Enter Height (feet): ");
                string h = Console.ReadLine();
                height = double.Parse(h);

                double area = length * width;
                double perimeter = 2 * (length + width);
                double volume = area * height;
                string size;

                if (area <= 250)
                {
                    size = "small";
                }
                else if (area < 650)
                {
                    size = "medium";
                }
                else
                {
                    size = "large";
                }

                Console.WriteLine("\nArea is " + area + " squared feet.");
                Console.WriteLine("Perimeter is " + perimeter + " feet.");
                Console.WriteLine("Volume is " + volume + " cubic feet.");
                Console.WriteLine("This is a " + size + "-sized room.\n");
                Console.Write("Continue? (y/n): ");

                cont = Console.ReadLine().ToLower();
                Console.WriteLine("*******************");
            }
                Console.WriteLine("\nThank you for using the Room Detail Generator!\n");
        }
    }
}
