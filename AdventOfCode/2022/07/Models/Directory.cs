using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Models;

public class Directory : IFileSystemItem
{
    public string Name { get; set; }
    public Directory Parent;
    public List<IFileSystemItem> Children { get; set; } = new();

    public int GetSize()
    {
        return Children.Sum(c => c.GetSize());
    }
}