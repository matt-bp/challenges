namespace _02.Tests
{
    public class RPSGameTests
    {
        [TestCase(Choice.Rock, 4)]
        [TestCase(Choice.Paper, 5)]
        [TestCase(Choice.Scissors, 6)]
        public void GetScoreWithKnownResult_WhenADraw_ReturnsCorrectScore(Choice opponentMove, int expectedScore)
        {
            var expectedRoundResult = ExpectedRoundResult.Draw;

            var score = RPSGame.GetScoreWithKnownResult(opponentMove, expectedRoundResult);

            Assert.That(score, Is.EqualTo(expectedScore));
        }

        [TestCase(Choice.Rock, 8)]
        [TestCase(Choice.Paper, 9)]
        [TestCase(Choice.Scissors, 7)]
        public void GetScoreWithKnownResult_WhenYouWin_ReturnsCorrectScore(Choice opponentMove, int expectedScore)
        {
            var expectedRoundResult = ExpectedRoundResult.Win;

            var score = RPSGame.GetScoreWithKnownResult(opponentMove, expectedRoundResult);

            Assert.That(score, Is.EqualTo(expectedScore));
        }

        [TestCase(Choice.Rock, 3)]
        [TestCase(Choice.Paper, 1)]
        [TestCase(Choice.Scissors, 2)]
        public void GetScoreWithKnownResult_WhenYouLose_ReturnsCorrectScore(Choice opponentMove, int expectedScore)
        {
            var expectedRoundResult = ExpectedRoundResult.Lose;

            var score = RPSGame.GetScoreWithKnownResult(opponentMove, expectedRoundResult);

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}