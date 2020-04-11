using System.Threading.Tasks;

namespace NetCoreRetarderCore
{
    public interface IStrategyAwait
    {
        Task<IStrategyAwait> AwaitDelayBefore();
        Task<IStrategyAwait> AwaitDelayAfter();
    }
}
