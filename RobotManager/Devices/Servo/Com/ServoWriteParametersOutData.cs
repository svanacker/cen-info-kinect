namespace Org.Cen.Devices.Servo.Com
{
    using Communication.Out;
    using Communication.Utils;
    using global::System.Text;

    public class ServoWriteParametersOutData : OutData
    {
        public const string Header = "sw";

        public ServoData Data { get; private set; }

        public ServoWriteParametersOutData(ServoData servoData)
        {
            Data = servoData;
        }

        public override string GetArguments()
        {
            StringBuilder result = new StringBuilder();
            string servoIndexAsString = DataParserUtils.format(Data.ServoIndex, 2);
            string servoSpeedAsString = DataParserUtils.format(Data.ServoSpeed, 2);
            string servoTargetPositionAsString = DataParserUtils.format(Data.ServoTargetPosition, 4);

            result.Append(servoIndexAsString);
            result.Append("-");
            result.Append(servoSpeedAsString);
            result.Append("-");
            result.Append(servoTargetPositionAsString);

            return result.ToString();
        }

        public override string GetHeader()
        {
            return Header;
        }
    }
}
