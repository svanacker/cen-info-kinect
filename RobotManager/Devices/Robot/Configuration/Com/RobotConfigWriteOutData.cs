namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Cen.Com.Out;
    using Communication.Utils;

    public class RobotConfigWriteOutData : OutData
    {
        private const string HEADER = "cw";

        public RobotConfig RobotConfig { get; private set; }

        public RobotConfigWriteOutData(RobotConfig robotConfig)
            : base()
        {
            this.RobotConfig = robotConfig;
        }

        public override string getMessage()
        {
            return DataParserUtils.format(RobotConfig.Value, 2);
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}