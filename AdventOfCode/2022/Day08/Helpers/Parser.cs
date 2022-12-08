namespace Day08.Helpers;

public static class Parser
{
    public static List<List<int>> GetTreeHeightGridFromInput(string[] input) => (
        from line in input
        let nums = line.ToCharArray().Select(c => int.Parse(c.ToString())).ToList()
        select nums
    ).ToList();
}