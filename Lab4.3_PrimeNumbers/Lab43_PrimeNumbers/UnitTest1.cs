using System;
using Xunit;
using Prime;

namespace Lab43_PrimeNumbers
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(4, 7)]
        [InlineData(5, 11)]
        [InlineData(10, 29)]
        [InlineData(100, 541)]
        [InlineData(1000, 7919)]
        [InlineData(10000, 104729)]
        [InlineData(100000, 1299709)]
        public void PrimeTrue(int a, int expected)
        {
            int result = PrimeNumber.GetPrime(a);

            Assert.Equal(expected, result);
        }
    }
}
