using System;
using System.Collections.Generic;

namespace Lab51_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameCharacter> gameCharacters = new List<GameCharacter>();
            gameCharacters.Add(new Warrior("Tnarg the Barbarian", 16, 9, "Axe"));
            gameCharacters.Add(new Warrior("Kincaid the Fighter", 15, 16, "Longsword"));
            gameCharacters.Add(new Warrior("Grant the Viking", 15, 16, "Spear"));
            gameCharacters.Add(new Wizard("Lady Witherell the Wizard", 11, 18, 10, 5));
            gameCharacters.Add(new Wizard("Pearl the Magician", 12, 17, 9, 4));

            PrintHeader();
            Console.WriteLine("Characters\n=======================\n");

            foreach (GameCharacter c in gameCharacters)
            {
                c.Play();
            }

            SetConsole();
        }


        static void SetConsole()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("\nPress ESC key to exit.");
            Console.SetCursorPosition(0, 0);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }


        static void PrintHeader()
        {
            Console.WriteLine("     \\p/");
            Console.WriteLine("      O       ________________");
            Console.WriteLine("      |      |                |   _____________________________");
            Console.WriteLine("      T______|                |  |                             \\");
            Console.WriteLine("      P\\     |                |__|        Welcome to           <");
            Console.WriteLine("      | |    |                |  |                              >");
            Console.WriteLine("      | |    |                |  |   World of Dev.Buildcraft!  /");
            Console.WriteLine("      | |    |________________|  |                             >");
            Console.WriteLine("      | |    \\              |/   |____________________________<");
            Console.WriteLine("      |/______\\             /____\\|");
            Console.WriteLine("      P");
            Console.WriteLine("   __ |  __    __                                              __    __    __");
            Console.WriteLine("  |  |I_|  |__|  |                                            <  |__|  |__|  |");
            Console.WriteLine("                 |                                            />   \\");
            Console.WriteLine("  _______________|                                            |____/\\_________");
            Console.WriteLine("  ______________>                                              < __><\\________");
            Console.WriteLine("  _____________/                                                \\_<__/________");
            Console.WriteLine("    |   |   | |_    __    __    __    __    __    __            _| > > |   |");
            Console.WriteLine("  __|___|___|_| |__|  |__|  |__|  |__|  |__|  |__|  |__|\\      / \\_|___|___|__");
            Console.WriteLine("  |   |   |   |________________________________________ <     />_|   |   |   |");
            Console.WriteLine("  |___|___|___| L L L L L L L L L L _______ L L L L L L  >__/\\>  /___|___|___|");
            Console.WriteLine("    |   |   | |L L L L L L L L L L /=|=|=|=\\ L L L L L  </> \\<   | |   |   |");
            Console.WriteLine("  __|___|___|_| L L L L L L L L L  I=|=|=|=I  L L L L L     <   L|_|___|___|__");
            Console.WriteLine("  |   |   |   |L L L L L L L L L L I V V V I L L L L L L L L   L |   |   |   |");
            Console.WriteLine("  |___|___|___|_L_L_L_L_L_L_L_L_L__I-------I__L_L_L_L_L_L_L_L_L_L|___|___|___|");
            Console.WriteLine();
        }
    }
}
