using HwInfoReader.Abstractions;
using HwInfoReader.Abstractions.Models;
using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using System.Collections.Generic;

namespace HwInfoWorker.Infrastructure.Repositories.HwInfo
{
    public class HwInfoRepository : IHwInfoRepository
    {
        private readonly IHwInfoReader _reader;

        public HwInfoRepository(IHwInfoReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<HwInfoSensorElement> GetSensorElements()
        {
            return _reader.ReadSensors();
        }

        public IEnumerable<HwInfoSensorReadingElement> GetSensorReadingElements()
        {
            return _reader.ReadSensorReadings();
        }
    }
}
