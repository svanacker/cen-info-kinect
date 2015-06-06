namespace Org.Cen.Devices.System.Com
{
    using Communication.Out;

    public class SystemClearLastErrorOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to show the usage of all devices.
        /// </summary>
        public const string HEADER = "SE";

        public SystemClearLastErrorOutData()
            : base()
        {
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
