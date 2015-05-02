namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;
    using global::System.Text;

    ///
    /// The encapsulation of the data which must be sent to write the eeprom.
    ///
    public class EepromWriteOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to read a char from the eeprom.
        /// </summary>
        public const string HEADER = "Ew";

        public int Address { get; private set; }
        public int Value { get; private set; }

        public EepromWriteOutData(int address, int value)
            : base()
        {
            Address = address;
            Value = value;
        }

        public override string getArguments()
        {
            StringBuilder result = new StringBuilder();

            result.Append(ComDataUtils.format(Address, 4));
            result.Append("-");
            result.Append(ComDataUtils.format(Value, 2));

            return result.ToString();
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}