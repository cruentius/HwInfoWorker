using HwInfoReader.Abstractions.Models;
using HwInfoService.Domain.SeedWork;
using System.Collections.Generic;

namespace HwInfoService.Domain.AggregatesModel.HwInfoElementAggregate
{
    public interface IHwInfoRepository : IRepository<HwInfoElement>
    {
        IEnumerable<HwInfoSensorElement> GetSensorElements();
        IEnumerable<HwInfoSensorReadingElement> GetSensorReadingElements();
    }
}
