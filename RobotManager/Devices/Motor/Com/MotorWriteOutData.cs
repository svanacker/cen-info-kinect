namespace Org.Cen.Devices.Motor.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;

    ///
    /// The encapsulation of the data which must be sent to rotate the motor.
    ///
    public class MotorWriteOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to go forward for xx millimeter.
        /// </summary>
        public const string HEADER = "mw";

        public int LeftValue { get; private set; }
        public int RightValue { get; private set; }

        public MotorWriteOutData(int leftValue, int rightValue)
            : base()
        {
            LeftValue = leftValue;
            RightValue = rightValue;
        }

        public override string GetArguments()
        {
            string hexLeftValue = DataParserUtils.format(LeftValue, 2);
            string hexRightValue = DataParserUtils.format(RightValue, 2);
            string result = hexLeftValue + hexRightValue;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}