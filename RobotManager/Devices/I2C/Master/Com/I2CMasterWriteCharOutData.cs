namespace Org.Cen.Devices.I2c.Master.Com
{
    using Communication.Out;
    using Communication.Utils;
    using global::System;

    public class I2CMasterWriteCharOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to send a char the I2cDebug.
        /// </summary>
        public const string HEADER = "Iw";

        public char Value { get; private set; }

        public I2CMasterWriteCharOutData(char value)
            : base()
        {
            Value = value;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(Value, 2);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
