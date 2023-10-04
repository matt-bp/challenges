// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

double MyPow(double x, int n)
{
    if (n == 0)
        return 1;

    if (x == 1)
        return 1;

    var valueToMultiply = n > 0 ? x : 1 / x;
    if (n == 1 || n == -1)
        return valueToMultiply;

    var nIsEven = n % 2 == 0;
    long maxNum = Math.Abs((long)n);
    if (!nIsEven)
        maxNum--;

    var map = new Dictionary<long, double>();

    var smallestNotEvenN = GetSmallestNotEvenN(maxNum);

    Console.WriteLine("=====================================");
    Console.WriteLine("SmallestNotEvenN: " + smallestNotEvenN);
    Console.WriteLine("isEven: " + nIsEven);
    Console.WriteLine("maxNum: " + maxNum);
    Console.WriteLine("=====================================");


    // Initialize cached results with lowest possible value

    var result = NaivePow(valueToMultiply, smallestNotEvenN);



    map.Add(smallestNotEvenN, result);
    //Console.WriteLine("Setting " + smallestNotEvenN + " to " + result);


    var previousN = smallestNotEvenN;
    //Console.WriteLine("previousN: " + previousN);
    var nextN = smallestNotEvenN * 2;
    //Console.WriteLine("nextN: " + nextN);

    while (nextN <= maxNum)
    {
        var prevMultiplied = map[previousN] * map[previousN];
        //Console.WriteLine("prevMultiplied: " + prevMultiplied);
        map.Add(nextN, prevMultiplied);
        previousN = nextN;
        nextN *= 2;
    }

    //Console.WriteLine("Last N is: " + nextN);
    //Console.WriteLine("=====================================");

    var modifier = nIsEven ? 1 : valueToMultiply;
    //Console.WriteLine("Modifier: " + modifier);

    if (nIsEven)
        return map[maxNum];
    else
        return map[previousN] * modifier;
}

double NaivePow(double x, long n)
{
    var result = 1.0;
    var valueToMultiply = n > 0 ? x : 1 / x;
    long iterations = Math.Abs(n);

    for (var i = 0; i < iterations; i++)
    {
        result *= valueToMultiply;
    }

    return result;
}


long GetSmallestNotEvenN(long max)
{
    var smallestNotEvenN = max;

    while (smallestNotEvenN % 2 == 0 && smallestNotEvenN > 2)
    {
        smallestNotEvenN /= 2;
    }

    return smallestNotEvenN;
}

var result = MyPow(1.0000000000001, -2147483648);

Console.WriteLine("Result: " + result);