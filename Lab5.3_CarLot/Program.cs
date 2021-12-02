using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab53_CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            CarLot carLot = new CarLot();
            FillCarLot(carLot);
            GetMenuInput(carLot);
        }


        static void PrintHeader(CarLot carLot, int index)
        {
            Console.Clear();
            Console.WriteLine(@"                              _.-='_ - _");
            Console.WriteLine(@"                          _.-='   _ -          | || '''''''---._______     __..");
            Console.WriteLine(@"              ___.===''''-.______-,,,,,,,,,,,,`-''----' '''''       '''''  __'	        ________________");
            Console.WriteLine(@"       __.--''     __        ,'                   o \           __        [__|	       / ____/_  _/ ___/");
            Console.WriteLine(@"  __-''=======.--''  ''--.=================================.--''  ''--.=======:	      / /     / / \__ \");
            Console.WriteLine(@" ]       [w] : /        \ : |========================|    : /        \ :  [w] 	     / /_____/ / ___/ /");
            Console.WriteLine(@" V___________:|          |: |========================|    :|          |:   _-'	     \____ /___/_____/");
            Console.WriteLine(@"  V__________: \        / :_|=======================/_____: \        / :__-'       Car Iventory System v0.1");
            Console.WriteLine(@"  -----------'  '-____ - '  `-------------------------------''-____ - '");
            Console.WriteLine("\n");
            Console.WriteLine($"| {"ID", -5} | {"Make", -18} | {"Model", -18} | {"Year", -18} | {"Price", -19} | {"Mileage", -15} |");
            Console.WriteLine("|" + String.Concat(Enumerable.Repeat("-", 110)) + "|");
            carLot.ListCars(index);
            Console.WriteLine("|" + String.Concat(Enumerable.Repeat("-", 110)) + "|");
            Console.WriteLine($"{"[U] Page Up   [D] Page Down", 100}   [{Math.Floor(index / 7.0) + 1} of {Math.Floor(carLot.Cars.Count / 8.0) + 1}]");
        }


        static void GetMenuInput(CarLot carLot)
        {
            int index = 0;
            char userInput;
            do
            {
                PrintHeader(carLot, index);
                Console.WriteLine(" [P] Purchase a Car\n [A] Add a Car\n [R] Remove a Car\n [E] Edit a Car\n [S] Search Cars \n [Q] Quit\n");
                Console.SetCursorPosition(0, 0);
                userInput = Console.ReadKey().KeyChar;
                if (userInput == 'q' || userInput == 'Q')
                {
                    PrintHeader(carLot, index);
                    Console.WriteLine("\n Have a great day!\n");
                }
                else if (userInput == 'a' || userInput == 'A')
                {
                    PrintHeader(carLot, index);
                    Console.WriteLine(" [N] Add a New Car\n [U] Add a Used Car\n");
                    Console.SetCursorPosition(0, 0);
                    userInput = Console.ReadKey().KeyChar;
                    if (userInput == 'n' || userInput == 'N')
                    {
                        PrintHeader(carLot, index);
                        Console.Write(" Enter Make: ");
                        string make = Console.ReadLine().Trim();
                        Console.Write(" Enter Model: ");
                        string model = Console.ReadLine().Trim();

                        int year;
                        do
                        {
                            Console.Write(" Enter Year: ");
                            year = int.Parse(Console.ReadLine().Trim());
                        } while (year <= 1930 || year > 2021);

                        double price;
                        do
                        {
                            Console.Write(" Enter Price: ");
                            price = double.Parse(Console.ReadLine().Trim());
                        } while (price < 0 || price > 999999);

                        carLot.AddCar(new Car(make, model, year, price));
                        Console.WriteLine($"\n Adding {year} {make} {model}.");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else if (userInput == 'u' || userInput == 'U')
                    {
                        PrintHeader(carLot, index);
                        Console.Write(" Enter Make: ");
                        string make = Console.ReadLine().Trim();
                        Console.Write(" Enter Model: ");
                        string model = Console.ReadLine().Trim();

                        int year;
                        do
                        {
                            Console.Write(" Enter Year: ");
                            year = int.Parse(Console.ReadLine().Trim());
                        } while (year <= 1930 || year > 2021);

                        double price;
                        do
                        {
                            Console.Write(" Enter Price: ");
                            price = double.Parse(Console.ReadLine().Trim());
                        } while (price < 0 || price > 999999);

                        int mileage;
                        do
                        {
                            Console.Write(" Enter mileage: ");
                            mileage = int.Parse(Console.ReadLine().Trim());
                        } while (mileage < 0 || mileage > 999999);

                        carLot.AddCar(new UsedCar(make, model, year, price, mileage));
                        Console.WriteLine($"\n Adding {year} {make} {model}.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else if (userInput == 'p' || userInput == 'P')
                {
                    PrintHeader(carLot, index);
                    Console.Write(" Enter the purchased Car ID: ");
                    int carID = int.Parse(Console.ReadLine().Trim());
                    bool carExist = false;
                    foreach (Car c in carLot.Cars)
                    {
                        if (c.Id == carID)
                        {
                            carExist = true;
                            Console.Write($"\n Are you sure you want to purchase the {c.Year} {c.Make} {c.Model} for ${string.Format("{0:n2}", c.Price)}? (y/n): ");
                            char input = Console.ReadKey().KeyChar;
                            if (input == 'y' || input == 'Y')
                            {
                                carLot.RemoveCar(c);
                                Console.WriteLine("\n\n Excellent! Our finance department will be in touch shortly.");
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                        }
                    }
                    if (!carExist)
                    {
                        Console.WriteLine(" Car ID does not exist.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else if (userInput == 'r' || userInput == 'R')
                {
                    PrintHeader(carLot, index);
                    Console.Write(" Enter the removed Car ID: ");
                    int carID = int.Parse(Console.ReadLine().Trim());
                    bool carExist = false;
                    foreach (Car c in carLot.Cars)
                    {
                        if (c.Id == carID)
                        {
                            carExist = true;
                            Console.Write($"\n Are you sure you want to remove the {c.Year} {c.Make} {c.Model} for ${string.Format("{0:n2}", c.Price)}? (y/n): ");
                            char input = Console.ReadKey().KeyChar;
                            if (input == 'y' || input == 'Y')
                            {
                                carLot.RemoveCar(c);
                                Console.WriteLine($"\n\n Removing {c.Year} {c.Make} {c.Model}.");
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                        }
                    }
                    if (!carExist)
                    {
                        Console.WriteLine(" Car ID does not exist.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else if (userInput == 'e' || userInput == 'E')
                {
                    PrintHeader(carLot, index);
                    Console.Write(" Enter the edited Car ID: ");
                    int carID = int.Parse(Console.ReadLine().Trim());
                    bool carExist = false;
                    foreach (Car c in carLot.Cars)
                    {
                        if (c.Id == carID)
                        {
                            carExist = true;
                            Console.WriteLine("\n Enter the field to be edited:");
                            Console.WriteLine($" [1] Make\n [2] Model\n [3] Year\n [4] Price");
                            Console.SetCursorPosition(0, 0);
                            char input = Console.ReadKey().KeyChar;
                            if (input == '1')
                            {
                                PrintHeader(carLot, index);
                                Console.Write(" Enter the new Make: ");
                                c.Make = Console.ReadLine().Trim();
                                break;
                            }
                            else if (input == '2')
                            {
                                PrintHeader(carLot, index);
                                Console.Write(" Enter the new Model: ");
                                c.Model = Console.ReadLine().Trim();
                                break;
                            }
                            else if (input == '3')
                            {
                                PrintHeader(carLot, index);
                                Console.Write(" Enter the new Year: ");
                                c.Year = int.Parse(Console.ReadLine().Trim());
                                break;
                            }
                            else if (input == '4')
                            {
                                PrintHeader(carLot, index);
                                Console.Write(" Enter the new Price: ");
                                c.Price = double.Parse(Console.ReadLine().Trim());
                                break;
                            }
                        }
                    }
                    if (!carExist)
                    {
                        Console.WriteLine(" Car ID does not exist.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else if (userInput == 's' || userInput == 'S')
                {
                    CarLot searchedCarLot = new CarLot();
                    PrintHeader(carLot, index);
                    Console.WriteLine(" Enter the field to be searched:");
                    Console.WriteLine($" [1] Make\n [2] Model\n [3] Year\n [4] Price\n [5] Used\n [6] New");
                    Console.SetCursorPosition(0, 0);
                    char input = Console.ReadKey().KeyChar;
                    
                    if (input == '1')
                    {
                        PrintHeader(carLot, index);
                        Console.Write(" Enter a Make to search: ");
                        string searchField = Console.ReadLine().Trim();
                        foreach (Car _car in carLot.Cars)
                        {
                            if (_car.Make.ToLower() == searchField.ToLower())
                            {
                                searchedCarLot.AddCar(_car);
                            }
                        }
                    }
                    else if (input == '2')
                    {
                        PrintHeader(carLot, index);
                        Console.Write(" Enter a Model to search: ");
                        string searchField = Console.ReadLine().Trim();
                        foreach (Car _car in carLot.Cars)
                        {
                            if (_car.Model.ToLower() == searchField.ToLower())
                            {
                                searchedCarLot.AddCar(_car);
                            }
                        }
                    }
                    else if (input == '3')
                    {
                        PrintHeader(carLot, index);
                        Console.Write(" Enter a lower bound Year to search: ");
                        int lowerBound = int.Parse(Console.ReadLine().Trim());
                        Console.Write(" Enter a upper bound Year to search: ");
                        int upperBound = int.Parse(Console.ReadLine().Trim());
                        foreach (Car _car in carLot.Cars)
                        {
                            if (_car.Year >= lowerBound && _car.Year <= upperBound)
                            {
                                searchedCarLot.AddCar(_car);
                            }
                        }
                    }
                    else if (input == '4')
                    {
                        PrintHeader(carLot, index);
                        Console.Write(" Enter a lower bound Price to search: ");
                        int lowerBound = int.Parse(Console.ReadLine().Trim());
                        Console.Write(" Enter a upper bound Price to search: ");
                        int upperBound = int.Parse(Console.ReadLine().Trim());
                        foreach (Car _car in carLot.Cars)
                        {
                            if (_car.Price >= lowerBound && _car.Price <= upperBound)
                            {
                                searchedCarLot.AddCar(_car);
                            }
                        }
                    }
                    else if (input == '5')
                    {
                        PrintHeader(carLot, index);
                        Console.WriteLine(" Used Cars:");
                        foreach (Car _car in carLot.Cars)
                        {
                            if (_car.GetType() == typeof(UsedCar))
                            {
                                searchedCarLot.AddCar(_car);
                            }
                        }
                    }
                    else if (input == '6')
                    {
                        PrintHeader(carLot, index);
                        Console.WriteLine(" New Cars:");
                        foreach (Car _car in carLot.Cars)
                        {
                            if (_car.GetType() == typeof(Car))
                            {
                                searchedCarLot.AddCar(_car);
                            }
                        }
                    }

                    Console.WriteLine("\n|" + String.Concat(Enumerable.Repeat("-", 110)) + "|");
                    foreach (Car _car in searchedCarLot.Cars)
                    {
                        Console.WriteLine(_car);
                    }
                    Console.WriteLine("|" + String.Concat(Enumerable.Repeat("-", 110)) + "|");
                    Console.WriteLine(" [Q] Quit");
                    char searchedCont;
                    do
                    {
                        Console.SetCursorPosition(0, 0);
                        searchedCont = Console.ReadKey().KeyChar;
                    } while (searchedCont != 'q' && searchedCont != 'Q');
                }
                else if ((userInput == 'u' || userInput == 'U') && (Math.Floor(index / 7.0) < Math.Floor(carLot.Cars.Count / 8.0)))
                {
                    index += 7;
                }
                else if ((userInput == 'd' || userInput == 'D') && (Math.Floor(index / 7.0) >= Math.Floor(carLot.Cars.Count / 8.0)) && index != 0)
                {
                    index -= 7;
                }
            } while (userInput != 'q' && userInput != 'Q');
        }


        static void FillCarLot(CarLot carLot) 
        {
            StreamReader sr = new StreamReader(@"CarDatabase.txt");
            while (sr.Peek() >= 0)
            {
                string str;
                string[] strArray;
                str = sr.ReadLine();
                strArray = str.Split(',');
                if (strArray.Length == 5)
                {
                    carLot.AddCar(new UsedCar(strArray[0], strArray[1], int.Parse(strArray[2]), double.Parse(strArray[3]), double.Parse(strArray[4])));
                }
                else
                {
                    carLot.AddCar(new Car(strArray[0], strArray[1], int.Parse(strArray[2]), double.Parse(strArray[3])));
                }
            }
        }
    }
}
