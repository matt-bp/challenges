using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.Helpers;

namespace _07.Tests.Helpers;

internal class DirectoryFinderTests
{
    [Test]
    public void GetDirectoriesWithAtMostSize()
    {
        var root = new Models.Directory
        {
            Children = new List<Models.IFileSystemItem>
            {
                new Models.Directory
                {
                    Children = new List<Models.IFileSystemItem>
                    {
                        new Models.File
                        {
                            Size = 50,
                            Name = "File to include"
                        }
                    },
                    Name = "Sub Directory"
                },
                new Models.File
                {
                    Size = 10000,
                    Name = "File to exclude"
                }
            },
            Name = "Top Level Directory"
        };

        var result = DirectoryFinder.GetDirectoriesWithAtMostSize(root, 100);

        Assert.That(result, Has.Count.EqualTo(1));
    }
}
