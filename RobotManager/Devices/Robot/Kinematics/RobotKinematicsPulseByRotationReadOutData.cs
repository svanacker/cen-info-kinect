namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;

    public class RobotKinematicsPulseByRotationReadOutData : OutData
    {
        public static string Header = "Kp";

        public override string GetHeader()
        {
            return Header;
        }
    }
}
