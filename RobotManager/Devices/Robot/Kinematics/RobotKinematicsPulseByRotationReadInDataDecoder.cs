namespace Org.Cen.Devices.Robot.Kinematics
{
    using Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class RobotKinematicsPulseByRotationReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { RobotKinematicsPulseByRotationReadOutData.Header};
        }

        public InData Decode(string data)
        {
            string pulseByRotationAsString = data.Substring(3, 4);
            int value = int.Parse(pulseByRotationAsString, NumberStyles.HexNumber);
            RobotKinematicsPulseByRotationReadInData result = new RobotKinematicsPulseByRotationReadInData(value);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 7;
        }
    }
}
