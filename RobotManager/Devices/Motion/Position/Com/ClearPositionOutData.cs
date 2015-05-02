namespace Org.Cen.Devices.Motion.Position.Com
{
    using Org.Cen.Com.Out;

    ///
    /// The encapsulation of the data which must be sent to clear the wheel positions.
    ///
    public class ClearPositionOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to change the PID.
        /// </summary>
        public const string HEADER = "wc";

        public ClearPositionOutData()
            : base()
        {
        }

        public override string getArguments()
        {
            return "";
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}