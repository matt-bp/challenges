using CommandLine;
using _05.Parts;
using Shared.Models;
using System.Linq;

using CommandLineParser = CommandLine.Parser;

CommandLineParser.Default.ParseArguments<Options>(args)
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
    //PartTwo.Run();
}

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}
