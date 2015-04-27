﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Com.Devices.Motion.Position.Com
{
    using System.Globalization;
    using Cen.Com;
    using Cen.Com.In;
    using Cen.Devices.Pid.Com;
    using global::Devices.Motion.Position;

    public class ReadRobotPositionDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ReadRobotPositionInData.HEADER };
        }

        public InData Decode(string data)
        {
            RobotPosition robotPosition = new RobotPosition();


            // anr01234-5678-9012
            string xPositionAsString = data.Substring(3, 4);
            robotPosition.X = int.Parse(xPositionAsString, NumberStyles.HexNumber);
            if (robotPosition.X > 0x7FFFF)
            {
                robotPosition.X -= 0x10000;
            }

            string yPositionAsString = data.Substring(8, 4);
            robotPosition.Y= int.Parse(yPositionAsString, NumberStyles.HexNumber);
            if (robotPosition.Y > 0x7FFF)
            {
                robotPosition.Y -= 0x10000;
            }

            string angleAsString = data.Substring(13, 4);
            robotPosition.DeciDegreeAngle= int.Parse(angleAsString, NumberStyles.HexNumber);
            if (robotPosition.DeciDegreeAngle > 0x7FFF)
            {
                robotPosition.DeciDegreeAngle -= 0x10000;
            }


            ReadRobotPositionInData result = new ReadRobotPositionInData(robotPosition);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 17;
        }
    }
}
