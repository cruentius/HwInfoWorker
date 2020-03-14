using HwInfoReader.Abstractions;
using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using System.Collections.Generic;
using System.Linq;

namespace HwInfoWorker.Infrastructure.Repositories.HwInfo
{
    public class HwInfoElementRepository : IHwInfoElementRepository
    {
        private readonly IHwInfoReader _reader;

        public HwInfoElementRepository(IHwInfoReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<HwInfoSensor> GetSensors()
        {
            return _reader.ReadSensors()
                .Select(s => 
                    HwInfoSensor.Create(s.dwSensorID, s.dwSensorInst, s.szSensorNameOrig, s.szSensorNameUser));
        }

        public IEnumerable<HwInfoReading> GetReadings()
        {
            return _reader.ReadSensorReadings()
                .Select(s => 
                    HwInfoReading.Create(s.tReading.ToString(), s.dwSensorIndex, s.dwReadingID, s.szLabelOrig, s.szLabelUser, s.szUnit, s.Value, s.ValueMin, s.ValueMax, s.ValueAvg));
        }
    }
}
