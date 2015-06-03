namespace Org.Cen.Devices.Timer.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class TimerWriteEnableOutData : OutData
    {
        public const string HEADER = "Ve";

        public int TimerIndex { get; private set; }

        public bool Enabled { get; private set; }

        public TimerWriteEnableOutData(int timerIndex, bool enabled)
            : base()
        {
            TimerIndex = timerIndex;
            Enabled = enabled;
        }

        public override string GetArguments()
        {
            string timerCodeAsString = DataParserUtils.format(TimerIndex, 2);
            string enabledAsString = DataParserUtils.format(Enabled);
            return timerCodeAsString + "-" + enabledAsString;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
