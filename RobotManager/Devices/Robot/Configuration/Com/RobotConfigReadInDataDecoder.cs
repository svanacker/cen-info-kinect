namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;

    public class RobotConfigReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { RobotConfigReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            // ac0123
            // config 
            string configAsString = data.Substring(3, 4);
            int value = int.Parse(configAsString, NumberStyles.HexNumber);

            RobotConfig robotConfig = new RobotConfig(value);
            RobotConfigReadInData result = new RobotConfigReadInData(robotConfig);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 7;
        }
    }
}
