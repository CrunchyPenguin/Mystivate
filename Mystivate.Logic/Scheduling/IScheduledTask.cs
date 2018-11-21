using System.Threading;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        bool RunOnStartup { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}