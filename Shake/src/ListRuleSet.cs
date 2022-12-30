using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shake
{
    public class ListRuleSet : IRuleSet
    {
        private readonly List<IRule> _rules;

        public ListRuleSet(List<IRule> rules)
        {
            _rules = rules;
        }
        
        public Task<IRule> FindFor(string file)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsFor(file))
                {
                    return Task.FromResult(rule);
                }
            }
            
            throw new RuleNotFoundException(file);
        }
    }
}