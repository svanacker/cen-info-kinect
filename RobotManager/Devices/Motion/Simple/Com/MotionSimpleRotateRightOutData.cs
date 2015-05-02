namespace Org.Cen.Devices.Motion.Simple.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;

    ///
    /// The encapsulation of the data which must be sent to rotate.
    ///
    public class MotionSimpleRotateRightOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to rotate of rightAngleDeciDegree.
        /// </summary>
        public const string HEADER = "Mr";

        public int RightAngleDeciDegree { get; private set; }

        public MotionSimpleRotateRightOutData(int rightAngleDeciDegree)
            : base()
        {
            RightAngleDeciDegree = rightAngleDeciDegree;
        }

        public override string getArguments()
        {
            string result = ComDataUtils.format(RightAngleDeciDegree, 4);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}