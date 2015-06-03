namespace Org.Cen.Devices.Timer.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class TimerReadTimeSinceLastMarkOutData : OutData
    {
        public const string HEADER = "Vm";

        public int TimerIndex { get; private set; }

        public TimerReadTimeSinceLastMarkOutData(int timerIndex)
            : base()
        {
            TimerIndex = timerIndex;
        }

        public override string GetArguments()
        {
            string result = DataParserUtils.format(TimerIndex, 2);
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
