namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;

    ///
    /// The encapsulation of the data which must be sent to read the eeprom.
    ///
    public class EepromReadOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to read a char from the eeprom.
        /// </summary>
        public const string HEADER = "Er";

        public int Address { get; private set; }

        public EepromReadOutData(int address)
            : base()
        {
            Address = address;
        }

        public override string getArguments()
        {
            return ComDataUtils.format(Address, 4);
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}