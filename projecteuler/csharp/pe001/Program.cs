
var result = Enumerable.Range(0, 1000).Where(x => x % 3 == 0 || x % 5 == 0).Sum();

Console.Write(result);
