using CommandLine;
using _01;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options opts)
{
    //handle options
    Console.WriteLine("hello! {0}", File.Exists(opts.InputFile));

    var lines = File.ReadAllLines(opts.InputFile);

    var elfCalories = new List<int>();
    var currentCalories = 0;
    
    foreach (var line in lines)
    {
        if (line == "")
        {
            elfCalories.Add(currentCalories);
            currentCalories = 0;
        }
        else
        {
            currentCalories += int.Parse(line);
        }
    }

    var total = elfCalories
        .OrderByDescending(x => x)
        .Take(3)
        .Sum();
    
    Console.WriteLine("Total Top 3 Elf Calories: {0}", total);
}

static void HandleParseError(IEnumerable<Error> errs)
{
    //handle errors
    Console.WriteLine("Error!");
}
