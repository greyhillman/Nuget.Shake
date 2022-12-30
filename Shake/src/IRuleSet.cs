using System.Threading.Tasks;

namespace Shake
{
    public interface IRuleSet
    {
        Task<IRule?> FindFor(string file);
    }
}
