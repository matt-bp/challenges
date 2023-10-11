namespace _020.UnitTests
{
    public class SolutionTests
    {
        [Test]
        public void IsValud_SimpleParens_ReturnsTrue()
        {
            var s = "()";
            var runner = new Solution();

            var result = runner.IsValid(s);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValud_NestedParens_ReturnsTrue()
        {
            var s = "(((((())))))";
            var runner = new Solution();

            var result = runner.IsValid(s);

            Assert.That(result, Is.True);
        }
    }
}