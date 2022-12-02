using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    public enum Choice
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    public enum ExpectedRoundResult
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }

    public static class RPSGame
    {
        public static int GetScoreWithKnownResult(Choice opponentMove, ExpectedRoundResult expectedRoundResult)
        {
            var roundScore = (int)expectedRoundResult;

            var move = GetMyMove(opponentMove, expectedRoundResult);

            return (int)move + roundScore;
        }

        static Choice GetMyMove(Choice opponentMove, ExpectedRoundResult expectedRoundResult) => expectedRoundResult switch
        {
            ExpectedRoundResult.Win => GetWinningMove(opponentMove),
            ExpectedRoundResult.Lose => GetLosingMove(opponentMove),
            _ => opponentMove,
        };

        static Choice GetWinningMove(Choice move) => move switch
        {
            Choice.Paper => Choice.Scissors,
            Choice.Scissors => Choice.Rock,
            Choice.Rock => Choice.Paper,
            _ => throw new ArgumentException($"{move} is not a valid move.")
        };

        static Choice GetLosingMove(Choice move) => move switch
        {
            Choice.Paper => Choice.Rock,
            Choice.Scissors => Choice.Paper,
            Choice.Rock => Choice.Scissors,
            _ => throw new ArgumentException($"{move} is not a valid move.")
        };
    }
}
