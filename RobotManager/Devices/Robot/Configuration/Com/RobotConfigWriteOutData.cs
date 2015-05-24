namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Cen.Com.Out;
    using Communication.Out;
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

        public override string GetArguments()
        {
            return DataParserUtils.format(RobotConfig.Config, 4);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}