namespace Shake.FileSystem;

public class FilePathBuilder
{
    public DirectoryBuilder Directory { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }

    public FilePathBuilder(string path)
    {
        var filepath = new FilePath(path);

        Name = filepath.Name;
        Extension = filepath.Extension;

        Directory = new DirectoryBuilder(filepath.Directory);
    }

    public FilePathBuilder(FilePath path)
    {
        Directory = new DirectoryBuilder(path.Directory);
        Name = path.Name;
        Extension = path.Extension;
    }

    public FilePath Path
    {
        get
        {
            return new FilePath(Directory.Directory, Name, Extension);
        }
    }
}
