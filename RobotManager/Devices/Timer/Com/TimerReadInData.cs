namespace Org.Cen.Devices.Timer.Com
{
    using Communication.In;

    public class TimerReadInData : InData
    {
        public const string HEADER = TimerReadOutData.HEADER;

        public int Index { get; set; }

        public int Code { get; set; }

        public int Diviser { get; set; }

        public int InternalCounter { get; set; }

        public int Time { get; set; }

        public int MarkTime { get; set; }

        public bool Enabled { get; set; }

        public TimerReadInData(int index, int code, int diviser, int internalCounter, int time, int markTime, bool enabled)
            : base()
        {
            Index = index;
            Code = code;
            Diviser = diviser;
            InternalCounter = internalCounter;
            Time = time;
            MarkTime = markTime;
            Enabled = enabled;
        }
    }
}
