using CommandLine;
using _03;
using _03.Models;
using System.Linq;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options opts)
{
    var exists = File.Exists(opts.InputFile) ? "Yes" : "Nope";
    Console.WriteLine("Does the files exist? {0}", exists);

    var lines = File.ReadAllLines(opts.InputFile);

    foreach (var line in lines)
    { 
        var firstRucksack = line.Take(line.Length/2);
        var secondRucksack = line.Skip(line.Length/2);

        var duplicateItem = firstRucksack.Where(c => secondRucksack.Contains(c)).First();

        var priority = ConvertItemToPriority(duplicateItem);
    }

    var sumPriority = (from line in lines
                       let firstRucksack = line.Take(line.Length / 2)
                       let secondRucksack = line.Skip(line.Length / 2)
                       let duplicateItem = firstRucksack.Where(c => secondRucksack.Contains(c)).First()
                       let priority = ConvertItemToPriority(duplicateItem)
                       select priority
                       ).Sum();

    Console.WriteLine("Sum or priorities is: {0}", sumPriority);
}

static int ConvertItemToPriority(char duplicateItem)
{
    if ('a' <= duplicateItem && duplicateItem <= 'z')
    {
        return (int)duplicateItem - (int)'a' + 1;
    }
    else if ('A' <= duplicateItem && duplicateItem <= 'Z')
    {
        return (int)duplicateItem - (int)'A' + 27;
    }
    else
    {
        throw new ArgumentException("Dupliacte item is not in the alphabetic range");
    }
}

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}
