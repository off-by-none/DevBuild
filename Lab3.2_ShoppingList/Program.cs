using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3._2_ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            char cont = 'y';
            ArrayList itemOrdered = new ArrayList();
            ArrayList itemOrderedPrice = new ArrayList();
            Dictionary<string, double> menuItems = new Dictionary<string, double>();
            menuItems.Add("apple", 0.99);
            menuItems.Add("banana", 0.59);
            menuItems.Add("cauliflower", 1.59);
            menuItems.Add("dragonfruit", 2.19);
            menuItems.Add("elderberry", 1.79);
            menuItems.Add("figs", 2.09);
            menuItems.Add("grapefruit", 1.99);
            menuItems.Add("honeydew", 3.49);

            Console.WriteLine("Welcome to Brandon's Market!\n");

            while (cont == 'y' || cont == 'Y')
            {
                displayMenu(menuItems);
                string item = getItem();

                if (menuItems.ContainsKey(item))
                {
                    Console.WriteLine($"Adding {item} to cart at ${menuItems[item]}");
                    itemOrdered.Add(item);
                    itemOrderedPrice.Add(menuItems[item]);
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have those. Please try again.");
                }
                cont = wantCont();
            }
            getCart(itemOrdered, itemOrderedPrice);
        }

        static void displayMenu(Dictionary<string, double> menu)
        {
            Console.WriteLine($"\n{"Item", -15} {"Price", 5}");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("=");
            foreach (KeyValuePair<string, double> item in menu)
            {
                Console.WriteLine($"{item.Key, -15} {"$" + item.Value, 4}");
            }
        }

        static string getItem()
        {
            Console.Write("\nWhat item would you like to order? ");
            string item = Console.ReadLine().Trim().ToLower();
            return item;
        }

        static void getCart(ArrayList itemOrdered, ArrayList itemOrderedPrice)
        {
            double sum = 0;
            Console.WriteLine("\nThanks for your order!");
            Console.WriteLine("Here's what you got: ");
            for (int i = 0; i < itemOrdered.Count; i++)
            {
                Console.WriteLine($"{itemOrdered[i], -15} {"$" + itemOrderedPrice[i], 5}");
                sum += (double)itemOrderedPrice[i];
            }
            Console.WriteLine($"Average price per item in order was ${sum / itemOrdered.Count}");
        }

        static char wantCont()
        {
            Console.Write("\nWould you like to order anything else (y/n)? ");
            char cont = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return cont;
        }
    }
}

