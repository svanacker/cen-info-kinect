namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com;
    using Cen.Com.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class EepromReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { EepromReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            // aEr56
            string valueAsString = data.Substring(3, 2);
            int value = int.Parse(valueAsString, NumberStyles.HexNumber);

            EepromReadInData result = new EepromReadInData(value);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 5;
        }
    }
}
