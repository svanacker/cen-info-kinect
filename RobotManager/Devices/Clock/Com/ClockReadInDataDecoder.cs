namespace Org.Cen.Devices.Clock.Com
{
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;
    public class ClockReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ClockReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            ClockData clockData = new ClockData();


            // akr11:15:2E 04/05/0F
            string HourAsString = data.Substring(3, 2);
            clockData.Hour = int.Parse(HourAsString, NumberStyles.HexNumber);

            string MinuteAsString = data.Substring(6, 2);
            clockData.Minute = int.Parse(MinuteAsString, NumberStyles.HexNumber);

            string SecondAsString = data.Substring(9, 2);
            clockData.Second = int.Parse(SecondAsString, NumberStyles.HexNumber);

            string DayAsString = data.Substring(12, 2);
            clockData.Day = int.Parse(DayAsString, NumberStyles.HexNumber);

            string MonthAsString = data.Substring(15, 2);
            clockData.Month = int.Parse(MonthAsString, NumberStyles.HexNumber);

            string YearAsString = data.Substring(18, 2);
            clockData.Year = int.Parse(YearAsString, NumberStyles.HexNumber);

            ClockReadInData result = new ClockReadInData(clockData);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 20;
        }
    }
}
