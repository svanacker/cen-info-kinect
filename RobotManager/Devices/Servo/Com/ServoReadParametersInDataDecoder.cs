namespace Org.Cen.Devices.Servo.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class ServoReadParametersInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ServoReadParametersInData.HEADER };
        }

        public InData Decode(string data)
        {
            string servoIndexAsString = data.Substring(3, 2);
            string servoSpeedAsString = data.Substring(6, 2);
            string servoCurrentPositionAsString = data.Substring(9, 4);
            string servoTargetPositionAsString = data.Substring(14, 4);

            int servoIndex = int.Parse(servoIndexAsString, NumberStyles.HexNumber);
            int servoSpeed = int.Parse(servoSpeedAsString, NumberStyles.HexNumber);
            int servoCurrentPosition = int.Parse(servoCurrentPositionAsString, NumberStyles.HexNumber);
            int servoTargetPosition = int.Parse(servoTargetPositionAsString, NumberStyles.HexNumber);

            ServoData servoData = new ServoData(servoIndex, servoSpeed, servoCurrentPosition, servoTargetPosition);

            ServoReadParametersInData result = new ServoReadParametersInData(servoData);

            return result;
        }

        public int GetDataLength(string header)
        {
            // asr01-FF-1234-5678
            return 18;
        }
    }
}
