namespace Org.Cen.Devices.Motion.Position.Com
{
    using System.Collections.Generic;
    using System.Globalization;
    using Cen.Com;
    using Cen.Com.In;
    using Eeprom.Com;
    using Org.Com.Devices.Motion.Position;

    public class EepromReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { EepromReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            // aEr12
            string valueAsString = data.Substring(3, 4);
            int value = int.Parse(valueAsString, NumberStyles.HexNumber);

            EepromReadInData result = new EepromReadInData(value);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 17;
        }
    }
}
