﻿namespace Org.Cen.Devices.Motion.Position.Com
{
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;

    public class WheelPositionReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { WheelPositionReadInData.HEADER };
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

            WheelPositionReadInData result = new WheelPositionReadInData(wheelPositionData);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 20;
        }
    }
}
