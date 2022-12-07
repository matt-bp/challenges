using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.Models;

namespace _07.Helpers;

public static class DirectoryFinder
{
    public static List<IFileSystemItem> GetDirectoriesWithAtMostSize(IFileSystemItem root, int atMostSize)
    {
        var returnDirectories = new List<IFileSystemItem>();
        foreach (var fromChild in from child in ((Models.Directory)root).Children.Where(c => c is Models.Directory)
                                  let fromChild = GetDirectoriesWithAtMostSize(child, atMostSize)
                                  select fromChild)
        {
            returnDirectories.AddRange(fromChild);
        }

        var currentSize = root.GetSize();

        if (currentSize <= atMostSize)
        {
            returnDirectories = returnDirectories.Append(root).ToList();
        }

        return returnDirectories;
    }

    public static List<IFileSystemItem> GetAllDirectories(IFileSystemItem root)
    {
        var returnDirectories = new List<IFileSystemItem>();

        foreach (var children in from child in ((Models.Directory)root).Children.Where(c => c is Models.Directory)
                                  let children = GetAllDirectories(child)
                                  select children)
        {
            returnDirectories.AddRange(children);
        }

        returnDirectories = returnDirectories.Append(root).ToList();

        return returnDirectories;
    }
}
