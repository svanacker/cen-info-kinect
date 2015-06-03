namespace Org.Cen.Devices.Timer.Com
{
    using Communication.In;

    public class TimerReadIsTimeoutInData : InData
    {
        public const string HEADER = TimerReadCountOutData.HEADER;

        public int TimerIndex { get; private set; }

        public bool TimeOut { get; private set; }

        public TimerReadIsTimeoutInData(int timerIndex, bool timeOut)
            : base()
        {
            this.TimerIndex = timerIndex;
            this.TimeOut = timeOut;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{TimerIndex=" + TimerIndex + ", TimeOut=" + TimeOut + "}";
        }
    }
}
