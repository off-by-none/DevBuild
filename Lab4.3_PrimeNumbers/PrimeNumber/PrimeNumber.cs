using System;
using System.Collections.Generic;
using System.Text;

namespace Prime
{
    public class PrimeNumber
    {
        public static int GetPrime(int n)
        {
            int i = 1;
            int count = 0;

            while (count < n)
            {
                i++;
                if (isPrime(i)) { count++; }
            }
            return i;
        }

        public static bool isPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) { return false; }
            }
            return true; 
        }
    }
}
