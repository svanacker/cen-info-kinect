namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Cen.Com.Out;

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