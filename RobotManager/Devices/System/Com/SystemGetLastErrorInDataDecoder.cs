namespace Org.Cen.Devices.System.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class SystemGetLastErrorInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { SystemGetLastErrorInData.HEADER };
        }

        public InData Decode(string data)
        {
            string lastErrorAsString = data.Substring(3, 4);
            int lastError = int.Parse(lastErrorAsString, NumberStyles.HexNumber);

            SystemGetLastErrorInData result = new SystemGetLastErrorInData(lastError);

            return result;
        }

        public int GetDataLength(string header)
        {
            // aSe1234
            return 7;
        }
    }
}
