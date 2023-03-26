using System.IO;
using System.Threading.Tasks;

namespace Shake.FileSystem;

public interface IFileSystem
{
    Task<Stream> Read(FilePath file);
    Task<StreamReader> ReadText(FilePath file);

    Task<Stream> Set(FilePath file);
    Task<StreamWriter> SetText(FilePath file);

    Task Copy(FilePath source, FilePath destination);

    Task<bool> Exists(FilePath file);
    Task<bool> Exists(DirectoryPath directory);

    Task Create(DirectoryPath directory);
}
