namespace pe003.UnitTests
{
    public class PrimeHandlerTests
    {
        /// <summary>
        /// Test cases taken from https://oeis.org/A000040.
        /// </summary>
        /// <param name="input">Number to test</param>
        /// <param name="expected">That the result of IsPrime should be.</param>
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(7, true)]
        [TestCase(8, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        [TestCase(11, true)]
        [TestCase(12, false)]
        [TestCase(13, true)]
        [TestCase(14, false)]
        [TestCase(15, false)]
        [TestCase(271, true)]
        public void IsPrime_WithPrimeAnNonPrimeNumbers_TellsWhichOneIsPrime(int input, bool expected)
        {
            var prime = new PrimeHandler<int>();

            var result = prime.IsPrime(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, 3)]
        [TestCase(6, 3)]
        [TestCase(15, 5)]
        [TestCase(13195, 29)] // Example from my problem statement
        public void GetLargestPrimeFactor_WithInput_ReturnsLargestPrimeFactor(int input, int expected)
        {
            var prime = new PrimeHandler<int>();

            var result = prime.GetLargestPrimeFactor(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3L, 3L)]
        [TestCase(600851475143L, 6857L), Timeout(1000)]
        public void GetLargestPrimeFactor_WithLargeInput_HandlesIt(long input, long expected)
        {
            var prime = new PrimeHandler<long>();

            var result = prime.GetLargestPrimeFactor(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}