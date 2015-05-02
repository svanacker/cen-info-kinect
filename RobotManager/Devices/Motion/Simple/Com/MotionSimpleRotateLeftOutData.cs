namespace Org.Cen.Devices.Motion.Simple.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;

    ///
    /// The encapsulation of the data which must be sent to rotate.
    ///
    public class MotionSimpleRotateLeftOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to rotate of leftAngleDeciDegree.
        /// </summary>
        public const string HEADER = "Ml";

        public int LeftAngleDeciDegree { get; private set; }

        public MotionSimpleRotateLeftOutData(int leftAngleDeciDegree)
            : base()
        {
            LeftAngleDeciDegree = leftAngleDeciDegree;
        }

        public override string getArguments()
        {
            string result = ComDataUtils.format(LeftAngleDeciDegree, 4);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}