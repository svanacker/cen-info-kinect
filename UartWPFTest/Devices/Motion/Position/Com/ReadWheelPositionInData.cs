namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.In;
    using global::Devices.Motion.Position;
    using global::Devices.Pid;

    /**
     * Encapsulation of the message corresponding to the read of the Wheels.
     */
    public class ReadWheelPositionInData : InData
    {

        public const string HEADER = "wr";

        public WheelPositionData WheelPosition { get; private set; }

        public ReadWheelPositionInData(WheelPositionData data)
            : base()
        {
            this.WheelPosition = data;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{data=" + WheelPosition + "}";
        }
    }
}