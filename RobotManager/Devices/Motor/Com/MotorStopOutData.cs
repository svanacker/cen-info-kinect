namespace Org.Cen.Devices.Motor.Com
{
    using Cen.Com.Out;

    ///
    /// The encapsulation of the data which must be sent to stop the motor.
    ///
    public class MotorStopOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to go forward for xx millimeter.
        /// </summary>
        public const string HEADER = "mc";

        public MotorStopOutData()
            : base()
        {
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}