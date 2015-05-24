namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class RobotKinematicsRotationBySecondAtFullSpeedReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { RobotKinematicsRotationBySecondAtFullSpeedReadOutData.Header };
        }

        public InData Decode(string data)
        {
            string pulseByRotationAsString = data.Substring(3, 2);
            int value = int.Parse(pulseByRotationAsString, NumberStyles.HexNumber);
            RobotKinematicsRotationBySecondAtFullSpeedReadInData result = new RobotKinematicsRotationBySecondAtFullSpeedReadInData(value);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 5;
        }
    }
}
