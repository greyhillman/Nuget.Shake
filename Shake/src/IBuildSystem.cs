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

        interface IBuilder
        {
            string OutputFile { get; }
            Task Need(params string[] files);

            // Like set the content of filepath to `content`
            FileStream WriteChanged(string filepath);
        }
    }
}
