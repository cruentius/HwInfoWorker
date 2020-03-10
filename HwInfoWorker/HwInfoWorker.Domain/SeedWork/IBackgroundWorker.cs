using System.Threading;
using System.Threading.Tasks;

namespace HwInfoWorker.Domain.SeedWork
{
    public interface IBackgroundWorker
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
