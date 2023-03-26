using System.Threading.Tasks;

namespace Shake;

public class SourceRule<T> : IRule<T>
{
    public async Task Build(IBuildSystem<T>.IBuilder builder)
    {
        await builder.Built(builder.Resource);
    }

    public bool IsFor(T resource)
    {
        return true;
    }
}
