namespace Org.Cen.Devices.Motion.Position.Com
{
    using Cen.Com.In;

    /**
     * Encapsulation of the message corresponding to the read of the Wheels.
     */
    public class WheelPositionReadInData : InData
    {

        public const string HEADER = "wr";

        public WheelPositionData WheelPosition { get; private set; }

        public WheelPositionReadInData(WheelPositionData data)
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