namespace Org.Cen.Devices.Motion.Simple.Com
{
    using Cen.Com.Out;
    using Org.Cen.Com.Utils;

    public class MotionCalibrationOutData : OutData
    {
        public enum CalibrationDirection
        {
            Left = 0,
            Rigth = 1
        }
        
        /// <summary>
        /// The Header which is used by the message to go forward for xx millimeter.
        /// </summary>
        public const string HEADER = "M@";

        public CalibrationDirection Direction {get; private set; }

        public int LengthMM { get; private set; }

        public MotionCalibrationOutData(CalibrationDirection direction, int lengthMM)
            : base()
        {
            Direction = direction;
            LengthMM = lengthMM;
        }

        public override string getArguments()
        {
            string directionAsString = ComDataUtils.format((int) Direction, 2);
            string lengthMMAsString = ComDataUtils.format(LengthMM, 4);
            return directionAsString + "-" + lengthMMAsString;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
