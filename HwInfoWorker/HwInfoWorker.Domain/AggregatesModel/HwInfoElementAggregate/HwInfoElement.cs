using HwInfoWorker.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate
{
    public class HwInfoElement : IAggregateRoot, IEntity, IAuditEntity
    {
        public Guid Id { get; private set; }
        public IEnumerable<HwInfoSensor> Sensors { get; private set; }
        public IEnumerable<HwInfoReading> Readings { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }

        public HwInfoElement() { }

        public static HwInfoElement Create(IEnumerable<HwInfoSensor> sensors, IEnumerable<HwInfoReading> readings) =>
            new HwInfoElement
            {
                Id = Guid.NewGuid(),
                Sensors = sensors,
                Readings = readings,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
    }
}
