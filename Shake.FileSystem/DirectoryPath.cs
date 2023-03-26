using System;
using System.Collections.Generic;
using System.IO;


namespace Shake.FileSystem;

public record DirectoryPath : IEquatable<DirectoryPath>
{
    private readonly string[] _levels;

    public DirectoryPath(string directory)
    {
        _levels = directory.Split(Path.DirectorySeparatorChar);
    }

    public DirectoryPath(string[] levels)
    {
        _levels = levels;
    }

    public string this[int index]
    {
        get
        {
            return _levels[index];
        }
    }

    public int Depth => _levels.Length;

    public static DirectoryPath operator +(DirectoryPath top, DirectoryPath below)
    {
        var levels = new List<string>();
        foreach (var level in top._levels)
        {
            levels.Add(level);
        }

        foreach (var level in below._levels)
        {
            levels.Add(level);
        }

        return new DirectoryPath(levels.ToArray());
    }

    public override int GetHashCode()
    {
        var hash_code = 0;
        foreach (var level in _levels)
        {
            hash_code ^= level.GetHashCode();
        }

        return hash_code;
    }

    public virtual bool Equals(DirectoryPath? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other._levels.Length != _levels.Length)
        {
            return false;
        }

        var result = true;
        for (var i = 0; i < _levels.Length; i++)
        {
            result = result && _levels[i] == other._levels[i];
        }

        return result;
    }

    public override string ToString()
    {
        return string.Join(Path.DirectorySeparatorChar, _levels);
    }
}
