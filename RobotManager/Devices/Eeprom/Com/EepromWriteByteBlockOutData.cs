namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;
    using global::System;
    using global::System.Text;

    ///
    /// The encapsulation of the data which must be sent to write a block of the eeprom.
    ///
    public class EepromWriteByteBlockOutData : OutData
    {
        public const int EEPROM_DEVICE_WRITE_BLOCK_LENGTH = 4;

        /// <summary>
        /// The Header which is used by the message to write a char from the eeprom.
        /// </summary>
        public const string HEADER = "EB";

        public int Address { get; private set; }

        public char[] Values { get; private set; }

        public EepromWriteByteBlockOutData(int address, char[] values)
            : base()
        {
            if (values.Length != EEPROM_DEVICE_WRITE_BLOCK_LENGTH)
            {
                throw new Exception("Values Array Length must be equal to " + EEPROM_DEVICE_WRITE_BLOCK_LENGTH);
            }
            Address = address;
            Values = values;
        }

        public override string GetArguments()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append(DataParserUtils.format(Address, 4));
            for (int i = 0; i < EEPROM_DEVICE_WRITE_BLOCK_LENGTH; i++)
            {
                result.Append('-');
                result.Append(DataParserUtils.format(Values[i], 2));
            }
            return result.ToString();
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}