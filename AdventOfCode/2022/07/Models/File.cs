using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Models;

public class File : IFileSystemItem
{
    public string Name { get; set; }
    public int Size { get; set; }
    public int GetSize()
    {
        return Size;
    }
}