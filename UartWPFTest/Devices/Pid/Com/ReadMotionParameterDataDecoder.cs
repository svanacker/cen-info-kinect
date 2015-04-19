using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Pid.Com
{
    using System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;
    using Org.Cen.Devices.Pid.Com;

    class ReadMotionParameterDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ReadMotionParameterInData.HEADER };
        }

        public InData Decode(string data)
        {
            MotionParameterData motionParameterData = new MotionParameterData();


            // Acceleration 
            string aAsString = data.Substring(3, 2);
            motionParameterData.Acceleration = int.Parse(aAsString, NumberStyles.HexNumber);

            // Speed 
            string speedAsString = data.Substring(6, 2);
            motionParameterData.Speed = int.Parse(speedAsString, NumberStyles.HexNumber);

            // SpeedMax 
            string speedMaxAsString = data.Substring(6, 2);
            motionParameterData.SpeedMax = int.Parse(speedMaxAsString, NumberStyles.HexNumber);

            // Time1
            string time1AsString = data.Substring(9, 4);
            motionParameterData.Time1 = int.Parse(time1AsString, NumberStyles.HexNumber);

            // Time2
            string time2AsString = data.Substring(14, 4);
            motionParameterData.Time2 = int.Parse(time2AsString, NumberStyles.HexNumber);

            // Time3
            string time3AsString = data.Substring(19, 4);
            motionParameterData.Time3 = int.Parse(time3AsString, NumberStyles.HexNumber);

            // Position1
            string position1AsString = data.Substring(26, 4);
            motionParameterData.Position1 = int.Parse(position1AsString, NumberStyles.HexNumber);

            // Position2
            string position2AsString = data.Substring(31, 4);
            motionParameterData.Position1 = int.Parse(position2AsString, NumberStyles.HexNumber);

            // TODO : 3 parameters more !
        }

        public int GetDataLength(string header)
        {
            return 46;
        }
    }
}
