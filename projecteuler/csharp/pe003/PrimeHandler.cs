using System.Numerics;

namespace pe003
{
    public class PrimeHandler<T> where T : IBinaryInteger<T>
    {
        private Dictionary<T, bool> cachedPrimeNumbers = new();

        public bool CachedIsPrime(T n)
        {
            if (!cachedPrimeNumbers.ContainsKey(n))
            {
                cachedPrimeNumbers[n] = IsPrime(n);
            }

            return cachedPrimeNumbers[n];
        }

        public bool IsPrime(T n)
        {
            var two = T.One + T.One;

            if (n < two) return false;
            if (n == two) return true;

            for (var i = two; i < n - T.One; i++)
            {
                if (n % i == T.Zero) return false;
            }

            return true;
        }

        public T GetLargestPrimeFactor(T number)
        {
            if (CachedIsPrime(number)) return number;

            var currentNumber = number;
            var largestPrime = -T.One;
            var two = T.One + T.One;
            for (var i = two; i < number; i++)
            {
                if (!CachedIsPrime(i)) continue;

                if (currentNumber <= T.One) break; // We've divided the number as much as we can

                if (currentNumber % i == T.Zero)
                {
                    if (i > largestPrime) largestPrime = i;

                    currentNumber /= i;
                    Console.WriteLine($"i = {i}, The number is now {currentNumber}, largestPrime is {largestPrime}");
                }
            }

            return largestPrime;
        }
    }
}
