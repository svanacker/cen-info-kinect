namespace Org.Cen.Devices.Motion.Position.Com
{
    using System.Collections.Generic;
    using System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;

    public class WheelPositionDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ReadWheelPositionInData.HEADER };
        }

        public InData Decode(string data)
        {
            WheelPositionData wheelPositionData = new WheelPositionData();


            // awr012345-678901
            string leftPositionAsString = data.Substring(3, 8);
            wheelPositionData.LeftPosition = long.Parse(leftPositionAsString, NumberStyles.HexNumber);
            if (wheelPositionData.LeftPosition > 0x7FFFFFFF)
            {
                wheelPositionData.LeftPosition -= 0x100000000;
            }

            string rightPositionAsString = data.Substring(12, 8);
            wheelPositionData.RightPosition = long.Parse(rightPositionAsString, NumberStyles.HexNumber);
            if (wheelPositionData.RightPosition > 0x7FFFFFFF)
            {
                wheelPositionData.RightPosition -= 0x100000000;
            }

            ReadWheelPositionInData result = new ReadWheelPositionInData(wheelPositionData);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 20;
        }
    }
}
