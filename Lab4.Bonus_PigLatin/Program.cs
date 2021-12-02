using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4.Bonus_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            SplashScreen();

            do
            {
                string finalTranslation = "";

                Console.Clear();
                Console.WriteLine("Welcome to the Pig Latin Translator!\n");
                string str = GetStrInput(out char endChar);
                string[] strArr = SplitStr(str);
                Console.WriteLine();

                foreach (string word in strArr)
                {
                    finalTranslation += TranslatePigLatin(word);
                }
                Console.Write(finalTranslation.Trim());
                Console.Write(endChar + "\n");
            } while (WantCont());
        }

        static string GetStrInput(out char endChar)
        {
            string strInput;

            // make sure something is entered
            do
            {
                Console.Write("Enter a line to be translated: ");
                strInput = Console.ReadLine();
            } while (strInput.Length == 0);

            // remove and preserve ending punctuation
            if ((char)strInput[strInput.Length - 1] == '.' || (char)strInput[strInput.Length - 1] == '!' || (char)strInput[strInput.Length - 1] == '?')
            {
                endChar = strInput[strInput.Length - 1];
                strInput = strInput.Remove(strInput.Length - 1, 1);
            }
            else
            {
                endChar = ' ';
            }
            return strInput;
        }

        static string[] SplitStr(string str)
        {
            // splits the entered string into words so each word can be translated
            string[] strArr = str.Split(" ");
            return strArr;
        }

        static string TranslatePigLatin(string word)
        {
            List<char> constList = new List<char>();
            int consts = 0;
            string constEnding = "";
            string alphaPattern = @"^[A-Za-z]+$";
            string vowelPattern = @"[aeiouAEIOU]";

            if (Regex.IsMatch(word, alphaPattern)) //only translate the word if it's all alpha characters
            {
                foreach (char c in word)
                {
                    // for each character in the word, if it's a consonant add it to a list and add one to consonants (which is used to remove the first consonants before a vowel)
                    if (!Regex.IsMatch(c.ToString(), vowelPattern))
                    {
                        constList.Add(c);
                        consts++;
                    }
                    // once a vowel is reached stop adding consonants to the list
                    else { break; }
                }

                if (constList.Count > 0)
                {
                    // put together the consonant ending
                    for (int i = 0; i < constList.Count; i++)
                    {
                        constEnding += constList[i];
                    }
                }
                else
                {
                    // if the word starts with a vowel the consonant list is empty...but we want to add a "w"
                    constEnding = "w";
                }

                string newWord = word.Remove(0, consts) + constEnding + "ay ";
                return newWord;
            }
            else
            {
                // if the word contains special character just return the word (do not translate)
                return word + " ";
            }
        }
        static bool WantCont()
        {
            char cont;

            // keep asking the user do they want to continue (until a 'Y' 'y' 'n' 'N' is entered)
            do
            {
                Console.Write("\nTranslate another line? (y/n): ");
                cont = Console.ReadKey().KeyChar;
                if (cont == 'n' || cont == 'N')
                {
                    Console.WriteLine();
                    return false;
                }
            } while (cont != 'y' && cont != 'Y');

            return true;
        }

        static void SplashScreen()
        {
            int sleepTime = 70;
            Console.ForegroundColor = ConsoleColor.Magenta;

            do
            {
                while (!Console.KeyAvailable)
                {
                    for (int i = 50; i > 0; i -= 2)
                    {
                        Console.Clear();
                        Console.WriteLine(String.Concat(Enumerable.Repeat(" ", i)) + @"    _____  ");
                        Console.WriteLine(String.Concat(Enumerable.Repeat(" ", i)) + @"^..^     \9");
                        Console.WriteLine(String.Concat(Enumerable.Repeat(" ", i)) + @"(oo)_____/ ");
                        Console.WriteLine(String.Concat(Enumerable.Repeat(" ", i)) + @"   WW  WW  ");
                        Console.WriteLine("\nPress ESC key to start translating to Pig Latin, Oinkway Oinkway!");
                        System.Threading.Thread.Sleep(sleepTime);
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.ResetColor();
        }
    }
}