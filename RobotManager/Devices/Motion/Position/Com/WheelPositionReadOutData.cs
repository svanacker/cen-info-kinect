namespace Org.Cen.Devices.Motion.Position.Com
{
    using Communication.Out;
    using Org.Cen.Com.Out;

    ///
    /// The encapsulation of the data which must be sent to read the wheel positions.
    ///
    public class WheelPositionReadOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to read the wheel position.
        /// </summary>
        public const string HEADER = "wr";

        public WheelPositionReadOutData()
            : base()
        {
        }

        public override string GetArguments()
        {
            return "";
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}