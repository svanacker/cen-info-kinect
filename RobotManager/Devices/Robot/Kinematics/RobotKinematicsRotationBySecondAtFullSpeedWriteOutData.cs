namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;
    using Communication.Utils;

    public class RobotKinematicsRotationBySecondAtFullSpeedWriteOutData : OutData
    {
        public int Value { get; private set; }

        public RobotKinematicsRotationBySecondAtFullSpeedWriteOutData(int value)
        {
            Value = value;
        }

        public override string GetArguments()
        {
            string result = DataParserUtils.format(Value, 2);
            return result;
        }

        public override string GetHeader()
        {
            return "KR";
        }
    }
}
