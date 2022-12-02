using CommandLine;

namespace _02;

public class Options
{
    [Option('r', "read", Required = true, HelpText = "Input file to be processed.")]
    public string InputFile { get; set; }
}