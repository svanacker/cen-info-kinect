namespace Org.Cen.Devices.Clock
{
    public class ClockData
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return GetType().Name.ToString() + "Hour=" + Hour + ":" + Minute + ":" + Second + ", day=" + Day + "/" + Month + "/" + Year;
        }
    }
}
