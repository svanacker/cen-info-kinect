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

            // position
            string positionAsString = data.Substring(14, 6);
            pidData.Position = int.Parse(positionAsString, NumberStyles.HexNumber);

            if (pidData.Position > 0x7F0000)
            {
                pidData.Position -= 0xFFFFFF;
            }

            // error
            string errorAsString = data.Substring(21, 4);
            pidData.U = int.Parse(errorAsString, NumberStyles.HexNumber);

            if (pidData.U > 0x7F00)
            {
                pidData.U -= 0xFFFF;
            }

            // u
            string uAsString = data.Substring(26, 2);
            pidData.U = int.Parse(uAsString, NumberStyles.HexNumber);

            if (pidData.U > 0x7F)
            {
                pidData.U -= 0xFF;
            }

            PIDDebugInData result = new PIDDebugInData(pidData);
            return result;

        }

        public int GetDataLength(string header)
        {
            return 40;
        }
    }
}
