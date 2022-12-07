using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Models;

public interface IFileSystemItem
{
    public string Name { get; set; }
    public int GetSize();
}

