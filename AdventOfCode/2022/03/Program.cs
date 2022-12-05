using CommandLine;
using _03;
using _03.Models;
using System.Linq;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options opts)
{
    PartOne(opts);
    PartTwo(opts);
}

static void PartOne(Options opts)
{
    var exists = File.Exists(opts.InputFile) ? "Yes" : "Nope";
    Console.WriteLine("Does the files exist? {0}", exists);

    var lines = File.ReadAllLines(opts.InputFile);

    var sumPriority = (from line in lines
                       let firstRucksack = line.Take(line.Length / 2)
                       let secondRucksack = line.Skip(line.Length / 2)
                       let duplicateItem = firstRucksack.Where(c => secondRucksack.Contains(c)).First()
                       let priority = ConvertItemToPriority(duplicateItem)
                       select priority
                       ).Sum();

    Console.WriteLine("Sum or priorities is: {0}", sumPriority);
}

static void PartTwo(Options opts)
{
    var lines = File.ReadAllLines(opts.InputFile);

    var sumGroupPriorities = (from elfGroup in lines.Chunk(3)
                              let firstElf = elfGroup[0]
                              let secondElf = elfGroup[1]
                              let thirdElf = elfGroup[2]
                              let duplicateItem = thirdElf.Where(c3 => firstElf.Where(c1 => secondElf.Contains(c1)).Contains(c3)).First()
                              let priority = ConvertItemToPriority(duplicateItem)
                              select priority
                              ).Sum();

    Console.WriteLine("Sum or group priorities is: {0}", sumGroupPriorities);
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
