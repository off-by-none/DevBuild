using System;

namespace Lab3._1_StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentInput;
            char seeList;
            string input;
            char cont = 'y';
            string[] students =
            {
                "Adam",
                "Brandon",
                "Cameron",
                "Doug",
                "Eric",
                "Fred",
                "Gina",
                "Heather",
                "Igor",
                "Jim",
                "Kelly",
                "Linda",
                "Mike",
                "Nick",
                "Oscar",
                "Paul"
            };
            
            string[] candy =
            {
                "Almond Joy",
                "Butterfinger",
                "Candy Corn",
                "Dove",
                "Eight Grand",
                "Forever Yours",
                "Galaxy Bar",
                "Heath Bar",
                "Idaho Spud",
                "Jumping Jacks",
                "Kit Kat",
                "Lindt Chocolate",
                "Milky Way",
                "Nutrageous",
                "Old Faithful",
                "Payday"
            };

            string[] job =
            {
                "Air Traffic Controller",
                "Business Analyst",
                "Cop",
                "Data Analyst",
                "Engineer",
                "First Responder",
                "General Manager",
                "Helicopter Pilot",
                "Intern",
                "Job Specialist",
                "Karate Master",
                "Leg Model",
                "Manager",
                "Nutritionist",
                "Operator",
                "Paramedic"
            };

            while (cont == 'y')
            {
                Console.Clear();
                Console.WriteLine("Welcome to our Dev.Build class!\n");
                Console.WriteLine($"There are {students.Length} students in the class.");
                Console.Write("Would you like to see the list of students? (y/n): ");
                seeList = Console.ReadKey().KeyChar;

                if (seeList == 'y' || seeList == 'Y')
                {
                    Console.WriteLine("\nStudent List: ");
                    for (int i = 0; i < students.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}\t{students[i]}");
                    }
                }

                Console.Write($"\nWhich student would you like to learn more about? (enter a number 1-{students.Length}): ");
                bool flag = int.TryParse(Console.ReadLine(), out studentInput);

                if (flag && (studentInput <= students.Length) && studentInput != 0)
                {
                    Console.WriteLine($"\nStudent {studentInput} is {students[studentInput - 1]}.");
                    do
                    {
                        Console.Write($"What would you like to know about {students[studentInput - 1]}? (enter 'favorite candy' or 'previous title'): ");
                        input = Console.ReadLine().ToLower();
                    } while (input != "favorite candy" && input != "previous title");

                    if (input == "favorite candy")
                    {
                        Console.WriteLine($"\n{students[studentInput - 1]}'s favorite candy is {candy[studentInput - 1]}.");
                    }
                    else if (input == "previous title")
                    {
                        Console.WriteLine($"\n{students[studentInput - 1]}'s previous title was {job[studentInput - 1]}.");
                    }
                    else
                    {
                        Console.WriteLine("That data does not exist. Please try again. (enter “favorite candy” or “previous title”): ");
                    }

                    Console.Write("\nWould you like to know about another student? (y/n): ");
                    cont = Console.ReadKey().KeyChar;
                }
                else
                {
                    Console.WriteLine("\nThat data does not exist. Please try again.");
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }
            }
            Console.WriteLine("\nThank You!");
        }
    }
}