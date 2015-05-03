namespace Org.Cen.Devices.Robot.End.Com
{
    using Cen.Com;
    using Cen.Com.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class EndMatchReadTimeLeftInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { EndMatchReadTimeLeftInData.HEADER };
        }

        public InData Decode(string data)
        {
            // aet12
            // timeLeft
            string timeLeftAsString = data.Substring(3, 2);
            int timeLeft = int.Parse(timeLeftAsString, NumberStyles.HexNumber);
            EndMatchReadTimeLeftInData result = new EndMatchReadTimeLeftInData(timeLeft);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 5;
        }
    }
}
