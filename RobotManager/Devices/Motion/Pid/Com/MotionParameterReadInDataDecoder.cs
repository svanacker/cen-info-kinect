namespace Org.Cen.Devices.Pid.Com
{
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;

    public class MotionParameterReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { MotionParameterReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            MotionParameterData motionParameterData = new MotionParameterData();


            // Acceleration 
            string aAsString = data.Substring(6, 2);
            motionParameterData.Acceleration = int.Parse(aAsString, NumberStyles.HexNumber);

            // Speed 
            string speedAsString = data.Substring(9, 2);
            motionParameterData.Speed = int.Parse(speedAsString, NumberStyles.HexNumber);

            // SpeedMax 
            string speedMaxAsString = data.Substring(12, 2);
            motionParameterData.SpeedMax = int.Parse(speedMaxAsString, NumberStyles.HexNumber);

            // Time1
            string time1AsString = data.Substring(15, 4);
            motionParameterData.Time1 = int.Parse(time1AsString, NumberStyles.HexNumber);

            // Time2
            string time2AsString = data.Substring(20, 4);
            motionParameterData.Time2 = int.Parse(time2AsString, NumberStyles.HexNumber);

            // Time3
            string time3AsString = data.Substring(25, 4);
            motionParameterData.Time3 = int.Parse(time3AsString, NumberStyles.HexNumber);

            // Position1
            string position1AsString = data.Substring(30, 6);
            motionParameterData.Position1 = int.Parse(position1AsString, NumberStyles.HexNumber);
            if (motionParameterData.Position1 > 0x7FFFFF)
            {
                motionParameterData.Position1 -= 0x1000000;
            }

            // Position2
            string position2AsString = data.Substring(37, 6);
            motionParameterData.Position2 = int.Parse(position2AsString, NumberStyles.HexNumber);
            if (motionParameterData.Position2 > 0x7FFFFF)
            {
                motionParameterData.Position2 -= 0x1000000;
            }

            // Position3
            string position3AsString = data.Substring(44, 6);
            motionParameterData.NextPosition = int.Parse(position3AsString, NumberStyles.HexNumber);
            if (motionParameterData.NextPosition > 0x7FFFFF)
            {
                motionParameterData.NextPosition -= 0x1000000;
            }

            // TODO : 3 parameters more !
            // profileType;
            // motionParameterType
            // pidType
            MotionParameterReadInData result = new MotionParameterReadInData(motionParameterData);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 56;
        }
    }
}
