namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;

    public class RobotConfigReadOutData : OutData
    {
        private const string HEADER = "cr";

        public RobotConfigReadOutData()
            : base()
        {
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}