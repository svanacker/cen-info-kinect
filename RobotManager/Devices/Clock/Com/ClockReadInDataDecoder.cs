namespace Org.Cen.Devices.Clock.Com
{
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Cen.Com;

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
            string hourAsString = data.Substring(3, 2);
            clockData.Hour = int.Parse(hourAsString, NumberStyles.HexNumber);

            string minuteAsString = data.Substring(6, 2);
            clockData.Minute = int.Parse(minuteAsString, NumberStyles.HexNumber);

            string secondAsString = data.Substring(9, 2);
            clockData.Second = int.Parse(secondAsString, NumberStyles.HexNumber);

            string dayAsString = data.Substring(12, 2);
            clockData.Day = int.Parse(dayAsString, NumberStyles.HexNumber);

            string monthAsString = data.Substring(15, 2);
            clockData.Month = int.Parse(monthAsString, NumberStyles.HexNumber);

            string yearAsString = data.Substring(18, 2);
            clockData.Year = int.Parse(yearAsString, NumberStyles.HexNumber);

            ClockReadInData result = new ClockReadInData(clockData);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 20;
        }
    }
}
