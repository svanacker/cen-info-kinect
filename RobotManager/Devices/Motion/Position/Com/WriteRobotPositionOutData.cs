namespace Org.Cen.Devices.Motion.Position.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;
    using Org.Com.Devices.Motion.Position;

    public class WriteRobotPositionOutData : OutData
    {
        public const string HEADER = "nw";

        public RobotPosition Position { get; private set; }

        public WriteRobotPositionOutData(RobotPosition position)
        {
            Position = position;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(Position.X, 4) + "-" + DataParserUtils.format(Position.Y, 4) + "-" +
                   DataParserUtils.format(Position.DeciDegreeAngle, 4);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
