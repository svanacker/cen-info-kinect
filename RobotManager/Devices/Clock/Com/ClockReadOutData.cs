namespace Org.Cen.Devices.Clock.Com
{
    using Cen.Com.Out;
    using Communication.Out;

    public class ClockReadOutData : OutData
    {
        public const string HEADER = "kr";

        public ClockReadOutData()
            : base()
        {
        }

        public override string GetArguments()
        {
            return "";
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
