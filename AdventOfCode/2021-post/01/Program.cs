using System;
using CommandLine;
using _01.Models;

Parser.Default.ParseArguments<CLIParameters>(args)
  .WithParsed(RunOptions)
  .WithNotParsed(HandleParseError);

static void RunOptions(CLIParameters opts)
{
	//handle options
	var input = File.ReadLines(opts.InputFiles.First()).ToList();
}
static void HandleParseError(IEnumerable<Error> errs)
{
	//handle errors
	foreach(var error in errs)
    {
		Console.WriteLine(error);
    }
}