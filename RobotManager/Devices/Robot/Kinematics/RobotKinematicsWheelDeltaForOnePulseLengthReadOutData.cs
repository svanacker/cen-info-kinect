namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;
    using global::System.Security.Policy;

    public class RobotKinematicsWheelDeltaForOnePulseLengthReadOutData : OutData
    {
        public static string Header = "Kw";

        public override string GetHeader()
        {
            return Header;
        }
    }
}
