using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Helpers;

public class Parser
{
    private Models.Directory? _root;
    private Models.Directory? _currentDirectory;

    public Models.Directory GetFileSystemStructure(string[] input)
    {
        for(int i = 0; i < input.Length; i++)
        {
            var parts = input[i].Split(' ');
            
            if (parts[0] == "$")
            {
                HandleUserCommand(parts[1], parts.Skip(2));
            }
            else
            {
                AddItemToCurrentDirectory(parts[0], parts[1]);
            }
        }


        return _root;
    }

    private void HandleUserCommand(string command, IEnumerable<string> rest)
    {
        if (command == "cd")
        {
            if (!rest.Any())
            {
                throw new ArgumentException("The cd command needs a directory to go do");
            }

            var directory = rest.First();

            if (directory == "/")
            {
                if (_root == null)
                {
                    _root = new Models.Directory
                    {
                        Name = directory
                    };
                }

                _currentDirectory = _root;
            }
            
            if (_root == null)
            {
                throw new InvalidOperationException("No root directory is set. Please make a call to $ cd /");
            }

            if (_currentDirectory == null)
            {
                throw new InvalidOperationException("No current directory is set.");
            }

            if (directory == "..")
            {
                _currentDirectory = _currentDirectory.Parent;
            }

            if (_currentDirectory.Children.Any(c => c.Name == directory))
            {
                _currentDirectory = _currentDirectory.Children.Where(c => c.Name == directory).First() as Models.Directory;
            }
        }
        else if (command == "ls")
        {
            // do nothing for now
        }
        else
        {
            throw new ArgumentException($"{command} is not a recognized user command.");
        }
    }

    private void AddItemToCurrentDirectory(string type, string name)
    {
        if (_currentDirectory == null)
        {
            throw new InvalidOperationException("No current directory is set.");
        }

        if (type == "dir")
        {
            _currentDirectory.Children.Add(new Models.Directory
            {
                Name = name,
                Parent = _currentDirectory
            });
        }
        else
        {
            var size = int.Parse(type);

            _currentDirectory.Children.Add(new Models.File
            {
                Name = name,
                Size = size
            });
        }
    }
}