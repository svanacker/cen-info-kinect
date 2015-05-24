namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;
    using global::System.Text;

    ///
    /// The encapsulation of the data which must be sent to read a block of the eeprom.
    ///
    public class EepromReadByteBlockOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to read a block of char from the eeprom.
        /// </summary>
        public const string HEADER = "Eb";

        public int Address { get; private set; }

        public EepromReadByteBlockOutData(int address)
            : base()
        {
            Address = address;
        }

        public override string GetArguments()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append(DataParserUtils.format(Address, 4));

            return result.ToString();
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}