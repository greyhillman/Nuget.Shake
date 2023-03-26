using System;

namespace Shake.FileSystem;

public class FileNotFoundException : Exception
{
    public FileNotFoundException(FilePath file)
        : base($"File could not be found: {file}")
    { }
}
