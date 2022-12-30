using System.Threading.Tasks;

namespace Shake
{
    public interface IRule
    {
        bool IsFor(string file);
        Task Build(IBuildSystem.IBuilder builder);
    }
}
