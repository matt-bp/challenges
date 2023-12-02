namespace CollisionDetection;

public class Solution
{
    public int NumberOfCollisions(int[][] centers) {
        var count = 0;

        var ordered = centers.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();
        
        Console.WriteLine("Sorted list: " + string.Join(',', ordered.Select(x => $"({x[0]}, {x[1]})")));

        var currentPoint = ordered[0];

        for (var i = 1; i < ordered.Count; i++)
        {
            if (Math.Abs(currentPoint[0] - ordered[i][0]) > 2 || Math.Abs(currentPoint[1] - ordered[i][1]) > 2)
            {
                Console.WriteLine($"Updating compare point to be: " + string.Join(',', ordered[i]));
                currentPoint = ordered[i];
                continue;
            }
            
            Console.WriteLine($"Going to compare {string.Join(',', currentPoint)} and {string.Join(',', ordered[i])}.");
            if (DidCollide(currentPoint, ordered[i]))
            {
                count += 1;
            }
        }

        return count;
    }


    private static bool DidCollide(IReadOnlyList<int> p1, IReadOnlyList<int> p2)
    {
        // Console.WriteLine($"\t\t|{p2[0]} - {p1[0]}| <= 2 && |{p2[1]} - {p1[1]}| <= 2");
        var firstAbs = Math.Abs(p2[0] - p1[0]);
        var secondAbs = Math.Abs(p2[1] - p1[1]);
        // Console.WriteLine($"\t\tFirst abs: {firstAbs}. Second abs: {secondAbs}.");

        return firstAbs <= 2 && secondAbs <= 2;
    }
}
