using System.Text;
using _10.Models;

namespace _10.Helpers;

public static class Renderer
{
    public static string RenderToString(RenderBuffer buffer)
    {
        StringBuilder sb = new();
        
        foreach (var row in buffer.Pixels)
        {
            foreach (var pixel in row)
            {
                sb.Append(pixel ? '#' : '.');
            }

            sb.Append('\n');
        }

        return sb.ToString();
    }
}