using System.Threading.Tasks;

namespace Shake
{
    public interface IBuildSystem<T>
    {
        /// <summary>
        /// Build the independent files asynchronously.
        /// </summary>
        Task Want(params T[] resources);

        interface IBuilder
        {
            T Resource { get; }
            Task Need(params T[] resources);

            /// <summary>
            /// Mark resource as built.
            /// </summary>
            Task Built(T resource);
        }
    }
}
