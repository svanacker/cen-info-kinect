namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;

    public class RobotKinematicsRotationBySecondAtFullSpeedReadOutData : OutData
    {
        public static string Header = "Kr";

        public override string GetHeader()
        {
            return Header;
        }
    }
}
