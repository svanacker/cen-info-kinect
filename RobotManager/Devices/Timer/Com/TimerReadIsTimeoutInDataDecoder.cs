namespace Org.Cen.Devices.Timer.Com
{
    using Cen.Com;
    using Communication.In;
    using Communication.Utils;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class TimerReadIsTimeoutInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { TimerReadIsTimeoutInData.HEADER };
        }

        public InData Decode(string data)
        {
            string timerIndexAsString = data.Substring(3, 2);
            int timerIndex = int.Parse(timerIndexAsString, NumberStyles.HexNumber);

            string enabledAsString = data.Substring(6, 1);
            bool enabled = DataParserUtils.ParseBool(enabledAsString);

            TimerReadIsTimeoutInData result = new TimerReadIsTimeoutInData(timerIndex, enabled);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 7;
        }
    }
}
