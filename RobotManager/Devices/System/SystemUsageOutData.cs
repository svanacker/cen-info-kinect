namespace Org.Cen.Devices.System
{
    using Com.Out;

    public class SystemUsageOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to show the usage of all devices.
        /// </summary>
        public const string HEADER = "Su";

        public SystemUsageOutData()
            : base()
        {
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
