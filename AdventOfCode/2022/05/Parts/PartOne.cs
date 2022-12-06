using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05.Parts;

using CrateStacks = List<List<int>>;

public static class PartOne
{
    public static void Run(string[] input)
    {
        Console.WriteLine("===== PART ONE =====");

        var crates = Parser.GetInitialCrateConfiguration(input);
        var moves = Parser.GetMoves(input);

        moves.ForEach((move) =>
        {
            Crane.ApplyMove(crates, move);
        });

        var topCrates = Crane.GetTopCrates(crates);
        Console.WriteLine("Crates at the top of the each stack are: {0}", topCrates);
    }
}

public static class Parser
{
    public static CrateStacks GetInitialCrateConfiguration(string[] lines)
    {
        var gridLines = lines.Where(i => !i.StartsWith("move"));
        var cleanedUp = gridLines.Reverse().Skip(2);

        foreach(var input in cleanedUp)
        {
            string pattern = @"\[(\w)\] ?";
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine(match);
            }
        }

        var stacks = new CrateStacks();



        return stacks;
    }

    public static List<Move> GetMoves(string[] input) => (from line in input
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
    public static void ApplyMove(CrateStacks stacks, Move move)
    {
        var currentStack = stacks[move.Source];

        var itemsToMove = currentStack.TakeLast(move.Count).ToList();
        itemsToMove.Reverse();

        stacks[move.Destination].AddRange(itemsToMove);
    }

    public static string GetTopCrates(CrateStacks stacks)
    {
        StringBuilder sb = new();

        foreach (var stack in stacks)
        {
            sb.Append(stack.Last());
        }

        return sb.ToString();
    }
}
