namespace Org.Cen.Devices.Clock.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;
    public class ClockWriteDateOutData : OutData
    {
        public const string HEADER = "kd";

        public ClockData Clock { get; set; }

        public ClockWriteDateOutData(int day, int month, int year)
            : base()
        {
            Clock = new ClockData();
            this.Clock.Day = day;
            this.Clock.Month = month;
            this.Clock.Year = year;
        }

        public override string getArguments()
        {
            string hexDayValue = ComDataUtils.format(this.Clock.Day, 2);
            string hexMonthValue = ComDataUtils.format(this.Clock.Month, 2);
            string hexYearValue = ComDataUtils.format(this.Clock.Year, 2);
            string result = hexDayValue + hexMonthValue + hexYearValue;
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
