namespace Org.Cen.Devices.Timer.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class TimerReadIsTimeoutOutData : OutData
    {
        public const string HEADER = "Vt";

        public int TimerIndex { get; private set; }

        public int TimeToCheck { get; private set; }

        public TimerReadIsTimeoutOutData(int timerIndex, int timeToCheck)
            : base()
        {
            TimerIndex = timerIndex;
            TimeToCheck = timeToCheck;
        }

        public override string GetArguments()
        {
            string timerIndexAsString = DataParserUtils.format(TimerIndex, 2);
            string timerToCheckAsString = DataParserUtils.format(TimeToCheck, 6);
            return timerIndexAsString + "-" + timerToCheckAsString;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
