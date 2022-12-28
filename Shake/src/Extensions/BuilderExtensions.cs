using System.Linq;
using System.Threading.Tasks;

namespace Shake.Extensions
{
    public static class BuilderExtensions
    {
        public static Task Need(this IBuildSystem.IBuilder builder, string file, params string[] rest)
        {
            return builder.Need(new[] { file }.Concat(rest).ToArray());
        }

        public static Task Need(this IBuildSystem.IBuilder builder, params string[][] rest)
        {
            return builder.Need(rest.SelectMany(x => x).ToArray());
        }
    }
}