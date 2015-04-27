using System.Collections.Generic;

namespace Devices.Motion.Position.Com
{
    using System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;
    using Org.Cen.Devices.Pid.Com;

    public class WheelPositionDataDecoder: IInDataDecoder {

        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ReadWheelPositionInData.HEADER };
        }

        public InData Decode(string data)
        {
            WheelPositionData wheelPositionData = new WheelPositionData();


            // awr012345-678901
            string leftPositionAsString = data.Substring(4, 6);
            wheelPositionData.LeftPosition = int.Parse(leftPositionAsString, NumberStyles.HexNumber);
            if (wheelPositionData.LeftPosition > 0x7FFFFF)
            {
                wheelPositionData.LeftPosition -= 0x1000000;
            }

            string rightPositionAsString = data.Substring(11, 6);
            wheelPositionData.RightPosition = int.Parse(rightPositionAsString, NumberStyles.HexNumber);
            if (wheelPositionData.RightPosition > 0x7FFFFF)
            {
                wheelPositionData.RightPosition -= 0x1000000;
            }

            ReadWheelPositionInData result = new ReadWheelPositionInData(wheelPositionData);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 17;
        }
    }
}
