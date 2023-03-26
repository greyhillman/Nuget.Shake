using System;
using System.Threading.Tasks;

namespace Shake
{
    public interface IRuleSet<T>
    {
        Task<IRule<T>> FindFor(T resource);
    }

    public class RuleNotFoundException<T> : Exception
    {
        public RuleNotFoundException(T resource) : base($"No rule was found for: {resource}")
        { }
    }
}
