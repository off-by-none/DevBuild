using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3._3_DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseInput(GetInput());  
        }

        static string GetInput()
        {
            Console.Write("Please enter a word you would like to reverse: ");
            string input = Console.ReadLine();
            return input;
        }

        static void ReverseInput(string input)
        {
            Stack<char> myStack = new Stack<char>();
            ArrayList myArr = new ArrayList();
            
            for (int i = 0; i < input.Split(" ").Length; i++)
            {
                myArr.Add(input.Split(" ")[i]);
            }

            myArr.Reverse();

            foreach (string word in myArr)
            {
                foreach (char letter in word)
                {
                    myStack.Push(letter);
                }
                myStack.Push(' ');
            }

            Console.Write("Your word in reverse is:");

            foreach (char letter in myStack)
            {
                Console.Write(letter);
            }
            Console.WriteLine("\n");
        }
    }
}
