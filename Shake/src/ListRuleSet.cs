using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shake
{
    public class ListRuleSet<T> : IRuleSet<T>
    {
        private readonly List<IRule<T>> _rules;

        public ListRuleSet(List<IRule<T>> rules)
        {
            _rules = rules;
        }

        public Task<IRule<T>> FindFor(T resource)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsFor(resource))
                {
                    return Task.FromResult(rule);
                }
            }

            throw new RuleNotFoundException<T>(resource);
        }
    }
}