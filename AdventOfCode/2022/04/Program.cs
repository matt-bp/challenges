using CommandLine;
using _04;
using _04.Parts;
using _04.Models;
using System.Linq;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options opts)
{
    var exists = File.Exists(opts.InputFile);
    if (!exists)
    {
        Console.WriteLine("The file doesn't exist.");
        return;
    }

    var lines = File.ReadAllLines(opts.InputFile);

    PartOne.Run(lines);
    var partTwoAnswer = PartTwo.Run(lines);
    Console.WriteLine("The number of assignment pairs with overlap is: {0}", partTwoAnswer);
}

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}
