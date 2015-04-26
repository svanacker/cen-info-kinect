namespace Devices.Pid.Com
{
    using System.Collections.Generic;

    using System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;
    using Org.Cen.Devices.Pid.Com;

    public class PIDDebugDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { PIDDebugInData.HEADER };
        }

        public InData Decode(string data)
        {
            PIDDebugData pidData = new PIDDebugData();


            // pidTime 
            string pidTimeAsString = data.Substring(6, 4);
            pidData.PidTime = int.Parse(pidTimeAsString, NumberStyles.HexNumber);
            if (pidData.PidTime > 16384)
            {
                pidData.PidTime -= 65536;
            }

            // normalPosition
            string normalPositionAsString = data.Substring(14, 6);
            pidData.NormalPosition = int.Parse(normalPositionAsString, NumberStyles.HexNumber);

            if (pidData.NormalPosition > 0x7FFFFF)
            {
                pidData.NormalPosition -= 0x1000000;
            }

            // position
            string positionAsString = data.Substring(21, 6);
            pidData.Position = int.Parse(positionAsString, NumberStyles.HexNumber);

            if (pidData.Position > 0x7FFFFF)
            {
                pidData.Position -= 0x1000000;
            }

            // error
            string errorAsString = data.Substring(28, 4);
            pidData.Error = int.Parse(errorAsString, NumberStyles.HexNumber);

            if (pidData.Error > 0x7FFF)
            {
                pidData.Error -= 0x10000;
            }

            // u
            string uAsString = data.Substring(33, 4);
            pidData.U = int.Parse(uAsString, NumberStyles.HexNumber);

            if (pidData.U > 0x7FFF)
            {
                pidData.U -= 0x10000;
            }

            PIDDebugInData result = new PIDDebugInData(pidData);
            return result;

        }

        public int GetDataLength(string header)
        {
            return 49;
        }
    }
}
