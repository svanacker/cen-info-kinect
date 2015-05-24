namespace Org.Cen.Devices.Clock.Com
{
    using Communication.Out;
    using Org.Cen.Com.Out;
    using Org.Cen.Communication.Utils;

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

        public override string GetArguments()
        {
            string hexDayValue = DataParserUtils.format(this.Clock.Day, 2);
            string hexMonthValue = DataParserUtils.format(this.Clock.Month, 2);
            string hexYearValue = DataParserUtils.format(this.Clock.Year, 2);
            string result = hexDayValue + hexMonthValue + hexYearValue;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
