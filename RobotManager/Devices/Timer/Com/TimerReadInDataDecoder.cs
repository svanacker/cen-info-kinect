namespace Org.Cen.Devices.Timer.Com
{
    using Cen.Com;
    using Communication.In;
    using Communication.Utils;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class TimerReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { TimerReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            string timerIndexAsString = data.Substring(3, 2);
            int timerIndex = int.Parse(timerIndexAsString, NumberStyles.HexNumber);

            string timerCodeAsString = data.Substring(6, 2);
            int timerCode = int.Parse(timerCodeAsString, NumberStyles.HexNumber);

            string timerDiviserAsString = data.Substring(9, 4);
            int timerDiviser = int.Parse(timerDiviserAsString, NumberStyles.HexNumber);

            string timerInternalCounterAsString = data.Substring(14, 4);
            int timerInternalCounter = int.Parse(timerInternalCounterAsString, NumberStyles.HexNumber);

            string timerAsString = data.Substring(19, 6);
            int time = int.Parse(timerAsString, NumberStyles.HexNumber);

            string markTimeAsString = data.Substring(26, 6);
            int markTime = int.Parse(markTimeAsString, NumberStyles.HexNumber);

            string enabledAsString = data.Substring(33, 1);
            bool enabled = DataParserUtils.ParseBool(enabledAsString);


            TimerReadInData result = new TimerReadInData(timerIndex, timerCode, timerDiviser, timerInternalCounter, time, markTime, enabled);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 34;
        }
    }
}
