namespace Org.Cen.Devices.Pid.Com
{
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;

    public class PIDDebugDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { PIDDebugInData.HEADER };
        }

        public InData Decode(string data)
        {
            PIDDebugData pidData = new PIDDebugData();

            // InstructionType
            string instructionTypeAsString = data.Substring(3, 2);
            pidData.InstructionType = int.Parse(instructionTypeAsString, NumberStyles.HexNumber);

            // pidTime 
            string pidTimeAsString = data.Substring(6, 4);
            pidData.PidTime = int.Parse(pidTimeAsString, NumberStyles.HexNumber);
            if (pidData.PidTime > 16384)
            {
                pidData.PidTime -= 65536;
            }

            // PidType
            string pidTypeAsString = data.Substring(11, 2);
            pidData.PidType = int.Parse(pidTypeAsString, NumberStyles.HexNumber);

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
            return 52;
        }
    }
}
