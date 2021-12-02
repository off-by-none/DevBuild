using System;
using System.Text.RegularExpressions;

namespace Lab2._3_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            // validate names
            string namePattern = @"^[A-Z][a-z]{1,30}$";
            Console.Write("Please enter a valid Name: ");
            string name = Console.ReadLine();
            Match nameMatch = Regex.Match(name, namePattern);
            if (nameMatch.Success)
            {
                Console.WriteLine("Name is valid!\n");
            }
            else
            {
                Console.WriteLine("Sorry, name is not valid!\n");
            }



            //validate emails
            string emailPattern = @"^[A-Za-z0-9]{5,30}@[A-Za-z0-9]{5,10}\.[A-Za-z0-9]{2,3}$";
            Console.Write("Please enter a valid email: ");
            string email = Console.ReadLine();
            Match emailMatch = Regex.Match(email, emailPattern);
            if (emailMatch.Success)
            {
                Console.WriteLine("Email is valid!\n");
            }
            else
            {
                Console.WriteLine("Sorry, email is not valid!\n");
            }



            //validate phone numbers
            string phonePattern = @"^\(*\d{3}\)*[-.]\d{3}[-.]\d{4}$";
            Console.Write("Please enter a valid phone number: ");
            string phone = Console.ReadLine();
            Match phoneMatch = Regex.Match(phone, phonePattern);
            if (phoneMatch.Success)
            {
                Console.WriteLine("Phone number is valid!\n");
            }
            else
            {
                Console.WriteLine("Sorry, phone number is not valid!\n");
            }


            //validate date
            string datePattern = @"^0?[1-3]?[0-9]\/0?1?[0-9]\/[0-9]{2,4}$";
            Console.Write("Please enter a valid date (dd/mm/yyyy): ");
            string date = Console.ReadLine();
            Match dateMatch = Regex.Match(date, datePattern);
            if (dateMatch.Success)
            {
                Console.WriteLine("Date is valid!\n");
            }
            else
            {
                Console.WriteLine("Sorry, date is not valid!\n");
            }



            //validate html
            string htmlPattern = @"<[a-z][0-3]?>\s</[a-z][0-3]?>";
            Console.Write("Please enter a valid HTML element: ");
            string html = Console.ReadLine();
            Match htmlMatch = Regex.Match(html, htmlPattern);
            if (htmlMatch.Success)
            {
                Console.WriteLine("HTML element is valid!\n");
            }
            else
            {
                Console.WriteLine("Sorry, HTML element is not valid!\n");
            }
        }
    }
}
