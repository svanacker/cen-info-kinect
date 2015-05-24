namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com;
    using Cen.Com.In;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class PidReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { PIDReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            // index
            string pidTimeAsString = data.Substring(3, 2);
            int index = int.Parse(pidTimeAsString, NumberStyles.HexNumber);

            // P
            string pAsString = data.Substring(6, 2);
            int p = int.Parse(pAsString, NumberStyles.HexNumber);

            // I
            string iAsString = data.Substring(9, 2);
            int i = int.Parse(iAsString, NumberStyles.HexNumber);

            // D
            string dAsString = data.Substring(12, 2);
            int d = int.Parse(dAsString, NumberStyles.HexNumber);

            // maxI
            string maxIAsString = data.Substring(15, 2);
            int maxI = int.Parse(maxIAsString, NumberStyles.HexNumber);

            PidData pidData = new PidData(p, i, d, maxI);

            PIDReadInData result = new PIDReadInData(index, pidData);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 17;
        }
    }
}
