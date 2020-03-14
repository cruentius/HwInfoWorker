using HwInfoWorker.Domain.SeedWork;
using System.Collections.Generic;

namespace HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate
{
    public interface IHwInfoElementRepository : IRepository<HwInfoElement>
    {
        IEnumerable<HwInfoSensor> GetSensors();
        IEnumerable<HwInfoReading> GetReadings();
    }
}
