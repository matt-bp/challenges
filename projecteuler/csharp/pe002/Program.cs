var results = new Dictionary<int, int>
{
    { 0, 1 },
    { 1, 2 },
};

var currentResult = 2;

var sum = 2;


for (var i = 2; currentResult < 4000000; i++)
{
    currentResult = results[i - 1] + results[i - 2];

    results[i] = currentResult;

    if (int.IsEvenInteger(currentResult))
        sum += currentResult;
}

Console.WriteLine(sum);
