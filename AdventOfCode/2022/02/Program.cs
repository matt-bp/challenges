using CommandLine;
using _02;
using System.Linq;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options opts)
{
    var exists = File.Exists(opts.InputFile) ? "Yes" : "Nope";
    Console.WriteLine("Does the files exist? {0}", exists);

    var strategies = File.ReadAllLines(opts.InputFile);

    var totalScore = (from strategy in strategies
                      let moves = strategy.Split(' ')
                      let opponentMove = ParseMove(moves.First())
                      let expectedRoundResult = ParseExpectedResult(moves.Last())
                      let score = RPSGame.GetScoreWithKnownResult(opponentMove, expectedRoundResult)
                      select score).Sum();

    Console.WriteLine("Total score of following strategy guide exactly is: {0}", totalScore);
}

static Choice ParseMove(string input) => input switch
{
    "A" => Choice.Rock,
    "B" => Choice.Paper,
    "C" => Choice.Scissors,
    _ => throw new ArgumentException($"{input} is not a valid move")
};

static ExpectedRoundResult ParseExpectedResult(string input) => input switch
{
    "X" => ExpectedRoundResult.Lose,
    "Y" => ExpectedRoundResult.Draw,
    "Z" => ExpectedRoundResult.Win,
    _ => throw new ArgumentException($"{input} is not a valid expected round result.")
};

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}
