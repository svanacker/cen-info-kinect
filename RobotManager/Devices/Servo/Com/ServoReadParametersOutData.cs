namespace Org.Cen.Devices.Servo.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class ServoReadParametersOutData : OutData
    {
        public const string Header = "sr";

        public int ServoIndex { get; private set; }

        public ServoReadParametersOutData(int servoIndex)
        {
            ServoIndex = servoIndex;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(ServoIndex, 2);
        }

        public override string GetHeader()
        {
            return Header;
        }
    }
}
