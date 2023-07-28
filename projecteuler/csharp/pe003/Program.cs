using pe003;

Console.Write("Find the largest prime factor for:\n>");

//if (!long.TryParse(Console.ReadLine(), out var input))
//{
//    Console.Error.WriteLine("Error reading console input, couldn't make it into a int.");
//}

var input = 600851475143L;
//var input = 13195L;

var primeHandler = new PrimeHandler<long>();
var primeFactor = primeHandler.GetLargestPrimeFactor(input);

Console.WriteLine($"The largets prime factor of {input} is {primeFactor}");
