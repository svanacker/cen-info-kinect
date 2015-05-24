namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;

    public class RobotKinematicsWheelsDistanceReadOutData : OutData
    {
        public static string Header = "Kh";

        public override string GetHeader()
        {
            return Header;
        }
    }
}
