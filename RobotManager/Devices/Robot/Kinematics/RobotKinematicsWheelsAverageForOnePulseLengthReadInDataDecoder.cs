namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class RobotKinematicsWheelsAverageForOnePulseLengthReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { RobotKinematicsWheelsAverageForOnePulseLengthReadOutData.Header };
        }

        public InData Decode(string data)
        {
            string pulseByRotationAsString = data.Substring(3, 6);
            int value = int.Parse(pulseByRotationAsString, NumberStyles.HexNumber);
            RobotKinematicsWheelsAverageForOnePulseLengthReadInData result = new RobotKinematicsWheelsAverageForOnePulseLengthReadInData(value);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 9;
        }
    }
}
