namespace Org.Cen.Devices.Timer.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class TimerWriteMarkInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { TimerWriteMarkInData.HEADER };
        }

        public InData Decode(string data)
        {
            string timerMarkAsString = data.Substring(3, 6);
            int timerMark = int.Parse(timerMarkAsString, NumberStyles.HexNumber);

            TimerWriteMarkInData result = new TimerWriteMarkInData(timerMark);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 9;
        }
    }
}
