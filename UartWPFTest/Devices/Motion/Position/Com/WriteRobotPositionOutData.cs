namespace Org.Cen.Devices.Motion.Position.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;
    using Org.Com.Devices.Motion.Position;

    public class WriteRobotPositionOutData : OutData
    {
        public const string HEADER = "nw";

        public RobotPosition Position { get; private set; }

        public WriteRobotPositionOutData(RobotPosition position)
        {
            Position = position;
        }

        public override string getArguments()
        {
            return ComDataUtils.format(Position.X, 4) + "-" + ComDataUtils.format(Position.Y, 4) + "-" +
                   ComDataUtils.format(Position.DeciDegreeAngle, 4);
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
