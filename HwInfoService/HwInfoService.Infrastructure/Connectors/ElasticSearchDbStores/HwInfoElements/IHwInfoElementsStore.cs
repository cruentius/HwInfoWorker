using HwInfoService.Domain.AggregatesModel.HwInfoElementAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace HwInfoService.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements
{
    public interface IHwInfoElementsStore
    {
        Task Store(HwInfoElement element, CancellationToken cancellationToken);
    }
}
