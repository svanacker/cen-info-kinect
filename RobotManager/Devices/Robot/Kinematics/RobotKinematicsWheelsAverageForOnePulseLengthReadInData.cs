namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com.In;
    using Communication.In;

    public class RobotKinematicsWheelsAverageForOnePulseLengthReadInData : InData
    {
        public int Value { get; private set; }

        public RobotKinematicsWheelsAverageForOnePulseLengthReadInData(int value)
        {
            Value = value;
        }
    }
}
