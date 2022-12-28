using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Shake
{
    public class DefaultBuildSystem : IBuildSystem
    {
        private readonly HashSet<string> _builtFiles;
        private readonly List<IRule> _rules;

        public DefaultBuildSystem()
        {
            _builtFiles = new();
            _rules = new();
        }

        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }

        public async Task Want(string[] files)
        {
            foreach (var file in files)
            {
                if (_builtFiles.Contains(file))
                {
                    continue;
                }

                IRule? matchingRule = null;
                foreach (var rule in _rules)
                {
                    if (rule.IsFor(file))
                    {
                        matchingRule = rule;
                        break;
                    }
                }

                if (matchingRule != null)
                {
                    await matchingRule.Build(new Builder(this, file));
                    
                    _builtFiles.Add(file);
                    continue;
                }

                if (File.Exists(file))
                {
                    _builtFiles.Add(file);
                    continue;
                }

                throw new InvalidOperationException($"Could not find rule or file for {file}");
            }
        }

        internal class Builder : IBuildSystem.IBuilder
        {
            public string OutputFile { get; private set; }

            private readonly DefaultBuildSystem _buildSystem;

            public Builder(DefaultBuildSystem buildSystem, string file)
            {
                OutputFile = file;
                _buildSystem = buildSystem;
            }

            public async Task Need(string[] files)
            {
                await _buildSystem.Want(files);
            }

            public FileStream WriteChanged(string filepath)
            {
                _buildSystem._builtFiles.Add(filepath);

                var directory = Path.GetDirectoryName(filepath);

                Directory.CreateDirectory(directory);

                var filestream = File.OpenWrite(filepath);

                // Clear the file contents
                filestream.SetLength(0);
                filestream.Flush();

                return filestream;
            }
        }
    }
}
