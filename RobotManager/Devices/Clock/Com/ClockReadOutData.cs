namespace Org.Cen.Devices.Clock.Com
{
    using Cen.Com.Out;

    public class ClockReadOutData : OutData
    {
        public const string HEADER = "kr";

        public ClockReadOutData()
            : base()
        {
        }

        public override string getArguments()
        {
            return "";
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
