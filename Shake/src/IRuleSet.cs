using System;
using System.Threading.Tasks;

namespace Shake
{
    public interface IRuleSet
    {
        Task<IRule> FindFor(string file);
    }

    public class RuleNotFoundException : Exception
    {
        public RuleNotFoundException(string file) : base($"No rule was found for: {file}")
        { }
    }
}
