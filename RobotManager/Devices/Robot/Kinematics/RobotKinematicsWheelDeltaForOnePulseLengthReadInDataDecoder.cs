namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class RobotKinematicsWheelDeltaForOnePulseLengthReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { RobotKinematicsWheelDeltaForOnePulseLengthReadOutData.Header };
        }

        public InData Decode(string data)
        {
            string pulseByRotationAsString = data.Substring(3, 6);
            int value = int.Parse(pulseByRotationAsString, NumberStyles.HexNumber);
            RobotKinematicsWheelDeltaForOnePulseLengthReadInData result = new RobotKinematicsWheelDeltaForOnePulseLengthReadInData(value);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 9;
        }
    }
}
