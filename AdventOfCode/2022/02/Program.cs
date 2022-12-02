using CommandLine;
using _02;


Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

static void RunOptions(Options opts)
{
    var exists = File.Exists(opts.InputFile) ? "Yes" : "Nope";
    Console.WriteLine("Does the files exist? {0}", exists);

    var strategies = File.ReadAllLines(opts.InputFile);

    var totalScore = 0;

    foreach (var strategy in strategies)
    {
        var moves = strategy.Split(' ');
        var opponentMove = ParseMove(moves.First());
        var myMove = ParseMove(moves.Last());

        var score = GetScore(opponentMove, myMove);

        totalScore += score;
    }

    Console.WriteLine("Total score of following strategy guide exactly is: {0}", totalScore);
}

static int GetScore(Choice opponentMove, Choice myMove)
{
    var moveScore = (int)myMove;

    var roundScore = 0;

    if (DidP1Win(myMove, opponentMove))
    {
        roundScore = 6;
    }
    else if (DidTie(myMove, opponentMove))
    {
        roundScore = 3;
    }
    else
    {
        roundScore = 0;
    }

    return moveScore + roundScore;
}

static bool DidP1Win(Choice p1, Choice p2) => p1 switch
{
    Choice.Paper when p2 == Choice.Rock => true,
    Choice.Scissors when p2 == Choice.Paper => true,
    Choice.Rock when p2 == Choice.Scissors => true,
    _ => false
};

static bool DidTie(Choice p1, Choice p2) => p1 == p2;

static Choice ParseMove(string input) => input switch
{
    "A" or "X" => Choice.Rock,
    "B" or "Y" => Choice.Paper,
    "C" or "Z" => Choice.Scissors,
    _ => throw new ArgumentException($"{input} is not a valid move")
};

static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("Error!");
}

enum Choice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
};