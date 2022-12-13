namespace _10.Models;

public class RenderBuffer
{
    public List<List<bool>> Pixels { get; set; }
    public int Width { get; set; }

    public RenderBuffer(int width, int height)
    {
        Pixels = Enumerable.Range(0, height)
            .Select(x => 
                Enumerable.Range(0, width)
                    .Select(h => false)
                    .ToList())
            .ToList();

        Width = width;
    }
}