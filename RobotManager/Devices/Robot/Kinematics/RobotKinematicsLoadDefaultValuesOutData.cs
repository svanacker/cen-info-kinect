namespace Org.Cen.Devices.Robot.Kinematics
{
    using Communication.Out;

    public class RobotKinematicsLoadDefaultValuesOutData : OutData
    {
        public override string GetHeader()
        {
            return "Kd";
        }
    }
}
