namespace Org.Cen.Devices.I2c.Master.Com
{
    using Communication.Out;
    using Communication.Utils;
    using global::System;

    public class I2CMasterDebugEnableOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to enable or disable the I2cDebug.
        /// </summary>
        public const string HEADER = "Ie";

        public bool Enabled { get; private set; }
        
        public I2CMasterDebugEnableOutData(bool enabled)
            : base()
        {
            Enabled = enabled;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(Enabled);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
