namespace HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate
{
    public class HwInfoSensor
    {
        public uint DwSensorId { get; private set; }
        public uint DwSensorInst { get; private set; }
        public string SzSensorNameOrig { get; private set; }
        public string SzSensorNameUser { get; private set; }

        public HwInfoSensor() { }

        public static HwInfoSensor Create(uint dwSensorId, uint dwSensorInst, string szSensorNameOrig, string szSensorNameUser) =>
            new HwInfoSensor
            {
                DwSensorId = dwSensorId,
                DwSensorInst = dwSensorInst,
                SzSensorNameOrig = szSensorNameOrig,
                SzSensorNameUser = szSensorNameUser
            };
    }
}
