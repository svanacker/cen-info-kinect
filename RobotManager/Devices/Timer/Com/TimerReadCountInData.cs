namespace Org.Cen.Devices.Timer.Com
{
    using Communication.In;

    public class TimerReadCountInData : InData
    {
        public const string HEADER = TimerReadCountOutData.HEADER;

        public int Count { get; private set; }

        public TimerReadCountInData(int count)
            : base()
        {
            this.Count = count;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{Count=" + Count + "}";
        }
    }
}
