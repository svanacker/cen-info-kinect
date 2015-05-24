namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;
    using Communication.Utils;

    public class RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData : OutData
    {
        public int Value { get; private set; }

        public RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData(int value)
        {
            Value = value;
        }

        public override string GetArguments()
        {
            string result = DataParserUtils.format(Value, 6);
            return result;
        }

        public override string GetHeader()
        {
            return "KL";
        }
    }
}
