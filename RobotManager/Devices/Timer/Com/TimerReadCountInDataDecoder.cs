namespace Org.Cen.Devices.Timer.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class TimerReadCountInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { TimerReadCountInData.HEADER };
        }

        public InData Decode(string data)
        {
            string countAsString = data.Substring(3, 2);
            int count = int.Parse(countAsString, NumberStyles.HexNumber);

            TimerReadCountInData result = new TimerReadCountInData(count);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 5;
        }
    }
}
