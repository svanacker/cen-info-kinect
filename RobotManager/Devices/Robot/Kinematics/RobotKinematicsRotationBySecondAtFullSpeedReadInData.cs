namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com.In;
    using Communication.In;

    public class RobotKinematicsRotationBySecondAtFullSpeedReadInData : InData
    {
        public int Value { get; private set; }

        public RobotKinematicsRotationBySecondAtFullSpeedReadInData(int value)
        {
            Value = value;
        }
    }
}
