using System.Threading.Tasks;

namespace Shake
{
    public interface IRule<T>
    {
        bool IsFor(T resource);
        Task Build(IBuildSystem<T>.IBuilder builder);
    }
}
