using System.Threading;
using System.Threading.Tasks;

namespace HwInfoService.Domain.SeedWork
{
    public interface IBackgroundService
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
