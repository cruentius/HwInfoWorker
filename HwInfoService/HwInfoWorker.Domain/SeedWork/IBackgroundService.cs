using System.Threading;
using System.Threading.Tasks;

namespace HwInfoWorker.Domain.SeedWork
{
    public interface IBackgroundService
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
