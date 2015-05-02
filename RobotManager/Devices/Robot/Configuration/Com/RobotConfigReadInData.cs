namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Cen.Com.In;

    public class RobotConfigReadInData : InData
    {
        public const string HEADER = "cr";

        public RobotConfig Config { get; private set; }

        public RobotConfigReadInData(RobotConfig config)
            : base()
        {
            this.Config = config;
        }

        public override string ToString()
        {
            return typeof(RobotConfigReadInData) + "{Config=" + Config + "}";
        }
    }
}