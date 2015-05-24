namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;
    using Communication.Utils;

    public class RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData : OutData
    {
        public int Value { get; private set; }

        public RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData(int value)
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
            return "KW";
        }
    }
}
