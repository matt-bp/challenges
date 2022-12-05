using CommandLine;

namespace _00.Models;

public class Options
{
    [Option('r', "read", Required = true, HelpText = "Input file to be processed.")]
    public string InputFile { get; set; }
}