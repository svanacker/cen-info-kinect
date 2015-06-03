namespace Org.Cen.Devices.Timer.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class TimerReadOutData : OutData
    {
        public const string HEADER = "Vr";

        public int TimerIndex { get; private set; }

        public TimerReadOutData(int timerIndex)
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
