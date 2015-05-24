namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com.In;
    using Communication.In;

    public class RobotKinematicsPulseByRotationReadInData : InData
    {
        public int Value { get; private set; }

        public RobotKinematicsPulseByRotationReadInData(int value)
        {
            Value = value;
        }
    }
}
