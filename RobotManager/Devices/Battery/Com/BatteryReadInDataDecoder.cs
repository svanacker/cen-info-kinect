namespace Org.Cen.Devices.Battery.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class BatteryReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { BatteryReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            // abr1234
            string valueAsString = data.Substring(3, 4);
            int value = int.Parse(valueAsString, NumberStyles.HexNumber);

            BatteryReadInData result = new BatteryReadInData(value);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 7;
        }
    }
}
