using System;

namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                PrintHeader();
                int seqNumber = GetNumberInput();
                int primeNumber = PrimeNumber.GetPrime(seqNumber);
                PrintStringOutput(seqNumber, primeNumber); 
            } while (WantContinue());
        }


        static int GetNumberInput()
        {
            int seqNumber;
            bool isInt;
            do
            {
                Console.Write("Which prime number are you looking for: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out seqNumber);
            } while (seqNumber < 1 || !isInt);
            return seqNumber;
        }


        static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("Let’s locate some primes!");
            Console.WriteLine("\nThis application will find you any prime, in order, from first prime number on.\n");
        }
        

        static void PrintStringOutput(int seqNumber, int primeNumber)
        {
            string suffix;
            string seqNumString = seqNumber.ToString();
            char finalChar = seqNumString[seqNumString.Length - 1];

            if (finalChar == '1') { suffix = "st"; }
            else if (finalChar == '2') { suffix = "nd"; }
            else if (finalChar == '3') { suffix = "rd"; }
            else { suffix = "th"; }

            Console.WriteLine($"\nThe {string.Format("{0:n0}", seqNumber)}{suffix} prime is {string.Format("{0:n0}", primeNumber)}.");
        }
        

        static bool WantContinue()
        {
            char wantCont;
            do
            {
                Console.Write("\nDo you want to find another prime number? (y/n): ");
                wantCont = Console.ReadKey().KeyChar;
                if (wantCont == 'n' || wantCont == 'N') { return false; }
            } while (wantCont != 'y' && wantCont != 'Y');
            return true;
        }
    }
}