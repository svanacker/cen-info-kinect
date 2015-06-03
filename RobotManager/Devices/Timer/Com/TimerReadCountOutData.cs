namespace Org.Cen.Devices.Timer.Com
{
    using Communication.Out;

    public class TimerReadCountOutData : OutData
    {
        public const string HEADER = "Vc";

        public TimerReadCountOutData()
            : base()
        {
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
