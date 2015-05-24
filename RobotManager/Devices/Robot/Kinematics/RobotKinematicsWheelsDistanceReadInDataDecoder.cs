namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class RobotKinematicsWheelsDistanceReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { RobotKinematicsWheelsDistanceReadOutData.Header };
        }

        public InData Decode(string data)
        {
            string pulseByRotationAsString = data.Substring(3, 6);
            int value = int.Parse(pulseByRotationAsString, NumberStyles.HexNumber);
            RobotKinematicsWheelsDistanceReadInData result = new RobotKinematicsWheelsDistanceReadInData(value);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 9;
        }
    }
}
