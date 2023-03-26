using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Shake
{
    public class DefaultBuildSystem<T> : IBuildSystem<T>
    {
        private readonly HashSet<T> _builtResources;
        private readonly IRuleSet<T> _rules;

        public DefaultBuildSystem(IRuleSet<T> rules)
        {
            _builtResources = new();
            _rules = rules;
        }

        public async Task Want(params T[] resources)
        {
            foreach (var resource in resources)
            {
                if (_builtResources.Contains(resource))
                {
                    continue;
                }

                IRule<T> matchingRule;
                try
                {
                    matchingRule = await _rules.FindFor(resource);
                }
                catch (RuleNotFoundException<T>)
                {
                    throw new InvalidOperationException($"Could not find rule or file for {resource}");
                }

                await matchingRule.Build(new Builder(this, resource));

                _builtResources.Add(resource);
            }
        }

        internal class Builder : IBuildSystem<T>.IBuilder
        {
            public T Resource { get; private set; }

            private readonly DefaultBuildSystem<T> _buildSystem;

            public Builder(DefaultBuildSystem<T> buildSystem, T resource)
            {
                Resource = resource;
                _buildSystem = buildSystem;
            }

            public async Task Need(params T[] resources)
            {
                await _buildSystem.Want(resources);
            }

            public async Task Built(T resource)
            {
                await Task.Run(() =>
                {
                    _buildSystem._builtResources.Add(resource);
                });
            }
        }
    }
}
