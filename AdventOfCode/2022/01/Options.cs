using CommandLine;

namespace _01;

public class Options
{
    [Option('r', "read", Required = true, HelpText = "Input file to be processed.")]
    public string InputFile { get; set; }
}