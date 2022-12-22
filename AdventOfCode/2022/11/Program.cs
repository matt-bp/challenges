using CommandLine;
using _00;
using _00.Parts;
using Shared.Models;
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
    PartTwo.Run();
}

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}
