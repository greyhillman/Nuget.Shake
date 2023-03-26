using System.IO;
using System.Threading.Tasks;

namespace Shake.FileSystem;

public class DefaultFileSystem : IFileSystem
{
    private readonly DirectoryPath _workingDirectory;

    public DefaultFileSystem(DirectoryPath workingDirectory)
    {
        _workingDirectory = workingDirectory;
    }

    public async Task Create(DirectoryPath directory)
    {
        await Task.Run(() =>
        {
            var absoluteDirectory = _workingDirectory + directory;

            Directory.CreateDirectory(absoluteDirectory.ToString());
        });
    }

    public async Task<bool> Exists(FilePath file)
    {
        return await Task.Run(() =>
        {
            var absolutePath = _workingDirectory + file;

            return File.Exists(absolutePath.ToString());
        });
    }

    public async Task<bool> Exists(DirectoryPath directory)
    {
        return await Task.Run(() =>
        {
            var absoluteDirectory = _workingDirectory + directory;

            return Directory.Exists(absoluteDirectory.ToString());
        });
    }

    public async Task<Stream> Set(FilePath file)
    {
        return await Task.Run(() =>
        {
            var absolutePath = _workingDirectory + file;

            return File.OpenWrite(absolutePath.ToString());
        });
    }

    public async Task<StreamWriter> SetText(FilePath file)
    {
        return await Task.Run(() =>
        {
            var absolutePath = _workingDirectory + file;

            var stream = File.OpenWrite(absolutePath.ToString());

            return new StreamWriter(stream);
        });
    }

    public async Task<Stream> Read(FilePath file)
    {
        return await Task.Run(() =>
        {
            var absolutePath = _workingDirectory + file;

            return File.OpenRead(absolutePath.ToString());
        });
    }

    public async Task<StreamReader> ReadText(FilePath file)
    {
        return await Task.Run(() =>
        {
            var absolutePath = _workingDirectory + file;

            var stream = File.OpenRead(absolutePath.ToString());

            return new StreamReader(stream);
        });
    }

    public async Task Copy(FilePath source, FilePath destination)
    {
        await Task.Run(() =>
        {
            var absoluteSource = _workingDirectory + source;
            var absoluteDestination = _workingDirectory + destination;

            File.Copy(absoluteSource.ToString(), absoluteDestination.ToString());
        });
    }
}