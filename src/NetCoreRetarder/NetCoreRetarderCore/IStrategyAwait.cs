using System.Threading.Tasks;

namespace NetCoreRetarderCore
{
    public interface IStrategyAwait
    {
        Task<IStrategyAwait> AwaitDelay();
    }
}
