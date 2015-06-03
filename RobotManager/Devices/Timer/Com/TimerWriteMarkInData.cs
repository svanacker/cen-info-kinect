namespace Org.Cen.Devices.Timer.Com
{
    using Communication.In;

    public class TimerWriteMarkInData : InData
    {
        public const string HEADER = TimerWriteMarkOutData.HEADER;

        public int TimerMark { get; private set; }

        public TimerWriteMarkInData(int timerMark)
            : base()
        {
            this.TimerMark = timerMark;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{TimerMark=" + TimerMark + "}";
        }
    }
}
