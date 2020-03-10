using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements
{
    public interface IHwInfoElementsStore
    {
        Task Store(HwInfoElement element, CancellationToken cancellationToken);
    }
}
