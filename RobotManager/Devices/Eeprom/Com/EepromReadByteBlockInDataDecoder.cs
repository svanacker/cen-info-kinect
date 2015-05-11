namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com;
    using Cen.Com.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class EepromReadByteBlockInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { EepromReadByteBlockInData.HEADER };
        }

        public InData Decode(string data)
        {
            char[] values = new char[EepromReadByteBlockInData.EEPROM_DEVICE_READ_BLOCK_LENGTH];
            // aEb12-34-56-78-90-12-34-56
            for (int i = 0; i < EepromReadByteBlockInData.EEPROM_DEVICE_READ_BLOCK_LENGTH; i++)
            {
                string valueAsString = data.Substring(i * 3 + 3, 2);
                values[i] = (char)int.Parse(valueAsString, NumberStyles.HexNumber);
            }

            EepromReadByteBlockInData result = new EepromReadByteBlockInData(values);

            return result;
        }

        public int GetDataLength(string header)
        {
            return EepromReadByteBlockInData.EEPROM_DEVICE_READ_BLOCK_LENGTH * 3 + 2;
        }
    }
}
