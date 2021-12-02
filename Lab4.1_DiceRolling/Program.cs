using System;

namespace Lab41_DiceRolling
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSides;
            int roll1;
            int roll2;
            char cont;
            
            Console.WriteLine("Welcome to the Grand Circus Casino!");

            do
            {
                numSides = GetDiceSides();
                roll1 = RollDice(numSides);
                roll2 = RollDice(numSides);
                Console.WriteLine($"\nYou rolled a {roll1} and a {roll2} for a total of {roll1 + roll2}.");

                if (numSides == 6)
                {
                    Console.WriteLine(d6message(roll1, roll2));
                }

                cont = WantCont();
            } while (cont == 'y');

            Console.WriteLine("\n\nThank for playing!!");
        }

        static int GetDiceSides()
        {
            bool isValid;
            int numSides;
            bool check = true;

            Console.Write("\n\nHow many sides should each die have?: ");
            isValid = int.TryParse(Console.ReadLine(), out numSides);

            while (check)
            {
                if (!isValid)
                {
                    Console.Write("\nPlease enter a number: ");
                    isValid = int.TryParse(Console.ReadLine(), out numSides);
                }
                else if (numSides <= 0)
                {
                    Console.Write("\nPlease enter a number greater than 0: ");
                    isValid = int.TryParse(Console.ReadLine(), out numSides);
                }
                else
                {
                    check = false;
                }
            }
            return numSides;
        }

        static int RollDice(int sides)
        {
            Random roll = new Random();
            return roll.Next(1, sides + 1);
        }

        static string d6message(int a, int b)
        {
            if (a + b == 2)
            {
                return "Snake Eyes\nCraps!";
            }
            else if (a + b == 3)
            {
                return "Ace Deuce\nCraps!";
            }
            else if (a + b == 12)
            {
                return "Box Cars\nCraps!";
            }
            else if (a + b == 7 || a + b == 11)
            {
                return "Win!";
            }
            else
            {
                return "";
            }
        }

        static char WantCont()
        {
            char cont;

            do
            {
                Console.Write("\nRoll again? (y/n): ");
                cont = Console.ReadKey().KeyChar;
                if (cont == 'n' || cont == 'N')
                {
                    return 'n';
                }
            } while (cont != 'y' && cont != 'Y');
            return 'y';

        }
    }
}