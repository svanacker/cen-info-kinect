namespace Org.Cen.Devices.Timer.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class TimerWriteMarkOutData : OutData
    {
        public const string HEADER = "VM";

        public int TimerIndex { get; private set; }

        public TimerWriteMarkOutData(int timerIndex)
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
