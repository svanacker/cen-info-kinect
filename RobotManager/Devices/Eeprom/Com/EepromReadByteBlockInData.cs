namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.In;
    using Communication.In;
    using global::System;

    public class EepromReadByteBlockInData : InData
    {
        public const string HEADER = "Eb";

        public const int EEPROM_DEVICE_READ_BLOCK_LENGTH = 8;
        public const int EEPROM_DEVICE_MAX_ADDRESS = 0x1000;


        public char[] Values { get; private set; }

        public EepromReadByteBlockInData(char[] values)
            : base()
        {
            if (values.Length != EEPROM_DEVICE_READ_BLOCK_LENGTH)
            {
                throw new Exception("Values Array Length must be equal to : " + EEPROM_DEVICE_READ_BLOCK_LENGTH);
            }
            this.Values = values;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{Values=" + Values + "}";
        }
    }
}
