using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements
{
    public interface IHwInfoElementsStore
    {
        Task<bool> TryStore(HwInfoElement element, CancellationToken cancellationToken);
    }
}
