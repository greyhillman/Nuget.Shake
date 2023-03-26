using System.Threading.Tasks;
using Shake;

namespace Shake.FileSystem;

public class SourceFileRule : IRule<FilePath>
{
    private readonly IFileSystem _fileSystem;

    public SourceFileRule(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public async Task Build(IBuildSystem<FilePath>.IBuilder builder)
    {
        if (await _fileSystem.Exists(builder.Resource))
        {
            return;
        }

        throw new FileNotFoundException(builder.Resource);
    }

    public bool IsFor(FilePath resource)
    {
        return true;
    }
}