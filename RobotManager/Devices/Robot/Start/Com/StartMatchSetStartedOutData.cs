namespace Org.Cen.Devices.Robot.Start.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;

    public class StartMatchSetStartedOutData : OutData
    {
        public const string HEADER = "!w";

        public bool Started { get; private set; }

        public StartMatchSetStartedOutData(bool started)
        {
            Started = started;
        }

        public override string getArguments()
        {
            return ComDataUtils.format(Started);
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
