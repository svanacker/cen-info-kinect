namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;
    using Communication.Utils;

    public class RobotKinematicsPulseByRotationWriteOutData : OutData
    {
        public static string Header = "KP";

        public int Value { get; private set; }

        public RobotKinematicsPulseByRotationWriteOutData(int value)
        {
            Value = value;
        }

        public override string GetArguments()
        {
            string result = DataParserUtils.format(Value, 4);
            return result;
        }

        public override string GetHeader()
        {
            return Header;
        }
    }
}
