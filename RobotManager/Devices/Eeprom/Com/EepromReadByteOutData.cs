namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;

    ///
    /// The encapsulation of the data which must be sent to read the eeprom.
    ///
    public class EepromReadByteOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to read a char from the eeprom.
        /// </summary>
        public const string HEADER = "Er";

        public int Address { get; private set; }

        public EepromReadByteOutData(int address)
            : base()
        {
            Address = address;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(Address, 4);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}