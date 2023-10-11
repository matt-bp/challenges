// See https://aka.ms/new-console-template for more information
using CollisionDetection.Library;
using CollisionDetection.Timer;
using CsvHelper;
using Serilog;
using ShellProgressBar;
using System.Diagnostics;
using System.Globalization;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


Log.Information("Running a stress test timing the divide algorithm.");

var runResults = new List<RunResult>();

var runner = new Solution();

var max = 100_000;
var factor = max / 100;

var options = new ProgressBarOptions
{
    ProgressCharacter = '─',
    ProgressBarOnBottom = true
};

using (var pbar = new ProgressBar(max, "Initial message", options))
{
    var listGenerator = new ListGenerator();
    for (var i = 0; i < max; i++)
    {
        var positions = listGenerator.Generate(i, -5 * factor, 5 * factor);

        var watch = Stopwatch.StartNew();

        runner.NumberOfCollisionsDivide(positions);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        runResults.Add(new RunResult
        {
            ElapsedMs = elapsedMs,
            NumberOfPositions = positions.Length,
        });

        pbar.Tick($"{i}/{max}");
    }
}


var runGuid = Guid.NewGuid();
var filename = $"./out/{runGuid}.csv";
Log.Information("Writing to: {FileName}", filename);

using (var writer = new StreamWriter(filename))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(runResults);
}