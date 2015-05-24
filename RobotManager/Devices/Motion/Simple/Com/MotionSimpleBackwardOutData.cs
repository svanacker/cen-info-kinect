namespace Org.Cen.Devices.Motion.Simple.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;

    ///
    /// The encapsulation of the data which must be sent to go forward.
    ///
    public class MotionSimpleForwardOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to go forward for xx millimeter.
        /// </summary>
        public const string HEADER = "Mf";

        public int DistanceMm { get; private set; }

        public MotionSimpleForwardOutData(int distanceMm)
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