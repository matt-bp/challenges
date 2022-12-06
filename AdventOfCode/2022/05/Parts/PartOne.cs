using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05.Parts;

using CrateStacks = List<List<string>>;

public static class PartOne
{
    public static void Run(string[] input)
    {
        Console.WriteLine("===== PART ONE =====");

        var crates = Parser.GetInitialCrateConfiguration(input);
        var moves = Parser.GetMoves(input);
        var crane = new Crane();

        moves.ForEach((move) =>
        {
            crane.ApplyMove(crates, move);
        });

        var topCrates = crane.GetTopCrates(crates);
        Console.WriteLine("Crates at the top of the each stack are: {0}", topCrates);
    }
}

public static class Parser
{
    public static CrateStacks GetInitialCrateConfiguration(IEnumerable<string> lines)
    {
        var gridLines = lines.Where(i => !i.StartsWith("move"));
        var cleanedUp = gridLines.Reverse().Skip(2).ToList();

        var length = (cleanedUp.First().Length + 1) / 4;

        var stacks = Crate.CreateStack(length);
        
        const string pattern = @"\[(\w)\] ?";
        
        foreach(var input in cleanedUp)
        {
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {
                var letterMatch = match.Groups[1];
                
                var goingTo = GetCrateIndexFromMatchIndex(letterMatch.Index);

                stacks[goingTo].Add(letterMatch.Value);
            }
        }
        
        return stacks;
    }

    private static int GetCrateIndexFromMatchIndex(int index) => (index - 1) / 4;

    public static List<Move> GetMoves(IEnumerable<string> input) => (from line in input
                                                          where line.StartsWith("move")
                                                          let parts = line.Split(' ')
                                                          select new Move
                                                          {
                                                              Count = int.Parse(parts[1]),
                                                              Source = int.Parse(parts[3]),
                                                              Destination = int.Parse(parts[5])
                                                          }).ToList();
}

public class Move
{
    public int Count { get; set; }
    public int Source { get; set; }
    public int Destination { get; set; }
}

public class Crane
{
    public void ApplyMove(CrateStacks stacks, Move move)
    {
        var currentStack = stacks[move.Source];

        var itemsToMove = currentStack.TakeLast(move.Count).ToList();
        itemsToMove.Reverse();
        
        currentStack.RemoveRange(currentStack.Count - move.Count, move.Count);
        
        stacks[move.Destination].AddRange(itemsToMove);
    }

    public string GetTopCrates(CrateStacks stacks)
    {
        StringBuilder sb = new();

        foreach (var stack in stacks)
        {
            if (stacks.Any())
            {
                sb.Append(stack.First());
            }
        }

        return sb.ToString();
    }
}

public static class Crate
{
    public static List<List<string>> CreateStack(int length) => Enumerable.Range(0, length)
        .Select(x => new List<string>()).ToList();
}