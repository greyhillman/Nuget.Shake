using System.IO;

namespace Shake.FileSystem;

public record FilePath
{
    public DirectoryPath Directory { get; init; }
    public string Name { get; init; }
    public string Extension { get; init; }

    public FilePath(DirectoryPath directory, string name, string extension)
    {
        Directory = directory;
        Name = name;
        Extension = extension;
    }

    public FilePath(string path)
    {
        Directory = new DirectoryPath(Path.GetDirectoryName(path));
        Name = Path.GetFileNameWithoutExtension(path);

        // Remove starting "."
        Extension = Path.GetExtension(path).Substring(1);
    }

    public static FilePath operator +(DirectoryPath directory, FilePath file)
    {
        return new FilePath(directory + file.Directory, file.Name, file.Extension);
    }

    public override string ToString()
    {
        var path = Path.Combine(Directory.ToString(), Name);
        path = Path.ChangeExtension(path, Extension);

        return path;
    }
}
