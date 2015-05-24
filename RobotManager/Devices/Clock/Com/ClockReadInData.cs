namespace Org.Cen.Devices.Clock.Com
{
    using Cen.Com.In;
    using Communication.In;

    public class ClockReadInData : InData
    {
        public const string HEADER = "kr";

        public ClockData Clock { get; private set; }

        public ClockReadInData(ClockData data)
            : base()
        {
            this.Clock = data;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{data=" + Clock + "}";
        }
    }
}
