using System;

namespace Lab52_RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            HumanPlayer player1 = new HumanPlayer(GetName(), 0, 0, 0, 0);
            Player computer = null;

            if (GetOpponent(player1.Name) == 'j')
            {
                computer = new RockPlayer("TheJets", 0, 0, 0, 0);
            }
            else
            {
                computer = new RandomPlayer("TheSharks", 0, 0, 0, 0);
            }
            
            do
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine($"\n\n{player1.Name}: {player1.GenerateRoshambo()}");
                Console.WriteLine($"{computer.Name}: {computer.GenerateRoshambo()}");
                determineWinner(player1, computer.RoshamboValue, computer.Name);
            } while (WantCont());

            Console.WriteLine("\nThank you for playing!");
            Console.WriteLine($"\nYou had {player1.Wins} wins, {player1.Losses} losses and {player1.Draws} draws.\n");
        }


        static void PrintHeader()
        {
            Console.WriteLine
                (@"
                  ___         _     ___                      ___     _                   
                 | _ \___  __| |__ | _ \__ _ _ __  ___ _ _  / __| __(_)______ ___ _ _ ___
                 |   / _ \/ _| / / |  _/ _` | '_ \/ -_) '_| \__ \/ _| (_-<_-</ _ \ '_(_-<
                 |_|_\___/\__|_\_\ |_| \__,_| .__/\___|_|   |___/\__|_/__/__/\___/_| /__/
                                            |_| 
                ");
        }


        static string GetName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            return name;
        }


        static char GetOpponent(string name)
        {
            char opponent;
            Console.Clear();
            PrintHeader();
            Console.WriteLine($"Hello {name}!");

            do
            {
                Console.Write("\nWould you like to play against TheJets or TheSharks (j/s)?: ");
                opponent = Console.ReadKey().KeyChar;
            } while (opponent != 'j' && opponent != 'J' && opponent != 's' && opponent != 'S');

            Console.Clear();
            PrintHeader();

            if (opponent == 'j' || opponent == 'J')
            {
                Console.WriteLine("You are playing against TheJets!");
                return 'j';
            }
            else
            {
                Console.WriteLine("You are playing against TheSharks!");
                return 's';
            }
        }


        static void determineWinner(HumanPlayer player1, RoshamboEnum computer, string computerName)
        {
            if (player1.RoshamboValue.Equals(computer))
            {
                Console.WriteLine("Draw!");
                player1.Draws++;
            }
            else if (player1.RoshamboValue.Equals(RoshamboEnum.Rock))
            {
                if (computer.Equals(RoshamboEnum.Paper))
                {
                    Console.WriteLine($"{computerName} Wins!");
                    player1.Losses++;
                }
                else 
                { 
                    Console.WriteLine($"{player1.Name} Wins!");
                    player1.Wins++;
                }
            }
            else if (player1.RoshamboValue.Equals(RoshamboEnum.Paper))
            {
                if (computer.Equals(RoshamboEnum.Rock))
                {
                    Console.WriteLine($"{player1.Name} Wins!");
                    player1.Wins++;
                }
                else 
                { 
                    Console.WriteLine($"{computerName} Wins!");
                    player1.Losses++;
                }
            }   
            else
            {
                if (computer.Equals(RoshamboEnum.Rock))
                {
                    Console.WriteLine($"{computerName} Wins!");
                    player1.Losses++;
                }
                else 
                { 
                    Console.WriteLine($"{player1.Name} Wins!");
                    player1.Wins++;
                }
            }   
        }


        static bool WantCont()
        {
            char cont;

            do
            {
                Console.Write("\nWould you like to play again? (y/n): ");
                cont = Console.ReadKey().KeyChar;
                if (cont == 'n' || cont == 'N')
                {
                    Console.WriteLine();
                    return false;
                }
            } while (cont != 'y' && cont != 'Y');
            return true;
        }
    }
}