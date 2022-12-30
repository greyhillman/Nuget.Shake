using System;
using System.IO;
using System.Threading.Tasks;

namespace Shake
{
    public interface IBuildSystem
    {
        /// <summary>
        /// Build the independent files asynchronously.
        /// </summary>
        Task Want(params string[] files);

        void AddRule(IRule rule);

        interface IBuilder
        {
            string OutputFile { get; }
            Task Need(params string[] files);

            // Like set the content of filepath to `content`
            FileStream WriteChanged(string filepath);
        }
    }

    public class RuleNotFoundException : Exception
    {
        public RuleNotFoundException(string file) : base($"No rule was found for: {file}")
        { }
    }
}
