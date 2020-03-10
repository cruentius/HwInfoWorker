using HwInfoReader.Abstractions.Models;
using HwInfoWorker.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate
{
    public class HwInfoElement : IAggregateRoot, IEntity, IAuditEntity
    {
        public Guid Id { get; private set; }
        public IEnumerable<HwInfoSensorElement> SensorElements { get; private set; }
        public IEnumerable<HwInfoSensorReadingElement> ReadingElements { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }

        public HwInfoElement() { }

        public static HwInfoElement Create(IEnumerable<HwInfoSensorElement> sensorElements, IEnumerable<HwInfoSensorReadingElement> readingElements) =>
            new HwInfoElement
            {
                Id = Guid.NewGuid(),
                SensorElements = sensorElements,
                ReadingElements = readingElements,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
    }
}
