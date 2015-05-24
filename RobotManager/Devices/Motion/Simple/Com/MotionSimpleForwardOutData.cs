namespace Org.Cen.Devices.Motion.Simple.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;

    ///
    /// The encapsulation of the data which must be sent to go backward.
    ///
    public class MotionSimpleBackwardOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to go forward for xx millimeter.
        /// </summary>
        public const string HEADER = "Mb";

        public int DistanceMm { get; private set; }

        public MotionSimpleBackwardOutData(int distanceMm)
            : base()
        {
            DistanceMm = distanceMm;
        }

        public override string GetArguments()
        {
            string result = DataParserUtils.format(DistanceMm, 4);
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}