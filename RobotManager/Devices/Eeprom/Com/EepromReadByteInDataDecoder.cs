namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com;
    using Cen.Com.In;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class EepromReadByteInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { EepromReadByteInData.HEADER };
        }

        public InData Decode(string data)
        {
            // aEr56
            string valueAsString = data.Substring(3, 2);
            int value = int.Parse(valueAsString, NumberStyles.HexNumber);

            EepromReadByteInData result = new EepromReadByteInData(value);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 5;
        }
    }
}
