namespace Org.Cen.Devices.Servo.Com
{
    using Communication.In;

    public class ServoReadParametersInData : InData
    {
        public const string HEADER = "sr";

        public ServoData Data { get; private set; }

        public ServoReadParametersInData(ServoData servoData)
            : base()
        {
            this.Data = servoData;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{Data=" + Data + "}";
        }
    }
}
