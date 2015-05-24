namespace Org.Cen.Devices.Robot.Start.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;

    public class StartMatchSetStartedOutData : OutData
    {
        public const string HEADER = "!w";

        public bool Started { get; private set; }

        public StartMatchSetStartedOutData(bool started)
        {
            Started = started;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(Started);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
