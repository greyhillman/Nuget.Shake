using System.Collections.Generic;
using System.IO;

namespace Shake.FileSystem;

public class DirectoryBuilder
{
    private readonly List<string> _levels;

    public DirectoryBuilder(DirectoryPath directory)
    {
        _levels = new();

        for (var level = 0; level < directory.Depth; level++)
        {
            _levels.Add(directory[level]);
        }
    }

    public string this[int index]
    {
        get
        {
            return _levels[index];
        }
        set
        {
            _levels[index] = value;
        }
    }

    public DirectoryBuilder Up()
    {
        _levels.RemoveAt(_levels.Count - 1);
        return this;
    }

    public DirectoryBuilder Down(string directory)
    {
        _levels.Add(directory);
        return this;
    }

    public DirectoryPath Directory
    {
        get
        {
            return new DirectoryPath(_levels.ToArray());
        }
    }
}
