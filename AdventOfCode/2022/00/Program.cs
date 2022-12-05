using CommandLine;
using _00;
using _00.Models;
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

    PartOne(opts);
    //PartTwo(opts);
}

static void PartOne(Options opts)
{
    Console.WriteLine("===== PART ONE =====");
}

static void PartTwo(Options opts)
{
    Console.WriteLine("===== PART TWO =====");
}

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}
