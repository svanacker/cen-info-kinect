namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com.In;
    using Communication.In;

    public class RobotKinematicsWheelDeltaForOnePulseLengthReadInData : InData
    {
        public int Value { get; private set; }

        public RobotKinematicsWheelDeltaForOnePulseLengthReadInData(int value)
        {
            Value = value;
        }
    }
}
