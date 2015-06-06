namespace Org.Cen.Devices.Battery.Com
{
    using Communication.Out;

    public class BatteryReadOutData : OutData
    {
        public const string HEADER = "br";

        public BatteryReadOutData()
            : base()
        {
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
