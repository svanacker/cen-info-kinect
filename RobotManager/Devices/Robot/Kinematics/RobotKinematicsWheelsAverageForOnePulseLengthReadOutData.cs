namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;

    public class RobotKinematicsWheelsAverageForOnePulseLengthReadOutData : OutData
    {
        public static string Header = "Kl";

        public override string GetHeader()
        {
            return Header;
        }
    }
}
