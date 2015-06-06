namespace Org.Cen.Devices.System.Com
{
    using Communication.Out;

    public class SystemGetLastErrorOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to ask the last error.
        /// </summary>
        public const string HEADER = "Se";

        public SystemGetLastErrorOutData()
            : base()
        {
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
