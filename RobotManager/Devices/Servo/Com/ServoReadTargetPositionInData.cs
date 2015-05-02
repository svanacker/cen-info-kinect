namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.In;

    public class ServoReadTargetPositionInData : InData
    {
        public const string HEADER = "sr";

        public int TargetPosition { get; private set; }

        public ServoReadTargetPositionInData(int targetPosition)
            : base()
        {
            this.TargetPosition = targetPosition;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{TargetPosition=" + TargetPosition + "}";
        }
    }
}
