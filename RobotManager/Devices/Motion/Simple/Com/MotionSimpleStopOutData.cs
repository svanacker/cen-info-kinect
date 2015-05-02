namespace Org.Cen.Devices.Motion.Simple.Com
{
    using Cen.Com.Out;

    ///
    /// The encapsulation of the data which must be used to stop.
    ///
    public class MotionSimpleStopOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to stop the Motion Instruction.
        /// </summary>
        public const string HEADER = "Mc";

        public MotionSimpleStopOutData()
            : base()
        {
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}