using HwInfoReader.Abstractions.Models;
using HwInfoWorker.Domain.SeedWork;
using System.Collections.Generic;

namespace HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate
{
    public interface IHwInfoElementRepository : IRepository<HwInfoElement>
    {
        IEnumerable<HwInfoSensorElement> GetSensorElements();
        IEnumerable<HwInfoSensorReadingElement> GetSensorReadingElements();
    }
}
