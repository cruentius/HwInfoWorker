namespace HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate
{
    public class HwInfoReading
    {
        public string ReadingType { get; private set; }
        public uint DwSensorIndex { get; private set; }
        public uint DwReadingId { get; private set; }
        public string SzLabelOrig { get; private set; }
        public string SzLabelUser { get; private set; }
        public string SzUnit { get; private set; }
        public double Value { get; private set; }
        public double ValueMin { get; private set; }
        public double ValueMax { get; private set; }
        public double ValueAvg { get; private set; }

        public HwInfoReading() { }

        public static HwInfoReading Create(string readingType, uint dwSensorIndex, uint dwReadingId, string szLabelOrig, string szLabelUser, 
            string szUnit, double value, double valueMin, double valueMax, double valueAvg) =>
            new HwInfoReading
            {
                ReadingType = readingType,
                DwSensorIndex = dwSensorIndex,
                DwReadingId = dwReadingId,
                SzLabelOrig = szLabelOrig,
                SzLabelUser = szLabelUser,
                SzUnit = szUnit,
                Value = value,
                ValueMin = valueMin,
                ValueMax = valueMax,
                ValueAvg = valueAvg,
            };
    }
}
