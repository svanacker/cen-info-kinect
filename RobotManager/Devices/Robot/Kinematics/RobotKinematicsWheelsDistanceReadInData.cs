namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com.In;
    using Communication.In;

    public class RobotKinematicsWheelsDistanceReadInData : InData
    {
        public int Value { get; private set; }

        public RobotKinematicsWheelsDistanceReadInData(int value)
        {
            Value = value;
        }
    }
}
